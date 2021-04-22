using System;
using System.Windows;
using System.Windows.Controls;
using Intel8086.Enums;


namespace Intel8086 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow {
        public MainWindow() {
            InitializeComponent();
            this.Closed += (sender, args) => Application.Current.Shutdown();
        }


        private void BasicOperationsRadioButton_OnChecked(object sender, RoutedEventArgs e) {
            BasicMemoryTextBoxesActive();
            BasicMemoryTextBoxesInsertStartValues();
            FunctionsComboBoxesActive();
            FunctionComboBox.ItemsSource = Enum.GetValues(typeof(BasicOperations));
            ToComboBox.ItemsSource = Enum.GetValues(typeof(Registers));
            FromCombobox.ItemsSource = Enum.GetValues(typeof(Registers));
        }
        private void MemoryOperationsRadioButton_OnChecked(object sender, RoutedEventArgs e) {
            AddressingModeTextBlock.Visibility = Visibility.Visible;
            AddressingModeComboBox.Visibility = Visibility.Visible;
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

        private void ExecuteButton_OnClick(object sender, RoutedEventArgs e) {
            var fromValue = (Registers) FromCombobox.SelectedItem;
            var toValue = (Registers) ToComboBox.SelectedItem;
            var function = (BasicOperations) FunctionComboBox.SelectedItem;

            if (BasicOperationsRadioButton.IsChecked == true) {
                var textBoxes = GetCheckedTextBoxes(fromValue, toValue);
                switch (function) {
                    case BasicOperations.MOV:
                        textBoxes[1].Text = textBoxes[0].Text;
                        break;
                    case BasicOperations.ECHG:
                        var toText = textBoxes[1].Text;
                        textBoxes[1].Text = textBoxes[0].Text;
                        textBoxes[0].Text = toText;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                

            }
        }

        private TextBox[] GetCheckedTextBoxes(Registers fromValue, Registers toValue) {
            TextBox fromTextBox;
            TextBox toTextBox;
            switch (fromValue) {
                case Registers.AX:
                    fromTextBox = AxTextBox;
                    break;
                case Registers.BX:
                    fromTextBox = BxTextBox;
                    break;
                case Registers.CX:
                    fromTextBox = CxTextBox;
                    break;
                case Registers.DX:
                    fromTextBox = DxTextBox;
                    break;
                case Registers.AH:
                    fromTextBox = AhTextBox;
                    break;
                case Registers.BH:
                    fromTextBox = BhTextBox;
                    break;
                case Registers.CH:
                    fromTextBox = ChTextBox;
                    break;
                case Registers.DH:
                    fromTextBox = DhTextBox;
                    break;
                case Registers.AL:
                    fromTextBox = AlTextBox;
                    break;
                case Registers.BL:
                    fromTextBox = BlTextBox;
                    break;
                case Registers.CL:
                    fromTextBox = ClTextBox;
                    break;
                case Registers.DL:
                    fromTextBox = DlTextBox;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            switch (toValue) {
                case Registers.AX:
                    toTextBox = AxTextBox;
                    break;
                case Registers.BX:
                    toTextBox = BxTextBox;
                    break;
                case Registers.CX:
                    toTextBox = CxTextBox;
                    break;
                case Registers.DX:
                    toTextBox = DxTextBox;
                    break;
                case Registers.AH:
                    toTextBox = AhTextBox;
                    break;
                case Registers.BH:
                    toTextBox = BhTextBox;
                    break;
                case Registers.CH:
                    toTextBox = ChTextBox;
                    break;
                case Registers.DH:
                    toTextBox = DhTextBox;
                    break;
                case Registers.AL:
                    toTextBox = AlTextBox;
                    break;
                case Registers.BL:
                    toTextBox = BlTextBox;
                    break;
                case Registers.CL:
                    toTextBox = ClTextBox;
                    break;
                case Registers.DL:
                    toTextBox = DlTextBox;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return new TextBox[2] {fromTextBox, toTextBox};
        }

        private void AddressingModeComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            BasicMemoryTextBoxesActive();
            BasicMemoryTextBoxesInsertStartValues();
            var checkedAddressingMode = (AddressingModes) AddressingModeComboBox.SelectedItem;
            switch (checkedAddressingMode) {
                case AddressingModes.Index:
                    BpTextBox.IsEnabled = false;
                    DiTextBox.IsEnabled = true;
                    SiTextBox.IsEnabled = true;
                    break;
                case AddressingModes.Base:
                    DiTextBox.IsEnabled = false;
                    SiTextBox.IsEnabled = false;
                    BpTextBox.IsEnabled = true;
                    break;
                case AddressingModes.IndexBase:
                    DiTextBox.IsEnabled = true;
                    SiTextBox.IsEnabled = true;
                    BpTextBox.IsEnabled = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}

//Taski na kiedyś:
//wyłączanie entry przy zmienie radiobutton