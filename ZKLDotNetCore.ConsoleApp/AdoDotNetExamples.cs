using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZKLDotNetCore.ConsoleApp
{
    internal class AdoDotNetExamples

    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",//Server Name
            InitialCatalog = "ZKLDotNetCore",//database name
            UserID="sa",
            Password="sasa@123",

        };
        public void Read() {
           
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            Console.WriteLine("open");

            string query = "select * from tbl_blog";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            Console.WriteLine("close");

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("Blog Id:" + dr["BlogId"]);
                Console.WriteLine("Blog Title:" + dr["BlogTitle"]);

                Console.WriteLine("Blog Author:" + dr["BlogAuthor"]);
                Console.WriteLine("Blog Content:" + dr["BlogContent"]);
                Console.WriteLine(".............................");
            }
        }

        public void Create(string title, string author, string content)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string query = @"INSERT INTO [dbo].[tbl_blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle,
		   @BlogAuthor,
		   @BlogContent)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BlogTitle", title);
            command.Parameters.AddWithValue("@BlogAuthor", author);
            command.Parameters.AddWithValue("@BlogContent", content);
            int result=command.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "Saving Successful." : "Saving Failed";
            Console.WriteLine(message);
        }
    }

   
}
