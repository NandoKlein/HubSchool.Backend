using HubSchool.Data.Dto;
using HubSchool.Model;

namespace HubSchool.Repositories
{
    public interface IHomeworkRepository
    {
        void Create(Aula aula);

        public Homework Create(Homework homework);

        List<Homework> MontarHomeworks(Aula aula);

        List<Homework> BuscaHomeworksPorAluno(long idAluno, int status);

        List<Homework> BuscaHomeworksPorProfessor(long idProfessor);

        Homework BuscaHomeworkPorAulaEAluno(long idAula, long idAluno);

        Homework Atualizar(Homework homeworkDTO);

        void Delete(long idAula, long idAluno);
    }
}
