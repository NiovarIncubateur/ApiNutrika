namespace AppNutrika.Models.Entities
{
    public class Observation
    {
        public int id { get; set; }
        public string observation { get; set; }
        public int productionid { get; set; }
        public Production production { get; set; }
        public int archived { get; set; }
        public DateTime createdAt { get; set; }
    }
}
