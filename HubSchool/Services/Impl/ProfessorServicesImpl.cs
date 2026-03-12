using HubSchool.Data.Converter.Impl;
using HubSchool.Data.Dto;
using HubSchool.Model;
using HubSchool.Repositories;

namespace HubSchool.Services.Impl
{
    public class ProfessorServicesImpl : IProfessorServices
    {
        private IAuteticadorRepository<Professor> _repository;
        private readonly ProfessorConverter _converter;

        public ProfessorServicesImpl(IAuteticadorRepository<Professor> repository)
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

        public ProfessorDTO Update(ProfessorDTO professorDTO)
        {
            var entity = _converter.Parse(professorDTO);            
            PreservaFotoExistente(entity);
            entity = _repository.Update(entity);
            return _converter.Parse(entity);
        }

        public void Delete(long id) => _repository.Delete(id);

        public ProfessorDTO Login(string login, string senha) => _converter.Parse(_repository.Login(login, senha));

        public void AtualizarFoto(long id, string url) => _repository.AtualizarFoto(id, url);

        public void PreservaFotoExistente(Professor professor)
        {
            if (professor.Foto == null)
            {
                var existing = _repository.FindById(professor.Id);
                if (existing?.Foto != null)
                    professor.Foto = existing.Foto;
            }
        }
       
    }
}
