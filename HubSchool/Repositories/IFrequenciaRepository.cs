using HubSchool.Model;

namespace HubSchool.Repositories
{
    public interface IFrequenciaRepository
    {
        List<Frequencia> Create(List<Frequencia> frequencias);

        List<Frequencia> MontarFrequencias(List<long> idAlunos, long idAula);

        void DeletaFrequenciaPorIdAula(long idAula);

        List<Frequencia> AtualizaFrequencias(List<Frequencia> frequencias);

        List<Frequencia> BuscaFrequenciasPorIdAula(long idAula);

    }
}
