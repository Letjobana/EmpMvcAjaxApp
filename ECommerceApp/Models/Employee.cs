namespace ECommerceApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int DesignationId { get; set; }
        public virtual Designation Designation { get; set; }
    }
}
