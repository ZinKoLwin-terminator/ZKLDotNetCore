

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



AdoDotNetExamples adoDotNetExamples = new AdoDotNetExamples();

//adoDotNetExamples.Create("title", "author", "content");
//adoDotNetExamples.Update(22, "test title", "test author", "test content");
//adoDotNetExamples.Delete(21);

//adoDotNetExamples.Read();
adoDotNetExamples.Edit(10);

Console.ReadLine();