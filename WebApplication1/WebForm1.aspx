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

        <%--<asp:Literal ID="LiteralCards" runat="server" />--%>


        <asp:GridView ID="GridViewUsers" runat="server" AutoGenerateColumns="False" CssClass="table t1 table-hover"
            OnRowCommand="GridViewUsers_RowCommand"
            DataKeyNames="AccoutNo">

            <Columns>

                <%--<asp:BoundField DataField="AccoutNo" HeaderStyle-Font-Bold="true" HeaderText="UID" ReadOnly="true" />--%>

                <asp:TemplateField HeaderText="UID">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" runat="server"
                            Text='<%# Eval("AccoutNo") %>'
                            CommandName="EditUser"
                            CommandArgument='<%# Eval("AccoutNo") %>'
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

    </section>



</asp:Content>
