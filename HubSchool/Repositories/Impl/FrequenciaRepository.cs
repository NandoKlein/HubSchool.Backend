using HubSchool.Model;
using HubSchool.Model.Context;
using HubSchool.Model.Enums;

namespace HubSchool.Repositories.Impl
{
    public class FrequenciaRepository : IFrequenciaRepository
    {
        private MSSQLContext _context;

        public FrequenciaRepository(MSSQLContext context)
        {
            _context = context;
        }

        public List<Frequencia> BuscaFrequenciasPorIdAula(long idAula) => _context.Frequencias.Where(a => a.IdAula == idAula).ToList();

        public List<Frequencia> AtualizaFrequencias(List <Frequencia> frequencias)
        {
            if (frequencias == null || !frequencias.Any()) return new List<Frequencia>();
            DeletaFrequenciaPorIdAula(frequencias[0].IdAula);
            return Create(frequencias);
        }

        public List<Frequencia> Create(List<Frequencia> frequencias)
        {
            _context.AddRange(frequencias);
            _context.SaveChanges();
            return frequencias;
        }

        public void DeletaFrequenciaPorIdAula(long idAula)
        {
            var frequencias = _context.Frequencias.Where(a => a.IdAula == idAula).ToList();
            if (!frequencias.Any()) return;
            _context.RemoveRange(frequencias);
            _context.SaveChanges();

        }

        public List<Frequencia> MontarFrequencias(List<long> idAlunos, long idAula)
        {
            var frenquencias = new List<Frequencia>();
            foreach (var idAluno in idAlunos)
            {
                frenquencias.Add(new Frequencia
                {
                    IdAluno = idAluno,
                    IdAula = idAula,
                    Presenca = Presenca.Ausente
                });
            }
            return frenquencias;
        }
    }
}
