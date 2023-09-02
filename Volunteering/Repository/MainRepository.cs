using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Volunteering.Data;
using Volunteering.Models;
using Volunteering.Repository.Base;

namespace Volunteering.Repository
{
    public class MainRepository<T> : IRepository<T> where T : class
    {
        public MainRepository(AppDbContext context)
        {
            this.context = context;
        }

        protected AppDbContext context;
        public T FindById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public IEnumerable<T> FindAll()
        {
            return context.Set<T>().ToList();
        }

        public IEnumerable<Opportunity> FindAllOpp()
        {
            return context.Opportunities.Include(s => s.Sector).ToList();
        }

        public void AddOne(T opp)
        {
            context.Set<T>().Add(opp);
            context.SaveChanges();
        }

        public void EditOne(T opp)
        {
            context.Set<T>().Update(opp);
            context.SaveChanges();
        }

        public void DeleteOne(T opp)
        {
            context.Set<T>().Remove(opp);
            context.SaveChanges();
        }
    }
}
