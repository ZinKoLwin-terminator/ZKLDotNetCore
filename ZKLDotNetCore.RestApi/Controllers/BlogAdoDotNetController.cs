using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

using System.Data;
using System.Data.SqlClient;
using ZKLDotNetCore.RestApi.Models;

namespace ZKLDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNetController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from tbl_blog";
            SqlConnection connection = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString); 
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            connection.Close();

            List<BlogModel> lst = dt.AsEnumerable().Select(dr => new BlogModel
            {
                BlogId = Convert.ToInt32(dr["BlogId"]),
                BlogTitle = Convert.ToString(dr["BlogTitle"]),
                BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
                BlogContent = Convert.ToString(dr["BlogContent"])
            }).ToList();

            return Ok(lst);


        
    }
        [HttpGet("{id}")]

        public IActionResult GetBlog(int id)
        {
            string query = "select * from tbl_blog where BlogId=@BlogId";
            SqlConnection connection = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            connection.Close ();

            if (dt.Rows.Count == 0)
            {
                return NotFound("No Data Found");
            }

            DataRow dr = dt.Rows[0];
            var item = new BlogModel
            {
                BlogId = Convert.ToInt32(dr["BlogId"]),
                BlogTitle = Convert.ToString(dr["BlogTitle"]),
                BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
                BlogContent = Convert.ToString(dr["BlogContent"]),
            };

            return Ok(item);

        }
        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            SqlConnection connection = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string query = @"
INSERT INTO [dbo].[tbl_blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle,@BlogAuthor,@BlogContent)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BlogTitle",blog.BlogTitle);
            command.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            command.Parameters.AddWithValue("@BlogContent", blog.BlogContent);

            int result = command.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "Saving Successfully" : "Saving Failed";
            return Ok(message);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id,BlogModel blog)
        {
            SqlConnection connection = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string query = @"UPDATE [dbo].[tbl_blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId=@BlogId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BlogId", blog.BlogId);
            command.Parameters.AddWithValue("@BlogTitle", blog.BlogAuthor);
            command.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            command.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            int result = command.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "Update successfully" : "UpdateFailed";
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id,BlogModel blog)
        {
            return Ok("Patch");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            SqlConnection connection = new SqlConnection(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            string query = @"DELETE FROM [dbo].[tbl_blog]
      WHERE BlogId=@BlogId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BlogId", id);


            int result = command.ExecuteNonQuery();
            connection.Close();

            string message = result > 0 ? "Delete Successfully." : "Delete Failed";
            return Ok(message);
        }
    }
}
