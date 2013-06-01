using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YiTui.BLL;
public partial class UI_CreateUserWizard1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        //YiTui.BLL.Updater.saveUser(this.CreateUserWizard1.UserName);
    }
    protected void CreateUserWizard1_ContinueButtonClick(object sender, EventArgs e)
    {
        try
        {
            YiTui.BLL.Updater.saveUser(this.CreateUserWizard1.UserName);
        }
        catch (Exception ex)
        {

            YiTui.BLL.Common.MessageBoxShow(this.Page, ex.Message);
        }
        
    }
}