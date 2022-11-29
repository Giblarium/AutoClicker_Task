
HttpClient httpClient = new()
{
    BaseAddress = new Uri("http://1c.giblarium.ru/")
};
StringContent jsonContentGet = new StringContent("");
HttpResponseMessage responseGet = await httpClient.GetAsync("Account/Avalible");
System.Net.HttpStatusCode statusCode = responseGet.StatusCode;

int i = 0;

