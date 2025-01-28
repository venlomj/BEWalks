using BEWalks.API.Models.Domain;

namespace BEWalks.API.Repositories
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}
