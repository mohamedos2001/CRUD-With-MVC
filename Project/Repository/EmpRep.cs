using Project.Models;

namespace Project.Repository
{
    public class EmpRep
    {
        AppDbContext context = new AppDbContext();

        public List<Employee> GetAll() { 
        
            return context.Employees.ToList();
        
        }
        public Employee GetById(int id) {

            return context.Employees.FirstOrDefault(e=>e.Id==id);
        }
        public void Insert(Employee employee) {
        
            context.Employees.Add(employee);
            context.SaveChanges();
        }

        public void Update(int id,Employee employee) {
            
            Employee employee1 = GetById(id);

            employee1.Name = employee.Name;
            employee1.Address = employee.Address;
            employee1.Age = employee.Age;
            employee1.Salary = employee.Salary;
            employee1.DeptId = employee.DeptId;
            context.SaveChanges();
        
        }

        public void Delete(int id) { 
        
            Employee employee = GetById(id);

            context.Employees.Remove(employee);
            context.SaveChanges();
        }
    }
}
