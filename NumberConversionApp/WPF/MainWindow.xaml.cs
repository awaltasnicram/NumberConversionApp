using System;
using System.Windows;
using System.ServiceModel;
using WPF.ServiceReference1;


namespace WPF
{

    /// Logika interakcji dla pliku MainWindow.xaml
  
    public partial class MainWindow : Window
    {

        private IConversionService serwer;
        public MainWindow()
        {
            Uri adres = new Uri("http://localhost:62476/ConversionService.svc"); //endpoint
            var c = new ChannelFactory<IConversionService>(
              new BasicHttpBinding(),
              new EndpointAddress(adres));
              serwer = c.CreateChannel();

        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {

            // tworzenie obiektu klienta usługi WCF    
            ServiceReference1.ConversionServiceClient service = new ServiceReference1.ConversionServiceClient();


            //przypisanie wartości wyjściowej z usługi Response    
            ServiceReference1.Response response = service.Convert(textBox1.Text);

            //przypisanie wartości wyjściowej do etykiety w celu wyświetlenia użytkownikowi  
            label2.Text += response.error ?? response.result;
        }
    }
}
