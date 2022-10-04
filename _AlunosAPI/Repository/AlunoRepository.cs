using _AlunosAPI.Context;
using _AlunosAPI.Models;
using _AlunosAPI.Pagination;
using _AlunosAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace _AlunosAPI.Repository
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(AppDbContext context) : base(context)
        {
        }
        
               
        //procurar as informações do aluno por nome
        public async Task<IEnumerable<Aluno>> GetAlunoByName(string nome)
        {
            if (!string.IsNullOrWhiteSpace(nome))
            {
                var aluno = await Get().Where(aluno => aluno.Nome.Contains(nome)).ToListAsync();
                return aluno;
            }
            else
            {
                var aluno = await Get().ToListAsync();
                return aluno;
            }
        }

        public async Task<PagedList<Aluno>> GetAlunos(AlunosParamers alunosParamers)
        {
            return await PagedList<Aluno>.ToPagedList(Get().OrderBy(on => on.Id),
            alunosParamers.PageNumber);
        }
    }
}
