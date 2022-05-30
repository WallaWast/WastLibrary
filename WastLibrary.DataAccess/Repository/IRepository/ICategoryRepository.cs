using WastLibrary.Models;

namespace WastLibrary.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);

        void Save();
    }
}
