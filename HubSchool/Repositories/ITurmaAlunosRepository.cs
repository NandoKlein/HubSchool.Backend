namespace HubSchool.Repositories
{
    public interface ITurmaAlunosRepository
    {
        void AdicionaAlunos(long idTurma, List<long> idAlunos);

        void DeletaAlunosPorIdDaTurma(long idTurma);

        void AtualizaAlunos(long idTurma, List<long> idAlunos);

        List<long> BuscaAlunosPorTurma(long idTurma);      
    }
}
