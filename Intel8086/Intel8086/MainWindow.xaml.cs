using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Intel8086.Enums;


namespace Intel8086 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow {
        public List<MemoryCell> MemoryCells { get; set; }

        public MainWindow() {
            InitializeComponent();
            this.Closed += (sender, args) => Application.Current.Shutdown();
        }


        private void BasicOperationsRadioButton_OnChecked(object sender, RoutedEventArgs e) {
            HideAddresingModeElements();
            DeactivateMemoryOperationsElements();
            ActivateBasicMemoryTextBoxes();
            SetDefaultValuesIntoBasicMemoryTextBoxes();
            FunctionsComboBoxesActive();
            FunctionComboBox.ItemsSource = Enum.GetValues(typeof(BasicOperations));
            ToComboBox.ItemsSource = Enum.GetValues(typeof(Registers));
            FromCombobox.ItemsSource = Enum.GetValues(typeof(Registers));
        }

        private void MemoryOperationsRadioButton_OnChecked(object sender, RoutedEventArgs e) {
            ExecuteButton.IsEnabled = false;
            FunctionComboBox.IsEnabled = false;
            ToComboBox.IsEnabled = false;
            FromCombobox.IsEnabled = false;
            AddressingModeTextBlock.Visibility = Visibility.Visible;
            AddressingModeComboBox.Visibility = Visibility.Visible;
            DispTextBlock.Visibility = Visibility.Visible;
            DispTextBox.Visibility = Visibility.Visible;
        }

        private void DeactivateMemoryOperationsElements() {
            DiTextBox.IsEnabled = false;
            SiTextBox.IsEnabled = false;
            BpTextBox.IsEnabled = false;
        }

        private void HideAddresingModeElements() {
            AddressingModeComboBox.Visibility = Visibility.Hidden;
            AddressingModeTextBlock.Visibility = Visibility.Hidden;
            DispTextBlock.Visibility = Visibility.Hidden;
            DispTextBox.Visibility = Visibility.Hidden;
        }

        private void FunctionsComboBoxesActive() {
            FunctionComboBox.IsEnabled = true;
            ToComboBox.IsEnabled = true;
            FromCombobox.IsEnabled = true;
        }

        private void SetDefaultValuesIntoBasicMemoryTextBoxes() {
            AhTextBox.Text = "00";
            BhTextBox.Text = "00";
            ChTextBox.Text = "00";
            DhTextBox.Text = "00";

            AlTextBox.Text = "00";
            BlTextBox.Text = "00";
            ClTextBox.Text = "00";
            DlTextBox.Text = "00";
        }

        private void ActivateBasicMemoryTextBoxes() {
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
            if (BasicOperationsRadioButton.IsChecked == true) {
                var fromValue = (Registers) FromCombobox.SelectedItem;
                var toValue = (Registers) ToComboBox.SelectedItem;
                var function = (BasicOperations) FunctionComboBox.SelectedItem;
                var textBoxes = GetBasicOperationsCheckedTextBoxes(fromValue, toValue);
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

            else if (MemoryOperationsRadioButton.IsChecked == true) {
                MemoryButton.IsEnabled = true;
                TextBox[] textBoxes;
                var function = (BasicOperations) FunctionComboBox.SelectedItem;
                if (Equals(AddressingModeComboBox.ItemsSource, Enum.GetValues(typeof(BaseAddresses)))) {
                    var fromValue = (BaseAddresses) FromCombobox.SelectedItem;
                    var toValue = (BaseAddresses) ToComboBox.SelectedItem;
                    textBoxes = GetMemoryOperationsWithBaseAddressesTypeCheckedTextBoxes(toValue, fromValue);
                }
                else if (Equals(AddressingModeComboBox.ItemsSource, Enum.GetValues(typeof(IndexAddresses)))) {
                    var fromValue = (IndexAddresses) FromCombobox.SelectedItem;
                    var toValue = (IndexAddresses) ToComboBox.SelectionBoxItem;
                    textBoxes = GetMemoryOperationsWithIndexAddressTypeCheckedTextBoxes(toValue, fromValue);
                }
                else if (Equals(AddressingModeComboBox.ItemsSource, Enum.GetValues(typeof(IndexBaseAddresses)))) {
                    var fromValue = (IndexBaseAddresses) FromCombobox.SelectedItem;
                    var toValue = (IndexBaseAddresses) ToComboBox.SelectionBoxItem;
                    textBoxes = GetMemoryOperationsWithIndexBaseAddressTypeCheckedTextBoxes(toValue, fromValue);
                }

                switch (function) {
                    case BasicOperations.MOV:
                        break;
                    case BasicOperations.ECHG:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }


        private void AddressingModeComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            ActivateBasicMemoryTextBoxes();
            SetDefaultValuesIntoBasicMemoryTextBoxes();
            FunctionsComboBoxesActive();
            FunctionComboBox.ItemsSource = Enum.GetValues(typeof(BasicOperations));
            ExecuteButton.IsEnabled = true;
            var checkedAddressingMode = (AddressingModes) AddressingModeComboBox.SelectedItem;
            switch (checkedAddressingMode) {
                case AddressingModes.Index:
                    BpTextBox.IsEnabled = false;
                    DiTextBox.IsEnabled = true;
                    SiTextBox.IsEnabled = true;
                    ToComboBox.ItemsSource = Enum.GetValues(typeof(IndexAddresses));
                    FromCombobox.ItemsSource = Enum.GetValues(typeof(IndexAddresses));
                    break;
                case AddressingModes.Base:
                    DiTextBox.IsEnabled = false;
                    SiTextBox.IsEnabled = false;
                    BpTextBox.IsEnabled = true;
                    ToComboBox.ItemsSource = Enum.GetValues(typeof(BaseAddresses));
                    FromCombobox.ItemsSource = Enum.GetValues(typeof(BaseAddresses));
                    break;
                case AddressingModes.IndexBase:
                    DiTextBox.IsEnabled = true;
                    SiTextBox.IsEnabled = true;
                    BpTextBox.IsEnabled = true;
                    ToComboBox.ItemsSource = Enum.GetValues(typeof(IndexBaseAddresses));
                    FromCombobox.ItemsSource = Enum.GetValues(typeof(IndexBaseAddresses));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void MemoryButton_OnClick(object sender, RoutedEventArgs e) {
            MemoryCellsWindow window = new MemoryCellsWindow(MemoryCells);
            window.Show();
        }

        private TextBox[] GetMemoryOperationsWithIndexBaseAddressTypeCheckedTextBoxes(IndexBaseAddresses toValue,
            IndexBaseAddresses fromValue) {
            TextBox toTextBox = toValue switch {
                IndexBaseAddresses.BP => BpTextBox,
                IndexBaseAddresses.DI => DiTextBox,
                IndexBaseAddresses.SI => SiTextBox,
                IndexBaseAddresses.AX => AxTextBox,
                IndexBaseAddresses.BX => BxTextBox,
                IndexBaseAddresses.CX => CxTextBox,
                IndexBaseAddresses.DX => DxTextBox,
                IndexBaseAddresses.AH => AhTextBox,
                IndexBaseAddresses.BH => BhTextBox,
                IndexBaseAddresses.CH => ChTextBox,
                IndexBaseAddresses.DH => DhTextBox,
                IndexBaseAddresses.AL => AlTextBox,
                IndexBaseAddresses.BL => BlTextBox,
                IndexBaseAddresses.CL => ClTextBox,
                IndexBaseAddresses.DL => DlTextBox,
                _ => throw new ArgumentOutOfRangeException(nameof(toValue), toValue, null)
            };
            TextBox fromTextBox = fromValue switch {
                IndexBaseAddresses.BP => BpTextBox,
                IndexBaseAddresses.DI => DiTextBox,
                IndexBaseAddresses.SI => SiTextBox,
                IndexBaseAddresses.AX => AxTextBox,
                IndexBaseAddresses.BX => BxTextBox,
                IndexBaseAddresses.CX => CxTextBox,
                IndexBaseAddresses.DX => DxTextBox,
                IndexBaseAddresses.AH => AhTextBox,
                IndexBaseAddresses.BH => BhTextBox,
                IndexBaseAddresses.CH => ChTextBox,
                IndexBaseAddresses.DH => DhTextBox,
                IndexBaseAddresses.AL => AlTextBox,
                IndexBaseAddresses.BL => BlTextBox,
                IndexBaseAddresses.CL => ClTextBox,
                IndexBaseAddresses.DL => DlTextBox,
                _ => throw new ArgumentOutOfRangeException(nameof(toValue), toValue, null)
            };
            return new TextBox[2] {fromTextBox, toTextBox};
        }

        private TextBox[] GetMemoryOperationsWithIndexAddressTypeCheckedTextBoxes(IndexAddresses toValue,
            IndexAddresses fromValue) {
            TextBox toTextBox = toValue switch {
                IndexAddresses.DI => DiTextBox,
                IndexAddresses.SI => SiTextBox,
                IndexAddresses.AX => AxTextBox,
                IndexAddresses.BX => BxTextBox,
                IndexAddresses.CX => CxTextBox,
                IndexAddresses.DX => DxTextBox,
                IndexAddresses.AH => AhTextBox,
                IndexAddresses.BH => BhTextBox,
                IndexAddresses.CH => ChTextBox,
                IndexAddresses.DH => DhTextBox,
                IndexAddresses.AL => AlTextBox,
                IndexAddresses.BL => BlTextBox,
                IndexAddresses.CL => ClTextBox,
                IndexAddresses.DL => DlTextBox,
                _ => throw new ArgumentOutOfRangeException(nameof(toValue), toValue, null)
            };
            TextBox fromTextBox = fromValue switch {
                IndexAddresses.DI => DiTextBox,
                IndexAddresses.SI => SiTextBox,
                IndexAddresses.AX => AxTextBox,
                IndexAddresses.BX => BxTextBox,
                IndexAddresses.CX => CxTextBox,
                IndexAddresses.DX => DxTextBox,
                IndexAddresses.AH => AhTextBox,
                IndexAddresses.BH => BhTextBox,
                IndexAddresses.CH => ChTextBox,
                IndexAddresses.DH => DhTextBox,
                IndexAddresses.AL => AlTextBox,
                IndexAddresses.BL => BlTextBox,
                IndexAddresses.CL => ClTextBox,
                IndexAddresses.DL => DlTextBox,
                _ => throw new ArgumentOutOfRangeException(nameof(fromValue), fromValue, null)
            };
            return new TextBox[2] {fromTextBox, toTextBox};
        }

        private TextBox[] GetMemoryOperationsWithBaseAddressesTypeCheckedTextBoxes(BaseAddresses toValue,
            BaseAddresses fromValue) {
            TextBox toTextBox = toValue switch {
                BaseAddresses.BP => BpTextBox,
                BaseAddresses.AX => AxTextBox,
                BaseAddresses.BX => BxTextBox,
                BaseAddresses.CX => CxTextBox,
                BaseAddresses.DX => DxTextBox,
                BaseAddresses.AH => AhTextBox,
                BaseAddresses.BH => BhTextBox,
                BaseAddresses.CH => ChTextBox,
                BaseAddresses.DH => DhTextBox,
                BaseAddresses.AL => AlTextBox,
                BaseAddresses.BL => BlTextBox,
                BaseAddresses.CL => ClTextBox,
                BaseAddresses.DL => DlTextBox,
                _ => throw new ArgumentOutOfRangeException()
            };
            TextBox fromTextBox = fromValue switch {
                BaseAddresses.BP => BpTextBox,
                BaseAddresses.AX => AxTextBox,
                BaseAddresses.BX => BxTextBox,
                BaseAddresses.CX => CxTextBox,
                BaseAddresses.DX => DxTextBox,
                BaseAddresses.AH => AhTextBox,
                BaseAddresses.BH => BhTextBox,
                BaseAddresses.CH => ChTextBox,
                BaseAddresses.DH => DhTextBox,
                BaseAddresses.AL => AlTextBox,
                BaseAddresses.BL => BlTextBox,
                BaseAddresses.CL => ClTextBox,
                BaseAddresses.DL => DlTextBox,
                _ => throw new ArgumentOutOfRangeException()
            };
            return new TextBox[2] {fromTextBox, toTextBox};
        }

        private TextBox[] GetBasicOperationsCheckedTextBoxes(Registers fromValue, Registers toValue) {
            TextBox fromTextBox = fromValue switch {
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

            TextBox toTextBox = toValue switch {
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
    }
}
// adres efektywny (16-bitowy) i zawartość 