using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace YiTui.DAL
{
    /// <summary>
    /// Summary description for DataBindingDAL
    /// </summary>
    public class DataBindingDAL
    {
        public DataBindingDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        internal static void loadNav(DevExpress.Web.ASPxNavBar.ASPxNavBar ASPxNavBar1, DataTable dt, string level1, string level2)
        {
            ASPxNavBar1.Groups.Clear();
            foreach (DataRow item in dt.Rows)
            {
                string level1Name = item[level1].ToString();
                string leve2Name = item[level2].ToString();
                if (ASPxNavBar1.Groups.IndexOfText(level1Name) < 0)
                {
                   ASPxNavBar1.Groups.Add(level1Name);
                }
                ASPxNavBar1.Groups[ASPxNavBar1.Groups.IndexOfText(level1Name)].Items.Add(leve2Name);
            }
        }
    }
}