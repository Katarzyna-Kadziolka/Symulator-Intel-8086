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
using AdonisUI.Controls;
using Intel8086.Windows;

namespace Intel8086 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow {
        public MainWindow() {
            InitializeComponent();
            this.Closed += (sender, args) =>  Application.Current.Shutdown();
        }

        private void OperationTypeButton_OnClick(object sender, RoutedEventArgs e) {
            GeneralPurposeRegistersWindow window = new GeneralPurposeRegistersWindow();
            window.Show();
        }
    }
}