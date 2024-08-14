using Project.Models;

namespace Project.Repository
{
    public class ProRep
    {
        AppDbContext context = new AppDbContext();

        public List<Product> GetAll()
        {

            return context.Products.ToList();

        }
        public Product GetById(int id)
        {

            return context.Products.FirstOrDefault(e => e.Id == id);
        }
        public void Insert(Product pro)
        {

            context.Products.Add(pro);
            context.SaveChanges();
        }

        public void Update(int id, Product pro)
        {

            Product pro1= GetById(id);

            pro1.Name = pro.Name;
            pro1.Price = pro.Price;    
            pro1.Description = pro.Description;
     
            context.SaveChanges();

        }

        public void Delete(int id)
        {

            Product pro = GetById(id);

            context.Products.Remove(pro);
            context.SaveChanges();
        }
    }
}
