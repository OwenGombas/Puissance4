using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Puissance4 {
    public class IA {
        public bool On { get; set; } = false;

        public void Play(Case[,] _tCases, int Align) {
            int max = -10000;
            int maxx = 0;
            int maxy = 0;

            for(int x = _tCases.GetLength(0) - 1; x >= 0; x--) {
                for (int y = _tCases.GetLength(1) - 1; y >= 0; y--) {
                    if (_tCases[x, y].Clicker <= 0) {
                        _tCases[x, y].BorderBrush = Brushes.Red;
                        //    _tCases[x, y].Clicker = 2;
                        //    int min = Min(_tCases, Align);

                        //    if (min > max) {
                        //        max = min;
                        //        maxx = x;
                        //        maxy = y;
                        //    }
                        //    _tCases[x, y].Clicker = 0;
                        //}
                    }
                }
            }
            _tCases[maxx, maxy].Clicker = 2;
        }

        private int Min(Case[,] _tCases, int Align) {
            if (Align == 0 || Win(_tCases))
                return Test(_tCases);

            int min = 10000;

            for (int x = _tCases.GetLength(0) - 1; x >= 0; x--) {
                for (int y = _tCases.GetLength(1) - 1; y >= 0; y--) {
                    if (_tCases[x, y].Clicker <= 0) {
                        _tCases[x, y].Clicker = 2;
                        int max = Max(_tCases, Align - 1);
                        if (max < min)
                            min = max;
                        _tCases[x, y].Clicker = 0;
                    }
                }
            }
            return min;
        }

        private int Max(Case[,] _tCases, int Align) {
            if (Align == 0 || Win(_tCases))
                return Test(_tCases);

            int max = -10000;

            for (int x = _tCases.GetLength(0) - 1; x >= 0; x--) {
                for (int y = _tCases.GetLength(1) - 1; y >= 0; y--) {
                    if (_tCases[x, y].Clicker <= 0) {
                        _tCases[x, y].Clicker = 1;
                        int min = Min(_tCases, Align - 1);
                        if (min > max)
                            max = min;
                        _tCases[x, y].Clicker = 0;
                    }
                }
            }
            return max;
        }

        private int Test(Case[,] _tCases) {
            throw new NotImplementedException();
        }

        private bool Win(Case[,] _tCases) {
            throw new NotImplementedException();
        }
    }
}
