using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projects.Models
{
    public class Project
    {
        [Key]
        public Guid id { get; set; }
        public string name { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        //linking Project to customer table to crete a foreign key
        public Guid customerId { get; set; }
        [ForeignKey("customerId")]        
        public virtual Customer customer { get; set; }
    }
}
