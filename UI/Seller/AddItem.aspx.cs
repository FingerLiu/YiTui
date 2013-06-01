using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_AddItem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ASPxButton1_Click(object sender, EventArgs e)
    {
        try
        {
            // ASPxUploadControl1.FileBytes
            //(卖家名)品名类价图
            int sellerId = 1;
            string itemName = ASPxTextBox1.Text;
            int catId = int.Parse(ASPxRadioButtonList1.SelectedItem.Value.ToString());
            float price = float.Parse(ASPxSpinEdit1.Value.ToString());
            byte[] img = ASPxUploadControl1.UploadedFiles[0].FileBytes;
            YiTui.BLL.Updater.addItem(sellerId, itemName, catId, price, img);
        }
        catch (Exception ex)
        {
            YiTui.BLL.Common.MessageBoxShow(this.Page,ex.Message);
        }

    }
}