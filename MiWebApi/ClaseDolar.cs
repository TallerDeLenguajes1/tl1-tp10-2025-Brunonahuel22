namespace ClaseDolar
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class Dolar
    {
        public string moneda { get; set; }
        public string casa { get; set; }
        public string nombre { get; set; }
        public double compra { get; set; }
        public double venta { get; set; }
        public DateTime fechaActualizacion { get; set; }
    }


}