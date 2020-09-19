using Models.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repository
{
    public interface IImageRepository: IRepositoryBase<Image>
    {
        Task<IEnumerable<Image>> GetAllImages();
        Task<Image> GetImageById(string Id);
        void CreateImage(Image image);
        void UpdateImage(Image image);
        void DeleteImage(Image image);
    }
}
