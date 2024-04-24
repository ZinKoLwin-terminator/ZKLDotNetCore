using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;

namespace ZKLDotNetCore.ConsoleApp
{
    internal class DapperExample
    {
        public void Run()
        {

            // Edit(1);
            //Edit(40);
            //Update(25,"update1 title", "update1 author", "update1 content");
            Delete(25);
            Read();


        }

        private void Read()
        {
            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            List<BlogDto> list = db.Query<BlogDto>("select * from tbl_blog").ToList();

            foreach (BlogDto blog in list)
            {
                Console.WriteLine(blog.BlogId);
                Console.WriteLine(blog.BlogTitle);
                Console.WriteLine(blog.BlogAuthor);
                Console.WriteLine(blog.BlogContent);
                Console.WriteLine("------------------------");
            }
        }
        private void Edit(int id)
        {
            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
          var item =  db.Query<BlogDto>("select * from tbl_blog where blogId = @blogId",new BlogDto { BlogId=id}).FirstOrDefault();
            if (item is null)
            {
                Console.WriteLine("NO data found");
                return;
                
            }
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);


        }
        private void Create(string title,string author,string content)
        {
            var item = new BlogDto
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };

            string query = @"INSERT INTO [dbo].[tbl_blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle,
		   @BlogAuthor,
		   @BlogContent)";

            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);

            int result = db.Execute(query, item);

            string message = result > 0 ? "Saving successfully" : "Saving Fail";
            Console.WriteLine(message);


        }

        private void Update(int id,string title, string author, string content)
        {
            var item = new BlogDto
            {   BlogId= id, 
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };

            string query = @"UPDATE [dbo].[tbl_blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId=@BlogId";

            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);

            int result = db.Execute(query, item);

            string message = result > 0 ? "Update successfully" : "Update Fail";
            Console.WriteLine(message);


        }
        private void Delete(int id)
        {
            var item=new BlogDto { BlogId= id };

            string query = @"DELETE FROM [dbo].[tbl_blog]
      WHERE BlogId=@BlogId";

            using IDbConnection db = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);

            int result = db.Execute(query, item);


            string message = result > 0 ? "Delete successfully" : "Delete Fail";
            Console.WriteLine(message);

        }
    }
}
