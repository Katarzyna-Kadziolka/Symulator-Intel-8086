using System;
using System.Windows;
using System.Windows.Controls;
using Intel8086.Enums;


namespace Intel8086
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Closed += (sender, args) => Application.Current.Shutdown();
        }


        private void BasicOperationsRadioButton_OnChecked(object sender, RoutedEventArgs e)
        {
            ActivateBasicMemoryTextBoxes();
            SetDefaultValuesIntoBasicMemoryTextBoxes();
            FunctionsComboBoxesActive();
            FunctionComboBox.ItemsSource = Enum.GetValues(typeof(BasicOperations));
            ToComboBox.ItemsSource = Enum.GetValues(typeof(Registers));
            FromCombobox.ItemsSource = Enum.GetValues(typeof(Registers));
        }

        private void MemoryOperationsRadioButton_OnChecked(object sender, RoutedEventArgs e)
        {
            AddressingModeTextBlock.Visibility = Visibility.Visible;
            AddressingModeComboBox.Visibility = Visibility.Visible;
        }

        private void FunctionsComboBoxesActive()
        {
            FunctionComboBox.IsEnabled = true;
            ToComboBox.IsEnabled = true;
            FromCombobox.IsEnabled = true;
        }

        private void SetDefaultValuesIntoBasicMemoryTextBoxes()
        {
            AhTextBox.Text = "00";
            BhTextBox.Text = "00";
            ChTextBox.Text = "00";
            DhTextBox.Text = "00";

            AlTextBox.Text = "00";
            BlTextBox.Text = "00";
            ClTextBox.Text = "00";
            DlTextBox.Text = "00";
        }

        private void ActivateBasicMemoryTextBoxes()
        {
            AhTextBox.IsEnabled = true;
            BhTextBox.IsEnabled = true;
            ChTextBox.IsEnabled = true;
            DhTextBox.IsEnabled = true;

            AlTextBox.IsEnabled = true;
            BlTextBox.IsEnabled = true;
            ClTextBox.IsEnabled = true;
            DlTextBox.IsEnabled = true;
        }

        private void RandomButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ATextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            AxTextBox.Text = $"{AhTextBox.Text} {AlTextBox.Text}";
        }

        private void BTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            BxTextBox.Text = $"{BhTextBox.Text} {BlTextBox.Text}";
        }

        private void CTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            CxTextBox.Text = $"{ChTextBox.Text} {ClTextBox.Text}";
        }

        private void DTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            DxTextBox.Text = $"{DhTextBox.Text} {DlTextBox.Text}";
        }

        private void ExecuteButton_OnClick(object sender, RoutedEventArgs e)
        {
            var fromValue = (Registers) FromCombobox.SelectedItem;
            var toValue = (Registers) ToComboBox.SelectedItem;
            var function = (BasicOperations) FunctionComboBox.SelectedItem;

            if (BasicOperationsRadioButton.IsChecked == true)
            {
                var textBoxes = GetCheckedTextBoxes(fromValue, toValue);
                switch (function)
                {
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

        private TextBox[] GetCheckedTextBoxes(Registers fromValue, Registers toValue)
        {
            TextBox fromTextBox;
            TextBox toTextBox;
            fromTextBox = fromValue switch
            {
                Registers.AX => AxTextBox,
                Registers.BX => BxTextBox,
                Registers.CX => CxTextBox,
                Registers.DX => DxTextBox,
                Registers.AH => AhTextBox,
                Registers.BH => BhTextBox,
                Registers.CH => ChTextBox,
                Registers.DH => DhTextBox,
                Registers.AL => AlTextBox,
                Registers.BL => BlTextBox,
                Registers.CL => ClTextBox,
                Registers.DL => DlTextBox,
                _ => throw new ArgumentOutOfRangeException()
            };

            toTextBox = toValue switch
            {
                Registers.AX => AxTextBox,
                Registers.BX => BxTextBox,
                Registers.CX => CxTextBox,
                Registers.DX => DxTextBox,
                Registers.AH => AhTextBox,
                Registers.BH => BhTextBox,
                Registers.CH => ChTextBox,
                Registers.DH => DhTextBox,
                Registers.AL => AlTextBox,
                Registers.BL => BlTextBox,
                Registers.CL => ClTextBox,
                Registers.DL => DlTextBox,
                _ => throw new ArgumentOutOfRangeException()
            };
            return new TextBox[2] {fromTextBox, toTextBox};
        }

        private void AddressingModeComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ActivateBasicMemoryTextBoxes();
            SetDefaultValuesIntoBasicMemoryTextBoxes();
            var checkedAddressingMode = (AddressingModes) AddressingModeComboBox.SelectedItem;
            switch (checkedAddressingMode)
            {
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