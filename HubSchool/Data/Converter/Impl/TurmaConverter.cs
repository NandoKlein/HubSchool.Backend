using HubSchool.Data.Converter.Contract;
using HubSchool.Data.Dto;
using HubSchool.Model;

namespace HubSchool.Data.Converter.Impl
{
    public class TurmaConverter : IParser<TurmaDTO, Turma>, IParser<Turma, TurmaDTO>
    {
        public Turma Parse(TurmaDTO origin)
        {
            if (origin == null) return null;
            return new Turma
            {
                Id = origin.Id,
                Alunos = origin.Alunos,
                Professor = origin.Professor,

            };
        }

        public TurmaDTO Parse(Turma origin)
        {
            if (origin == null) return null;
            return new TurmaDTO
            {
                Id = origin.Id,
                Alunos = origin.Alunos,
                Professor = origin.Professor,

            };
        }

        public List<Turma> ParseList(List<TurmaDTO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<TurmaDTO> ParseList(List<Turma> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
