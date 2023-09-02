using Volunteering.Models;

namespace Volunteering.Repository.Base
{
    public interface IRepository<T> where T : class
    {
        T FindById(int id);
        IEnumerable<T> FindAll();
        IEnumerable<Opportunity> FindAllOpp();

        void AddOne(T opp);
        void EditOne(T opp);
        void DeleteOne(T opp);

    }
}
