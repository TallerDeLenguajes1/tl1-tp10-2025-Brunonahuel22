using ClaseTarea;
using System.Text.Json;
using System.IO;
using System.Globalization;

string url = "https://jsonplaceholder.typicode.com/todos/";

HttpClient client = new HttpClient();

HttpResponseMessage respuesta = await client.GetAsync(url);

respuesta.EnsureSuccessStatusCode();

string resonseBody = await respuesta.Content.ReadAsStringAsync();

List<Tarea> listaTareas = JsonSerializer.Deserialize<List<Tarea>>(resonseBody);



Console.WriteLine("\t TAREAS PENDIENTES");
foreach (var tarea in listaTareas)
{
    if (tarea.completed == false)
    {
        Console.WriteLine($"Titulo: {tarea.title} Estado: {tarea.completed}");
    }

}


Console.WriteLine("\t TAREAS COMPLETADAS");
foreach (var tarea in listaTareas)
{
    if (tarea.completed == true)
    {
        Console.WriteLine($"Titulo: {tarea.title} Estado: {tarea.completed}");
    }

}

string json = JsonSerializer.Serialize(listaTareas);

string directorio = @"c:\Users\PC\Desktop\tl1-tp10-2025-Brunonahuel22\tareas.json";

File.WriteAllText(directorio, json);
if (File.Exists(directorio))
{
    Console.WriteLine("Archivo Creado");
}