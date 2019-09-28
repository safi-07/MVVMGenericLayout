using Application.Windows;
using DesktopApplication.ViewModels.Base;
using Models;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace DesktopApplication.ViewModels.Branch
{
    public sealed class ShelfViewModel : CRUDBaseViewModel<ShelfModel, ShelfSearchViewModel>
    {

        #region[Properties]
        private ShelfSearchViewModel filters;
        public override ShelfSearchViewModel Filters
        {
            get
            {
                return filters;
            }
            set
            {
                filters = value;
                NotifyPropertyChanged();
            }
        }

        private SearchResultModel<ShelfModel> items;
        public override SearchResultModel<ShelfModel> Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
                NotifyPropertyChanged();
            }
        }

        private ShelfModel selectedItem;
        public override ShelfModel SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region [Constructor]
        public ShelfViewModel()
        {
            Filters = new ShelfSearchViewModel();
            Items = new SearchResultModel<ShelfModel>();
            SearchCommand.Execute(null);

        }
        #endregion

        #region[Commands]
        protected override async Task Search()
        {
            Items = await logic.GetShelvesByFilter(Filters);
        }

        protected override async Task Update()
        {
            bool result = false;
            result = await logic.AddShelf(SelectedItem);
            ShowUpdateActionNotification(result);
        }
        #endregion
        
    }
}
