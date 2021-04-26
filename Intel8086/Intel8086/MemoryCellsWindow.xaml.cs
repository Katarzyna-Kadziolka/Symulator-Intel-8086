using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Intel8086
{
    /// <summary>
    /// Interaction logic for MemoryCellsWindow.xaml
    /// </summary>
    public partial class MemoryCellsWindow 
    {
        public MemoryCellsWindow(List<MemoryCell> memoryCells)
        {
            InitializeComponent();
            this.DataContext = this;
            MemoryListView.ItemsSource = memoryCells;
        }
    }
}
