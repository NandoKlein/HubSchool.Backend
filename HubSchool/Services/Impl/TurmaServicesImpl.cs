using HubSchool.Data.Converter.Impl;
using HubSchool.Data.Dto;
using HubSchool.Model;
using HubSchool.Repositories;
using System;

namespace HubSchool.Services.Impl
{
    public class TurmaServicesImpl : ITurmaServices        
    {
        private IRepository<Turma> _repository; 
        private readonly TurmaConverter _turmaConverter;

        
        public TurmaServicesImpl(IRepository<Turma> repository)
        {
            _repository = repository;
            _turmaConverter = new TurmaConverter();       
        }

        public List<TurmaDTO> FindAll() => _turmaConverter.ParseList(_repository.FindAll());

        public int Count() => _repository.Count();

        public TurmaDTO FindById(long id) => _turmaConverter.Parse(_repository.FindById(id));

        public TurmaDTO Create(TurmaDTO turma)
        {
            var entity = _turmaConverter.Parse(turma);            
            entity = _repository.Create(entity);
            return _turmaConverter.Parse(entity);
        }

        public TurmaDTO Update(TurmaDTO aluno)
        {
            var entity = _turmaConverter.Parse(aluno);
            entity = _repository.Update(entity);
            return _turmaConverter.Parse(entity);
        }

        public void Delete(long id) => _repository.Delete(id);
    }
}
