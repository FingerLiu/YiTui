using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using YiTui;
using YiTui.DAL;
namespace YiTui.BLL
{
    /// <summary>
    /// Summary description for DataBinding
    /// </summary>
    public class DataBinding
    {
        public DataBinding()
        {
            //
            // TODO: Add constructor logic here
            //

        }

        public static void loadSessionNav(string userName, DevExpress.Web.ASPxNavBar.ASPxNavBar ASPxNavBar1)
        {
            try
            {
                DataTable dt = getUserSessionDt(userName);
                YiTui.DAL.DataBindingDAL.loadNav(ASPxNavBar1, dt, "SESSION_NAME", "ITEM_NAME");
            }
            catch (Exception)
            {
                throw;
            }

        }

        private static DataTable getUserSessionDt(string userName)
        {
            try
            {
                int userID=-1;
                Common.getUserID(userName,ref userID);
                var parameters = new SqlParameter[] { new SqlParameter("USER_ID", userID) };
                return YiTui.DAL.Execute.ExecuteProcDataTable("sp_Query_SessionName_ItemName_By_USER_ID",ref parameters);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static DataTable getItemDetailTb(string p)
        {
            throw new NotImplementedException();
        }

        public static DataTable getSessionDetailTb(string p)
        {
            throw new NotImplementedException();
        }
    }
}