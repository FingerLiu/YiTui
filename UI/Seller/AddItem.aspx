<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddItem.aspx.cs" Inherits="UI_AddItem" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
        }
        .style2
        {
            width: 110px;
            height: 97px;
        }
        .style3
        {
            height: 97px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width: 100%; height: 370px;">
            <tr>
                <td class="style1">
                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="商品名称">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" Width="170px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="类目">
                    </dx:ASPxLabel>
                </td>
                <td class="style3">
                    <dx:ASPxRadioButtonList ID="ASPxRadioButtonList1" runat="server" 
                        ClientIDMode="AutoID" DataSourceID="SqlDataSourceCat" TextField="CAT_NAME" 
                        ValueField="CAT_ID">
                    </dx:ASPxRadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="价格（元）">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxSpinEdit ID="ASPxSpinEdit1" runat="server" Height="21px" Number="0" />
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="图片">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxUploadControl ID="ASPxUploadControl1" runat="server">
                    </dx:ASPxUploadControl>
                </td>
            </tr>
            <tr>
                <td align="center" class="style1" colspan="2">
                    <dx:ASPxButton ID="ASPxButton1" runat="server" onclick="ASPxButton1_Click" 
                        Text="ASPxButton">
                    </dx:ASPxButton>
                </td>
            </tr>
        </table>
    
    </div>
                <asp:SqlDataSource ID="SqlDataSourceCat" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:DB_MARKETConnectionString %>" 
                    SelectCommand="SELECT [CAT_NAME], [CAT_ID] FROM [TB_CAT] ORDER BY [CAT_ID]">
                </asp:SqlDataSource>
    </form>
</body>
</html>
