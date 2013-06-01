<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateUserWizard1.aspx.cs" Inherits="UI_CreateUserWizard1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>易购推荐</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" 
            CancelDestinationPageUrl="~/UI/Login.aspx" 
            ContinueDestinationPageUrl="~/UI/Login.aspx" 
            oncreateduser="CreateUserWizard1_CreatedUser" ContinueButtonText="继续" 
            CreateUserButtonText="新建用户" FinishCompleteButtonText="完成" 
            FinishDestinationPageUrl="~/UI/Login.aspx" FinishPreviousButtonText="上一步" 
            LoginCreatedUser="False" 
            oncontinuebuttonclick="CreateUserWizard1_ContinueButtonClick">
            <WizardSteps>
                <asp:CreateUserWizardStep runat="server" />
                <asp:CompleteWizardStep runat="server" />
            </WizardSteps>
        </asp:CreateUserWizard>
    
    </div>
    </form>
</body>
</html>
