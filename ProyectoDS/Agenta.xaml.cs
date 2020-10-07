using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoDS
{
    /// <summary>
    /// Lógica de interacción para Agenta.xaml
    /// </summary>
    public partial class Agenta : Window
    {
        public Agenta()
        {
            InitializeComponent();
        }

        public void agregarProcedimiento(string nombre, string precio, string descripcion)
        {
            using(AcmeEntities db = new AcmeEntities())
            {
                Procedimiento oProcedimiento = new Procedimiento();
                oProcedimiento.nombre = nombre;
                oProcedimiento.precio = precio;
                oProcedimiento.descripcion = descripcion;

                db.Procedimiento.Add(oProcedimiento);
                db.SaveChanges();
            }
        }

        public void agregarPersonal(string tipoDocumento, string numeroDocumento, string nombre, string correo, string telefono, string fechaNacimiento, string codigoCargo, string contrasena, string tipoSangre = "",string descripcion = "", string especialidad = "")
        {

            using (AcmeEntities db = new AcmeEntities())
            {

                if(codigoCargo.Equals("2"))
                {

                    Paciente oPaciente = new Paciente();
                    oPaciente.documento = numeroDocumento;
                    oPaciente.tipoDocumento = tipoDocumento;
                    oPaciente.nombre = nombre;
                    oPaciente.correo = correo;
                    oPaciente.telefono = telefono;
                    oPaciente.tipoSangre = tipoSangre;

                    db.Paciente.Add(oPaciente);
                    db.SaveChanges();

                    
                }
                else {

                    Empleado oEmpleado = new Empleado();
                    oEmpleado.documento = numeroDocumento;
                    oEmpleado.tipoDocumento = tipoDocumento;
                    oEmpleado.nombre = nombre;
                    oEmpleado.correo = correo;
                    oEmpleado.telefono = telefono;
                    MessageBox.Show(fechaNacimiento);
                    DateTime prueba = DateTime.Parse(fechaNacimiento);
                    oEmpleado.fechaNacimiento = prueba;
                    oEmpleado.codigoCargo = codigoCargo;
                    oEmpleado.contrasena = contrasena;

                    db.Empleado.Add(oEmpleado);
                    db.SaveChanges();

                    if (codigoCargo.Equals("1"))
                    {
                        Odontologo oDontologo = new Odontologo();
                        oDontologo.descripcion = descripcion;
                        oDontologo.especialidad = especialidad;
                        oDontologo.documento = numeroDocumento;

                        db.Odontologo.Add(oDontologo);
                        db.SaveChanges();
                    }

                }


            }

        }

        public void agregarSecretaria()
        {

        }

        private void tabControl1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Path_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            tabControlPrincipal.SelectedIndex = 0;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            tabControlPrincipal.SelectedIndex = 0;
        }

        private void Path_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            tabControlPrincipal.SelectedIndex = 1;
        }

        private void Path_MouseLeftButtonDown_4(object sender, MouseButtonEventArgs e)
        {
            tabControlPrincipal.SelectedIndex = 2;
        }

        private void Path_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            tabControlPrincipal.SelectedIndex = 3;
        }

        private void btnAgregarPersonas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void txtTipoDocumentoSecretaria_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnAgregarSecretaria_Click(object sender, RoutedEventArgs e)
        {
            agregarPersonal(cbxTipoDocumento.Text, txtDocumento.Text, txtNombre.Text, txtcorreo.Text, txtTelefono.Text, txtFechaNacimiento.Text, cbxCargo.SelectedIndex.ToString(), txtContrasena.Text, cbxTipoSangre.Text, txtDescripcion.Text, txtEspecialidad.Text);
            //MessageBox.Show(cbxCargo.Text);
              
        }



        private void cbxCargo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbxCargo.SelectedIndex == 2)
            {
                txtDocumento.Visibility = Visibility.Visible;
                txtNombre.Visibility = Visibility.Visible;
                txtTipoDocumento.Visibility = Visibility.Visible;
                txtcorreo.Visibility = Visibility.Visible;
                txtTelefono.Visibility = Visibility.Visible;
                cbxTipoSangre.Visibility = Visibility.Visible;

                txtFechaNacimiento.Visibility = Visibility.Hidden;
                txtContrasena.Visibility = Visibility.Hidden;
                txtDescripcion.Visibility = Visibility.Hidden;
                txtEspecialidad.Visibility = Visibility.Hidden;
            }

            else if(cbxCargo.SelectedIndex == 1)
            { 
                txtDocumento.Visibility = Visibility.Visible;
                txtNombre.Visibility = Visibility.Visible;
                txtTipoDocumento.Visibility = Visibility.Visible;
                txtcorreo.Visibility = Visibility.Visible;
                txtTelefono.Visibility = Visibility.Visible;
                txtDescripcion.Visibility = Visibility.Visible;
                txtEspecialidad.Visibility = Visibility.Visible;
                cbxTipoSangre.Visibility = Visibility.Hidden;
                txtFechaNacimiento.Visibility = Visibility.Visible;
                txtContrasena.Visibility = Visibility.Visible;
            }

            else if (cbxCargo.SelectedIndex == 0)
            {
                txtDocumento.Visibility = Visibility.Visible;
                txtNombre.Visibility = Visibility.Visible;
                txtTipoDocumento.Visibility = Visibility.Visible;
                txtcorreo.Visibility = Visibility.Visible;
                txtTelefono.Visibility = Visibility.Visible;
                txtDescripcion.Visibility = Visibility.Hidden;
                txtEspecialidad.Visibility = Visibility.Hidden;
                cbxTipoSangre.Visibility = Visibility.Hidden;
                txtFechaNacimiento.Visibility = Visibility.Visible;
                txtContrasena.Visibility = Visibility.Visible;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource pacienteViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("pacienteViewSource")));
            // Cargar datos estableciendo la propiedad CollectionViewSource.Source:
            // pacienteViewSource.Source = [origen de datos genérico]
            System.Windows.Data.CollectionViewSource procedimientoViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("procedimientoViewSource")));
            // Cargar datos estableciendo la propiedad CollectionViewSource.Source:
            // procedimientoViewSource.Source = [origen de datos genérico]
            System.Windows.Data.CollectionViewSource historia_clinicaViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("historia_clinicaViewSource")));
            // Cargar datos estableciendo la propiedad CollectionViewSource.Source:
            // historia_clinicaViewSource.Source = [origen de datos genérico]
            System.Windows.Data.CollectionViewSource citaViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("citaViewSource")));
            // Cargar datos estableciendo la propiedad CollectionViewSource.Source:
            // citaViewSource.Source = [origen de datos genérico]
        }

        private void pacienteDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            using(AcmeEntities db = new AcmeEntities())
            {
                db.Paciente.Load();
                
                this.pacienteDataGrid.DataContext = db.Paciente.Local.ToBindingList();
            }
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            List<DatosOdontologo> resultadoConsulta = new List<DatosOdontologo>();

            using (AcmeEntities db = new AcmeEntities())
            {
                resultadoConsulta = db.Database.SqlQuery<DatosOdontologo>("obtener_especialidad").ToList();
                var listaBinding = new BindingList<DatosOdontologo>(resultadoConsulta);

                this.dataGridDatosOdontologo.ItemsSource = listaBinding;
            }
        }



        private void txtcorreo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void procedimientoDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            using (AcmeEntities db = new AcmeEntities())
            {
                db.Procedimiento.Load();

                this.procedimientoDataGrid.DataContext = db.Procedimiento.Local.ToBindingList();
            }

        }

        private void btnAgregarProcedimiento_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dtfSecretaria_Loaded(object sender, RoutedEventArgs e)
        {

            List<DatosSecretaria> resultadoConsulta = new List<DatosSecretaria>();

            using (AcmeEntities db = new AcmeEntities())
            {
                resultadoConsulta = db.Database.SqlQuery<DatosSecretaria>("consulta_secretaria").ToList();
                //MessageBox.Show(resultadoConsulta[0].TipoDocumento);
                var listaBinding = new BindingList<DatosSecretaria>(resultadoConsulta);

                this.dtfSecretaria.ItemsSource = listaBinding;
            }

        }

        public void eliminarEmpleado(string documentoin)
        {
            using (AcmeEntities db = new AcmeEntities())
            {
                Empleado oEmpleado = db.Empleado.Where(x => x.documento == documentoin).FirstOrDefault();
                //MessageBox.Show(Convert.ToString(oEmpleado.codigoCargo == "0"));
                // 0: Secretaria, 1: Odontólogo, 2: Paciente
                
                if (oEmpleado != null && Convert.ToInt32(oEmpleado.codigoCargo) == 0)
                {
                    db.Empleado.Remove(oEmpleado);
                    db.SaveChanges();
                    MessageBox.Show("La secretaria se ha eliminado exitosamente");
                }
                else if (oEmpleado != null &&  Convert.ToInt32(oEmpleado.codigoCargo) == 1)
                {
                    Odontologo oOdontologo = db.Odontologo.Where(x => x.documento == documentoin).FirstOrDefault();

                    db.Odontologo.Remove(oOdontologo);
                    db.SaveChanges();
                    db.Empleado.Remove(oEmpleado);
                    db.SaveChanges();
                    MessageBox.Show("El odontólogo se ha eliminado con exito");
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado");
                }
                       
            }

        }

        //public void eliminarPaci

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            eliminarEmpleado(txtCodigoEliminarSecretaria.Text);
        }

    
    }
 
}
