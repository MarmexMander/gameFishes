using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Threading;

namespace Game
{
    class Controller
    {
        public static IField Field;
        public static MainWindow window;
        public static DispatcherTimer ticker;
        static public System.Windows.Media.ImageSource BitmapToImageSource(Bitmap value)
        {
            MemoryStream ms = new MemoryStream();
            ((System.Drawing.Bitmap)value).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            System.Windows.Media.Imaging.BitmapImage image = new System.Windows.Media.Imaging.BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit(); 

            return image;
        }
        public static void GameOver()
        {

        }
        public static void restart()
        {
            ticker = new DispatcherTimer();
            ticker.Interval = new TimeSpan(0,0,0,0,500);
            ticker.Tick += Ticker_tick;
            Field = new Model.Fild((int)MainWindow.TilemapSize.Width,(int)MainWindow.TilemapSize.Height);
            ((Model.Fild)Field).pushBackColumn(1, new Model.SmallFish());
            window.Field = Field as Model.Fild;
            window.DrawFishes(Field);
            ((Model.Fild)Field).Row_Add();
            ((Model.Fild)Field).Row_Add();
            ((Model.Fild)Field).Row_Add();
            ticker.Start();
        }

        private static void Ticker_tick(object sender, EventArgs e)
        {
            window.DrawFishes(Field);
        }
    }
}
    