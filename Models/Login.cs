using System.ComponentModel.DataAnnotations;

namespace Projects.Models
{
    public class Login
    {
        [Key]
        public Guid id { get; set; }
        public int username { get; set; }
        public int password { get; set; }
    }
}
