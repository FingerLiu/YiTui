<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="UI_Login" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Login ID="Login1" runat="server" LoginButtonText="登陆" 
            PasswordLabelText="密码:" RememberMeText="记住我" TitleText="用户登陆" 
            UserNameLabelText="用户名:" DestinationPageUrl="~/UI/Default.aspx?Type=Radom">
<%--               <asp:Login ID="Login1" runat="server" LoginButtonText="登陆" 
            PasswordLabelText="密码:" RememberMeText="记住我" TitleText="用户登陆" 
            UserNameLabelText="用户名:" DestinationPageUrl="~/UI/Default.aspx?Type=Radom">--%>
        </asp:Login>
    
        <dx:ASPxHyperLink ID="ASPxHyperLink1" runat="server" 
            NavigateUrl="~/UI/CreateUserWizard1.aspx" Text="注册新用户" />
    
    </div>
    </form>
</body>
</html>
