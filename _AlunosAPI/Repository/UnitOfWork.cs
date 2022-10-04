using _AlunosAPI.Context;
using _AlunosAPI.Repository.Interface;

namespace _AlunosAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AlunoRepository _alunoRepo;

        public AppDbContext _context;
        public UnitOfWork(AppDbContext contexto)
        {
            _context = contexto;
        }

        public IAlunoRepository AlunoRepository
        {
            get
            {
                return _alunoRepo = _alunoRepo ?? new AlunoRepository(_context);
            }
        }


        public async Task Commit()
        {
             await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
