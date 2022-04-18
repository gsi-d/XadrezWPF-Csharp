using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace XadrezWPFCsharp.Model
{
    public class Peca
    {
        public string Nome { get; set; }
        public UIElement UiElement { get; set; }
        public Brush Cor { get; set; }
        public Point Posicao { get; set; }
        public bool Status { get; set; }
        public int Movimentos { get; set; }
    }
}
