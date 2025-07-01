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
    public partial class EditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            { 
                string accNo = Request.QueryString["AccountNo"];
                if (!string.IsNullOrEmpty(accNo))
                {
                    LoadUser(accNo);
                }
            }
        }

        protected void LoadUser(string acc)
        {
            string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * from dbo.Table1 WHERE Account_No = @AccountNo", conn);

                cmd.Parameters.AddWithValue("AccountNo", acc);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtName.Text = reader["Name"].ToString();
                    cardlist.SelectedValue = reader["CardType"].ToString();
                    statuslist.SelectedValue = reader["ConnectionStatus"].ToString();
                    txtDate.Text = reader["dateofjoin"] == DBNull.Value ? DateTime.Now.ToString("yyyy-MM-dd") : Convert.ToDateTime(reader["dateofjoin"]).ToString("yyyy-MM-dd");
                }
            }
        }

        protected void Updatehandler(object sender, EventArgs e)
        {
            string accNo = Request.QueryString["AccountNo"];

            string name = txtName.Text.Trim();

            string cardType = cardlist.SelectedValue;

            string status = statuslist.SelectedValue;

            DateTime doj = !String.IsNullOrWhiteSpace(txtDate.Text) ? DateTime.Parse(txtDate.Text) : DateTime.Now.Date;

            try
            {
                AddUserDAL dataSubmit = new AddUserDAL();

                bool flag = dataSubmit.DataSubmission(accNo ,name ,cardType , status ,doj);

                if (flag)
                {
                    lblMessage.Text = "User updated successfully!";

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