namespace AppNutrika.Dto
{
    public class CategorieOfConsommationDto
    {
        public string libelle { get; set;  }
        public string description { get; set; }

    }
    public class CategoryUpdateDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}
