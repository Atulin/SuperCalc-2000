using System;
using System.Collections.Generic;
using System.Data;
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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string math = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        // Titlebar buttons
        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        // Drag window
        private void Label_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            this.ResizeMode = ResizeMode.NoResize;
        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {
            this.ResizeMode = ResizeMode.CanResizeWithGrip;
        }

        // Buttonz
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            switch (((Button)sender).Content)
            {
                case "CE":
                    math = "";
                    TblOutput.Text = "";
                    break;
                case "DEL":
                    if (math != "")
                        math = math.Remove(math.Length - 1);
                    TblOutput.Text = math;
                    break;
                case "=":
                    math = math.Replace(',', '.');
                    math = new DataTable().Compute(math, null).ToString();
                    TblOutput.Text = math;
                    break;
                default:
                    math += ((Button)sender).Content;
                    TblOutput.Text = math;
                    break;
            }

        }
    }
}
