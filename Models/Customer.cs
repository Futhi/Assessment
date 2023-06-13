using System.ComponentModel.DataAnnotations;

namespace Projects.Models
{
    public class Customer
    {
        [Key]
        public Guid id { get; set; } 
        public string name { get; set; }    
        public string surname { get; set; } 
        public string age { get; set; }

     //   public Project project { get; set; }
    }
}
