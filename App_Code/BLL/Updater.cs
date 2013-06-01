using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YiTui.DAL;
using System.Data;
using System.Data.SqlClient;
namespace YiTui.BLL
{
    /// <summary>
    /// Summary description for Updater
    /// </summary>
    public class Updater
    {
        public Updater()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //////////////////////////////////////2013/5/3 16:54/////////////////////////
        /// <summary>
        /// 把用户名保存到TB_USER
        /// </summary>
        /// <param name="p"></param>
        public static void saveUser(string userName)
        {
            try
            {
                Execute.ExecuteNonQuery(string.Format("INSERT into TB_USER VALUES('{0}')", userName));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void addSession(string userName, int catId, int sessionType, string sessionDesc)
        {
            try
            {
                int userId=-1;
                YiTui.BLL.Common.getUserID(userName, ref userId);
                YiTui.DAL.Execute.ExecuteNonQuery(string.Format(@"INSERT INTO TB_SESSION(USER_ID,CAT_ID,
                    SESSION_TYPE,SESSION_DESC) VALUES({0},{1},'{2}','{3}')",userId,catId,sessionType,sessionDesc));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sellerId"></param>
        /// <param name="itemName"></param>
        /// <param name="catId"></param>
        /// <param name="price"></param>
        /// <param name="img"></param>
        public static void addItem(int sellerId, string itemName, int catId, float price, byte[] img)
        {
            try
            {
                //                var parameters = new SqlParameter[] { new SqlParameter("USER_ID", userID) };
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@sellerId",SqlDbType.Int),
                    new SqlParameter("@itemName",SqlDbType.VarChar,50),
                    new SqlParameter("@catId",SqlDbType.Int),
                    new SqlParameter("@price",SqlDbType.Float),
                    new SqlParameter("@img",SqlDbType.Image),
                };
                parameters[0].Value = sellerId;
                parameters[1].Value = itemName;
                parameters[2].Value = catId;
                parameters[3].Value = price;
                parameters[4].Value = img;

                YiTui.DAL.Execute.ExecuteNonQuery("INSERT INTO TB_ITEM(seller_Id,item_Name,cat_Id,price,img) values(@sellerId,@itemName,@catId,@price,@img)", parameters);
            }
            catch (Exception)
            {
                
                throw;
            }

        }
    }
}
