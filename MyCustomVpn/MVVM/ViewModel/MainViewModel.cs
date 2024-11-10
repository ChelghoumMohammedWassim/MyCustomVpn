using MyCustomVpn.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyCustomVpn.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {

        /* Commandes */

        public RelayCommand MoveWindowCommand  { get; set; }
        public RelayCommand ShutdownWindowCommand  { get; set; }
        public RelayCommand MaximizeWindowCommand  { get; set; }
        public RelayCommand MinimizeWindowCommand  { get; set; }
        public RelayCommand ShowProtectionViewCommand  { get; set; }
        public RelayCommand ShowSettingsViewCommand { get; set; }

        public object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value;
                OnPropertyChange();
            }
        }


        public ProtectionViewModel ProtectionVM { get; set; }
        public SettingsViewModel SettingsVM { get; set; }

        public MainViewModel()
        {

            ProtectionVM = new ProtectionViewModel();
            SettingsVM = new SettingsViewModel();

            _currentView = ProtectionVM;

            Application.Current.MainWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

            MoveWindowCommand = new RelayCommand(o => { Application.Current.MainWindow.DragMove(); });

            ShutdownWindowCommand = new RelayCommand(o => {
                var process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
                process.StartInfo.Arguments = "/C rasdial /d";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                process.Start();
                process.WaitForExit();
                Application.Current.Shutdown();
            });

            MaximizeWindowCommand = new RelayCommand(o =>
            {
                if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
                {
                    Application.Current.MainWindow.WindowState = WindowState.Normal;
                }
                else
                {
                    Application.Current.MainWindow.WindowState = WindowState.Maximized;
                }
            });

            MinimizeWindowCommand = new RelayCommand(o => { Application.Current.MainWindow.WindowState = WindowState.Minimized; });
            
            ShowProtectionViewCommand = new RelayCommand(o => { CurrentView = ProtectionVM;  });

            ShowSettingsViewCommand = new RelayCommand(o => { CurrentView = SettingsVM;  });



        }
    }
}
