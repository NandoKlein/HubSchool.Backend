using HubSchool.Data.Converter.Impl;
using HubSchool.Data.Dto;
using HubSchool.Model;
using HubSchool.Repositories;
using System;

namespace HubSchool.Services.Impl
{
    public class TurmaServicesImpl : ITurmaServices
    {
        private ITurmaAlunosRepository _repositoryTurmaAlunos;
        private IRepository<Turma> _repository;
        private readonly TurmaConverter _turmaConverter;

        public TurmaServicesImpl(IRepository<Turma> repository, ITurmaAlunosRepository repositoryTurmaAlunos)
        {
            _repository = repository;
            _turmaConverter = new TurmaConverter();
            _repositoryTurmaAlunos = repositoryTurmaAlunos;
        }

        public List<TurmaDTO> FindAll()
        {
            var turmas = _repository.FindAll();
            foreach (var turma in turmas)
            {
                turma.IdAlunos = _repositoryTurmaAlunos.BuscaAlunosPorTurma(turma.Id);
            }
            return _turmaConverter.ParseList(turmas);
        }

        public int Count() => _repository.Count();

        public TurmaDTO FindById(long id)
        {
            var turma = _repository.FindById(id);
            if (turma == null) return null;
            turma.IdAlunos = _repositoryTurmaAlunos.BuscaAlunosPorTurma(id);
            return _turmaConverter.Parse(turma);
        }

        public TurmaDTO Create(TurmaDTO turma)
        {
            var entity = _turmaConverter.Parse(turma);
            entity = _repository.Create(entity);
            if (entity.IdAlunos != null && entity.IdAlunos.Any())
                _repositoryTurmaAlunos.AdicionaAlunos(entity.Id, entity.IdAlunos);
            return _turmaConverter.Parse(entity);
        }

        public TurmaDTO Update(TurmaDTO aluno)
        {
            var entity = _turmaConverter.Parse(aluno);
            entity = _repository.Update(entity);
            if (entity.IdAlunos != null && entity.IdAlunos.Any())
                _repositoryTurmaAlunos.AtualizaAlunos(entity.Id, entity.IdAlunos);
            return _turmaConverter.Parse(entity);
        }

        public void Delete(long id)
        {
            _repositoryTurmaAlunos.DeletaAlunosPorIdDaTurma(id);
            _repository.Delete(id);
        }
    }
}
