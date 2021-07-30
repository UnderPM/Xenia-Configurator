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

namespace Xenia_Configurator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Toml toml = new Toml();
        
        private void MenuFileLoad(object sender, RoutedEventArgs eventArgs)
        {
            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();
            fileDialog.Filter = "Xenia Config Files|*.config.toml";
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Xenia";
            if (fileDialog.ShowDialog() == true)
            {
                toml.Read(fileDialog.FileName);
                MessageBox.Show(toml.GetTest());
            }
            MessageBox.Show(fileDialog.InitialDirectory);
        }
    }
}
