using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Puissance4 {
    public class Game : Grid {
        const int ALIGN = 4;
        const byte ALPHA_HOVER = 40;

        public event EventHandler<string> End;

        public List<Case> Cases { get { return Children.OfType<Case>().ToList(); } }
        public IA IAGame { get; private set; } = new IA();
        public bool PlayerOne { get; private set; } = true;
        public bool EndGame { get; private set; } = false;
        public bool Empty { get { return Cases.All(_c => _c.Clicker <= 0); } }
        public int X {
            get { return ColumnDefinitions.Count; }
            set {
                for (int x = 0; x < value; x++)
                    ColumnDefinitions.Add(new ColumnDefinition());
            }
        }
        public int Y {
            get { return RowDefinitions.Count; }
            set {
                for (int y = 0; y < value; y++)
                    RowDefinitions.Add(new RowDefinition());
            }
        }

        public void Initialize(int X, int Y) {
            EndGame = false;
            PlayerOne = true;
            Children.Clear();
            ColumnDefinitions.Clear();
            RowDefinitions.Clear();

            this.X = X;
            this.Y = Y;

            for (int x = 0; x < X; x++) {
                for (int y = 0; y < Y; y++) {
                    Case _c = new Case() {
                        X = x,
                        Y = y
                    };
                    _c.MouseDown += new MouseButtonEventHandler(c_MouseDown);
                    _c.MouseEnter += (sender, e) => { HoverCase((Case)sender); };
                    _c.MouseLeave += delegate { UnHoverCase(); };

                    Children.Add(_c);
                }
            }
        }

        private void c_MouseDown(object sender, MouseButtonEventArgs e) {
            if (!EndGame) {
                Case _case = (Case)sender;
                Case[] _tcCase = Cases.Where(_c => _c.X == _case.X && _c.Clicker <= 0).ToArray();
                Cases.ForEach(_c => _c.BorderBrush = Brushes.Transparent);
                if (_tcCase.Length > 0) {
                    _case = CaseXY(_case.X, _tcCase.Length - 1);

                    if (PlayerOne) _case.Clicker = 1;
                    else if(!IAGame.On)_case.Clicker = 2;
                    PlayerOne = !PlayerOne;
                    _case.AnimateMargin(true);
                    HoverCase(_case);

                    List<List<Case>> _lDirections = new List<List<Case>>() {
                        { Cases.Where(_c => _c.X - _case.X == _c.Y - _case.Y).ToList() },
                        { Cases.Where(_c => -(_c.X - _case.X) == _c.Y - _case.Y).ToList() },
                        { Cases.Where(_c => _c.X == _case.X).ToList() },
                        { Cases.Where(_c => _c.Y == _case.Y).ToList() }
                    };

                    foreach (List<Case> _lc in _lDirections) {
                        List<Case> _lcWin = new List<Case>();
                        foreach (Case _c in _lc) {
                            if (_c.Clicker == _case.Clicker) _lcWin.Add(_c);
                            else _lcWin.Clear();

                            if (_lcWin.Count >= ALIGN) {
                                UnHoverCase();
                                Cases.Where(_cGrid => _cGrid.Clicker > 0 && !_lcWin.Contains(_cGrid)).ToList()
                                     .ForEach(_cGrid => _cGrid.AnimateBackground(false, setAlpha(((SolidColorBrush)_cGrid.Background).Color, 50), 300));
                                GameEnd("Le joueur " + _case.Clicker + " à gagné");
                                break;
                            }
                        }
                    }
                    if (Cases.All(_c => _c.Clicker > 0)) GameEnd("Egalité");

                    //Case[,] _tCases = new Case[X, Y];

                    //foreach(Case _c in Cases) {
                    //    if (_c.Clicker <= 0) {
                    //        Case _caseDetected = CaseXY(_case.X, Cases.Where(_b => _c.X == _b.X && _b.Clicker > 0).Count() - 1);
                    //        _caseDetected.BorderBrush = Brushes.Red;
                    //        _tCases[_c.X, _caseDetected.Y] = _caseDetected;
                    //    }
                    //}

                    //if (IAGame.On) IAGame.Play(_tCases, ALIGN);
                }
            }
        }

        private Case CaseXY(int X, int Y) {
            Case _cR = Cases.FirstOrDefault(_c => _c.X == X && _c.Y == Y);

            if (_cR != null) return _cR;
            else return new Case();
        }

        private void HoverCase(Case _case) {
            CaseXY(_case.X, Cases.Where(_c => !EndGame && _c.X == _case.X && _c.Clicker <= 0).Count() - 1)
                                 .Background = new SolidColorBrush((PlayerOne) ? setAlpha(Case.ColorPlayerOne, ALPHA_HOVER) : setAlpha(Case.ColorPlayerTwo, ALPHA_HOVER));
        }

        private void UnHoverCase() {
            Cases.Where(_c => ((SolidColorBrush)(_c.Background)).Color.A == ALPHA_HOVER && _c.Clicker <= 0).ToList()
                 .ForEach(_c => _c.Background = new SolidColorBrush(Case.ColorEmpty));
        }

        public Color setAlpha(Color Color, byte Alpha) {
            Color.A = Alpha;
            return Color;
        }

        private void GameEnd(string Message) {
            if (!EndGame) {
                EndGame = true;
                End?.Invoke(this, Message);
            }
        }
    }
}
