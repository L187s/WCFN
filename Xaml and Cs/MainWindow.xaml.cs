using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CmdExecutor
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SwitchGroup(object sender, RoutedEventArgs e)
        {
            NetzwerkGroup.Visibility = Visibility.Collapsed;
            SystemGroup.Visibility = Visibility.Collapsed;
            BenutzerverwaltungGroup.Visibility = Visibility.Collapsed;
            ProzesseGroup.Visibility = Visibility.Collapsed;
            HardwareGroup.Visibility = Visibility.Collapsed;

            if (sender is Button button && button.CommandParameter is string groupName)
            {
                switch (groupName)
                {
                    case "NetzwerkGroup":
                        NetzwerkGroup.Visibility = Visibility.Visible;
                        break;
                    case "SystemGroup":
                        SystemGroup.Visibility = Visibility.Visible;
                        break;
                    case "BenutzerverwaltungGroup":
                        BenutzerverwaltungGroup.Visibility = Visibility.Visible;
                        break;
                    case "ProzesseGroup":
                        ProzesseGroup.Visibility = Visibility.Visible;
                        break;
                    case "HardwareGroup":
                        HardwareGroup.Visibility = Visibility.Visible;
                        break;
                }
            }
        }

        private async void ExecuteCommand(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is string command)
            {
                OutputBox.Text = "Befehl wird ausgeführt...";
                OutputBox.Text = await Task.Run(() => RunCommand(command));
            }
        }

        private async void ExecuteCustomCommand(object sender, RoutedEventArgs e)
        {
            string command = CustomCommandInput.Text;
            if (!string.IsNullOrWhiteSpace(command))
            {
                OutputBox.Text = "Benutzerdefinierter Befehl wird ausgeführt...";
                OutputBox.Text = await Task.Run(() => RunCommand(command));
            }
        }

        private string RunCommand(string command)
        {
            try
            {
                ProcessStartInfo processInfo = new ProcessStartInfo("cmd.exe", "/c " + command)
                {
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                Process process = Process.Start(processInfo);
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();
                return string.IsNullOrWhiteSpace(error) ? output : $"Fehler: {error}";
            }
            catch
            {
                return "Ein Fehler ist beim Ausführen des Befehls aufgetreten.";
            }
        }
    }
}
