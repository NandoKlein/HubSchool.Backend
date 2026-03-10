
using HubSchool.Model;
using HubSchool.Model.Context;
using System.Data;

namespace HubSchool.Repositories.Impl
{
    public class TurmaAlunosRepository : ITurmaAlunosRepository
    {
        private readonly MSSQLContext _context;

        public TurmaAlunosRepository(MSSQLContext context)
        {
            _context = context;
        }

        public void AdicionaAlunos(long idTurma, List<long> idAlunos)
        {
            foreach (var idAluno in idAlunos)
            {
                _context.TurmaAlunos.Add( new TurmaAlunos
                {
                    IdTurma = idTurma,
                    IdAluno = idAluno
                });                
            }
            _context.SaveChanges();
        }

        public void DeletaAlunosPorIdDaTurma(long idTurma)
        {
            var alunosDaTurma = _context.TurmaAlunos.Where(aluno => aluno.IdTurma == idTurma);
            if (!alunosDaTurma.Any()) return;
            _context.RemoveRange(alunosDaTurma);
            _context.SaveChanges();
        }
        public void AtualizaAlunos(long idTurma, List<long> idAlunos)
        {
            DeletaAlunosPorIdDaTurma(idTurma);
            AdicionaAlunos(idTurma, idAlunos);
        }

        public List<long> BuscaAlunosPorTurma(long idTurma)
        {
            var alunosDaTurma = _context.TurmaAlunos.Where(aluno => aluno.IdTurma == idTurma);
            return alunosDaTurma.Select(a => a.IdAluno).ToList();
        }
    }
}
