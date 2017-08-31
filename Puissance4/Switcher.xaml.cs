using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace MiniPuzzle {
    public partial class Switcher : Viewbox {

        public event EventHandler StateChanged;
        public int CornerRadius {
            set { BorderSwitcher.CornerRadius = new CornerRadius(value); }
        }
        private bool bCanSwitch = true;

        public bool CanSwitch {
            get { return bCanSwitch; }
            set {
                if (value) {
                    EllipseSwitcher.Fill = Brushes.White;
                    Cursor = Cursors.Hand;
                } else {
                    EllipseSwitcher.Fill = Brushes.Transparent;
                    Cursor = Cursors.Arrow;
                }
                bCanSwitch = value;
            }
        }

        private bool bOn = false;
        public bool On {
            get { return bOn; }
            set {
                ThicknessAnimation _marginAnim;
                ColorAnimation _colorAnim;
                Duration _timeAnim = new Duration(TimeSpan.FromMilliseconds(120));
                if (value) {
                    _marginAnim = new ThicknessAnimation(new Thickness(BorderSwitcher.Width - BorderSwitcher.Padding.Left * 2 - EllipseSwitcher.Width, 0, 0, 0), _timeAnim);
                    _colorAnim = new ColorAnimation(new SolidColorBrush(Color.FromRgb(30, 215, 96)).Color, _timeAnim);
                } else {
                    _marginAnim = new ThicknessAnimation(new Thickness(0), _timeAnim);
                    _colorAnim = new ColorAnimation(new SolidColorBrush(Color.FromRgb(238, 238, 238)).Color, _timeAnim);
                }
                EllipseSwitcher.BeginAnimation(MarginProperty, _marginAnim);
                BorderSwitcher.Background.BeginAnimation(SolidColorBrush.ColorProperty, _colorAnim);
                bOn = value;

                StateChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public Switcher() {
            InitializeComponent();
        }

        private void this_MouseDown(object sender, MouseButtonEventArgs e) {
            if (CanSwitch) On = !On;
        }
    }
}
