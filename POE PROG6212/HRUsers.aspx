<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HRUsers.aspx.cs" Inherits="YourNamespace.HRUsers" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> HRUsers</title>
    <style>
        body {
            background-color: #c0b7d5;
            font-family: Arial, sans-serif;
        }

        .container {
            width: 80%;
            margin: 50px auto;
            background-color: #E6E6FA;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            display: flex;
            flex-direction: row;
            align-items: flex-start;
        }

        .form-container {
            flex: 1;
            margin-right: 20px;
        }

        .form-container label {
            display: block;
            margin-top: 10px;
        }

        input[type="text"], input[type="email"], select {
            width: 90%;
            padding: 5px;
            margin-top: 5px;
        }

        .button-container {
            text-align: center;
            margin-top: 20px;
        }

        input[type="button"], input[type="submit"], .button-container asp:Button {
            padding: 10px;
            background-color: #D3D3D3;
            border: none;
            border-radius: 4px;
            font-size: 16px;
            cursor: pointer;
            margin-right: 10px;
        }

        input[type="button"]:hover, input[type="submit"]:hover, .button-container asp:Button:hover {
            background-color: #FF877C94;
        }

        .grid-container {
            flex: 1;
            width: 100%;
        }

        table {
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 20px;
        }

        th, td {
            padding: 10px;
            border: 1px solid #ccc;
        }

        th {
            background-color: #D3D3D3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="form-container">
                <h2>HRUsers</h2>
                <div class="form-group">
                    <label for="UserId">User ID (For Update/Delete):</label>
                    <asp:TextBox ID="UserId" runat="server" Enabled="false"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="UserName">User Name:</label>
                    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="UserEmail">User Email:</label>
                    <asp:TextBox ID="UserEmail" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="UserRole">User Role:</label>
                    <asp:DropDownList ID="UserRole" runat="server">
                        <asp:ListItem Text="Select Role" Value=""></asp:ListItem>
                        <asp:ListItem Text="HR" Value="HR"></asp:ListItem>
                        <asp:ListItem Text="Lecture" Value="Lecture"></asp:ListItem>
                        <asp:ListItem Text="Program Coordinator" Value="Program Coordinator"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="button-container">
                    <asp:Button ID="btnAddUser" runat="server" Text="Add User" OnClick="btnAddUser_Click" />
                    <asp:Button ID="btnUpdateUser" runat="server" Text="Update User" OnClick="btnUpdateUser_Click" />
                    <asp:Button ID="btnDeleteUser" runat="server" Text="Delete User" OnClick="btnDeleteUser_Click" />
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                </div>
            </div>

            <!-- Users Grid -->
            <div class="grid-container">
                <asp:GridView ID="UsersGridView" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="UsersGridView_SelectedIndexChanged" DataKeyNames="UserId">
                    <Columns>
                        <asp:BoundField DataField="UserId" HeaderText="User ID" />
                        <asp:BoundField DataField="UserName" HeaderText="User Name" />
                        <asp:BoundField DataField="UserEmail" HeaderText="User Email" />
                        <asp:BoundField DataField="UserRole" HeaderText="User Role" />
                        <asp:CommandField ShowSelectButton="True" SelectText="Select" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
