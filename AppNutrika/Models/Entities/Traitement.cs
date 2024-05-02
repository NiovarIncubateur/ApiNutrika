namespace AppNutrika.Models.Entities
{
    public class Traitement
    {
        public int id { get; set; } 
        public string libelleTraitement { get; set; }
        public DateTime debut { get; set; }
        public DateTime fin { get; set; }
        public string description { get; set; }
        public int productionid { get; set; }
        public Production production { get; set; }
        public int archived { get; set; }
        public DateTime createdAt { get; set; }
    }
}
