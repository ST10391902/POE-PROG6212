<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="POE_PROG6212.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style>
        body {
            font-family: Arial, sans-serif;
        }
        .form-container {
            margin: 50px auto;
            width: 40%;
            background-color: #f4f4f4;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        .button-container {
            text-align: center;
            margin-top: 20px;
        }
        .button-container button {
            margin-right: 10px;
            padding: 10px 20px;
            background-color: #007bff;
            border: none;
            font-size: 16px;
            cursor: pointer;
        }
        .button-container button:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <h2>Login</h2>

            <!-- User credentials input fields -->
            <label for="txtUser">Username:</label>
            <asp:TextBox ID="txtUser" runat="server" placeholder="Enter your username" />

            <label for="txtPass">Password:</label>
            <asp:TextBox ID="txtPass" runat="server" TextMode="Password" placeholder="Enter your password" />

            <label for="drpUser">User Type:</label>
            <asp:DropDownList ID="drpUser" runat="server">
                <asp:ListItem Value="Lecture">Lecture</asp:ListItem>
                <asp:ListItem Value="Program Coordinator">Program Coordinator</asp:ListItem>
                <asp:ListItem Value="HR">HR</asp:ListItem>
            </asp:DropDownList>

            <div class="button-container">
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            </div>

        </div>
    </form>
</body>
</html>
