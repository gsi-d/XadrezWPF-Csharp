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
using XadrezWPFCsharp.Model;
using XadrezWPFCsharp.ViewModel;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;

namespace XadrezWPFCsharp
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        Peca peca = new Peca();
        public List<Peca> pecas = new List<Peca>();
        Tabuleiro tab = new Tabuleiro();
        bool emEspera = false;
        Peca pecaSelecionada = new Peca();
        Peca pecaDestino = new Peca();
        int contadorPecas = 0;
        bool inicio = true;

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
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Window_ContentRendered(object sender, EventArgs e)
        {
            DesenharTabuleiro(TabuleiroJogo);
            PosicionarPecas(TabuleiroJogo);
        }

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
            
            try
            {
                if (inicio)
                {
                    AtribuiIcones();
                }
                foreach (Peca peca in pecas)
                {
                    contadorPecas++;
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
                                    BorderBrush = Brushes.Transparent,
                                    TabIndex = contadorPecas,
                                    Width = sizeTabuleiro,
                                    Height = sizeTabuleiro,
                                    Content = img,
                                    Background = Brushes.Transparent,
                                    Foreground = Brushes.Red,
                                    DataContext = peca
                                };
                            }
                            else
                            {
                                Image img = new Image();
                                img.Source = peaoBege;
                                peca.UiElement = new Button()
                                {
                                    BorderBrush = Brushes.Transparent,
                                    TabIndex = contadorPecas,
                                    Width = sizeTabuleiro,
                                    Height = sizeTabuleiro,
                                    Content = img,
                                    Background = Brushes.Transparent,
                                    Foreground = Brushes.Green,
                                    DataContext = peca
                                };
                            }
                        }

                        if ((peca.Nome == "T") && peca.Status == true)
                        {
                            if (peca.Cor == Brushes.Gray)
                            {
                                Image img = new Image();
                                img.Source = torreGray;
                                peca.UiElement = new Button()
                                {
                                    BorderBrush = Brushes.Transparent,
                                    TabIndex = contadorPecas,
                                    Width = sizeTabuleiro,
                                    Height = sizeTabuleiro,
                                    Content = img,
                                    Background = Brushes.Transparent,
                                    Foreground = Brushes.Red,
                                    DataContext = peca
                                };
                            }
                            else
                            {
                                Image img = new Image();
                                img.Source = torreBege;
                                peca.UiElement = new Button()
                                {
                                    BorderBrush = Brushes.Transparent,
                                    TabIndex = contadorPecas,
                                    Width = sizeTabuleiro,
                                    Height = sizeTabuleiro,
                                    Content = img,
                                    Background = Brushes.Transparent,
                                    Foreground = Brushes.Green,
                                    DataContext = peca
                                };
                            }

                        }

                        if ((peca.Nome == "B") && peca.Status == true)
                        {
                            if (peca.Cor == Brushes.Gray)
                            {
                                Image img = new Image();
                                img.Source = bispoGray;
                                peca.UiElement = new Button()
                                {
                                    BorderBrush = Brushes.Transparent,
                                    TabIndex = contadorPecas,
                                    Width = sizeTabuleiro,
                                    Height = sizeTabuleiro,
                                    Content = img,
                                    Background = Brushes.Transparent,
                                    Foreground = Brushes.Red,
                                    DataContext = peca
                                };
                            }
                            else
                            {
                                Image img = new Image();
                                img.Source = bispoBege;
                                peca.UiElement = new Button()
                                {
                                    BorderBrush = Brushes.Transparent,
                                    TabIndex = contadorPecas,
                                    Width = sizeTabuleiro,
                                    Height = sizeTabuleiro,
                                    Content = img,
                                    Background = Brushes.Transparent,
                                    Foreground = Brushes.Green,
                                    DataContext = peca
                                };
                            }

                        }

                        if ((peca.Nome == "C") && peca.Status == true)
                        {
                            if (peca.Cor == Brushes.Gray)
                            {
                                Image img = new Image();
                                img.Source = cavaloGray;
                                peca.UiElement = new Button()
                                {
                                    BorderBrush = Brushes.Transparent,
                                    TabIndex = contadorPecas,
                                    Width = sizeTabuleiro,
                                    Height = sizeTabuleiro,
                                    Content = img,
                                    Background = Brushes.Transparent,
                                    Foreground = Brushes.Red,
                                    DataContext = peca
                                };
                            }
                            else
                            {
                                Image img = new Image();
                                img.Source = cavaloBege;
                                peca.UiElement = new Button()
                                {
                                    BorderBrush = Brushes.Transparent,
                                    TabIndex = contadorPecas,
                                    Width = sizeTabuleiro,
                                    Height = sizeTabuleiro,
                                    Content = img,
                                    Background = Brushes.Transparent,
                                    Foreground = Brushes.Green,
                                    DataContext = peca
                                };
                            }
                        }
                        if ((peca.Nome == "RE") && peca.Status == true)
                        {
                            if (peca.Cor == Brushes.Gray)
                            {
                                Image img = new Image();
                                img.Source = reiGray;
                                peca.UiElement = new Button()
                                {
                                    BorderBrush = Brushes.Transparent,
                                    TabIndex = contadorPecas,
                                    Width = sizeTabuleiro,
                                    Height = sizeTabuleiro,
                                    Content = img,
                                    Background = Brushes.Transparent,
                                    Foreground = Brushes.Red,
                                    DataContext = peca
                                };
                            }
                            else
                            {
                                Image img = new Image();
                                img.Source = reiBege;
                                peca.UiElement = new Button()
                                {
                                    BorderBrush = Brushes.Transparent,
                                    TabIndex = contadorPecas,
                                    Width = sizeTabuleiro,
                                    Height = sizeTabuleiro,
                                    Content = img,
                                    Background = Brushes.Transparent,
                                    Foreground = Brushes.Green,
                                    DataContext = peca
                                };
                            }

                        }
                        if ((peca.Nome == "RA") && peca.Status == true)
                        {
                            if (peca.Cor == Brushes.Gray)
                            {
                                Image img = new Image();
                                img.Source = rainhaGray;
                                peca.UiElement = new Button()
                                {
                                    BorderBrush = Brushes.Transparent,
                                    TabIndex = contadorPecas,
                                    Width = sizeTabuleiro,
                                    Height = sizeTabuleiro,
                                    Content = img,
                                    Background = Brushes.Transparent,
                                    Foreground = Brushes.Red,
                                    DataContext = peca
                                };
                            }
                            else
                            {
                                Image img = new Image();
                                img.Source = rainhaBege;
                                peca.UiElement = new Button()
                                {
                                    BorderBrush = Brushes.Transparent,
                                    TabIndex = contadorPecas,
                                    Width = sizeTabuleiro,
                                    Height = sizeTabuleiro,
                                    Content = img,
                                    Background = Brushes.Transparent,
                                    Foreground = Brushes.Green,
                                    DataContext = peca
                                };
                            }
                        }
                        if ((peca.Nome == "Vazio") && (peca.Status == true))
                        {
                            Image img = new Image();
                            peca.UiElement = new Button()
                            {
                                BorderBrush = Brushes.Transparent,
                                TabIndex = contadorPecas,
                                Width = sizeTabuleiro,
                                Height = sizeTabuleiro,
                                Content = "",
                                Background = Brushes.Transparent,
                                Foreground = Brushes.Green,
                                DataContext = peca
                            };
                        }
                        (peca.UiElement as Button).Click += VMTabuleiro_Click;
                    }
                    
                    canvas.Children.Add(peca.UiElement);
                    Canvas.SetTop(peca.UiElement, peca.Posicao.Y);
                    Canvas.SetLeft(peca.UiElement, peca.Posicao.X);
                }
                inicio = false;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void VMTabuleiro_Click(object sender, RoutedEventArgs e)
        {
            Button iButton = (Button)sender;
            var pecaClick = iButton.DataContext;
            var pecaRecuperada = pecaClick as Peca;
            if (!emEspera)
            {
                foreach (Peca peca in pecas)
                {
                    if (pecaRecuperada.Posicao == peca.Posicao)
                    {
                        pecaSelecionada = peca;
                        definePecasSelecionaveis();
                        emEspera = true;
                    }
                }
            }
            else
            {
                if (pecaRecuperada.Cor != pecaSelecionada.Cor)
                {
                    for(int i = 0; i < pecas.Count; i++)
                    {
                        if (pecaSelecionada.Posicao == pecas[i].Posicao)
                        {
                            pecas[i].Posicao = pecaRecuperada.Posicao;
                        }
                        if (pecaRecuperada.Posicao == pecas[i].Posicao)
                        {
                            pecas[i].Posicao = pecaSelecionada.Posicao;
                        }
                    }
                    emEspera = false;
                    TabuleiroJogo.Children.Clear();
                    DesenharTabuleiro(TabuleiroJogo);
                    PosicionarPecas(TabuleiroJogo);
                    retiraPecasSelecionaveis();
                }
            }
        }

        private void AtribuiIcones()
        {
            try
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        int nrPecas = pecas.Count;
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
                        if(nrPecas == pecas.Count)
                        {
                            pecas.Add(new Peca() { Posicao = new Point(i * sizeTabuleiro, j * sizeTabuleiro), Status = true, Nome = "Vazio", Cor = Brushes.Transparent });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void definePecasSelecionaveis()
        {
            foreach(Peca peca in pecas)
            {
                if(peca.Nome == "Vazio")
                {
                    (peca.UiElement as Button).Click += VMTabuleiro_Click;
                }
            }
        }

        private void retiraPecasSelecionaveis()
        {
            foreach (Peca peca in pecas)
            {
                if (peca.Nome == "Vazio")
                {
                    (peca.UiElement as Button).Click -= VMTabuleiro_Click;
                }
            }
        }
    }
}
