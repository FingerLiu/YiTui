<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="易购推荐" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" 
        CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
        Width="682px" AutoGenerateColumns="False" ClientIDMode="AutoID">
        <Styles CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua">
            <LoadingPanel ImageSpacing="8px">
            </LoadingPanel>
        </Styles>
        <SettingsLoadingPanel ImagePosition="Top" />
        <ImagesFilterControl>
            <LoadingPanel Url="~/App_Themes/Aqua/Editors/Loading.gif">
            </LoadingPanel>
        </ImagesFilterControl>

<SettingsLoadingPanel ImagePosition="Top"></SettingsLoadingPanel>

        <Images SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css">
            <LoadingPanelOnStatusBar Url="~/App_Themes/Aqua/GridView/gvLoadingOnStatusBar.gif">
            </LoadingPanelOnStatusBar>
            <LoadingPanel Url="~/App_Themes/Aqua/GridView/Loading.gif">
            </LoadingPanel>
        </Images>
        <StylesEditors>
            <CalendarHeader Spacing="1px">
            </CalendarHeader>
            <ProgressBar Height="25px">
            </ProgressBar>
        </StylesEditors>
        <ImagesEditors>
            <DropDownEditDropDown>
                <SpriteProperties HottrackedCssClass="dxEditors_edtDropDownHover_Aqua" 
                    PressedCssClass="dxEditors_edtDropDownPressed_Aqua" />
<SpriteProperties HottrackedCssClass="dxEditors_edtDropDownHover_Aqua" PressedCssClass="dxEditors_edtDropDownPressed_Aqua"></SpriteProperties>
            </DropDownEditDropDown>
            <SpinEditIncrement>
                <SpriteProperties HottrackedCssClass="dxEditors_edtSpinEditIncrementImageHover_Aqua" 
                    PressedCssClass="dxEditors_edtSpinEditIncrementImagePressed_Aqua" />
<SpriteProperties HottrackedCssClass="dxEditors_edtSpinEditIncrementImageHover_Aqua" PressedCssClass="dxEditors_edtSpinEditIncrementImagePressed_Aqua"></SpriteProperties>
            </SpinEditIncrement>
            <SpinEditDecrement>
                <SpriteProperties HottrackedCssClass="dxEditors_edtSpinEditDecrementImageHover_Aqua" 
                    PressedCssClass="dxEditors_edtSpinEditDecrementImagePressed_Aqua" />
<SpriteProperties HottrackedCssClass="dxEditors_edtSpinEditDecrementImageHover_Aqua" PressedCssClass="dxEditors_edtSpinEditDecrementImagePressed_Aqua"></SpriteProperties>
            </SpinEditDecrement>
            <SpinEditLargeIncrement>
                <SpriteProperties HottrackedCssClass="dxEditors_edtSpinEditLargeIncImageHover_Aqua" 
                    PressedCssClass="dxEditors_edtSpinEditLargeIncImagePressed_Aqua" />
<SpriteProperties HottrackedCssClass="dxEditors_edtSpinEditLargeIncImageHover_Aqua" PressedCssClass="dxEditors_edtSpinEditLargeIncImagePressed_Aqua"></SpriteProperties>
            </SpinEditLargeIncrement>
            <SpinEditLargeDecrement>
                <SpriteProperties HottrackedCssClass="dxEditors_edtSpinEditLargeDecImageHover_Aqua" 
                    PressedCssClass="dxEditors_edtSpinEditLargeDecImagePressed_Aqua" />
<SpriteProperties HottrackedCssClass="dxEditors_edtSpinEditLargeDecImageHover_Aqua" PressedCssClass="dxEditors_edtSpinEditLargeDecImagePressed_Aqua"></SpriteProperties>
            </SpinEditLargeDecrement>
        </ImagesEditors>
        <Templates>
        <DataRow>
            <div style="padding:5px">
                <table class="templateTable">
                    <tr>
                        <td rowspan="4" style="width: 180px;">
                        <dx:ASPxBinaryImage ID="ASPxBinaryImage1" runat="server" Value='<%# Eval("IMG") %>' Width="120px" Height="150px">
                        </dx:ASPxBinaryImage>
                        </td>
                        <td class="caption" style="width: 180px;">商品名</td>
                        <td><%# Eval("ITEM_NAME")%></td>
                        <td class="caption" style="width: 180px;">类别</td>
                        <td><%# Eval("CAT_NAME")%></td>   
                    </tr>
                    <tr>
                        <td class="caption" style="width: 180px;">价格</td>
                        <td><%# Eval("PRICE")%></td>
                            <td class="caption"style="width: 180px;">库存数</td>
                        <td><%# Eval("CNT")%></td>
                    </tr>
                    <tr>
                        <td class="caption">买家名称</td>
                        <td ><%# Eval("SELLER_NAME")%></td>
                        <td class="caption">上线日期</td>
                        <td><%# Eval("ITEM_ONLINE_DATE")%></td>
                    </tr>
                    <tr>
                        <td class="caption">商品得分</td>
                        <td><%#Eval("RATE_AVL")%></td>
                        <td><dx:ASPxButton ID="ASPxButton1" runat="server" Text="收藏"></dx:ASPxButton></td>
                        <td><dx:ASPxButton ID="ASPxButton2" runat="server" Text="购买"></dx:ASPxButton></td>
                    </tr>
                </table>
            </div>
        </DataRow>
    </Templates>
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DB_MARKETConnectionString %>" 
        SelectCommand="SELECT A.ITEM_NAME, B.CAT_NAME, A.PRICE FROM TB_ITEM AS A INNER JOIN TB_CAT AS B ON A.CAT_ID = B.CAT_ID">
    </asp:SqlDataSource>

</asp:Content>

