using Microsoft.EntityFrameworkCore;
namespace SETEC.Data.Entities
{
    public class User
    {
        public int id { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
		public string email { get; set; }
		public string empresa { get; set; }
        public string rol { get; set; }
        public DateTime fecha { get; set; }
    }
}