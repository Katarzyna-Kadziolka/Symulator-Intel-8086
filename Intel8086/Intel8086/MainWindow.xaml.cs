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
using Intel8086.Enums;


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
            FunctionsComboBoxesActive();
            FunctionComboBox.ItemsSource = Enum.GetValues(typeof(BasicOperations));
        }

        private void FunctionsComboBoxesActive() {
            FunctionComboBox.IsEnabled = true;
            ToComboBox.IsEnabled = true;
            FromCombobox.IsEnabled = true;
        }

        private void BasicMemoryTextBoxesInsertStartValues() {
            AhTextBox.Text = "00";
            BhTextBox.Text = "00";
            ChTextBox.Text = "00";
            DhTextBox.Text = "00";

            AlTextBox.Text = "00";
            BlTextBox.Text = "00";
            ClTextBox.Text = "00";
            DlTextBox.Text = "00";
        }

        private void BasicMemoryTextBoxesActive() {
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

        private void ATextBox_OnTextChanged(object sender, TextChangedEventArgs e) {
            AxTextBox.Text = $"{AhTextBox.Text} {AlTextBox.Text}";
        }

        private void BTextBox_OnTextChanged(object sender, TextChangedEventArgs e) {
            BxTextBox.Text = $"{BhTextBox.Text} {BlTextBox.Text}";
        }

        private void CTextBox_OnTextChanged(object sender, TextChangedEventArgs e) {
            CxTextBox.Text = $"{ChTextBox.Text} {ClTextBox.Text}";
        }

        private void DTextBox_OnTextChanged(object sender, TextChangedEventArgs e) {
            DxTextBox.Text = $"{DhTextBox.Text} {DlTextBox.Text}";
        }
    }
}