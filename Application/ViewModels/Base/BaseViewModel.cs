using Application.Windows;
using AsyncAwaitBestPractices.MVVM;
using BusinessLogic;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesktopApplication.ViewModels.Base
{
    public abstract class BaseViewModel<M, F> : ViewModel where M : class, new()
        where F : GenralSearchModel, new()
    {

        #region[Generic Properties]
        protected readonly Logic logic;

        protected int LastPage
        {
            get
            {
                return (Items.TotalCount / Filters.RecordsPerPage);
            }
        }

        public string PaginationText
        {
            get
            {
                int TotalRecords = Items.TotalCount;
                int CurrentPageRecordsFrom = 0;
                if (Filters.CurrentPage > 1)
                {
                    CurrentPageRecordsFrom = (Filters.CurrentPage - 1) * Filters.RecordsPerPage;
                }
                CurrentPageRecordsFrom += 1;
                int CurrentPageRecordsTo = Filters.CurrentPage * Filters.RecordsPerPage;

                return string.Format("Showing {0}-{1} of {2} records", CurrentPageRecordsFrom, CurrentPageRecordsTo, Items.TotalCount);
            }

        }

        public List<int> PageList
        {
            get
            {
                var pages = new List<int>();
                for (int i = 1; i <= LastPage; i++)
                {
                    pages.Add(i);
                }
                return pages;
            }

        }
        // Disable pagination when searching to avoid bubbling of Selected Page
        private bool isPaginationEnabled = false;
        private bool isPaginationSearch = false;

        private int selectedPageIndex;
        public int SelectedPageIndex
        {
            get
            {
                return selectedPageIndex;
            }
            set
            {
                selectedPageIndex = value;
                NotifyPropertyChanged();
            }
        }

        private bool showClearLoader = false;
        public bool ShowClearLoader
        {
            get
            {
                return showClearLoader;
            }
            set
            {
                showClearLoader = value;
                NotifyPropertyChanged();
            }
        }

        private bool showSearchLoader = false;
        public bool ShowSearchLoader
        {
            get
            {
                return showSearchLoader;
            }
            set
            {
                showSearchLoader = value;
                NotifyPropertyChanged();
            }
        }

        private bool showLoadOverlay = false;
        public bool ShowLoadOverlay
        {
            get
            {
                return showLoadOverlay;
            }
            set
            {
                showLoadOverlay = value;
                NotifyPropertyChanged();
            }
        }

        private string loadOverlayText = "Loading...";
        public string LoadOverlayText
        {
            get
            {
                return loadOverlayText;
            }
            set
            {
                loadOverlayText = value;
                NotifyPropertyChanged();
            }
        }




        #endregion

        #region[Read Operation Properties]
        public abstract F Filters { get; set; }
        public abstract SearchResultModel<M> Items { get; set; }
        #endregion


        #region [Constructor]
        public BaseViewModel()
        {
            logic = new Logic();
        }
        #endregion

        private bool CanExecutePaginationSearch()
        {
            return isPaginationEnabled;
        }
        #region[Commands]
        public IAsyncCommand SearchCommand => new AsyncCommand(ExecuteSearchCommand);
        public IAsyncCommand ClearCommand => new AsyncCommand(ExecuteClear);
        public IAsyncCommand<object> PageSelectedCommand => new AsyncCommand<object>(p => PageSelected(p));
        public ICommand FirstPageCommand => new ActionCommand(p => FirstPageSelected());
        public ICommand PreviousPageCommand => new ActionCommand(p => PreviousPageSelected());
        public ICommand LastPageCommand => new ActionCommand(p => LastPageSelected());
        public ICommand NextPageCommand => new ActionCommand(p => NextPageSelected());
        #endregion

        #region[Supportive Function Commands]
        private async Task PageSelected(object selectedPage)
        {
            if (selectedPage != null && selectedPage is int)
            {
                await ExecutePagination((int)selectedPage);
            }
        }
        private void FirstPageSelected()
        {
            ChangeSelectedPage(1);
        }
        private void LastPageSelected()
        {
            ChangeSelectedPage(LastPage);
        }
        private void PreviousPageSelected()
        {
            ChangeSelectedPage(Filters.CurrentPage - 1);
        }
        private void NextPageSelected()
        {
            ChangeSelectedPage(Filters.CurrentPage + 1);
        }
        #endregion

        #region[Read Command]
        protected abstract Task Search();
        #endregion

        #region[Helper Function]
        private void BeforeSearch()
        {
            ShowSearchLoader = true;
            ShowLoadOverlay = true;
            LoadOverlayText = "Loading Items...";
        }
        private void AfterSearch()
        {
            ShowSearchLoader = false;
            ShowLoadOverlay = false;
        }
        protected async Task ExecuteSearchCommand()
        {
            BeforeSearch();
            await ExecuteSearch();
            AfterSearch();
        }

        private void BeforeClear()
        {
            ShowClearLoader = true;
            ShowLoadOverlay = true;
            Filters = new F();
            LoadOverlayText = "Loading Items...";
        }
        private void AfterClear()
        {
            ShowClearLoader = false;
            ShowLoadOverlay = false;

        }
        private async Task ExecuteClear()
        {
            BeforeClear();
            await ExecuteSearch();
            AfterClear();
        }

        private void ChangeSelectedPage(int ChangedPage)
        {
            if (ChangedPage >= 1 && ChangedPage <= LastPage)
            {
                SelectedPageIndex = ChangedPage - 1;
            }
        }
        private async Task ExecutePagination(int ChangedPage)
        {
            if (CanExecutePaginationSearch())
            {
                if (ChangedPage >= 1 && ChangedPage <= LastPage)
                {
                    Filters.CalculateTotal = false;
                    Filters.CurrentPage = ChangedPage;
                    isPaginationSearch = true;
                    await ExecuteSearch();
                }
            }
        }

        protected async Task ExecuteSearch()
        {
            int PreviousTotalCount = Items.TotalCount;

            if (Filters.CalculateTotal == true)
            {
                Filters.CurrentPage = 1;
            }
            await Search();
            if (Filters.CalculateTotal == false)
            {
                Items.TotalCount = PreviousTotalCount;
            }
            else
            {
                NotifyPropertyChanged("PageList");
            }
            NotifyPropertyChanged("PaginationText");
            Filters.CalculateTotal = true;
            AfterSearchExecute();

        }
        private void AfterSearchExecute()
        {
            ShowSearchLoader = false;
            ShowLoadOverlay = false;
            if (isPaginationSearch == false)
            {
                ChangeSelectedPage(1);
            }
            isPaginationEnabled = true;
            isPaginationSearch = false;
        }
        #endregion
    }
}
