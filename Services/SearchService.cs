using Latiendita.Repositories;
using Latiendita.Models;

public interface ISearchService
{
    Task<IEnumerable<Product>> SearchProductsAsync(string query);
}

public class SearchService : ISearchService
{
    private readonly IProductRepository _productRepository;

    public SearchService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<Product>> SearchProductsAsync(string query)
    {
        return await _productRepository.SearchAsync(query);
    }
}