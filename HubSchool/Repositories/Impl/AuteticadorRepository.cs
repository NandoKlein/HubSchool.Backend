using HubSchool.Model.Base;
using HubSchool.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace HubSchool.Repositories.Impl
{
    public class AuteticadorRepository<T> : IAuteticadorRepository<T> where T : AuthEntity
    {
        private MSSQLContext _context;
        private DbSet<T> _dataset;

        public AuteticadorRepository(MSSQLContext context)
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
        public bool Exists(long id) => _dataset.Any(item => item.Id == id);

        public void AtualizarFoto(long id, string url)
        {
            var existingItem = _dataset.Find(id);
            if (existingItem == null) return;
            _context.Entry(existingItem).Property("Foto").CurrentValue = url;
            _context.SaveChanges();
        }

        public T Login(string login, string senha)
        {
            var existingItem = _dataset.FirstOrDefault(cadastro => cadastro.Login == login);
            if (existingItem == null) return null;
            if (existingItem.Senha != senha) return null;
            return existingItem;
        }
    }
}
