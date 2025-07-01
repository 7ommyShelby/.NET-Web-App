<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <h1 class="h1">this is a content page
        </h1>
    </div>

    <section class="sec1">

        <%--  <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" CssClass="tb table table-dark table-striped table-bordered table-hover"></asp:GridView>--%>


        <div class="d-flex gap-3 flex align-items-center justify-content-evenly p-5 px-4">

            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Enter name to search" />

            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn text-center btn-primary" OnClick="searchHandler" />

            <asp:HyperLink ID="hlAddUser" runat="server" NavigateUrl="AddUser.aspx" CssClass="btn btn-success mb-3">Add New User</asp:HyperLink>

        </div>

        <div class="usercount">
            <asp:Label ID="userCount" Text="" runat="server" />
            <asp:Label ID="CreditUserCount" Text="" runat="server" />
        </div>

        <asp:GridView ID="GridViewUsers" runat="server" AutoGenerateColumns="False" CssClass="table t1 table-hover"
            OnRowCommand="GridViewUsers_RowCommand"
            DataKeyNames="AccountNo">

            <Columns>

                <%--<asp:BoundField DataField="AccoutNo" HeaderStyle-Font-Bold="true" HeaderText="UID" ReadOnly="true" />--%>

                <asp:TemplateField HeaderText="UID">

                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" runat="server"
                            Text='<%# Eval("AccountNo") %>'
                            CommandName="EditUser"
                            CommandArgument='<%# Eval("AccountNo") %>'
                            CssClass="text-primary text-decoration-underline">
                        </asp:LinkButton>
                    </ItemTemplate>

                </asp:TemplateField>

                <asp:BoundField DataField="Name" HeaderText="Name" />

                <asp:BoundField DataField="CardType" HeaderText="Card Type" />

                <asp:BoundField DataField="ConnectionStatus" HeaderText="Connection Status" />

                <asp:BoundField DataField="DateOfJoin" HeaderText="Date Of Joining" DataFormatString="{0:dd-MM-yyyy}" />

            </Columns>

        </asp:GridView>

        <div class="toast align-items-center text-white bg-primary border-0" role="alert" aria-live="assertive" aria-atomic="true">
            <div class="d-flex">
                <div class="toast-body">
                    Hello, world! This is a toast message.
                </div>
                <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>
            </div>
        </div>

    </section>



</asp:Content>
