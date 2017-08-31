using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Puissance4 {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            grdGame.Initialize(nbrX.Value, nbrY.Value);
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e) {
            grdGame.Initialize(nbrX.Value, nbrY.Value);
        }

        private void cbxIA_StateChanged(object sender, EventArgs e) {
            grdGame.IAGame.On = cbxIA.On;
        }

        private void grdGame_End(object sender, string msg) {
            lblWin.Content = msg;
            grdWin.Visibility = Visibility.Visible;
            grdWin.BeginAnimation(OpacityProperty, new DoubleAnimation(.85, new Duration(TimeSpan.FromMilliseconds(200))));
        }

        private void btnOk_MouseDown(object sender, MouseButtonEventArgs e) {
            DoubleAnimation _dblAnim = new DoubleAnimation(0, new Duration(TimeSpan.FromMilliseconds(200)));
            _dblAnim.Completed += delegate { grdWin.Visibility = Visibility.Collapsed; };
            grdWin.BeginAnimation(OpacityProperty, _dblAnim);
        }

        bool bAnimFinish = true;
        private void nbr_ValueChanged(object sender, EventArgs e) {
            if(grdGame.Empty) grdGame.Initialize(nbrX.Value, nbrY.Value);
            else if(bAnimFinish){
                ColorAnimation _borderAnim = new ColorAnimation(Colors.Red, new Duration(TimeSpan.FromMilliseconds(250)));
                _borderAnim.AutoReverse = true;
                _borderAnim.Completed += delegate { bAnimFinish = true; };
                btnPlay.BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, _borderAnim);
                bAnimFinish = false;
            }
        }
    }
}
