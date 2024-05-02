namespace AppNutrika.Dto
{
    public class UserDto
    {
    
            public string name { get; set; }
            public string email { get; set; }
             public IFormFile profile { get; set; }
            public string phone { get; set; }
            public int roleId { get; set; }
         
        
    }
    public class UpdateUserDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public IFormFile profile { get; set; }
        public string numeroCni { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string state { get; set; }

    }

    public class LoginDto
    {
       
        public string email { get; set; }
        public string password { get; set; }

    }
}
