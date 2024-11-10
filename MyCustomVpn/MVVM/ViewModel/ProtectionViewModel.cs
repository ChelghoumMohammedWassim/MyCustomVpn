using System.Text;
using System.Collections.ObjectModel;
using MyCustomVpn.MVVM.Model;
using MyCustomVpn.Core;
using System.IO;
using System.Windows;
using System.Diagnostics;

namespace MyCustomVpn.MVVM.ViewModel
{
    class ProtectionViewModel : ObservableObject
    {

        public ObservableCollection <ServerModel>  Servers { get; set; }

        private string _connectionStatus;

        public string ConnectionStatus
        {
            get { return _connectionStatus; }
            set { 
                _connectionStatus = value;
                OnPropertyChange();
                }
        }

        private string _buttonStatus;

        public string ButtonStatus
        {
            get { return _buttonStatus; }
            set
            {
                _buttonStatus = value;
                OnPropertyChange();
            }
        }


        private ServerModel _selectedServer;
        public ServerModel SelectedServer
        {
            get => _selectedServer;
            set
            {
                _selectedServer = value;
                OnPropertyChange(nameof(SelectedServer)); 
            }
        }



        public RelayCommand ConnectCommand{ get; set; }

        public ProtectionViewModel()
        {
            Servers = new ObservableCollection<ServerModel>();

            List<String> adress = new List<String> 
            {
                "CA149.vpnbook.com",
                "DE20.vpnbook.com",
                "FR200.vpnbook.com",
                "PL134.vpnbook.com",
                "UK205.vpnbook.com",
                "US16.vpnbook.com",
                "US178.vpnbook.com",
                "CA196.vpnbook.com",
                "DE220.vpnbook.com",
                "FR231.vpnbook.com",
                "PL140.vpnbook.com",
                "UK68.vpnbook.com"
            };

            for (int i = 0; i < 10; i++) 
            {
                Servers.Add(new ServerModel
                    {
                        ID = i,
                        UserName = "vpnbook",
                        Password = "e83zu76",
                        Server = adress[i],
                        Country = adress[i].Split(".")[0],

                });
            
            }

            ButtonStatus = "Connect";
            ConnectionStatus = "Disconnected";

            ConnectCommand = new RelayCommand(o => 
            {

                if (ConnectionStatus != "Connected")
                {
                    Task.Run(() =>
                    {
                        ConnectionStatus = "Connecting...";

                        ServerBuilder(SelectedServer.Server);

                        var process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
                        process.StartInfo.ArgumentList.Add(@"/c rasdial MyServer vpnbook e83zu76 /phonebook:./VPN/VPN.pbk");
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.CreateNoWindow = true;

                        process.Start();
                        process.WaitForExit();

                        switch (process.ExitCode)
                        {

                            case 0:
                                Console.WriteLine("Seccess!");
                                ConnectionStatus = "Connected";
                                ButtonStatus = "Diconnect";
                                break;

                            case 691:
                                Console.WriteLine("Wrong credentials!");
                                ConnectionStatus = "Error!!";
                                break;

                            default:
                                Console.WriteLine($"Wrong: {process.ExitCode.ToString()}");
                                break;
                        }


                    });

                }

                else
                {
                    ConnectionStatus = "Disconnecting";

                    var process = new Process();
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
                    process.StartInfo.Arguments = "/C rasdial /d";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;

                    process.Start();
                    process.WaitForExit();

                    ConnectionStatus = "Disconnected";

                    ButtonStatus = "Connect";

                }

            });
            
        }


        private void ServerBuilder(string adress)
        {
            var FolderPath = $"{Directory.GetCurrentDirectory()}/VPN";
            var PbkPath = $"{FolderPath}/VPN.pbk";

            if (!Directory.Exists(FolderPath)) 
            {
                Directory.CreateDirectory(FolderPath);
            }


            var sb = new StringBuilder();
            sb.AppendLine("[MyServer]");
            sb.AppendLine("MEDIA=rastapi");
            sb.AppendLine("Port=VPN2-0");
            sb.AppendLine("Device=WAN Miniport (IKEv2)");
            sb.AppendLine("DEVICE=vpn");
            sb.AppendLine($"PhoneNumber={adress}");
            File.WriteAllText(PbkPath, sb.ToString());

        }

    }
}
