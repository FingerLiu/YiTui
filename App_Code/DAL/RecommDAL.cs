using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace YiTui.DAL
{
    /// <summary>
    /// 貌似这玩意不好用？？排不出结果？？？
    /// </summary>
    class scoreComparer : IComparer<double>
    {
        public int Compare(double x, double y)
        {
            return x < y ? 1 : (x == y ? 0 : -1);
        }
    }

    public class objectSimilarity{
        public objectSimilarity(int objectId,double similarity){this.objectId=objectId;this.similarity=similarity;}
        public int objectId{get;set;}
        public double similarity{get;set;}
    }

    public class RecommDAL
    {
        public RecommDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// 返回关于1和2的基于距离的相似度评价
        /// </summary>
        /// <param name="person1Dic"></param>
        /// <param name="person2Dic"></param>
        /// <returns></returns>
        private static double simDistance(Dictionary<int,double>person1Dic,Dictionary<int,double>person2Dic)
        {
            //如果两人没有消费过相同的条目，则相似度为0
            bool simTag = false;
            foreach (int item in person1Dic.Keys)
            {
                if (person2Dic.Keys.Contains(item))
                {
                    simTag = true;
                    break;
                }
            }
            if (!simTag) return 0;
            double ret=0;
            int sum=0;
            foreach (int item in person1Dic.Keys)
                if(person2Dic.Keys.Contains(item))
                    sum+=Convert.ToInt32(Math.Pow(Convert.ToDouble(person1Dic[item]-person2Dic[item]),Convert.ToDouble(2)));
            ret = 1 / (1 + Math.Sqrt(sum));
            return ret;
        }

        /// <summary>
        /// 获取指定字典
        /// </summary>
        /// <param name="mainKeyName"></param>
        /// <param name="subKeyName"></param>
        /// <param name="valueName"></param>
        /// <returns></returns>
        private static Dictionary<int, Dictionary<int, double>> 
                                getDic(string mainKeyName,string subKeyName,string valueName)
        {
            Dictionary<int, Dictionary<int, double>> ret = new Dictionary<int, Dictionary<int, double>>();
            DataTable tmpDT = YiTui.DAL.Execute.ExecuteProcDataTable("sp_Query_User_Item_Rate");

            int lastId = 0;//记录上一次获取的结果，如果不相同，则需新建dic

            foreach (DataRow item in tmpDT.Rows)
            {
                //如果ret中没有该用户，向ret添加该用户，以及其对应的字典
                //如果ret中有，则向该用户的字典中添加数据项
                int mainId = Convert.ToInt32(item["mainKeyName"].ToString());
                if (mainId != lastId)
                    ret.Add(mainId, new Dictionary<int, double>());
                ret[mainId].Add(Convert.ToInt32(item["subKeyName"].ToString()),
                               Convert.ToSingle(item["valueName"].ToString()));
                lastId = mainId;
            }
            return ret;
        }

        /// <summary>
        /// 获取相似的条目/用户
        /// </summary>
        /// <param name="Dic"></param>
        /// <param name="item"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private static List<objectSimilarity> getSimObject
            (Dictionary<int, Dictionary<int, double>> Dic, int item, int n = 3)
        {
            List<objectSimilarity> ls = new List<objectSimilarity>();
            foreach (int other in Dic.Keys)
            {
                if (other != item)
                {
                    double similarity = simDistance(Dic[item], Dic[other]);
                    if (similarity != 0)
                        ls.Add(new objectSimilarity(other, similarity));
                }
            }
            ls.OrderBy(x => x.similarity, new scoreComparer());
            //???ret.Reverse();???
            var t = ls.Take(n);
            List<objectSimilarity> ret = new List<objectSimilarity>();
            foreach (objectSimilarity i in t)
            {
                ret.Add(i);
            }
            return ret;
        }

#region 基于用户的推荐

        /// <summary>
        /// 外部接口
        /// 当规模小时，userDic可选用所有用户的userDic
        /// 当规模较大时，应通过getSimUser获取相似用户，再获取相似用户的itemDic
        /// </summary>
        /// <param name="person"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static  List<objectSimilarity> getItemRecommUserBased(int person,int n=3)
        {
            return getItemRecommUserBased(getUserDic(),person,n);
        }

        /// <summary>
        /// 获得指定用户的基于用户的条目推荐结果
        /// 当规模小时，userDic可选用所有用户的userDic
        /// 当规模较大时，应通过getSimUser获取相似用户，再获取相似用户的itemDic
        /// </summary>
        /// <param name="userDic"></param>
        /// <param name="person"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static List<objectSimilarity> getItemRecommUserBased
            (Dictionary<int, Dictionary<int, double>> userDic, int person, int n = 3)
        {
            Dictionary<int, double> totals = new Dictionary<int, double>();
            Dictionary<int, double> simSums = new Dictionary<int, double>();
            foreach (int other in userDic.Keys)
            {
                if (other == person)
                    continue;
                double sim = simDistance(userDic[person], userDic[other]);
                if (sim <= 0) continue;
                foreach (int item in userDic[other].Keys)
                {
                    if (!userDic[person].Keys.Contains(item) || userDic[person][item] == 0)
                    {
                        totals.DefaultIfEmpty(new System.Collections.Generic.KeyValuePair<int, double>(item, 0));
                        totals[item] += userDic[other][item] * sim;
                        simSums.DefaultIfEmpty(new System.Collections.Generic.KeyValuePair<int, double>(item, 0));
                        simSums[item] += sim;
                    }
                }
            }
            List<objectSimilarity> rankings = new System.Collections.Generic.List<objectSimilarity>();
            foreach (int item in totals.Keys)
                rankings.Add(new objectSimilarity(item, totals[item] / simSums[item]));
            rankings.OrderBy(x => x.similarity, new scoreComparer());
            var t = rankings.Take(n);
            List<objectSimilarity> ret = new List<objectSimilarity>();
            foreach (objectSimilarity item in t)
            {
                ret.Add(item);
            }
            return ret;
        }

        /// <summary>
        /// 返回一个带有userId itemId 和 rate的 全部用户字典
        /// 是否可以改进为带yeild的？
        /// </summary>
        /// <returns></returns>
        private static Dictionary<int, Dictionary<int, double>> getUserDic()
        {
            return getDic("USER_ID", "ITEM_ID", "RATE");
        }

#endregion 基于用户的推荐

#region 基于条目的推荐

        /// <summary>
        /// 外部程序部应该直接使用此函数，应使用封装好的另一个重载
        /// </summary>
        /// <param name="person"></param>
        /// <param name="n"></param>
        /// <returns>返回相似条目的列表</returns>
        private static List<objectSimilarity> getItemRecommItemBased
            (Dictionary<int, Dictionary<int, double>> userDic,
                   Dictionary<int, List<objectSimilarity>> simItemDic, int person, int n)
        {
            Dictionary<int, double> personDic = new Dictionary<int, double>();
            personDic = userDic[person];
            Dictionary<int, double> scores = new Dictionary<int, double>();
            Dictionary<int, double> totalSum = new Dictionary<int, double>();
            foreach (int item in personDic.Keys)
            {
                foreach (objectSimilarity item2 in simItemDic[item])
                {
                    if(personDic.Keys.Contains(item2.objectId))
                        continue;
                    scores.DefaultIfEmpty(new KeyValuePair<int,double>(item2.objectId,0));
                    scores[item2.objectId] += item2.similarity * personDic[item2.objectId];

                    totalSum.DefaultIfEmpty(new KeyValuePair<int,double>(item2.objectId,0));
                    totalSum[item2.objectId]+=personDic[item2.objectId];
                }
            }
                List<objectSimilarity> rankings = new List<objectSimilarity>();
            foreach (int item in scores.Keys)
                rankings.Add(new objectSimilarity(item, scores[item] / totalSum[item]));
            rankings.OrderBy(x => x.similarity, new scoreComparer());
            var t = rankings.Take(n);
            List<objectSimilarity> ret = new List<objectSimilarity>();
            foreach (objectSimilarity item in t)
            {
                ret.Add(item);
            }
            return ret;
        }

        /// <summary>
        /// 获得某一条目的基于条目的推荐结果
        /// </summary>
        /// <param name="item"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static List<objectSimilarity> getItemRecommItemBased(int item, int n = 3)
        {
            List<objectSimilarity> ret = new List<objectSimilarity>();
            ret=simItemDic[item];
            if (n < ret.Count)
                return ret.GetRange(0, n);
            else
                return ret;
        }

        /// <summary>
        /// 基于物品的过滤过程总体思路就是为媒介物品预先计算好最为相近的其他物品。然后，当我们相位某位用户提供推荐时，就可以查看
        /// 他曾经评分过的物品，并从中选出排位靠前者，再构造出一个加权列表，其中包含了与这些选中物品最为相近的物品。此处最为显著
        /// 的区别在于，尽管第一步要求我们检查所有的数据，但物品键的比较不会像用户的比较那么频繁变化。无需不停的为每样物品计算最
        /// 为相似的物品。我们可将这样的任务安排在网络流量不是很大的时候定期进行，活在独立于主程序之外的另一台计算机上单独进行。
        /// 
        /// 实际应用中，此数据应存放于数据库中，演示时，为了方便，设为静态变量放在了程序中。
        /// </summary>
        private static Dictionary<int, List<objectSimilarity>> simItemDic = new Dictionary<int, List<objectSimilarity>>();

        /// <summary>
        /// 获得条目的总字典
        /// </summary>
        /// <returns></returns>
        private static Dictionary<int, Dictionary<int, double>> getItemDic()
        {
            return getDic("ITEM_ID", "USER_ID", "RATE");
        }

        /// <summary>
        /// 为每个条目执行距离向量算法，计算相似度生成simItemDic
        /// </summary>
        /// <param name="itemDic"></param>
        /// <param name="n"></param>
        private static void calcSimItemDic(Dictionary<int, Dictionary<int, double>> itemDic, int n = 3)
        {
            Dictionary<int, List<objectSimilarity>> simItemDicBack=new Dictionary<int,List<objectSimilarity>>();
            simItemDicBack=simItemDic;
            simItemDic.Clear();
            try
            {  
                foreach (int item in itemDic.Keys)
                    simItemDic.Add(item, getSimObject(itemDic, item, n));
                simItemDicBack.Clear();
            }
            catch (Exception)
            {
                simItemDic = simItemDicBack;
                simItemDicBack.Clear();
                throw;
            }

        }

#endregion 基于条目的推荐

    } 
}