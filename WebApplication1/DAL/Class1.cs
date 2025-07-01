using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1.DAL
{

    public class User
    {
        public int AccountNo { get; set; }
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

                using (SqlCommand command = new SqlCommand("GetAllUsers", conn))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User
                            {
                                AccountNo = Convert.ToInt32(reader["Account_No"]),
                                Name = reader["Name"].ToString(),
                                CardType = reader["CardType"].ToString(),
                                ConnectionStatus = reader["ConnectionStatus"].ToString(),
                                DateOfJoin = reader["dateofjoin"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader["dateofjoin"])
                            });
                        }
                    }

                }

            }

            if (!String.IsNullOrWhiteSpace(search))
            {
                List<User> filterUsers = users.FindAll((e) =>
                {
                    return e.Name.ToLower().Contains(search.ToLower()) || e.CardType.ToLower().Contains(search.ToLower());
                });

                return filterUsers;

            }

            return users;

        }
        public int GetActiveUsers()
        {
            string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            int users = 0;

            using (var conn = new SqlConnection(strcon))
            {

                using (var cmd = new SqlCommand("GetActiveUserCount", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();


                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            users = Convert.ToInt32(reader["ActiveUsers"]);
                        }
                    }


                    //var output = new SqlParameter("@count", SqlDbType.Int)
                    //{
                    //    Direction = ParameterDirection.Output
                    //};


                    //cmd.Parameters.Add(output);
                    //conn.Open();

                    //cmd.ExecuteNonQuery();

                    //var result = cmd.Parameters["@count"].Value;

                    //if (result != DBNull.Value)
                    //{
                    //    users = Convert.ToInt32(result);
                    //}

                }

                //using (SqlCommand cmd = new SqlCommand("SELECT dbo.ActiveUserCount()", conn))
                //{
                //  var result = cmd.ExecuteScalar();
                //    if (result!=DBNull.Value)
                //    {
                //        users = Convert.ToInt32(result);
                //    }
                //}

            }

            return users;
        }

        public int CreditUser()
        {
            string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            int users = 0;

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT dbo.Credit()", conn))
                {
                    var result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        users = Convert.ToInt32(result);
                    }

                }
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

                //string query = "INSERT INTO dbo.Table1 (Account_No, Name, Cardtype, ConnectionStatus , dateofjoin) VALUES (@AccountNo , @Name, @CardType, @Status, @DateOfJoin)";

                using (SqlCommand cmd = new SqlCommand("AddNewUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AccountNo", user.AccountNo);
                    cmd.Parameters.AddWithValue("@Name", user.Name);
                    cmd.Parameters.AddWithValue("@CardType", user.CardType);
                    cmd.Parameters.AddWithValue("@ConnectionStatus", user.ConnectionStatus);
                    //cmd.Parameters.AddWithValue("@DateOfJoin", user.DateOfJoin);
                    cmd.Parameters.Add("@DateOfJoin", SqlDbType.Date).Value = user.DateOfJoin;

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

                string query = "UPDATE dbo.Table1 SET Name = @Name , CardType = @CardType ,ConnectionStatus = @Status , dateofjoin = @Date WHERE Account_No = @AccountNo";


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