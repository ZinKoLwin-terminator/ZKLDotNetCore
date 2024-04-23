using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace ZKLDotNetCore.ConsoleApp
{
    internal class AdoDotNetExamples

    {

        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            //ServerName
            InitialCatalog = "ZKLDotNetCore",
            UserID = "sa",
            Password = "sasa@123",
        };

        public void Read()
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            Console.WriteLine("open Connection");

            string query = "select * from tbl_blog";

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();

            adapter.Fill(dt);
            connection.Close();
            Console.WriteLine("connection close");

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("BlogId:" + dr["BlogId"]);
                Console.WriteLine("Blog Title:" + dr["BlogTitle"]);
                Console.WriteLine("Blog Author:" + dr["BlogAuthor"]);
                Console.WriteLine("Blog Content:" + dr["BlogContent"]);

                Console.WriteLine("...............");
            }
        }
        public void Edit(int id)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            Console.WriteLine();
            string query = "select * from tbl_blog where BlogId=@BlogId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            Console.WriteLine("close");

            if (dt.Rows
                .Count < 0)
            {
                Console.WriteLine("No Data Found");
            }
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("BlogId:" + dr["BlogId"]);
                Console.WriteLine("Blog Title:" + dr["BlogTitle"]);
                Console.WriteLine("Blog Author:" + dr["BlogAuthor"]);
                Console.WriteLine("Blog Content:" + dr["BlogContent"]);

                Console.WriteLine("...............");
            }
        }

        public void Create(string title, string author, string content)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            Console.WriteLine("Connection open");
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

            int result = command.ExecuteNonQuery();
            connection.Close();

            string message = result > 0 ? "Saving successfully" : "Saving Fail";
            Console.WriteLine(message);

        }

        public void Update(int id, string title, string author, string content)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string query = @"UPDATE [dbo].[tbl_blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId=@BlogId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BlogId", id);
            command.Parameters.AddWithValue("@BlogTitle", title);
            command.Parameters.AddWithValue("@BlogAuthor", author);
            command.Parameters.AddWithValue("@BlogContent", content);
            int result = command.ExecuteNonQuery();
            connection.Close();

            string message = result > 0 ? "Update successfully" : "update fail";
        }
        public void Delete(int id)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string query = @"DELETE FROM [dbo].[tbl_blog]
      WHERE BlogId=@BlogId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BlogId", id);


            int result = command.ExecuteNonQuery();
            connection.Close();

            string message = result > 0 ? "Delete Successfully." : "Delete Failed";
            Console.WriteLine(message);
        }
    }

   
}
