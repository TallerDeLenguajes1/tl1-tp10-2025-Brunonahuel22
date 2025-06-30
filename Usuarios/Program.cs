using System.Net.Http;
using System.Text.Json;
using System.IO;
using ClaseUsuario;


string url = "https://jsonplaceholder.typicode.com/users";

HttpClient client = new HttpClient();

HttpResponseMessage respuesta = await client.GetAsync(url);
respuesta.EnsureSuccessStatusCode();



string cuerpoBody = await respuesta.Content.ReadAsStringAsync();


List<Root> listaUsuarios = JsonSerializer.Deserialize<List<Root>>(cuerpoBody);
List<string> cincoUsuarios =new List<string>();
int i = 0;
foreach (var usuario in listaUsuarios)
{

    if (i < 5)
    {
        Console.WriteLine($"Usuario:{usuario.name} Email:{usuario.email} Direccion:{usuario.address.suite}");
        Console.WriteLine();
        cincoUsuarios.Add($"Usuario:{usuario.name} Email:{usuario.email} Direccion:{usuario.address.suite}");
        i++;
    }

}

string directorio = @"c:\Users\Estudiante\Desktop\tl1-tp10-2025-Brunonahuel22\Usuarios\informeJson.json";

File.WriteAllLines(directorio, cincoUsuarios);

if (File.Exists(directorio))
{
    Console.Write("Usuario Guardados");
}






