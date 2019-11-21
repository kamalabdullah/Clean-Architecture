using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Persistence.Shared;

namespace CleanArchitecture. Persistence.Images
{
    public class ImagesRepository : Repository<CleanArchitecture.Domain.Images.Images>, IImagesRepository
    {
        public ImagesRepository(IDatabaseContext database) : base(database)
        {
        }
    }
}
