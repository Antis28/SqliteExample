
using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqliteExample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();


            Test_1.Clicked += (x,y) => GetLocalAddress();
            Test_2.Clicked += (x,y) => GetMacAddress();
        }

        

        public void GetLocalAddress()
        {
            label.Text = string.Empty;
            // доступно ли сетевое подключение
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                return;
            label.Text += "Доступно сетевое подключение" + Environment.NewLine;
            // запросить у DNS-сервера IP-адрес, связанный с именем узла
            var host = Dns.GetHostEntry(Dns.GetHostName());
            // Пройдем по списку IP-адресов, связанных с узлом
            foreach (var ip in host.AddressList)
            {
                // если текущий IP-адрес версии IPv4, то выведем его 
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    label.Text += ip.ToString() + Environment.NewLine;
                }
            }
        }

        public void GetMacAddress()
        {
            label.Text = string.Empty;
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    label.Text += nic.Name + " = " + nic.GetPhysicalAddress().ToString() + Environment.NewLine;
                }
            }
        }

    }
}