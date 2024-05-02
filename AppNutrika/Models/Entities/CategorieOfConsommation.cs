namespace AppNutrika.Models.Entities
{
    public class CategorieOfConsommation
    {
        public int id { get; set; }
        public string libelle { get; set; }
        public string description { get; set; }
        public DateTime createdAt { get; set; }
        public int archived { get; set; }
    }
}
