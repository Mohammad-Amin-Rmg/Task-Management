using Entities.ViewModels;

namespace Services
{
    public interface ISearchService
    {
        List<ShowSearchResultViewModel> Search(string query);
    }
}