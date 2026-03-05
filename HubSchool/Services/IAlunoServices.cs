using HubSchool.Data.Dto;

namespace HubSchool.Services
{
    public interface IAlunoServices
    {
        AlunoDTO Create(AlunoDTO alunoDTO);
        AlunoDTO FindById(long id);
        List<AlunoDTO> FindAll();
        AlunoDTO Update(AlunoDTO aluno);
        void Delete(long id);
    }
}
