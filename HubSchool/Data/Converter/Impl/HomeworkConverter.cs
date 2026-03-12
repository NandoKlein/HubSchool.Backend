using HubSchool.Data.Converter.Contract;
using HubSchool.Data.Dto;
using HubSchool.Model;

namespace HubSchool.Data.Converter.Impl
{
    public class HomeworkConverter : IParser<HomeworkDTO, Homework>, IParser<Homework, HomeworkDTO>
    {
        public Homework Parse(HomeworkDTO origin)
        {
            if(origin == null)return null;
            return new Homework
            {
                IdAluno = origin.IdAluno,
                IdAula = origin.IdAula,
                IdProfessor = origin.IdProfessor,
                IdTurma = origin.IdTurma,
                Arquivo = origin.Arquivo,
                Comentario = origin.Comentario,
                Nota = origin.Nota,
                StatusHomework = origin.StatusHomework,
                PrazoDeEntrega = origin.PrazoDeEntrega
            };
        }

        public HomeworkDTO Parse(Homework origin)
        {
            if (origin == null)return null;
            return new HomeworkDTO
            {
                IdAluno = origin.IdAluno,
                IdAula = origin.IdAula,
                IdProfessor = origin.IdProfessor,
                IdTurma = origin.IdTurma,
                Arquivo = origin.Arquivo,
                Comentario = origin.Comentario,
                Nota = origin.Nota,
                StatusHomework = origin.StatusHomework,
                PrazoDeEntrega = origin.PrazoDeEntrega
            };
        }

        public List<Homework> ParseList(List<HomeworkDTO> origin)
        {
            if (origin == null) return null; 
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<HomeworkDTO> ParseList(List<Homework> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
