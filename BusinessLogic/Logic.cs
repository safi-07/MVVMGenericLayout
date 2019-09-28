using FizzWare.NBuilder;
using Helpers;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Logic
    {
        List<BranchModel> Branches = new List<BranchModel>();
        List<ShelfModel> Shelves = new List<ShelfModel>();
        public Logic()
        {
            
        }
        private void LoadBranches()
        {
            Branches = Builder<BranchModel>.CreateListOfSize(100).Build().ToList();
        }
        public async Task<SearchResultModel<BranchModel>> GetBranchesByFilter(BranchSearchViewModel filters)
        {
            if(Branches.Count==0)
            {
                Branches = await Task.Run(() => Builder<BranchModel>.CreateListOfSize(100).Build().ToList());
            }
            SearchResultModel<BranchModel> searchResult = new SearchResultModel<BranchModel>();
            var BranchQueryable = Branches.Where(x => string.IsNullOrEmpty(filters.Name) || x.Name.Contains(filters.Name)).AsQueryable();
            List<BranchModel> BranchList = await Task.Run(() => BranchQueryable.OrderBy(x => x.Name).Skip((filters.CurrentPage - 1) * filters.RecordsPerPage).Take(filters.RecordsPerPage).ToList());
            searchResult.ResultList = Conventors.ToObservableCollection(BranchList ?? new List<BranchModel>());
            if (filters.CalculateTotal)
            {
                searchResult.TotalCount = BranchQueryable == null ? 0 : BranchQueryable.Count();
            }
            return searchResult;
        }
        public async Task<bool> AddBranch(BranchModel Branch)
        {
            await Task.Delay(1000);
            return true;
        }

        private void LoadShelves()
        {
            Shelves = Builder<ShelfModel>.CreateListOfSize(100).Build().ToList();
        }
        public async Task<SearchResultModel<ShelfModel>> GetShelvesByFilter(ShelfSearchViewModel filters)
        {
            if (Shelves.Count == 0)
            {
                Shelves = await Task.Run(() => Builder<ShelfModel>.CreateListOfSize(100).Build().ToList());
            }
            SearchResultModel<ShelfModel> searchResult = new SearchResultModel<ShelfModel>();
            var ShelfQueryable = Shelves.Where(x => string.IsNullOrEmpty(filters.Name) || x.Name.Contains(filters.Name)).AsQueryable();
            List<ShelfModel> ShelvesList = await Task.Run(() => ShelfQueryable.OrderBy(x => x.Name).Skip((filters.CurrentPage - 1) * filters.RecordsPerPage).Take(filters.RecordsPerPage).ToList());
            searchResult.ResultList = Conventors.ToObservableCollection(ShelvesList ?? new List<ShelfModel>());
            if (filters.CalculateTotal)
            {
                searchResult.TotalCount = ShelfQueryable == null ? 0 : ShelfQueryable.Count();
            }
            return searchResult;
        }
        public async Task<bool> AddShelf(ShelfModel Shelf)
        {
            await Task.Delay(1000);
            return true;
        }
    }
}
