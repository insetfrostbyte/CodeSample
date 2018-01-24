<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Boggle.aspx.cs" Inherits="CodeSample.Web.Boggle" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtBoardInput" runat="server" Height="339px" Width="333px" TextMode="MultiLine"></asp:TextBox>
            <br />
            Board Height:<asp:TextBox ID="txtHeight" runat="server" TextMode="Number"></asp:TextBox>
            <br />
            Board Width:<asp:TextBox ID="txtWidth" runat="server" TextMode="Number"></asp:TextBox>
            <br />
            Minimum Word Size
            <asp:TextBox ID="txtMinWordSize" runat="server" TextMode="Number"></asp:TextBox>
            <br />
            <asp:Button ID="btn_SolveBoggle" runat="server" Text="Solve" OnClick="btn_SolveBoggle_Click" />
            <br />
            <asp:Label ID="wordList" runat="server" Text=""></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
