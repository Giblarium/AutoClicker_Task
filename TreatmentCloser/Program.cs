using System;
using System.Net;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

Console.WriteLine("Hello, World!");

string server = "https://push.1c-connect.com";
string query = "/v1/line/treatment/";

string login = "Edrobisheva";
string password = "miv49861";

HttpClient httpClient = new HttpClient();
HttpContent httpContent = new StringContent("");
httpContent.Headers.Add("authorization", $"{login} {password}");


try
{
    WebResponse response = getWeb.GetResponse();
    Stream stream = response.GetResponseStream();
    StreamReader sr = new StreamReader(stream);
    string s = sr.ReadToEnd();
    Console.WriteLine(s);
}
catch (Exception e )
{
    Console.WriteLine(e.Message);
}
