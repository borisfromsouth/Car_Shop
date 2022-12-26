using Car_Shop.Domain.Enum;

namespace Car_Shop.Domain.Models
{
    public class User
    {
        public long Id { get; set; }

        public string Name { get; set; }  
        
        public string Password { get; set; }

        public Role Role { get; set; }
    }
}
