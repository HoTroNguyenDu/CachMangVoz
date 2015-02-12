
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CachMangVoz
{
    public static  class PictureBoxExtensions
    {
        public static void SetImageLocationThreadSafe(this PictureBox picturebox, string imagePath)
        {
            SetImageLocation(picturebox, imagePath);
        }

        public static void SetImageLocation(PictureBox picturebox, string imagePath)
        {
            if (picturebox.InvokeRequired)
            {
                Action<PictureBox, string> deleg = new Action<PictureBox, string>(SetImageLocation);
                picturebox.Invoke(deleg, new object[] { picturebox, imagePath });
            }
            else
            {
                picturebox.ImageLocation = imagePath;
            }
        }
    }
}
