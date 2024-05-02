namespace AppNutrika.Dto
{
    public class RoleOfUserDto
    {
        public class AddRoleOfUserDto
        {
            public string libelle { get; set; }
            public string description { get; set; }
        }

        public class UpdateRoleOfUserDto
        {
            public int id { get; set; }
            public string libelle { get; set; }
            public string description { get; set; }
        }
    }
}
