using HubSchool.Data.Converter.Impl;
using HubSchool.Data.Dto;
using HubSchool.Model;
using HubSchool.Repositories;

namespace HubSchool.Services.Impl
{
    public class ProfessorServicesImpl : IProfessorServices
    {
        private IRepository<Professor> _repository;
        private readonly ProfessorConverter _converter;

        public ProfessorServicesImpl(IRepository<Professor> repository)
        {
            _repository = repository;
            _converter  = new ProfessorConverter();
        }

        public List<ProfessorDTO> FindAll() => _converter.ParseList(_repository.FindAll());

        public int Count() => _repository.Count();

        public ProfessorDTO FindById(long id) => _converter.Parse(_repository.FindById(id));

        public ProfessorDTO Create(ProfessorDTO professor)
        {
            var entity = _converter.Parse(professor);
            entity.Login = entity.Email;
            entity.DataDaContratacao = DateTime.Now;
            entity = _repository.Create(entity);
            return _converter.Parse(entity);
        }

        public ProfessorDTO Update(ProfessorDTO professor)
        {
            var entity = _converter.Parse(professor);
            entity = _repository.Update(entity);
            return _converter.Parse(entity);
        }

        public void Delete(long id) => _repository.Delete(id);

        public bool Login(string login, string senha) => _repository.Login(login, senha);
    }
}
