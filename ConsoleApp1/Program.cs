using System.Text.Json;
using System.Text;

HttpClient httpClient = new() { 
    BaseAddress = new Uri("http://1c.giblarium.ru/")
};
using StringContent jsonContent = new StringContent("");

using HttpResponseMessage response = await httpClient.PostAsync(
    "Account/Update/123/2/",
    jsonContent);
int i = 0;