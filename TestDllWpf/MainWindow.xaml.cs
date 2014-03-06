using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IdenticonsDll;
using System.Drawing;

namespace TestDllWpf
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            Create();
        }        
        
        IdenticonsDll.IdIcon ic = new IdIcon();
        private void Create()
        {
            List<Dictionary<int, int>> lst = new List<Dictionary<int, int>>();
            lst = ic.ListCreate(8);//8个
            string json = ic.LstTjson(lst);
            System.Drawing.Image img = ic.IdenticonsCreate(Convert.ToInt32(image1.Width), Convert.ToInt32(image1.Height), lst, System.Drawing.Color.Silver, "#A87EDF", "#A87EDF");//浅紫色
            image1.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(((Bitmap)img).GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            label1.Content = "time:" + DateTime.Now.ToString("HH:mm:ss") + "\n" + "id:" + json;
        }
    }
}
