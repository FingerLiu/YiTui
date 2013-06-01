using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace YiTui.BLL
{
    /// <summary>
    /// Summary description for Common
    /// </summary>
    public class Common
    {
        public Common()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static string getSessionIdFromSessionName(string sessionName)
        {
            return sessionName.Substring(sessionName.LastIndexOf(' ')+1);
        }
        public static void MessageBoxShow(System.Web.UI.Page page,string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message",
                string.Format("<script>alert('{0}')</script>", msg));
            
        }
        public static void getUserID(string userName, ref int id)
        {
            try
            {
                id = -1;
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("USER_NAME",SqlDbType.VarChar,50),
                    new SqlParameter("USER_ID",SqlDbType.Int,32,ParameterDirection.Output,false,
                            byte.MinValue,byte.MaxValue,null,DataRowVersion.Default,null)
                };
                parameters[0].Value = userName;
                YiTui.DAL.Execute.ExecuteProcNonQuery("sp_Query_USER_ID_By_USER_NAME", ref parameters);
                id = int.Parse(parameters[1].Value.ToString());
                return;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}