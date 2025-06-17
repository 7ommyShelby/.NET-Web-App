<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="WebApplication1.EditUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Edit User</title>
    <link href="btsrp/bootstrap.min.css" rel="stylesheet" />

    <link href="style.css" rel="stylesheet" />

</head>
<body>

    <form id="form3" runat="server" class="container flex-column mt-5 p-4 rounded shadow bg-light" style="max-width: 50%;">

        <h2 class="mb-4 text-center text-primary">Edit User</h2>

        <div class="mb-3 frm-child">
            <label for="txtName" class="form-label fw-bold">Name</label>
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />

        </div>

        <div class="mb-3 frm-child">
            <label class="form-label fw-bold">
                Card Type
            </label>
            <asp:DropDownList ID="CardType" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Card Type" Value="" />
                <asp:ListItem Text="Credit" Value="Credit" />
                <asp:ListItem Text="Debit" Value="Debit" />
                <asp:ListItem Text="Prepaid" Value="Prepaid" />
            </asp:DropDownList>

        </div>

        <div class="mb-3 frm-child">
            <label class="form-label fw-bold">
                Account Status
            </label>
            <asp:DropDownList ID="statuslist" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Account Status" Value="" />
                <asp:ListItem Text="Active" Value="Active" />
                <asp:ListItem Text="Inactive" Value="Inactive" />

            </asp:DropDownList>
        </div>

        <div class="mb-3 frm-child">
            <label class="form-label fw-bold">
                Select Date :
            </label>
            <asp:TextBox ID="txtDate" runat="server" TextMode="Date" CssClass="form-control" />
        </div>


        <div class="w-100 d-flex justify-content-center gap-2">
            <asp:Button ID="btnSubmit" runat="server" Style="width: 50%" Text="Update User" CssClass="btn btn-primary btn-lg" OnClick="Updatehandler" />
        </div>


        <asp:Label ID="lblMessage" runat="server" CssClass="text-success mt-3 fw-semibold d-block text-center" />
    </form>
</body>
</html>
