using System.Net.Http;


string url = "https://jsonplaceholder.typicode.com/users";
HttpClient client = new HttpClient();

HttpResponseMessage respuesta = await client.GetAsync(url);

string cuerpoBody = await respuesta.Content.ReadAsStringAsync();

Console.WriteLine(cuerpoBody);

