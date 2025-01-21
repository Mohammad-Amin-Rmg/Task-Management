using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using Entities.ViewModels;
using Entities.Enums;

namespace Services
{
    public class SearchService : ISearchService
    {
        private readonly ApplicationDbContext _context;
        public SearchService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public List<ShowSearchResultViewModel> Search(string query)
        {
            return _context
                   .TaskBases
                   .Include(x => x.AssignedUser)
                   .Where(s => s.Name.Contains(query) ||
                   s.AssignedUser!.Name.Contains(query) ||
                   s.Status.Equals(query))
                   .Select(s => new ShowSearchResultViewModel
                   {
                       Id = s.Id,
                       TaskName = s.Name,
                       AssignedUserName = s.AssignedUser!.Name,
                       Status = s.Status
                   }).ToList();
        }

    }
}
