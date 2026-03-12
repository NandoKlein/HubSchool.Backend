using HubSchool.Data.Converter.Impl;
using HubSchool.Data.Dto;
using HubSchool.Model;
using HubSchool.Repositories;

namespace HubSchool.Services.Impl
{
    public class AtendenteServicesImpl : IAtendenteServices
    {
        private readonly IAuteticadorRepository<Atendente> _repository;
        private readonly AtendenteConverter _converter;

        public AtendenteServicesImpl(IAuteticadorRepository<Atendente> repository)
        {
            _repository = repository;
            _converter = new AtendenteConverter();
        }

        public List<AtendenteDTO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public AtendenteDTO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public int Count()
        {
            return _repository.Count();
        }

        public AtendenteDTO Create(AtendenteDTO atendenteDto)
        {
            var atendente = _converter.Parse(atendenteDto);
            atendente = _repository.Create(atendente);
            return _converter.Parse(atendente);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public AtendenteDTO Update(AtendenteDTO atendenteDto)
        {
            var atendente = _converter.Parse(atendenteDto);
            atendente = _repository.Update(atendente);
            return _converter.Parse(atendente);
        }

        public AtendenteDTO Login(string login, string senha)
        {
            return _converter.Parse(_repository.Login(login, senha));
        }
        
        public void AtualizarFoto(long id, string url)
        {
            _repository.AtualizarFoto(id, url);
        }

        public void PreservaFotoExistente(Atendente atendente)
        {
            if (atendente.Foto == null)
            {
                var existing = _repository.FindById(atendente.Id);
                if (existing?.Foto != null)
                    atendente.Foto = existing.Foto;
            }
        }
    }
}
