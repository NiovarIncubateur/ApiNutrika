namespace AppNutrika.Models.Entities
{
    public class RoleOfUser
    {
        public int id { get; set; }
        public string libelle { get; set; }
        public string description { get; set; }
        public DateTime creatAt { get; set; }
        public int archived { get; set; }
    }
}
