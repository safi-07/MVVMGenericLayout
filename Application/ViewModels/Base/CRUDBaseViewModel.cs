using DesktopApplication.ViewModels.Base;
using Application.Windows;
using AsyncAwaitBestPractices.MVVM;
using BusinessLogic;
using Models;
using Notifications.Wpf;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesktopApplication.ViewModels.Base
{
    public abstract class CRUDBaseViewModel<M, F> : BaseViewModel<M, F> where M : class, new()
        where F : GenralSearchModel, new()
    {
        #region[Generic Properties]
        protected readonly NotificationManager _notificationManager = new NotificationManager();

        private bool isUpdatePanelVisible = false;
        public bool IsUpdatePanelVisible
        {
            get
            {
                return isUpdatePanelVisible;
            }
            set
            {
                isUpdatePanelVisible = value;
                NotifyPropertyChanged();
            }
        }

        private bool showSaveLoader = false;
        public bool ShowSaveLoader
        {
            get
            {
                return showSaveLoader;
            }
            set
            {
                showSaveLoader = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region[Read Operation Properties]
        public override abstract F Filters { get; set; }
        public override abstract SearchResultModel<M> Items { get; set; }
        #endregion

        #region[Create Operation Properties]
        public bool CanAdd
        {
            get
            {
                return true;
            }
        }

        #endregion

        #region[Update Operation Properties]
        public bool CanUpdate
        {
            get
            {
                return true;
            }
        }

        public abstract M SelectedItem { get; set; }

        #endregion

        #region[Delete Operation Properties]
        public bool CanDelete
        {
            get
            {
                return true;
            }
        }
        #endregion

        #region[Commands]
        public ICommand GoBackCommand => new ActionCommand(p => HideUpdatePanel());
        public ICommand AddCommand => new ActionCommand(p => ShowUpdatePanel(new M()));
        public ICommand ShowUpdatePanelCommand => new ActionCommand(p => ShowUpdatePanel(GetModelType(p)));
        public IAsyncCommand UpdateCommand => new AsyncCommand(ExecuteUpdate);
        #endregion

        #region[Supportive Function Commands]
        private void ShowUpdatePanel(M selectedItem)
        {
            SelectedItem = selectedItem;
            IsUpdatePanelVisible = true;
        }
        private void HideUpdatePanel()
        {
            IsUpdatePanelVisible = false;
        }
        #endregion

        #region[Crud Commands]

        protected abstract Task Update();
        protected override abstract Task Search();
        #endregion

        #region[Helper Function]
        public M GetModelType(object obj)
        {
            if (obj is M)
            {
                return (M)obj;
            }
            try
            {
                return (M)Convert.ChangeType(obj, typeof(M));
            }
            catch (InvalidCastException)
            {
                return default(M);
            }
        }
        protected void ShowUpdateActionNotification(bool result)
        {
            _notificationManager.Show(new NotificationContent
            {
                Title = "Result",
                Message = result == false ? "There was some error in saving. Please try again later." : "Successfully Added!.",
                Type = result == false ? NotificationType.Error : NotificationType.Success
            });
        }

       

        private async Task ExecuteUpdate()
        {
            BeforeUpdate();
            await Update();
            AfterUpdate();
        }
        private void BeforeUpdate()
        {
            ShowSaveLoader = true;
            ShowLoadOverlay = true;
            LoadOverlayText = "Saving Item...";
        }
        private void AfterUpdate()
        {
            ShowSaveLoader = false;
            ShowLoadOverlay = false;
            HideUpdatePanel();
        }
        #endregion

    }
}
