using Application.Windows;
using DesktopApplication.ViewModels.Base;
using Models;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace DesktopApplication.ViewModels.Branch
{
    public sealed class BranchViewModel : CRUDBaseViewModel<BranchModel, BranchSearchViewModel>
    {

        #region[Properties]
        private BranchSearchViewModel filters;
        public override BranchSearchViewModel Filters
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

        private SearchResultModel<BranchModel> items;
        public override SearchResultModel<BranchModel> Items
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

        private BranchModel selectedItem;
        public override BranchModel SelectedItem
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
        public BranchViewModel()
        {
            Filters = new BranchSearchViewModel();
            Items = new SearchResultModel<BranchModel>();
            //SearchCommand.Execute(null);

        }
        #endregion

        #region[Commands]
        protected override async Task Search()
        {
            Items = await logic.GetBranchesByFilter(Filters);
        }

        protected override async Task Update()
        {
            bool result = false;
            result = await logic.AddBranch(SelectedItem);
            ShowUpdateActionNotification(result);
        }
        #endregion

        #region[Image Upload Command]
        public ICommand ImageUploadCommand => new ActionCommand(p => UploadImage());
        private void UploadImage()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //image.Source = new BitmapImage(new Uri(dlg.FileName));
                SelectedItem.ServerPicturePath = dlg.FileName;
                System.Drawing.Image BranchLogo = System.Drawing.Image.FromFile(dlg.FileName);
                using (var ms = new MemoryStream())
                {
                    BranchLogo.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    SelectedItem.PictureInBytes = ms.ToArray();
                }
                try
                {
                    string imageFormat = dlg.FileName.Split('.')[1].ToLower();
                    if (imageFormat == "jpg")
                        imageFormat = "jpeg";
                    SelectedItem.PictureType = "image/" + imageFormat;
                }
                catch
                {
                    SelectedItem.PictureType = "";
                }

                SelectedItem.IsPictureUploaded = true;
            }
        }
        #endregion
    }
}
