using _AlunosAPI.Models;
using _AlunosAPI.Pagination;

namespace _AlunosAPI.Repository.Interface
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        Task <PagedList<Aluno>> GetAlunos(AlunosParamers alunosParamers);
        Task <IEnumerable<Aluno>> GetAlunoByName(string nome);
    }
}
