namespace AppNutrika.Models.Entities
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }  
        public string profile { get; set;  }
        public string password { get; set; }
        public string phone { get; set; }
        public int roleOfUserid { get; set; }
        public RoleOfUser roleOfUser { get; set; }
        public int status { get; set; }
        public int etat { get; set; }
        public DateTime createdAt { get; set; }
        public int archived { get; set; }
    }
}
