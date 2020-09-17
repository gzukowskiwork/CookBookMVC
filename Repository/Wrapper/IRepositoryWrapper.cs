using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wrapper.Repository
{
    public interface IRepositoryWrapper
    {
        IImageRepository imageRepository { get; }
        void Save();
    }
}
