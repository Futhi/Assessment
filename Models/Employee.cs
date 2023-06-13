using System.ComponentModel.DataAnnotations;

namespace Projects.Models
{
    public class Employee
    {
        [Key]
        public Guid id { get; set; }
        public string name { get; set; }
        public string surname { get; set;}
    }
}
