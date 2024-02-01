using Microsoft.AspNetCore.Identity;

namespace SETEC.Data.Entities
{
    public class Users: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }


    }
}
