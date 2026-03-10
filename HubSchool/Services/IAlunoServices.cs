using HubSchool.Data.Dto;
using HubSchool.Model;

namespace HubSchool.Services
{
    public interface IAlunoServices
    {
        AlunoDTO Create(AlunoDTO alunoDTO);
        AlunoDTO FindById(long id);
        List<AlunoDTO> FindAll();
        int Count();
        AlunoDTO Update(AlunoDTO aluno);
        void Delete(long id);
        AlunoDTO Login(string login, string senha);
        void AtualizarFoto(long id, string url);
        void PreservaFotoExistente(Aluno entity);

    }
}
