namespace _AlunosAPI.Repository.Interface
{
    public interface IUnitOfWork
    {
        IAlunoRepository AlunoRepository { get; }
        Task Commit();
        void Dispose();
    }
}
