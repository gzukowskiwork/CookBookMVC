using Interfaces.Repository;

namespace Wrapper.Repository
{
    public interface IRepositoryWrapper
    {
        IImageRepository ImageRepository { get; }
        void Save();
    }
}
