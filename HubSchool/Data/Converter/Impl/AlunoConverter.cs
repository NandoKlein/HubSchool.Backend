using HubSchool.Data.Converter.Contract;
using HubSchool.Data.Dto;
using HubSchool.Model;

namespace HubSchool.Data.Converter.Impl
{
    public class AlunoConverter : IParser<AlunoDTO, Aluno>, IParser<Aluno, AlunoDTO>
    {
        public Aluno Parse(AlunoDTO origin)
        {
            if (origin == null) return null;
            return new Aluno
            {
                Id = origin.Id,
                Matricula = origin.Matricula,
                Name = origin.Name,
                Login = origin.Login,
                Senha = origin.Senha,
                Address = origin.Address,
                Birthday = origin.Birthday,
                Email = origin.Email,
                Phone = origin.Phone,
                DataDaMatricula = DateTime.Now,
                Foto = origin.Foto
            };
        }

        public AlunoDTO Parse(Aluno origin)
        {
            if (origin == null) return null;
            return new AlunoDTO
            {
                Id = origin.Id,
                Matricula = origin.Matricula,
                Name = origin.Name,
                Login = origin.Login,
                Senha = origin.Senha,
                Address = origin.Address,
                Birthday = origin.Birthday,
                Email = origin.Email,
                Phone = origin.Phone,
                DataDaMatricula = origin.DataDaMatricula,
                Foto = origin.Foto
            };

        }
        public List<Aluno> ParseList(List<AlunoDTO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }


        public List<AlunoDTO> ParseList(List<Aluno> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
