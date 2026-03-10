using HubSchool.Data.Converter.Impl;
using HubSchool.Data.Dto;
using HubSchool.Model;
using HubSchool.Repositories;



namespace HubSchool.Services.Impl
{
    public class AlunoServicesImpl : IAlunoServices
    {

        private IAuteticadorRepository<Aluno> _repository;
        private readonly AlunoConverter _converter;

        public AlunoServicesImpl(IAuteticadorRepository<Aluno> repository)
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
            PreservaFotoExistente(entity);
            entity = _repository.Update(entity);
            return _converter.Parse(entity);
        }

        public void Delete(long id) => _repository.Delete(id);

        public AlunoDTO Login(string login, string senha) => _converter.Parse(_repository.Login(login, senha));

        public void AtualizarFoto(long id, string url) => _repository.AtualizarFoto(id, url);

        public void PreservaFotoExistente(Aluno entity)
        {
            if (entity.Foto == null)
            {
                var existing = _repository.FindById(entity.Id);
                if (existing?.Foto != null)
                    entity.Foto = existing.Foto;
            }
        }


    }
}
