using CookBookMVC.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface IImageRepository: IRepositoryBase<Image>
    {
        Task<IEnumerable<Image>> GetAllImages();
    }
}
