<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        if (window.performance) {
            if (performance.navigation.type === 1) {
                window.location = "WebForm1.aspx";
            }
        }

        function showToast(message, duration = 3000) {
            const toast = document.querySelector('#custom-toast');

            toast.innerText = 'TOAST DELIVERED';
            toast.classList.remove('d-none');
            toast.classList.add('show');

            setTimeout(() => {
                setTimeout(() => {
                    toast.classList.remove('show')
                }, 400);
                toast.classList.add('d-none');
            }, duration)
            toast.classList.remove('hide');
        }


    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="sec1">

        <div class="d-flex gap-3 flex align-items-center justify-content-evenly p-5 px-4">

            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Enter name to search" />

            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn text-center btn-primary" OnClick="searchHandler" />

            <asp:HyperLink ID="hlAddUser" runat="server" NavigateUrl="AddUser.aspx" CssClass="btn btn-success mb-3">Add New User</asp:HyperLink>

        </div>

        <div class="usercount">

            <asp:Button ID="btnActive" runat="server" Text="Active Users" CssClass="btn text-center btn-primary" OnClick="activeUserHandler" />

            <div>

                <asp:Label ID="userCount" Text="" runat="server" />
                <asp:Label ID="CreditUserCount" Text="" runat="server" />
            </div>
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

        <div id="custom-toast" class="toast-box d-none"></div>


    </section>



</asp:Content>
