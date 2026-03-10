using HubSchool.Data.Converter.Impl;
using HubSchool.Data.Dto;
using HubSchool.Model;
using HubSchool.Repositories;

namespace HubSchool.Services.Impl
{
    public class HomeworkServicesImpl : IHomeworkServices
    {
        private readonly HomeworkConverter _converter;
        private IHomeworkRepository _repository;

        public HomeworkServicesImpl(IHomeworkRepository repository)
        {
            _converter = new HomeworkConverter();
            _repository = repository;
        }

        public HomeworkDTO Atualizar(HomeworkDTO homeworkDTO)
        {
            var homework = _converter.Parse(homeworkDTO);
            return _converter.Parse(_repository.Atualizar(homework));
        }
        public void Delete(long idAula, long idAluno) => _repository.Delete(idAula, idAluno);

        public List<HomeworkDTO> BuscaHomeworksPorAluno(long idAluno, int status)
        {
            var homeworks = new List<HomeworkDTO>();
            homeworks = _converter.ParseList(_repository.BuscaHomeworksPorAluno(idAluno, status));
            return homeworks;
        }

        public List<HomeworkDTO> BuscaHomeworksPorProfessor(long idProfessor)
        {
            var homeworks = new List<HomeworkDTO>();
            homeworks = _converter.ParseList(_repository.BuscaHomeworksPorProfessor(idProfessor));
            return homeworks;
        }

        public HomeworkDTO BuscaHomeworkPorAulaEAluno(long idAula, long idAluno)
        {
            return _converter.Parse(_repository.BuscaHomeworkPorAulaEAluno(idAula, idAluno));         
        }

        public void Create(Aula aula)
        {
            _repository.Create(aula);
        }      
    }
}
