using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using YiTui.BLL;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack && HttpContext.Current.User.Identity.Name != null)
            {
                string userName = HttpContext.Current.User.Identity.Name;
                YiTui.BLL.DataBinding.loadSessionNav(userName, ASPxNavBar1);
            }
        }
        catch (Exception ex)
        {
            YiTui.BLL.Common.MessageBoxShow(this.Page, ex.Message);
        }

    }
    protected void ASPxNavBar1_ItemClick(object source, DevExpress.Web.ASPxNavBar.NavBarItemEventArgs e)
    {
        Response.Redirect("~/UI/Default.aspx?Type=ItemDetail&ItemName=" + e.Item.Text);
    }
    protected void ASPxNavBar1_HeaderClick(object source, DevExpress.Web.ASPxNavBar.NavBarGroupCancelEventArgs e)
    {
        Response.Redirect("~/UI/Default.aspx?Type=SessionDetail&SessionName=" + e.Group.Text);
    }
}
