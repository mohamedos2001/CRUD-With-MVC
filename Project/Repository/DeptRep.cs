using Project.Models;

namespace Project.Repository
{
    public class DeptRep
    {
        AppDbContext context = new AppDbContext();

        public List<Department> GetAll()
        {

            return context.Departments.ToList();

        }
        public Department GetById(int id)
        {

            return context.Departments.FirstOrDefault(e => e.Id == id);
        }
        public void Insert(Department dept)
        {

            context.Departments.Add(dept);
            context.SaveChanges();
        }

        public void Update(int id, Department dept)
        {

            Department dept1 = GetById(id);

            dept1.Name = dept.Name;
            dept1.MangerName = dept.MangerName;
           
            context.SaveChanges();

        }

        public void Delete(int id)
        {

            Department dept = GetById(id);

            context.Departments.Remove(dept);
            context.SaveChanges();
        }
    }
}
