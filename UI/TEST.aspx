<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TEST.aspx.cs" Inherits="UI_TEST" %>

<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxMenu" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSiteMapControl" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxNavBar" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx1" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            height: 24px;
        }
    
.dxpControl_Aqua
{
	font: 9pt Tahoma;
	color: #C7DFFF;
}
.dxpSummary_Aqua
{
	font: 9pt Tahoma;
	color: #749BCA;
	white-space: nowrap;
	text-align: center;
	vertical-align: middle;
	padding: 0px 4px 0px 4px;
}
.dxpDisabled_Aqua
{
	color: #A6A6A6;
	border-color: #A6A6A6;
	cursor: default;
}

.dxpDisabledButton_Aqua
{
	font: 9pt Tahoma;
	color: #000000;
	text-decoration: none;
}
.dxpButton_Aqua
{
	font: 9pt Tahoma;
	color: #394EA2;
	text-decoration: underline;
	white-space: nowrap;
	text-align: center;
	vertical-align: middle;
}

.dxWeb_pPrevDisabled_Aqua {
    background-position: -105px -25px;
    width: 19px;
    height: 19px;
}

.dxWeb_rpHeaderTopLeftCorner_Aqua,
.dxWeb_rpHeaderTopRightCorner_Aqua,
.dxWeb_rpBottomLeftCorner_Aqua,
.dxWeb_rpBottomRightCorner_Aqua,
.dxWeb_rpTopLeftCorner_Aqua,
.dxWeb_rpTopRightCorner_Aqua,
.dxWeb_rpGroupBoxBottomLeftCorner_Aqua,
.dxWeb_rpGroupBoxBottomRightCorner_Aqua,
.dxWeb_rpGroupBoxTopLeftCorner_Aqua,
.dxWeb_rpGroupBoxTopRightCorner_Aqua,
.dxWeb_mHorizontalPopOut_Aqua,
.dxWeb_mVerticalPopOut_Aqua,
.dxWeb_mSubMenuItem_Aqua,
.dxWeb_mSubMenuItemChecked_Aqua,
.dxWeb_nbCollapse_Aqua,
.dxWeb_nbExpand_Aqua,
.dxWeb_splVSeparator_Aqua,
.dxWeb_splVSeparatorHover_Aqua,
.dxWeb_splHSeparator_Aqua,
.dxWeb_splHSeparatorHover_Aqua,
.dxWeb_splVCollapseBackwardButton_Aqua,
.dxWeb_splVCollapseBackwardButtonHover_Aqua,
.dxWeb_splHCollapseBackwardButton_Aqua,
.dxWeb_splHCollapseBackwardButtonHover_Aqua,
.dxWeb_splVCollapseForwardButton_Aqua,
.dxWeb_splVCollapseForwardButtonHover_Aqua,
.dxWeb_splHCollapseForwardButton_Aqua,
.dxWeb_splHCollapseForwardButtonHover_Aqua,
.dxWeb_pcCloseButton_Aqua,
.dxWeb_pcSizeGrip_Aqua,
.dxWeb_pAll_Aqua,
.dxWeb_pAllDisabled_Aqua,
.dxWeb_pPrev_Aqua,
.dxWeb_pPrevDisabled_Aqua,
.dxWeb_pNext_Aqua,
.dxWeb_pNextDisabled_Aqua,
.dxWeb_pLast_Aqua,
.dxWeb_pLastDisabled_Aqua,
.dxWeb_pFirst_Aqua,
.dxWeb_pFirstDisabled_Aqua,
.dxWeb_tiBackToTop_Aqua,
.dxWeb_smLevelBullet_Aqua {
    background-repeat: no-repeat;
    background-color: transparent;
}

.dxpCurrentPageNumber_Aqua
{
	font: 9pt Tahoma;
	color: #000000;
	text-decoration: none;
	padding: 0px 3px 0px 3px;
	background-color: #FFE7A2;
	border: solid 1px #FFBD69;
}
.dxpPageNumber_Aqua
{
	font: 9pt Tahoma;
	color: #3F66A0;
	text-decoration: underline;
	text-align: center;
	vertical-align: middle;
	padding: 0px 5px 0px 5px;
}

.dxWeb_pNextDisabled_Aqua {
    background-position: -81px -25px;
    width: 19px;
    height: 19px;
}

        </style>
        <style type="text/css">
		.templateTable {
			border-collapse: collapse;
			background: #F3F8F7;
            width: 100%;
		}
		.templateTable td {
			border: solid 1px #C2D4DA;
			padding: 2px;
		}
		.templateCaption td.caption {
			background: #ECF2F3;
		}    
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <dx:ASPxMenu ID="ASPxMenu1" runat="server" ClientIDMode="AutoID" 
            SkinID="MenuToolBar" Target="_top" Width="90%">
            <Items>
                <dx:MenuItem Text="随便看看">
                </dx:MenuItem>
                <dx:MenuItem Text="同类热门商品">
                </dx:MenuItem>
                <dx:MenuItem Text="好友的推荐">
                </dx:MenuItem>
                <dx:MenuItem Text="综合推荐">
                </dx:MenuItem>
                <dx:MenuItem Text="新建购买会话">
                </dx:MenuItem>
                <dx:MenuItem Text="管理购买会话">
                </dx:MenuItem>
                <dx:MenuItem Text="个人信息">
                </dx:MenuItem>
                <dx:MenuItem Text="我的好友">
                </dx:MenuItem>
            </Items>
        </dx:ASPxMenu>
        <asp:LoginName ID="LoginName1" runat="server" />
        <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutAction="Redirect" 
            LogoutPageUrl="~/UI/Login.aspx" />
    
    </div>
        <dx1:ASPxGridView ID="ASPxGridView1" runat="server" 
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
                </DropDownEditDropDown>
                <SpinEditIncrement>
                    <SpriteProperties HottrackedCssClass="dxEditors_edtSpinEditIncrementImageHover_Aqua" 
                        PressedCssClass="dxEditors_edtSpinEditIncrementImagePressed_Aqua" />
                </SpinEditIncrement>
                <SpinEditDecrement>
                    <SpriteProperties HottrackedCssClass="dxEditors_edtSpinEditDecrementImageHover_Aqua" 
                        PressedCssClass="dxEditors_edtSpinEditDecrementImagePressed_Aqua" />
                </SpinEditDecrement>
                <SpinEditLargeIncrement>
                    <SpriteProperties HottrackedCssClass="dxEditors_edtSpinEditLargeIncImageHover_Aqua" 
                        PressedCssClass="dxEditors_edtSpinEditLargeIncImagePressed_Aqua" />
                </SpinEditLargeIncrement>
                <SpinEditLargeDecrement>
                    <SpriteProperties HottrackedCssClass="dxEditors_edtSpinEditLargeDecImageHover_Aqua" 
                        PressedCssClass="dxEditors_edtSpinEditLargeDecImagePressed_Aqua" />
                </SpinEditLargeDecrement>
            </ImagesEditors>
                    <Templates>
            <DataRow>
                <div style="padding:5px">
                    <table class="templateTable">
                        <tr>
                            <td rowspan="4">
                            <dx:ASPxBinaryImage ID="ASPxBinaryImage1" runat="server" Value='<%# Eval("IMG") %>'>
                            </dx:ASPxBinaryImage>
                            </td>
                            <td class="caption">商品名</td>
                            <td><%# Eval("ITEM_NAME")%></td>
                            <td class="caption">类别</td>
                            <td><%# Eval("CAT_NAME")%></td>   
                        </tr>
                        <tr>
                            <td class="caption">价格</td>
                            <td><%# Eval("PRICE")%></td>
                             <td class="caption">库存数</td>
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
                        </tr>
                    </table>
                </div>
            </DataRow>
        </Templates>

        </dx1:ASPxGridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DB_MARKETConnectionString %>" 
        SelectCommand="SELECT [IMG], [ITEM_NAME], [PRICE], [CAT_ID],[SELLER_ID],[ITEM_ONLINE_DATE] FROM [TB_ITEM]">
    </asp:SqlDataSource>
    <table style="width: 100%; height: 302px; margin-top: 0px;">
        <tr>
            <td class="style1">
                <dx:ASPxButton ID="ASPxButton1" runat="server" onclick="ASPxButton1_Click" 
                    Text="check sp">
                </dx:ASPxButton>
            </td>
        </tr>
        </table>
    <dx:ASPxSiteMapDataSource ID="ASPxSiteMapDataSource1" runat="server" 
        SiteMapFileName="~/web.sitemap" />

    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DB_MARKETConnectionString %>" 
        SelectCommand="sp_Query_Items_Full" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>

    </form>
</body>
</html>
