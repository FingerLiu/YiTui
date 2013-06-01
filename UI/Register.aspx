<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="UI_Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center">
    
        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" 
            AnswerLabelText="安全问题答案:" ConfirmPasswordCompareErrorMessage="两次输入的密码不一致" 
            ConfirmPasswordLabelText="确认密码:" ConfirmPasswordRequiredErrorMessage="请确认密码" 
            CreateUserButtonText="创建用户" EmailRegularExpressionErrorMessage="请换一个邮箱" 
            EmailRequiredErrorMessage="请输入邮箱" PasswordLabelText="密码:" 
            PasswordRegularExpressionErrorMessage="请更换密码" 
            PasswordRequiredErrorMessage="请输入密码" QuestionLabelText="安全问题:" 
            QuestionRequiredErrorMessage="请输入安全问题" SkinID="ASPxButton" 
            UserNameLabelText="用户名:" UserNameRequiredErrorMessage="请输入用户名" 
            ContinueDestinationPageUrl="~/UI/Default.aspx" 
            oncreateduser="CreateUserWizard1_CreatedUser">
            <WizardSteps>
                <asp:CreateUserWizardStep runat="server" Title="注册新用户" />
                <asp:CompleteWizardStep runat="server" Title="注册成功" />
            </WizardSteps>
        </asp:CreateUserWizard>
    
    </div>
    </form>
</body>
</html>
