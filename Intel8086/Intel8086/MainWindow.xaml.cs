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


namespace Intel8086 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow {
        public MainWindow() {
            InitializeComponent();
            this.Closed += (sender, args) =>  Application.Current.Shutdown();
        }


        private void BasicOperationsRadioButton_OnChecked(object sender, RoutedEventArgs e) {
            BasicMemoryTextBoxesActive();
            BasicMemoryTextBoxesInsertStartValues();

        }

        private void BasicMemoryTextBoxesInsertStartValues() {
            AxTextBox.Text = "00 00";
            BxTextBox.Text = "00 00";
            CxTextBox.Text = "00 00";
            DxTextBox.Text = "00 00";
        }

        private void BasicMemoryTextBoxesActive() {
            AxTextBox.IsEnabled = true;
            BxTextBox.IsEnabled = true;
            CxTextBox.IsEnabled = true;
            DxTextBox.IsEnabled = true;

            AhTextBox.IsEnabled = true;
            BhTextBox.IsEnabled = true;
            ChTextBox.IsEnabled = true;
            DhTextBox.IsEnabled = true;

            AlTextBox.IsEnabled = true;
            BlTextBox.IsEnabled = true;
            ClTextBox.IsEnabled = true;
            DlTextBox.IsEnabled = true;
        }

        private void RandomButton_OnClick(object sender, RoutedEventArgs e) {
            throw new NotImplementedException();
        }
    }
}