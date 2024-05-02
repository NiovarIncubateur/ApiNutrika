namespace AppNutrika.Models.Entities
{
    public class Materiels
    {
        public int id { get; set; }
        public string title { get; set; }
        public int stock { get; set; }
        public int qteUtilise { get; set; }
        public int qteReste { get; set; }
        public int archived { get; set; }
        public DateTime createdAt { get; set; }
    }
}
