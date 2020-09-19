using CpntextLib.Context;
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

        public async Task< IEnumerable<Image>> GetAllImages()
        {
            return await FindAll().OrderBy(x => x.ImageName).ToListAsync();
        }

        
    }
}
