using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using YiTui.BLL;
using System.Text;
    public partial class UI_TEST: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DataTable dt = YiTui.DAL.Execute.ExecuteProcDataTable("[sp_Query_Items_Full]");
                try
                {
                    ASPxGridView1.DataSource = dt;
                    ASPxGridView1.DataBind();
                }
                catch (Exception)
                {
                    //remove datatable errors  
                    DataRow[] rowsInError;
                    if (dt.HasErrors)
                    {
                        // Get an array of all rows with errors. 
                        rowsInError = dt.GetErrors();
                        // Print the error of each column in each row. 
                        StringBuilder sbError = new StringBuilder();
                        for (int i = 0; i < rowsInError.Length; i++)
                        {
                            foreach (DataColumn myCol in dt.Columns)
                            {
                                sbError.Append(myCol.ColumnName + " " + rowsInError[i].GetColumnError(myCol));
                            }
                            // Clear the row errors 
                            rowsInError[i].ClearErrors(); //设置断点，然后运行时观察其中错误 
                        }
                    }
                    throw;
                }
            }
        }
        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            DataTable dt = YiTui.DAL.Execute.ExecuteProcDataTable("[sp_Query_Items_Full]");
 
        }
}
