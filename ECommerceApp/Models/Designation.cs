using System.Collections.Generic;

namespace ECommerceApp.Models
{
    public class Designation
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
