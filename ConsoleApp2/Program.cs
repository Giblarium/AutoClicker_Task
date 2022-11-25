using System.Text.Json;
using System.Text;
using ConsoleApp2;
while (true)
{
HttpClient httpClient = new()
{
    BaseAddress = new Uri("http://1c.giblarium.ru/")
};
using StringContent jsonContentGet = new StringContent("");

using HttpResponseMessage responseGet = await httpClient.GetAsync("Account/Get/");

responseGet.EnsureSuccessStatusCode().WriteRequestToConsole();

var jsonResponse = await responseGet.Content.ReadAsStringAsync();
	if (jsonResponse is null || jsonResponse == "")
	{
		break;
	}
Console.WriteLine($"{jsonResponse}\n");
}



//using StringContent jsonContentPost = new("");

//using HttpResponseMessage responsePost = await httpClient.PostAsync(
//    "/Account/Update/123/4/",
//    jsonContentPost);

//responsePost.EnsureSuccessStatusCode().WriteRequestToConsole();

//var jsonResponsePost = await responsePost.Content.ReadAsStringAsync();
//Console.WriteLine($"{jsonResponsePost}\n");


int i = 0;

