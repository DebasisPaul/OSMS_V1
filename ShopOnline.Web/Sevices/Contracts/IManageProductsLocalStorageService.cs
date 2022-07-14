using ShopOnline.Models.Dtos;

namespace ShopOnline.Web.Sevices.Contracts
{
    public interface IManageProductsLocalStorageService
    {
        Task<IEnumerable<ProductDto>> GetCollection();
        Task RemoveCollection();
    }
}
