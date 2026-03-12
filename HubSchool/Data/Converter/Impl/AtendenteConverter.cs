using HubSchool.Data.Converter.Contract;
using HubSchool.Data.Dto;
using HubSchool.Model;

namespace HubSchool.Data.Converter.Impl
{
    public class AtendenteConverter : IParser<AtendenteDTO, Atendente>, IParser<Atendente, AtendenteDTO>
    {
        public Atendente Parse(AtendenteDTO origin)
        {
            if (origin == null) return null;
            return new Atendente
            {
                Id = origin.Id,
                Name = origin.Name,
                Login = origin.Login,
                Senha = origin.Senha,
                Address = origin.Address,
                Birthday = origin.Birthday,
                DataDaContratacao = origin.DataDaContratacao,
                Email = origin.Email,
                Phone = origin.Phone,
                Foto = origin.Foto
            };
        }

        public AtendenteDTO Parse(Atendente origin)
        {
            if (origin == null) return null;
            return new AtendenteDTO
            {
                Id = origin.Id,
                Name = origin.Name,
                Login = origin.Login,
                Senha = origin.Senha,
                Address = origin.Address,
                Birthday = origin.Birthday,
                DataDaContratacao = origin.DataDaContratacao,
                Email = origin.Email,
                Phone = origin.Phone,
                Foto = origin.Foto
            };
        }

        public List<Atendente> ParseList(List<AtendenteDTO> origin)
        {
            if (origin == null) return null;            
            return origin.Select(item => Parse(item)).ToList();

        }

        public List<AtendenteDTO> ParseList(List<Atendente> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
