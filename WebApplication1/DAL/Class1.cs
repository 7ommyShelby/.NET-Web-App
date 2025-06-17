using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using static WebApplication1.WebForm1;
using static WebApplication1.EditUser;
using System.Data;

namespace WebApplication1.DAL
{

    public class User
    {
        public int AccoutNo { get; set; }
        public string Name { get; set; }

        public string CardType { get; set; }

        public string ConnectionStatus { get; set; }

        public DateTime DateOfJoin { get; set; }
    }

    public class Class1
    {

        string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public List<User> GetUsers(string search = "")
        {

            List<User> users = new List<User>();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                string query = "SELECT * FROM dbo.Table1";

                //if (!String.IsNullOrWhiteSpace(search))
                //{
                //    query += " WHERE Name LIKE @Search OR Account_type LIKE @Search";
                //}

                using (SqlCommand command = new SqlCommand(query, conn))
                {

                    //if (!string.IsNullOrWhiteSpace(search))
                    //{
                    //    command.Parameters.AddWithValue("@Search", "%" + search + "%");   // (search is a param which stores the value after the ","  ,  in this case "search from tetxbox") 
                    //}

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User
                            {
                                AccoutNo = Convert.ToInt32(reader["A_No"]),
                                Name = reader["Name"].ToString(),
                                CardType = reader["Account_Type"].ToString(),
                                ConnectionStatus = reader["Status"].ToString(),
                                DateOfJoin = reader["dateofjoin"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader["dateofjoin"])
                            });
                        }
                    }

                }

            }

            if (!String.IsNullOrWhiteSpace(search))
            {
                //foreach (var item in users)
                //{
                //    if (item.Name == search || item.CardType == search)
                //    {
                //        filterUsers.Add(item);
                //    }
                //}

                List<User> filterUsers = users.FindAll((e) =>
                {
                    return e.Name.ToLower().Contains(search.ToLower()) || e.CardType.ToLower().Contains(search.ToLower());
                });

                return filterUsers;

            }

            return users;

        }

    }

    public class AddUserDAL
    {
        string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public bool AddNewUser(User user)
        {

            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();

                string query = "INSERT INTO dbo.Table1 (A_No, Name, Account_Type, Status , dateofjoin) VALUES (@AccountNo , @Name, @CardType, @Status, @DateOfJoin)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@AccountNo", user.AccoutNo);
                    cmd.Parameters.AddWithValue("@Name", user.Name);
                    cmd.Parameters.AddWithValue("@CardType", user.CardType);
                    cmd.Parameters.AddWithValue("@Status", user.ConnectionStatus);
                    cmd.Parameters.AddWithValue("@DateOfJoin", user.DateOfJoin);

                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }

            }
        }


        public bool DataSubmission(string accNo, string name, string cardType, string status, DateTime doj)
        {
            string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                string query = "UPDATE dbo.Table1 SET Name = @Name , Account_type = @CardType ,Status = @Status , dateofjoin = @Date WHERE A_No = @AccountNo";


                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@AccountNo", accNo);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@CardType", cardType);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.Add("@Date", SqlDbType.Date).Value = doj;

                int rows = cmd.ExecuteNonQuery();

                return rows > 0;
            }

        }

    }

}