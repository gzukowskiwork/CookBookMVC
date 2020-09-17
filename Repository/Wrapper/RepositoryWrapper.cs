using CookBookMVC.Context;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Wrapper.Repository;

namespace Repository.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private CookBookContext _cookBookContext;
        private IImageRepository _imageRepository;

        public IImageRepository imageRepository
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
