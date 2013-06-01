<%@ Page Title="易购推荐" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewSession.aspx.cs" Inherits="UI_NewSession" Theme="Aqua" %><%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style4
        {
            height: 86px;
        }
        .style5
        {
            height: 31px;
        }
        .style6
        {
            height: 9px;
        }
        .style7
        {
            height: 31px;
            width: 268px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 700; height: 800; " width="700">
        <tr>
            <td class="style7">
                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Session类型：">
                </dx:ASPxLabel>
            </td>
            <td class="style5">
                <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" ClientIDMode="AutoID" 
                    SelectedIndex="0" ValueType="System.String">
                    <Items>
                        <dx:ListEditItem Selected="True" Text="为自己购买非隐私物品" Value="0" />
                        <dx:ListEditItem Text="为自己购买隐私物品" Value="1" />
                        <dx:ListEditItem Text="为他人购买非隐私物品" Value="2" />
                        <dx:ListEditItem Text="为他人购买隐私物品" Value="3" />
                    </Items>
                </dx:ASPxComboBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                <dx:ASPxRadioButtonList ID="ASPxRadioButtonList1" runat="server" 
                    ClientIDMode="AutoID" DataSourceID="SqlDataSourceCat" TextField="CAT_NAME" 
                    ValueField="CAT_ID">
                </dx:ASPxRadioButtonList>
                <asp:SqlDataSource ID="SqlDataSourceCat" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:DB_MARKETConnectionString %>" 
                    SelectCommand="SELECT [CAT_NAME], [CAT_ID] FROM [TB_CAT] ORDER BY [CAT_ID]">
                </asp:SqlDataSource>
            </td>
            <td class="style4">
                <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="描述">
                </dx:ASPxLabel>
                <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td class="style6" colspan="2">
                <dx:ASPxButton ID="ASPxButton1" runat="server" onclick="ASPxButton1_Click" 
                    Text="确定">
                </dx:ASPxButton>
            </td>
        </tr>
    </table>
</asp:Content>

