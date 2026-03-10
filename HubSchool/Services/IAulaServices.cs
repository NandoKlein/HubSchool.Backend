using HubSchool.Data.Dto;

namespace HubSchool.Services
{
    public interface IAulaServices
    {
        AulaDTO Create(AulaDTO aulaDTO);
        AulaDTO FindById(long id);
        List<AulaDTO> FindAll();
        int Count();
        AulaDTO Update(AulaDTO aula);
        void Delete(long id);
        AulaDTO UpdateFrequencias(AulaDTO aulaDTO);
    }
}
