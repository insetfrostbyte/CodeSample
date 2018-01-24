<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NodeList.aspx.cs" Inherits="CodeSample.Web.NodeList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button runat="server" id="CreateButton" text="Create List" OnClick="CreateButton_Click" />
            &nbsp;<asp:TextBox runat="server" id="listSizeTextBox" type="text" TextMode="Number" value="5"/>
            <asp:CheckBox id="allowSelfLinks" runat="server"  Text="Allow Self Links"/>
            <br />
            <asp:Label ID="originalLabel" runat="server" Text=""></asp:Label>
            <br />
        </div>
        <p>
            <asp:Button runat="server" id="CopyButton" text="Copy list" OnClick="CopyButton_Click" />
        </p>
        <p>
            <asp:Label ID="copyLabel" runat="server" Text=""></asp:Label>
        </p>
    </form>
</body>
</html>
