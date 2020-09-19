using CpntextLib.Context;
using Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class ImageRepository: RepositoryBase<Image>, IImageRepository
    {
        public ImageRepository(CookBookContext cookBookContext): base(cookBookContext)
        {
        }

        public void CreateImage(Image image)
        {
            Create(image);
        }

        public async Task< IEnumerable<Image>> GetAllImages()
        {
            return await FindAll().OrderBy(x => x.ImageName).ToListAsync();
        }

        public void DeleteImage(Image image)
        {
            Delete(image);
        }

        public void UpdateImage(Image image)
        {
            Update(image);
        }

        public async Task<Image> GetImageById(string Id)
        {
            return await FindByCondition(x => x.ImageId == Id).FirstOrDefaultAsync();
        }
    }
}
