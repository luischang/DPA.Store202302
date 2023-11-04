using DPA.Store.DOMAIN.Core.DTO;

namespace DPA.Store.DOMAIN.Core.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductCategoryDTO>> GetAll();
    }
}