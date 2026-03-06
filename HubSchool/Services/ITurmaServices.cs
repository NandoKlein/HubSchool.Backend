using HubSchool.Data.Dto;

namespace HubSchool.Services
{
    public interface ITurmaServices
    {
        TurmaDTO Create(TurmaDTO turmaDto);
        TurmaDTO FindById(long id);
        List<TurmaDTO> FindAll();
        int Count();
        TurmaDTO Update(TurmaDTO turma);
        void Delete(long id);      
    }
}
