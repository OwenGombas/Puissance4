using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Puissance4 {
    public partial class NumberChooser : UserControl {

        public event EventHandler ValueChanged;

        public int ValueMax { get; set; }
        public int ValueMin { get; set; }

        private int iValue;
        public int Value {
            get { return iValue; }
            set {
                if (value <= ValueMax && value >= ValueMin) {
                    iValue = value;
                    lblNumber.Content = Value;
                    if(IsLoaded) ValueChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public NumberChooser() {
            InitializeComponent();
        }

        private void Polygon_MouseDown(object sender, MouseButtonEventArgs e) {
            Grid _grid = (Grid)sender;
            if (_grid.Uid == "up") Value++;
            else Value--;
        }
    }
}
