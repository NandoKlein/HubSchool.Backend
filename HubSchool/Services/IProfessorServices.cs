using HubSchool.Data.Dto;

namespace HubSchool.Services
{
    public interface IProfessorServices
    {
        ProfessorDTO Create(ProfessorDTO professorDTO);
        ProfessorDTO FindById(long id);
        List<ProfessorDTO> FindAll();
        int Count();
        ProfessorDTO Update(ProfessorDTO professor);
        void Delete(long id);
        bool Login(string login, string senha);
    }
}
