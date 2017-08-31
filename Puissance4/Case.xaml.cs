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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Puissance4 {
    public partial class Case : Border {

        int iClicker = 0;
        static public Color ColorPlayerOne { get; set; } = Color.FromRgb(247, 56, 89);
        static public Color ColorPlayerTwo { get; set; } = Color.FromRgb(41, 210, 228);
        static public Color ColorEmpty { get; set; } = Color.FromRgb(238, 238, 238);

        public int X {
            get { return Grid.GetColumn(this); }
            set { Grid.SetColumn(this, value); }
        }

        public int Y {
            get { return Grid.GetRow(this); }
            set { Grid.SetRow(this, value); }
        }

        public int Clicker {
            get { return iClicker; }
            set {
                AnimateBackground(false, (value > 1) ? ColorPlayerTwo : ColorPlayerOne, 400);
                iClicker = value;
            }
        }

        public Case() {
            InitializeComponent();
        }

        public Case(int x, int y, int Clicker) {
            InitializeComponent();
            this.Clicker = Clicker;
        }
        
        public void AnimateMargin(bool AutoReverse) {
            ThicknessAnimation _canAnimMargin = new ThicknessAnimation(new Thickness(-5), new Duration(TimeSpan.FromMilliseconds(200)));
            _canAnimMargin.AutoReverse = AutoReverse;
            BeginAnimation(MarginProperty, _canAnimMargin);
        }

        public void AnimateBorder(bool AutoReverse, Color Color) {
            ColorAnimation _canAnimBorder = new ColorAnimation(Color, new Duration(TimeSpan.FromMilliseconds(175)));
            _canAnimBorder.AutoReverse = AutoReverse;
            BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, _canAnimBorder);
        }

        public void AnimateBackground(bool AutoReverse, Color Color, int Milliseconds) {
            ColorAnimation _canAnim = new ColorAnimation(Color, new Duration(TimeSpan.FromMilliseconds(Milliseconds)));
            _canAnim.AutoReverse = AutoReverse;
            Background.BeginAnimation(SolidColorBrush.ColorProperty, _canAnim);
        }

        public void RefreshBackground() {
            Clicker = Clicker;
        }
    }
}
