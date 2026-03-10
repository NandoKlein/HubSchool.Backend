using HubSchool.Model.Base;

namespace HubSchool.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        List<T> FindAll();
        int Count();
        T FindById(long id);
        T Create(T item);
        T Update(T item);
        void Delete(long id);
        bool Exists(long id);
        void AtualizarFoto(long id, string url);
    }
}
