using HubSchool.Model.Base;

namespace HubSchool.Repositories
{
    public interface IAuteticadorRepository<T> : IRepository<T> where T : AuthEntity
    {     
        T Login(string login, string senha);
    }
}
