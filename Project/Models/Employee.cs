using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }

        [ForeignKey("department")]
        public int DeptId { get; set; }
        public Department department { get; set; }




    }
}
