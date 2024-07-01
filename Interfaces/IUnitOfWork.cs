


namespace ECAN_INVOICE.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }

        IProduct product { get; }
        int save();
    }
}
