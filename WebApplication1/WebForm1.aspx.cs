using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.UI.WebControls;
using WebApplication1.DAL;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString

            if (!IsPostBack)
            {
                //string search = Request.QueryString["search"] ?? "";

                string search = Session["search"] as string ?? "";

                LoadData(search);

                Session.Remove("search");

            }

        }

        public void LoadData(string search = "")
        {

            try
            {
                Class1 dal = new Class1();

                //List<User> users = dal.GetUsers();

                List<User> users = String.IsNullOrEmpty(search) ? dal.GetUsers() : dal.GetUsers(search);

                GridViewUsers.DataSource = users;

                GridViewUsers.DataBind();

                userCount.Text = "Active Users : " + dal.GetActiveUsers().ToString();

                CreditUserCount.Text = "Credit Card Users : " + dal.CreditUser().ToString();

                txtSearch.Text = search;

                CallToast();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Response.Write("An error occurred while loading data: " + ex.Message);
            }
        }



        private void CallToast()
        {

            string msg = "Page loaded successfully!";
            string script = $"showToast('{msg.Replace("'", "\\'")}');";

            ClientScript.RegisterStartupScript(this.GetType(), "ToastScript", script, true);
        }

        protected void GridViewUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditUser")
            {
                string acc = e.CommandArgument.ToString();
                Response.Redirect("EditUser.aspx?AccountNo=" + acc);
            }
        }

        protected void searchHandler(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim();

            //Response.Redirect("WebForm1.aspx?search=" + Server.UrlEncode(search));

            Session["search"] = search;
            Response.Redirect("Webform1.aspx");

            txtSearch.Text = "";
        }

        public void activeUserHandler(object sender, EventArgs e)
        {

            Class1 dal = new Class1();

            var activeUsers = dal.GetActive();

            GridViewUsers.DataSource = activeUsers;

            GridViewUsers.DataBind();

        }
    }
}