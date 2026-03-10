using HubSchool.Data.Converter.Impl;
using HubSchool.Data.Dto;
using HubSchool.Model;
using HubSchool.Model.Enums;
using HubSchool.Repositories;

namespace HubSchool.Services.Impl
{
    public class AulaServicesImpl : IAulaServices
    {
        private IFrequenciaRepository _frequenciaRepository;
        private ITurmaAlunosRepository _turmaAlunosRepository;
        private IHomeworkRepository _homeworkRepository;
        private IRepository<Aula> _aulaRepository;
        private  readonly AulaConverter _aulaConverter;

        public AulaServicesImpl(IRepository<Aula> repository, IFrequenciaRepository frequenciaRepository, ITurmaAlunosRepository turmaAlunosRepository, IHomeworkRepository homeWorkRepository)
        {
            _aulaRepository = repository;
            _aulaConverter = new AulaConverter();
            _frequenciaRepository = frequenciaRepository;
            _turmaAlunosRepository = turmaAlunosRepository;
            _homeworkRepository = homeWorkRepository;
        }

        public int Count() => _aulaRepository.Count();

        public AulaDTO Create(AulaDTO aulaDTO)
        {
            var aula = _aulaConverter.Parse(aulaDTO);
            aula = _aulaRepository.Create(aula);
            var idAlunos = _turmaAlunosRepository.BuscaAlunosPorTurma(aula.IdTurma);
            var frequencias = _frequenciaRepository.MontarFrequencias(idAlunos, aula.Id);
            frequencias =_frequenciaRepository.Create(frequencias);
            aula.Frequencias = frequencias;
            return _aulaConverter.Parse(aula);         
        }

        public void Delete(long id)
        {
            _frequenciaRepository.DeletaFrequenciaPorIdAula(id);
            _aulaRepository.Delete(id);
        }

        public List<AulaDTO> FindAll()
        {
            var aulas = _aulaRepository.FindAll();
            return _aulaConverter.ParseList(aulas);
        }

        public AulaDTO FindById(long id)
        {
            var aula = _aulaRepository.FindById(id);
            if (aula == null) return null;
            aula.Frequencias = _frequenciaRepository.BuscaFrequenciasPorIdAula(aula.Id);
            return _aulaConverter.Parse(aula);
        }

        public AulaDTO Update(AulaDTO aulaDTO)
        {
            var aula = _aulaConverter.Parse(aulaDTO);
            aula = _aulaRepository.Update(aula);          
            return _aulaConverter.Parse(aula);
        }

        public AulaDTO UpdateFrequencias(AulaDTO aulaDTO)
        {
            var aula = _aulaConverter.Parse(aulaDTO);
            aula = _aulaRepository.Update(aula);
            aula.Frequencias = _frequenciaRepository.AtualizaFrequencias(aula.Frequencias);
            if(aula.Status == StatusAula.Finalizado)            
                _homeworkRepository.Create(aula);
            
            return _aulaConverter.Parse(aula);

        }

    }
}
