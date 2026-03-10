using HubSchool.Data.Converter.Contract;
using HubSchool.Data.Dto;
using HubSchool.Model;

namespace HubSchool.Data.Converter.Impl
{
    public class AulaConverter : IParser<AulaDTO, Aula>, IParser<Aula, AulaDTO>
    {
        public Aula Parse(AulaDTO origin)
        {
            if (origin == null) return null;
            return new Aula
            {
                Id = origin.Id,
                IdTurma = origin.IdTurma,
                IdProfessor = origin.IdProfessor,
                Capitulo = origin.Capitulo,
                DataDaAula = origin.DataDaAula,
                Resumo = origin.Resumo,
                Status = origin.Status,
                Frequencias = origin.Frequencias
            };
        }

        public AulaDTO Parse(Aula origin)
        {
            if (origin == null) return null;
            return new AulaDTO
            {
                Id = origin.Id,
                IdTurma = origin.IdTurma,
                IdProfessor = origin.IdProfessor,
                Capitulo = origin.Capitulo,
                DataDaAula = origin.DataDaAula,
                Resumo = origin.Resumo,
                Status = origin.Status,
                Frequencias = origin.Frequencias
            };
        }

        public List<Aula> ParseList(List<AulaDTO> origin)
        {
            if (origin == null) return null;           
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<AulaDTO> ParseList(List<Aula> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
