using HubSchool.Data.Converter.Contract;
using HubSchool.Data.Dto;
using HubSchool.Model;

namespace HubSchool.Data.Converter.Impl
{
    public class ProfessorConverter : IParser<ProfessorDTO, Professor>, IParser<Professor, ProfessorDTO>
    {
        public Professor Parse(ProfessorDTO origin)
        {
            if (origin == null) return null;
            return new Professor
            {
                Id = origin.Id,
                Name = origin.Name,
                Login = origin.Login,
                Senha = origin.Senha,
                Address = origin.Address,
                Birthday = origin.Birthday,
                DataDaContratacao = origin.DataDaContratacao,
                Email = origin.Email,
                Phone = origin.Phone

            };
        }

        public ProfessorDTO Parse(Professor origin)
        {
            if (origin == null) return null;
            return new ProfessorDTO
            {
                Id = origin.Id,
                Name = origin.Name,
                Login = origin.Login,
                Senha = origin.Senha,
                Address = origin.Address,
                Birthday = origin.Birthday,
                DataDaContratacao = origin.DataDaContratacao,
                Email = origin.Email,
                Phone = origin.Phone

            };
        }

        public List<Professor> ParseList(List<ProfessorDTO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<ProfessorDTO> ParseList(List<Professor> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
