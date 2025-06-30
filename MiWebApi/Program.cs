using System.Xml.Serialization;
using System.IO;
using ClaseDolar;
using System.Text.Json;


string link = "https://dolarapi.com/v1/dolares";


HttpClient client = new HttpClient();

HttpResponseMessage message = await client.GetAsync(link);


message.EnsureSuccessStatusCode();

string textoJson = await message.Content.ReadAsStringAsync();



List<Dolar> listaObjetosDolar = JsonSerializer.Deserialize<List<Dolar>>(textoJson);

List<string> nuevaLista = new List<string>();

foreach (var dato in listaObjetosDolar)
{
    Console.WriteLine($"moneda : {dato.moneda} casa : {dato.casa} compra : {dato.compra} venta : {dato.venta} fechaActualizacion : {dato.fechaActualizacion}");
    nuevaLista.Add($"moneda : {dato.moneda} casa : {dato.casa} compra : {dato.compra} venta : {dato.venta} fechaActualizacion : {dato.fechaActualizacion}");
}

string direccion = @"c:\Users\Estudiante\Desktop\tl1-tp10-2025-Brunonahuel22\MiWebApi\informe.json";

File.WriteAllLines(direccion, nuevaLista);

if (File.Exists(direccion))
{
    Console.WriteLine("Arhivo creado");
}