using HubSchool.Data.Converter.Contract;
using HubSchool.Data.Converter.Impl;
using HubSchool.Data.Dto;
using HubSchool.Model;
using HubSchool.Model.Context;
using HubSchool.Model.Enums;

namespace HubSchool.Repositories.Impl
{
    public class HomeworkRepository : IHomeworkRepository
    {
        private readonly MSSQLContext _context;
        

        public HomeworkRepository(MSSQLContext context)
        {
            _context = context;            
        }

        public void Create(Aula aula)
        {
            var homeWorks =  MontarHomeworks(aula);
            _context.AddRange(homeWorks);
            _context.SaveChanges();

        }

        public Homework Create(Homework homework)
        {            
            _context.Add(homework);
            _context.SaveChanges();
            return homework;
        }

        public List<Homework> MontarHomeworks(Aula aula)
        {
            var homeWorks = new List<Homework>();
            if (aula.Frequencias == null) return homeWorks;
            foreach (var item in aula.Frequencias)
            {
                homeWorks.Add(new Homework
                {
                    IdAluno = item.IdAluno,
                    IdAula = aula.Id,
                    IdProfessor = aula.IdProfessor,
                    StatusHomework = StatusHomework.PendenteParaAluno,
                    PrazoDeEntrega = DateTime.Now.AddDays(7)
                });
            }
            return homeWorks;
        }

        public List<Homework> BuscaHomeworksPorAluno(long idAluno, int status)
        {
            var homeworks = new List<Homework>();
            homeworks = _context.Homeworks.Where(a => a.IdAluno == idAluno && a.StatusHomework == (StatusHomework)status).ToList();
            return homeworks;
        }

        public List<Homework> BuscaHomeworksPorProfessor(long idProfessor)
        {
            var homeworks = new List<Homework>();
            homeworks = _context.Homeworks.Where(a => a.IdProfessor == idProfessor).ToList();
            return homeworks;
        }

        public Homework BuscaHomeworkPorAulaEAluno(long idAula, long idAluno)
        {                       
            return _context.Homeworks.FirstOrDefault(homework => homework.IdAula == idAula && homework.IdAluno == idAluno);            
        }

        public Homework Atualizar(Homework homework)
        {
            Delete(homework.IdAula, homework.IdAluno);
            return Create(homework);         
        }

        public void Delete(long idAula, long idAluno)
        {
            var homework = _context.Homeworks.FirstOrDefault(a => a.IdAula == idAula && a.IdAluno == idAluno);
            if (homework == null) return;
            _context.Remove(homework);
            _context.SaveChanges();
        }
    }
}
