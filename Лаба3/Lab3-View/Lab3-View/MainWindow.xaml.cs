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
using System.Net;
using Client;

namespace Lab3_View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int port = 600;
        Client.Client client;

        public MainWindow()
        {
            InitializeComponent();
            // Создаем экземпляр клиента
            client = new Client.Client();
            client.connectEnding = connectEnding;
            client.receivedMessage = receivedMessage;
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {           
            if(client.Send(SendMessageTextBox.Text) != 0)
            {
                ReceivedMessageTextBox.AppendText("\nПроизошла ошибка при отправке данных на сервер\n");
            }

        }

        private void ConnectDisconnectButton_Click(object sender, RoutedEventArgs e)
        {
            if (client.isConnected)
            {
                client.Disconnect();
            }
            else 
            {
                IPAddress addr = IPAddress.Parse(IpTextBox.Text);
                client.Connect(addr, port);
                client.Send(UserNameTextBox.Text);
            }    
        }

        private void connectEnding(Client.ConnectStatus connectStatus)
        {
            switch (connectStatus)
            {
                case ConnectStatus.Connected:
                    ReceivedMessageTextBox.AppendText("\nСоедниение установлено\n");
                    break;
                case ConnectStatus.Disconnected:
                    ReceivedMessageTextBox.AppendText("\nСоедниение разорвано\n");
                    break;
                case ConnectStatus.Error:
                    ReceivedMessageTextBox.AppendText("\nПроизошла ошибка при соединении\n");
                    break;
            }
        }

        private void receivedMessage(string message)
        {
            Dispatcher.Invoke(() => ReceivedMessageTextBox.AppendText("\n"+message));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (client.isConnected)
            {
                client.Disconnect();
            }
        }
    }
}
