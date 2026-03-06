using HubSchool.Model.Base;
using HubSchool.Model.Context;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HubSchool.Repositories.Impl
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MSSQLContext _context;
        private DbSet<T> _dataset;

        public GenericRepository(MSSQLContext context)
        {
            _context = context;
            _dataset = context.Set<T>();
        }

        public List<T> FindAll() => _dataset.ToList();

        public int Count() => _dataset.Count();

        public T FindById(long id) => _dataset.Find(id);

        public T Create(T item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }

        public T Update(T item)
        {
            var existingItem = _dataset.Find(item.Id);
            if (existingItem == null) return null;

            _context.Entry(existingItem).CurrentValues.SetValues(item);
            _context.SaveChanges();
            return item;
        }

        public void Delete(long id)
        {
            var existingItem = _dataset.Find(id);
            if (existingItem == null) return;
            _context.Remove(existingItem);
            _context.SaveChanges();

        }

        public bool Login(string login, string senha)
        {
            var existingItem = _dataset.FirstOrDefault(cadastro => cadastro.Login == login);
            if (existingItem == null) return false;
            if (existingItem.Senha != senha) return false;
            return true;
        }

        public bool Exists(long id) => _dataset.Any(item => item.Id == id);
    }
}
