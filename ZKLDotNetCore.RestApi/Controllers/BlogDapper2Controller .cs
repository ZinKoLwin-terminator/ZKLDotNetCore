using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using ZKLDotNetCore.RestApi.Models;
using ZKLDotNetCore.Shared;

namespace ZKLDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogDapper2Controller : ControllerBase
    {
        private readonly DapperService _dapperService = new DapperService(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);

        [HttpGet]
        public IActionResult GetBlogs ()
        {
            string query = "select * from tbl_blog";
            var lst = _dapperService.Query<BlogModel>(query);
            return (Ok(lst));
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
           var item = FindById(id);
            if (item is null)
            {
                return NotFound("No DAta found");
            }
            return (Ok(item));
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            string query = @"INSERT INTO [dbo].[tbl_blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle,@BlogAuthor,@BlogContent)";

           int result = _dapperService.Execute(query, blog);
            string message = result > 0 ? "Saving Successful" : "Saving Failed";
            return (Ok(message));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id,BlogModel blog)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No data found");
            }
            blog.BlogId = id;
            string query = @"UPDATE [dbo].[tbl_blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId=@BlogId";
            int result = _dapperService.Execute(query, blog);
            string message = result > 0 ? "Update successful" : "Update Failed";
            return (Ok(message));
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id,BlogModel blog)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("Data Not Found");
            }
            string conditions = string.Empty;

            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                conditions += "[BlogTitle]=@BlogTitle, ";
            }

            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                conditions += "[BlogAuthor]=@BlogAuthor, ";
            }

            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                conditions += "[BlogContent]=@BlogContent, ";
            }

            if(conditions.Length == 0)
            {
                return NotFound("No data to update");
            }
            conditions=conditions.Substring(0,conditions.Length-2);

            blog.BlogId = id;

            string query = $@"UPDATE [dbo].[tbl_blog]
   SET  {conditions}
 WHERE BlogId=@BlogId";

            int result = _dapperService.Execute(query, blog);
            string message = result > 0 ? "Updating successfully" : "Updating Failed";
            return (Ok(message));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No data found");
            }
            string query = @"DELETE FROM [dbo].[tbl_blog]
      WHERE BlogId=@BlogId";
            int result = _dapperService.Execute(query, new BlogModel { BlogId=id});
            string message = result > 0 ? "Delete successfylly" : "Delete failed";
            return (Ok(message));
        }
        private BlogModel? FindById(int id)
        {
            string query = "select * from tbl_blog where BlogId=@BlogId";
           var item = _dapperService.QueryFirstOrDefault<BlogModel>(query,new BlogModel { BlogId=id});
            return item;
        }
    }
}
