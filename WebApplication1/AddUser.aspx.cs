using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using WebApplication1.DAL;


namespace WebApplication1
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitHandler(object sender, EventArgs e)
        {

            Random rnd = new Random();

            int accountNumber = rnd.Next(100000, 999999);

            string name = txtName.Text.Trim();

            string cardType = CardType.SelectedValue;

            string status = statuslist.SelectedValue;

            DateTime doj = !String.IsNullOrWhiteSpace(txtDate.Text) ? DateTime.Parse(txtDate.Text) : DateTime.Now.Date;


            User newUser = new User { AccoutNo = accountNumber, Name = name, CardType = cardType, ConnectionStatus = status, DateOfJoin = doj };

            try
            {
                AddUserDAL dal = new AddUserDAL();

                if (dal.AddNewUser(newUser))
                {

                    lblMessage.Text = "User added successfully!";

                    Response.Redirect("WebForm1.aspx");

                }

            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }


        }


    }
}