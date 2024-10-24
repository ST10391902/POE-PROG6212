<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Programming_p2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <style>
        body {
            background-color: #c0b7d5; /* Updated background color */
            font-family: Arial, sans-serif;
        }
        .login-container {
            margin: 50px auto;
            width: 80%;
            background-color: #E6E6FA; /* Light lavender for login container */
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            text-align: center;
        }

        .login-container h2 {
            margin-bottom: 20px;
            font-size: 24px;
            color: #333;
        }

        .login-container table {
            width: 100%;
            border-collapse: collapse;
        }

        .login-container td {
            padding: 10px;
            vertical-align: top;
        }

        .login-container label {
            display: block;
            margin-bottom: 5px;
        }

        .login-container input[type="text"], 
        .login-container input[type="password"], 
        .login-container select {
            width: 90%;
            padding: 5px;
            margin-top: 5px;
            border: 1px solid #ccc;
            border-radius: 4px;
            font-size: 16px;
        }

        .login-container input[type="submit"], 
        .login-container button {
            width: 100%;
            padding: 10px;
            background-color: #D3D3D3; /* Button color */
            border: none;
            border-radius: 4px;
            color: #333;
            font-size: 16px;
            cursor: pointer;
        }

        .login-container input[type="submit"]:hover, 
        .login-container button:hover {
            background-color: #FF877C94; /* Hover effect color */
        }

        .error-message {
            color: red;
            font-size: 14px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>Login</h2>
            <table>
                <tr>
                    <td>
                        <label for="txtUser">Username</label>
                        <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="txtPass">Password</label>
                        <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="drpUser">Select User Type</label>
                        <asp:DropDownList ID="drpUser" runat="server">
                            <asp:ListItem Value="Program Coordinator">Program Coordinator</asp:ListItem>
                            <asp:ListItem Value="Lecture">Lecture</asp:ListItem>
                            <asp:ListItem Value="Manager">Manager</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
