using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Game
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            init(70);

        }

        static Button[,] tilemapForm;
        static List<Tile> tilemap = new List<Tile>();
        static Size tilemapSize;
        public static Size TilemapSize { get { return tilemapSize; } }

        public void DrawFishes(IField field)
        {
            int i = 0, j = 0;
            
            foreach (List <IFish> fishes in field.Field)
            {
                foreach (IFish fish in fishes) 
                {
                    if (fish == null)
                        tilemap.Find(t => t.X == i && t.Y == j).setData(null,"null");
                    else
                    tilemap.Find(t => t.X == i && t.Y == j).setData(fish.Sprite, fish.Size.ToString());
                    j++;
                }
                i++;
                j = 0;
            }



        }
        void init(int spriteSize)
        {
            Controller.window = this;
            canvas.Background = new ImageBrush(Controller.BitmapToImageSource(Properties.Resources.fon1));

            Random rand = new Random(DateTime.Now.Millisecond * DateTime.Now.Year * DateTime.Now.Day);

            tilemapSize.Width = 8;
            tilemapSize.Height = 6;
            tilemapForm = new Button[(int)TilemapSize.Width, (int)TilemapSize.Height];
            for (int i = 0; i < (TilemapSize.Width); i++)
            {
                for (int j = 0; j < (TilemapSize.Height); j++)
                {
                    Button buff = new Button();
                    buff.Width = spriteSize;
                    buff.Height = spriteSize;
                    Canvas.SetLeft(buff, i * spriteSize);
                    Canvas.SetTop(buff, j * spriteSize);
                    buff.Click += tile_Click;
                    buff.Background = new System.Windows.Media.SolidColorBrush(Color.FromRgb(255, 255, 255));
                    buff.Background.Opacity = 100;
                    //buff.Background.Transform.
                    tilemapForm[i, j] = buff;
                    Tile buffTile = new Tile(i, j);
                    tilemap.Add(buffTile);
                    canvas.Children.Add(buff);
                    //Refresh();
                }
            }
            //this.MaximumSize = Size;
            Controller.restart();
        }

        private void tile_Click(object sender, RoutedEventArgs e)
        {
            
        }

        static void redraw()
        {
            for (int i = 0; i < (TilemapSize.Width); i++)
            {
                for (int j = 0; j < (TilemapSize.Height); j++)
                {
                    tilemapForm[i, j].Background = new ImageBrush(tilemap.Find(t => t.X == i && t.Y == j).Sprite.Source);
                    //Refresh();
                }
            }
        }
        static void redraw(int x, int y, Image sprite)
        {
            try
            {
                if (sprite == null)
                    tilemapForm[x, y].Background = new System.Windows.Media.SolidColorBrush(Color.FromArgb(0,255, 255, 255));
                else
                tilemapForm[x, y].Background = new ImageBrush(sprite.Source);
            }
            catch { }
        }
        class Tile
        {
            int x;
            int y;
            Image sprite;
            string type;
            public Tile()
            {
                x = 0;
                y = 0;
                sprite = null;
                type = "null";
            }
            public Tile(int _x, int _y)
            {
                x = _x;
                y = _y;
                sprite = null;
                type = "null";
            }
            public void setData(Image _Sprite, string _Type)
            {
                Sprite = _Sprite;
                Type = _Type;
            }
            public string Type
            {
                set
                {
                    type = value;
                }
                get
                {
                    return type;
                }
            }
            public Image Sprite
            {
                set
                {
                    sprite = value;
                    redraw(x, y, value);
                }
                get
                {
                    return sprite;
                }
            }
            public int X
            {
                get
                {
                    return x;
                }
            }
            public int Y
            {
                get
                {
                    return y;
                }
            }
        }

        private void RestartGame_Click(object sender, RoutedEventArgs e)
        {
            init(70);
        }
    }
}
