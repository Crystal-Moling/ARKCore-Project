using System.ComponentModel;
using RMA70_LauncherLib.CoreIO;

namespace RMA70_LauncherExampleWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeIO();
        }

        public void InitializeIO()
        {
            JavaListBox.ItemsSource = IO.LocateJava();
            VersionListBox.ItemsSource = IO.LocateMinecraft(".minecraft");
        }
    }
}