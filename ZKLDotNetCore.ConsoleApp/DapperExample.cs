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
            Read();
            Edit(1);
            Edit(40);

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
    }
}
