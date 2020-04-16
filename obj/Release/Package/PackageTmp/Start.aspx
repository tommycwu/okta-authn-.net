<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Start.aspx.cs" Inherits="PerfTest.Start" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #TextArea1 {
            height: 315px;
            width: 761px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <br />
        api url&nbsp;
        <asp:TextBox ID="TextBoxUrl" runat="server" Width="724px">https://twu.oktapreview.com/api/v1/authn</asp:TextBox>
        <br />
        <br />
        api key <asp:TextBox ID="TextBoxKey" runat="server" Width="720px">00f7Uhl0rKGor8cnvLQkZr08x0Sk8WnCjmBfbiEMvt</asp:TextBox>
        <br />
        <br />
        <br />
        username
        <asp:TextBox ID="TextBox3" runat="server">tommy.wu</asp:TextBox>
        <br />
        <br />
        password
        <asp:TextBox ID="TextBox4" runat="server">1_Thousand!!!!!</asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="ButtonPost" runat="server" OnClick="ButtonPost_Click" Text="POST" />
&nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Loop" />
        <asp:TextBox ID="TextBox2" runat="server">50</asp:TextBox>
        <br />
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Height="71px" TextMode="MultiLine" Width="770px"></asp:TextBox>
        <br />
        <br />
        <asp:ListBox ID="ListBox1" runat="server" Height="254px" Width="388px"></asp:ListBox>
        <asp:ListBox ID="ListBox2" runat="server" Height="254px" Width="388px"></asp:ListBox>
        <br />
        <br />
        <asp:Label ID="LabelTotal" runat="server" Text="Total Time: 0"></asp:Label>
    </form>
</body>
</html>
