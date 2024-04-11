

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

adoDotNetExamples.Create("title", "author", "content");

adoDotNetExamples.Read();

Console.ReadLine();