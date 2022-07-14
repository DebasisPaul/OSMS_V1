using Blazored.LocalStorage;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Sevices.Contracts;

namespace ShopOnline.Web.Sevices
{
    public class ManageProductsLocalStorageService : IManageProductsLocalStorageService
    {
        private readonly ILocalStorageService localStorageService;
        private readonly IProductService productService;

        private const string Key = "ProductCollection";
        
        public ManageProductsLocalStorageService(ILocalStorageService localStorageService,
                                                          IProductService productService)
        {
            this.localStorageService = localStorageService;
            this.productService = productService;
        }
        
        public async Task<IEnumerable<ProductDto>> GetCollection()
        {
            return await this.localStorageService.GetItemAsync<IEnumerable<ProductDto>>(Key)
                        ?? await AddCollection();
        }

        public async Task RemoveCollection()
        {
            await this.localStorageService.RemoveItemAsync(Key);
        }

        private async Task<IEnumerable<ProductDto>> AddCollection()
        {
            var productCollection = await this.productService.GetItems();

            if (productCollection != null)
            {
                await this.localStorageService.SetItemAsync(Key, productCollection);
            }

            return productCollection;
        }
    }
}
