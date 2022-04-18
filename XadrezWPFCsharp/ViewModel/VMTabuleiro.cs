using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using XadrezWPFCsharp.Model;

namespace XadrezWPFCsharp.ViewModel
{
    public class VMTabuleiro
    {
        public List<Peca> pecas = new List<Peca>();
        Tabuleiro tab = new Tabuleiro();
        Peca peca = new Peca();
        bool emEspera = false;
        Peca pecaSelecionada = new Peca();
        Peca pecaDestino = new Peca();

        int sizeTabuleiro = 48;
        BitmapImage peaoGray = new BitmapImage(new Uri("Pictures/peaoGray.png", UriKind.Relative));
        BitmapImage peaoBege = new BitmapImage(new Uri("Pictures/peaoBege.png", UriKind.Relative));
        BitmapImage torreBege = new BitmapImage(new Uri("Pictures/torreBege.png", UriKind.Relative));
        BitmapImage torreGray = new BitmapImage(new Uri("Pictures/torreGray.png", UriKind.Relative));
        BitmapImage bispoGray = new BitmapImage(new Uri("Pictures/bispoGray.png", UriKind.Relative));
        BitmapImage bispoBege = new BitmapImage(new Uri("Pictures/bispoBege.png", UriKind.Relative));
        BitmapImage cavaloBege = new BitmapImage(new Uri("Pictures/cavaloBege.png", UriKind.Relative));
        BitmapImage cavaloGray = new BitmapImage(new Uri("Pictures/cavaloGray.png", UriKind.Relative));
        BitmapImage reiBege = new BitmapImage(new Uri("Pictures/reiBege.png", UriKind.Relative));
        BitmapImage reiGray = new BitmapImage(new Uri("Pictures/reiGray.png", UriKind.Relative));
        BitmapImage rainhaBege = new BitmapImage(new Uri("Pictures/rainhaBege.png", UriKind.Relative));
        BitmapImage rainhaGray = new BitmapImage(new Uri("Pictures/rainhaGray.png", UriKind.Relative));

        public void DesenharTabuleiro(Canvas canvas)
        {
            bool doneDrawingBackground = false;
            int nextX = 0, nextY = 0;
            int rowCounter = 0;
            int columnCounter = 0;
            bool nextIsOdd = false;
            try
            {
                while (doneDrawingBackground == false)
                {
                    Rectangle rect = new Rectangle
                    {
                        Width = sizeTabuleiro,
                        Height = sizeTabuleiro,
                        Fill = nextIsOdd == true ? Brushes.Black : Brushes.White
                    };

                    canvas.Children.Add(rect);
                    Canvas.SetTop(rect, nextY);
                    Canvas.SetLeft(rect, nextX);

                    nextIsOdd = !nextIsOdd;

                    nextX += sizeTabuleiro;
                    columnCounter++;

                    if (nextX >= canvas.ActualWidth)
                    {
                        nextX = 0;
                        nextY += sizeTabuleiro;
                        rowCounter++;
                        nextIsOdd = (rowCounter % 2 != 0);
                    }
                    else
                    {

                    }
                    doneDrawingBackground = rowCounter >= 8 ? true : false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void PosicionarPecas(Canvas canvas)
        {
            AtribuiIcones();
            try
            {
                foreach (Peca peca in pecas)
                {
                    if (peca.UiElement == null)
                    {
                        if ((peca.Nome == "P") && peca.Status == true)
                        {
                            if (peca.Cor == Brushes.Gray)
                            {
                                Image img = new Image();
                                img.Source = peaoGray;
                                peca.UiElement = new Button()
                                {
                                    
                                    Width = sizeTabuleiro,
                                    Height = sizeTabuleiro,
                                    Content = img,
                                    Background = Brushes.Transparent,
                                    Foreground = Brushes.Red

                                };

                                if (peca.UiElement is Button)
                                {
                                    (peca.UiElement as Button).Click += VMTabuleiro_Click;

                                }
                            }
                            else
                            {
                                peca.UiElement = new Button()
                                {
                                    //Source = peaoBege,
                                    Width = sizeTabuleiro,
                                    Height = sizeTabuleiro,
                                    Content = "P",
                                    Background = Brushes.Transparent,
                                    Foreground = Brushes.Green
                                };

                                if (peca.UiElement is Button)
                                {
                                    (peca.UiElement as Button).Click += VMTabuleiro_Click;

                                }
                            }
                        }

                        if ((peca.Nome == "T") && peca.Status == true)
                        {
                            if (peca.Cor == Brushes.Gray)
                            {
                                peca.UiElement = new Button()
                                {
                                    //Source = torreGray,
                                    Width = sizeTabuleiro,
                                    Height = sizeTabuleiro,
                                    Content = "T",
                                    Background = Brushes.Transparent,
                                    Foreground = Brushes.Red
                                };

                                if (peca.UiElement is Button)
                                {
                                    (peca.UiElement as Button).Click += VMTabuleiro_Click;

                                }
                            }
                            else
                            {
                                peca.UiElement = new Button()
                                {
                                    //Source = torreBege,
                                    Width = sizeTabuleiro,
                                    Height = sizeTabuleiro,
                                    Content = "T",
                                    Background = Brushes.Transparent,
                                    Foreground = Brushes.Green
                                };

                                if (peca.UiElement is Button)
                                {
                                    (peca.UiElement as Button).Click += VMTabuleiro_Click;

                                }
                            }

                        }

                        if ((peca.Nome == "B") && peca.Status == true)
                        {
                            if (peca.Cor == Brushes.Gray)
                            {
                                peca.UiElement = new Button()
                                {
                                    //Source = bispoGray,
                                    Width = sizeTabuleiro,
                                    Height = sizeTabuleiro,
                                    Content = "B",
                                    Background = Brushes.Transparent,
                                    Foreground = Brushes.Red
                                };

                                if (peca.UiElement is Button)
                                {
                                    (peca.UiElement as Button).Click += VMTabuleiro_Click;

                                }
                            }
                            else
                            {
                                peca.UiElement = new Button()
                                {
                                    //Source = bispoBege,
                                    Width = sizeTabuleiro,
                                    Height = sizeTabuleiro,
                                    Content = "B",
                                    Background = Brushes.Transparent,
                                    Foreground = Brushes.Green
                                };

                                if (peca.UiElement is Button)
                                {
                                    (peca.UiElement as Button).Click += VMTabuleiro_Click;

                                }
                            }

                        }

                        if ((peca.Nome == "C") && peca.Status == true)
                        {
                            if (peca.Cor == Brushes.Gray)
                            {
                                peca.UiElement = new Button()
                                {
                                    //Source = cavaloGray,
                                    Width = sizeTabuleiro,
                                    Height = sizeTabuleiro,
                                    Content = "C",
                                    Background = Brushes.Transparent,
                                    Foreground = Brushes.Red
                                };

                                if (peca.UiElement is Button)
                                {
                                    (peca.UiElement as Button).Click += VMTabuleiro_Click;

                                }
                            }
                            else
                            {
                                peca.UiElement = new Button()
                                {
                                    //Source = cavaloBege,                                    
                                    Width = sizeTabuleiro,
                                    Height = sizeTabuleiro,
                                    Content = "C",
                                    Background = Brushes.Transparent,
                                    Foreground = Brushes.Green
                                };

                                if (peca.UiElement is Button)
                                {
                                    (peca.UiElement as Button).Click += VMTabuleiro_Click;

                                }

                            }
                        }
                        if ((peca.Nome == "RE") && peca.Status == true)
                        {
                            if (peca.Cor == Brushes.Gray)
                            {
                                peca.UiElement = new Button()
                                {
                                    //Source = reiGray,
                                    Width = sizeTabuleiro,
                                    Height = sizeTabuleiro,
                                    Content = "RE",
                                    Background = Brushes.Transparent,
                                    Foreground = Brushes.Red
                                };

                                if (peca.UiElement is Button)
                                {
                                    (peca.UiElement as Button).Click += VMTabuleiro_Click;

                                }
                            }
                            else
                            {
                                peca.UiElement = new Button()
                                {
                                    //Source = reiBege,
                                    Width = sizeTabuleiro,
                                    Height = sizeTabuleiro,
                                    Content = "RE",
                                    Background = Brushes.Transparent,
                                    Foreground = Brushes.Green
                                };

                                if (peca.UiElement is Button)
                                {
                                    (peca.UiElement as Button).Click += VMTabuleiro_Click;

                                }
                            }

                        }
                        if ((peca.Nome == "RA") && peca.Status == true)
                        {
                            if (peca.Cor == Brushes.Gray)
                            {
                                peca.UiElement = new Button()
                                {
                                    //Source = rainhaGray,
                                    Width = sizeTabuleiro,
                                    Height = sizeTabuleiro,
                                    Content = "RA",
                                    Background = Brushes.Transparent,
                                    Foreground = Brushes.Red
                                };

                                if (peca.UiElement is Button)
                                {
                                    (peca.UiElement as Button).Click += VMTabuleiro_Click;

                                }
                            }
                            else
                            {
                                peca.UiElement = new Button()
                                {
                                    //Source = rainhaBege,
                                    Width = sizeTabuleiro,
                                    Height = sizeTabuleiro,
                                    Content = "RA",
                                    Background = Brushes.Transparent,
                                    Foreground = Brushes.Green
                                };

                                if (peca.UiElement is Button)
                                {
                                    (peca.UiElement as Button).Click += VMTabuleiro_Click;

                                }
                            }

                        }
                    }
                    canvas.Children.Add(peca.UiElement);
                    Canvas.SetTop(peca.UiElement, peca.Posicao.Y);
                    Canvas.SetLeft(peca.UiElement, peca.Posicao.X);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void VMTabuleiro_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AtribuiIcones()
        {
            try
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (j == 1)
                            pecas.Add(new Peao() { Nome = "P", Cor = Brushes.Gray, Posicao = new Point(i * sizeTabuleiro, j * sizeTabuleiro), Status = true });
                        if ((j == 0) && (i == 0) || (j == 0) && (i == 7))
                            pecas.Add(new Torre() { Nome = "T", Cor = Brushes.Gray, Posicao = new Point(i * sizeTabuleiro, j * sizeTabuleiro), Status = true });
                        if ((j == 0) && (i == 1) || (j == 0) && (i == 6))
                            pecas.Add(new Cavalo() { Nome = "C", Cor = Brushes.Gray, Posicao = new Point(i * sizeTabuleiro, j * sizeTabuleiro), Status = true });
                        if ((j == 0) && (i == 2) || (j == 0) && (i == 5))
                            pecas.Add(new Bispo() { Nome = "B", Cor = Brushes.Gray, Posicao = new Point(i * sizeTabuleiro, j * sizeTabuleiro), Status = true });
                        if ((j == 0) && (i == 3))
                            pecas.Add(new Rei() { Nome = "RE", Cor = Brushes.Gray, Posicao = new Point(i * sizeTabuleiro, j * sizeTabuleiro), Status = true });
                        if ((j == 0) && (i == 4))
                            pecas.Add(new Rainha() { Nome = "RA", Cor = Brushes.Gray, Posicao = new Point(i * sizeTabuleiro, j * sizeTabuleiro), Status = true });

                        if (j == 6)
                            pecas.Add(new Peao() { Nome = "P", Cor = Brushes.Beige, Posicao = new Point(i * sizeTabuleiro, j * sizeTabuleiro), Status = true });
                        if ((j == 7) && (i == 0) || (j == 7) && (i == 7))
                            pecas.Add(new Torre() { Nome = "T", Cor = Brushes.Beige, Posicao = new Point(i * sizeTabuleiro, j * sizeTabuleiro), Status = true });
                        if ((j == 7) && (i == 1) || (j == 7) && (i == 6))
                            pecas.Add(new Cavalo() { Nome = "C", Cor = Brushes.Beige, Posicao = new Point(i * sizeTabuleiro, j * sizeTabuleiro), Status = true });
                        if ((j == 7) && (i == 2) || (j == 7) && (i == 5))
                            pecas.Add(new Bispo() { Nome = "B", Cor = Brushes.Beige, Posicao = new Point(i * sizeTabuleiro, j * sizeTabuleiro), Status = true });
                        if ((j == 7) && (i == 4))
                            pecas.Add(new Rei() { Nome = "RE", Cor = Brushes.Beige, Posicao = new Point(i * sizeTabuleiro, j * sizeTabuleiro), Status = true });
                        if ((j == 7) && (i == 3))
                            pecas.Add(new Rainha() { Nome = "RA", Cor = Brushes.Beige, Posicao = new Point(i * sizeTabuleiro, j * sizeTabuleiro), Status = true });
                        else
                        {
                            pecas.Add(new Peca()
                            {
                                UiElement = new Button()
                                {
                                    Width = sizeTabuleiro,
                                    Height = sizeTabuleiro,
                                    Content = "",
                                    Background = Brushes.Transparent,
                                },
                                Posicao = new Point(i * sizeTabuleiro, j * sizeTabuleiro),
                                Status = true
                            });
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ClickBotao(MouseEventArgs e, Canvas canva)
        {
            if (!emEspera)
            {
                Point pecaClick = new Point();

                foreach (Peca peca in pecas)
                {
                    if ((peca.Posicao.X == 5) && (peca.Posicao.Y == 5))
                    {
                        pecaClick = e.GetPosition(peca as IInputElement);
                    }
                }

                for (int i = 0; i < pecas.Count; i++)
                {
                    if (pecas[i].Posicao == pecaClick)
                    {
                        pecaSelecionada = pecas[i];
                        emEspera = true;
                    }
                }
            }
            else
            {
                Point click = new Point();

                foreach (Peca peca in pecas)
                {
                    if ((peca.Posicao.X == 0) && (peca.Posicao.Y == 0))
                    {
                        click = e.GetPosition(peca as IInputElement);
                    }
                }

                for (int i = 0; i < pecas.Count; i++)
                {
                    if (pecas[i].Posicao == click)
                    {
                        pecaDestino = pecas[i];
                    }
                }

                if (pecaDestino == null)
                {
                    switch (pecaSelecionada.Nome)
                    {
                        case "P":
                            for (int i = 0; i < pecas.Count; i++)
                            {
                                if (pecaSelecionada.Posicao == pecas[i].Posicao)
                                {
                                    pecas[i].Posicao = click;
                                }
                            }
                            emEspera = false;
                            PosicionarPecas(canva);
                            break;
                        case "T":
                            for (int i = 0; i < pecas.Count; i++)
                            {
                                if (pecaSelecionada.Posicao == pecas[i].Posicao)
                                {
                                    pecas[i].Posicao = click;
                                }
                            }
                            emEspera = false;
                            PosicionarPecas(canva);
                            break;
                        case "C":
                            for (int i = 0; i < pecas.Count; i++)
                            {
                                if (pecaSelecionada.Posicao == pecas[i].Posicao)
                                {
                                    pecas[i].Posicao = click;
                                }
                            }
                            emEspera = false;
                            PosicionarPecas(canva);
                            break;
                        case "B":
                            for (int i = 0; i < pecas.Count; i++)
                            {
                                if (pecaSelecionada.Posicao == pecas[i].Posicao)
                                {
                                    pecas[i].Posicao = click;
                                }
                            }
                            emEspera = false;
                            PosicionarPecas(canva);
                            break;
                        case "RE":
                            for (int i = 0; i < pecas.Count; i++)
                            {
                                if (pecaSelecionada.Posicao == pecas[i].Posicao)
                                {
                                    pecas[i].Posicao = click;
                                }
                            }
                            emEspera = false;
                            PosicionarPecas(canva);
                            break;
                        case "RA":
                            for (int i = 0; i < pecas.Count; i++)
                            {
                                if (pecaSelecionada.Posicao == pecas[i].Posicao)
                                {
                                    pecas[i].Posicao = click;
                                }
                            }
                            emEspera = false;
                            PosicionarPecas(canva);
                            break;
                    }
                }
            }
        }
    }
}
