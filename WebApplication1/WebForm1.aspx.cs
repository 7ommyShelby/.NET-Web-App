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
                LoadData();
            }

        }

        public void LoadData(string search = "")
        {

            string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            try
            {

                Class1 dal = new Class1();

                List<User> users = dal.GetUsers(search);

                GridViewUsers.DataSource = users;

                GridViewUsers.DataBind();


            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Response.Write("An error occurred while loading data: " + ex.Message);
            }
            Response.Write("<script>console.log('Search: " + search + "');</script>");
                txtSearch.Text = "";

        }

        protected void GridViewUsers_RowCommand(object sender , GridViewCommandEventArgs e)
        {
            if(e.CommandName == "EditUser")
            {
                string acc = e.CommandArgument.ToString();
                Response.Redirect("EditUser.aspx?AccountNo=" + acc);
            }
        }

        protected void searchHandler(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim();

            LoadData(search);

        }
    }
}