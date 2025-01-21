using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

namespace TaskManagementApp.Pages.Search
{
    public class IndexModel : PageModel
    {
        private readonly ISearchService _searchService;

        public IndexModel(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public List<ShowSearchResultViewModel> Results { get; set; }

        public void OnGet(string query)
        {
            Results = _searchService.Search(query);
        }
    }
}
