using CpntextLib.Context;
using Interfaces.Repository;
using Repository.Repository;
using Wrapper.Repository;

namespace Repository.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private CookBookContext _cookBookContext;
        private IImageRepository _imageRepository;

        public RepositoryWrapper(CookBookContext cookBookContext)
        {
            _cookBookContext = cookBookContext;
        }

        public IImageRepository ImageRepository
        {
            get
            {
                if(_imageRepository is null)
                {
                    _imageRepository = new ImageRepository(_cookBookContext);
                }
                return _imageRepository; 
            }
        }


        public void Save()
        {
            _cookBookContext.SaveChangesAsync();
        }
    }
}
