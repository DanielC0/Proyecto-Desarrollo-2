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

namespace ProyectoDS
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        public void ingresarAlSistema()
        {
            string usuario = txtUsuarioLogin.Text;
            string contrasena = txtPassLogin.Text;

            using(AcmeEntities bd = new AcmeEntities())
            {
                var oEmpleado = bd.Empleado.Where(x => x.documento == usuario && x.contrasena == contrasena).FirstOrDefault();
                
                if(oEmpleado != null)
                {
                    Agenta agenda = new Agenta();
                    agenda.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Datos erroneos");
                }
            }
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            
        }

 

        private void passLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ingresarAlSistema();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Agenta agenda = new Agenta();
            agenda.Show();
            this.Hide();
        }
    }
}
