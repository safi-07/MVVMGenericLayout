using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Models.Interfaces
{
    public interface IImage
    {
        bool IsPictureUploaded { get; set; }
        string ServerPicturePath { get; set; }
        string PictureType { get; set; }
        byte[] PictureInBytes { get; set; }
        ImageSource Picture { get; }
    }
}
