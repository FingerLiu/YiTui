using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_NewSession : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated) Response.Redirect("~/UI/Login.aspx");
    }
    protected void ASPxButton1_Click(object sender, EventArgs e)
    {
        try
        {
            string userName = User.Identity.Name;
            int sessionType=int.Parse(ASPxComboBox1.SelectedItem.Value.ToString());
            int catId = int.Parse(ASPxRadioButtonList1.SelectedItem.Value.ToString());
            string sessionDesc = ASPxTextBox1.Text.Trim();
            YiTui.BLL.Updater.addSession(userName,catId,sessionType,sessionDesc);
        }
        catch (Exception ex)
        {
            YiTui.BLL.Common.MessageBoxShow(this.Page, ex.Message);
        }
       
    }
}