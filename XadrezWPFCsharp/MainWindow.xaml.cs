using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using XadrezWPFCsharp.ViewModel;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;

namespace XadrezWPFCsharp
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        VMTabuleiro vm = new VMTabuleiro();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            vm.DesenharTabuleiro(TabuleiroJogo);
            vm.PosicionarPecas(TabuleiroJogo);
        }

        private void Window_MouseDown(object sender, MouseEventArgs e)
        {
            vm.ClickBotao(e, TabuleiroJogo);
        }
    }
}
