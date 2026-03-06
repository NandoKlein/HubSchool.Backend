using HubSchool.Data.Converter.Impl;
using HubSchool.Data.Dto;
using HubSchool.Model;
using HubSchool.Repositories;



namespace HubSchool.Services.Impl
{
    public class AlunoServicesImpl : IAlunoServices
    {

        private IRepository<Aluno> _repository;
        private readonly AlunoConverter _converter;

        public AlunoServicesImpl(IRepository<Aluno> repository)
        {
            _repository = repository;
            _converter = new AlunoConverter();
        }
        public List<AlunoDTO> FindAll() => _converter.ParseList(_repository.FindAll());

        public int Count() => _repository.Count();

        public AlunoDTO FindById(long id) => _converter.Parse(_repository.FindById(id));

        public AlunoDTO Create(AlunoDTO aluno)
        {
            var entity = _converter.Parse(aluno);
            entity.Login = entity.Email;
            entity = _repository.Create(entity);
            return _converter.Parse(entity);
        }

        public AlunoDTO Update(AlunoDTO aluno)
        {
            var entity = _converter.Parse(aluno);
            entity = _repository.Update(entity);
            return _converter.Parse(entity);
        }

        public void Delete(long id) => _repository.Delete(id);

        public bool Login(string login, string senha) => _repository.Login(login, senha);
    }
}
