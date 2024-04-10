

using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello,World");
//npm
//pub.dev
//nuget
//SqlConnection

//C
//F10
//F11



SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
stringBuilder.DataSource = "DESKTOP-6HBOPOG";
stringBuilder.InitialCatalog = "ZKLDotNetCore";
stringBuilder.UserID = "sa";
stringBuilder.Password = "sasa@123";
SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);
connection.Open();
Console.WriteLine("open");

string query = "select * from tbl_blog";
SqlCommand cmd = new SqlCommand(query, connection);
SqlDataAdapter adapter = new SqlDataAdapter(cmd);
DataTable dt=new DataTable();
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

Console.ReadKey();