using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ASPxGridView1.Settings.ShowVerticalScrollBar = true;
        ASPxGridView1.Settings.VerticalScrollableHeight = 450;
        try
        {
            string Type = Request.Params["Type"].ToString();
            if (!User.Identity.IsAuthenticated && Type != "Radom") Response.Redirect("~/UI/Login.aspx");
            if (!IsPostBack && Type == "Radom")
            {
                ASPxGridView1.DataSource = YiTui.DAL.Execute.ExecuteProcDataTable("[sp_Query_Items_Full]");
                ASPxGridView1.DataBind();
            }
            else if (!IsPostBack && Type == "ItemDetail")
            {
                ASPxGridView1.DataSource = YiTui.BLL.DataBinding.getItemDetailTb(Request.Params["ItemName"].ToString());
                ASPxGridView1.DataBind();
            }
            else if (!IsPostBack && Type == "SessionDetail")
            {
                ASPxGridView1.DataSource = YiTui.BLL.DataBinding.getSessionDetailTb(Request.Params["SessionName"].ToString());
                ASPxGridView1.DataBind();
            }
        }
        catch (Exception ex)
        {
            YiTui.BLL.Common.MessageBoxShow(this.Page, ex.Message);
            Response.Redirect("~/UI/Login.aspx");
        }
    }
}
