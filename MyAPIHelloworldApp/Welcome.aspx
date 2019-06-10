<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="MyAPIHelloworldApp.Welcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue" Text=" Hello World"></asp:Label>
            </div>
        <hr />
       <hr />
        <br />
        <br />
        <div>
            <asp:Button ID="Button1" runat="server" Text="Call API without Database" OnClick="Button1_Click" />
             </div>
          <hr />
       <hr />
        <div>
            <asp:Button ID="Button2" runat="server" Text="Call Api with Database call" OnClick="Button2_Click" />
        </div>
 </form>
</body>
</html>
