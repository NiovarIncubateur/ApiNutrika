namespace AppNutrika.Models.Entities
{
    public class Consommation
    {
        public int id { get; set; }
        public int qteServie { get; set; }
        public int qteUtilise { get; set; }
        public int qteRestant { get; set; }
        public int categorieOfConsommationid { get; set; }
        public CategorieOfConsommation categorieOfConsommation { get; set; }
        public int productionid { get; set; }
        public Production production { get; set; }
        public int archived { get; set; }
        public DateTime createdAt { get; set; }
    }
}
