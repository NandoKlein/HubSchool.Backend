using HubSchool.Data.Dto;
using HubSchool.Model;
using HubSchool.Repositories;

namespace HubSchool.Services
{
    public interface IHomeworkServices
    {
        void Create(Aula aula);
        
        List<HomeworkDTO> BuscaHomeworksPorAluno(long idAluno, int status);

        List<HomeworkDTO> BuscaHomeworksPorProfessor(long idProfessor);

        HomeworkDTO BuscaHomeworkPorAulaEAluno(long idAula, long idAluno);

        HomeworkDTO Atualizar(HomeworkDTO homeworkDTO);

        void Delete(long idAula, long idAluno);

    }
}
