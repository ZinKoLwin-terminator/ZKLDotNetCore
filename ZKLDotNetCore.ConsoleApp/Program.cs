

using System.Data;
using System.Data.SqlClient;
using ZKLDotNetCore.ConsoleApp;

Console.WriteLine("Hello,World");
//npm
//pub.dev
//nuget
//SqlConnection

//C
//F10
//F11



//AdoDotNetExamples adoDotNetExamples = new AdoDotNetExamples();

//adoDotNetExamples.Create("title", "author", "content");
//adoDotNetExamples.Update(1, "test title1", "test author1", "test content1");
//adoDotNetExamples.Delete(24);

//adoDotNetExamples.Read();
//adoDotNetExamples.Edit(1);

//adoDotNetExamples.Create("new title", "new author", "new content");
DapperExample dapper = new DapperExample();
dapper.Run();

Console.ReadLine();