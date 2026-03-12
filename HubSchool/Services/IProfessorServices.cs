using HubSchool.Data.Dto;
using HubSchool.Model;

namespace HubSchool.Services
{
    public interface IProfessorServices
    {
        ProfessorDTO Create(ProfessorDTO professorDTO);
        ProfessorDTO FindById(long id);
        List<ProfessorDTO> FindAll();
        int Count();
        ProfessorDTO Update(ProfessorDTO professorDTO);
        void Delete(long id);
        ProfessorDTO Login(string login, string senha);
        void AtualizarFoto(long id, string url);
        void PreservaFotoExistente(Professor professor);
    }
}
