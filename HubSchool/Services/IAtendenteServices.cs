using HubSchool.Data.Dto;
using HubSchool.Model;

namespace HubSchool.Services
{
    public interface IAtendenteServices
    {
        AtendenteDTO Create(AtendenteDTO atendenteDto);
        AtendenteDTO FindById(long id);
        List<AtendenteDTO> FindAll();
        int Count();
        AtendenteDTO Update(AtendenteDTO atendenteDto);
        void Delete(long id);
        AtendenteDTO Login(string login, string senha);
        void AtualizarFoto(long id, string url);
        void PreservaFotoExistente(Atendente atendente);
    }
}
