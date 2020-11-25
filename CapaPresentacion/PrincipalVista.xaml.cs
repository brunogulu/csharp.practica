using FontAwesome.WPF;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Windows.Input;
using System.Linq;
using System.Windows.Shell;

namespace CapaPresentacion
{
    /// <summary>
    /// Lógica de interacción para PrincipalVista.xaml
    /// </summary>
    public partial class PrincipalVista : Window
    {
        // Variables Menu Principal
        private ImageAwesome currentIcon;
        private Label currentLabel;
        private Button currentBtn;
        private DockPanel currentPanel;
        
        // Variables Botón Maximizar/Restaurar
        static bool isMax = false;
        static Point old_loc;
        static Size old_size;

        #region Colores
        // Colores para el Texto del botón.
        SolidColorBrush lblDefault = new SolidColorBrush(Color.FromRgb(92, 92, 92));
        SolidColorBrush lblClicked = new SolidColorBrush(Color.FromRgb(31, 31, 31));
        // Colores para el Ícono del botón.
        SolidColorBrush iconDefault = new SolidColorBrush(Color.FromRgb(92, 92, 92));
        SolidColorBrush iconClicked = new SolidColorBrush(Color.FromRgb(31, 31, 31));
        // Colores para la Barra del botón.
        SolidColorBrush barraDefault = new SolidColorBrush(Color.FromRgb(245, 245, 232));
        SolidColorBrush barraClicked = new SolidColorBrush(Color.FromRgb(74, 143, 232));
        #endregion

        public PrincipalVista()
        {
            InitializeComponent();
            InicializarMedidasVentana(this);
        }

        #region BarraSuperior
        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMaximizar_Click(object sender, RoutedEventArgs e)
        {
            MaximizarORestaurar(this, sender);
        }

        private void btnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        // Arrastrar ventana
        private void Window_DragWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                MaximizarORestaurar(this, btnMaximizar);
            }

            DragMove();
        }

        /// <summary>
        /// Cambia el fondo del botón según se tenga que maximizar o restaurar.
        /// </summary>
        /// <param name="sender">Botón al cual se le cambia el fondo.</param>
        /// <param name="nombreImagen">Nombre de la imagen de fondo utilizada. La misma debe estar
        /// dentro de la carpeta "Imagenes".</param>
        /// <param name="estiloBoton">Nombre del estilo que debe aplicarse al botón. Los mismos se
        /// encuentran dentro de la carpeta Styles, en el archivo General.xaml.</param>
        private void CambiarImagenBoton(object sender, string nombreImagen, string estiloBoton)
        {
            string ruta = "pack://application:,,,/CapaPresentacion;component/Imagenes/" + nombreImagen + ".jpg";

            Button button = sender as Button;
            ImageBrush brush = new ImageBrush();
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(ruta, UriKind.Absolute);
            bitmap.EndInit();
            brush.ImageSource = bitmap;
            button.Background = brush;
            Style style = this.FindResource(estiloBoton) as Style;
            button.Style = style;
        }

        private void InicializarMedidasVentana(Window ventana)
        {
            old_size = new Size(ventana.Width, ventana.Height);
            old_loc = new Point(ventana.Top, ventana.Left);
        }

        private void Maximizar(Window ventana)
        {
            double x = SystemParameters.WorkArea.Width;
            double y = SystemParameters.WorkArea.Height;
            ventana.WindowState = WindowState.Normal;
            ventana.Top = 0;
            ventana.Left = 0;
            ventana.Width = x;
            ventana.Height = y;
        }

        /// <summary>
        /// Maximiza o Restaura la ventana según esté o no maximizada, y a su vez
        /// cambia la imagen del botón.
        /// </summary>
        /// <param name="ventana">Ventana de la App que se maximizará o restaurará.</param>
        /// <param name="sender">Botón al cual se le cambiará la imagen.</param>
        private void MaximizarORestaurar(Window ventana, object sender)
        {
            if (isMax == false) // ventana no maximizada, entonces maximizar
            {
                old_size = new Size(ventana.Width, ventana.Height);
                old_loc = new Point(ventana.Top, ventana.Left);
                Maximizar(ventana);
                isMax = true;
                ventana.ResizeMode = ResizeMode.NoResize;
                // Cambia la propiedad ResizeBorderThickness
                chrome.ResizeBorderThickness = new Thickness(0);
                CambiarImagenBoton(sender, "restaurar", "ButtonStyleRestaurar");
            }
            else // ventana maximizada, entonces restaurar
            {
                ventana.Top = old_loc.Y;
                ventana.Left = old_loc.X;
                ventana.Width = old_size.Width;
                ventana.Height = old_size.Height;
                isMax = false;
                ventana.ResizeMode = ResizeMode.CanResize;
                // Cambia la propiedad ResizeBorderThickness
                chrome.ResizeBorderThickness = new Thickness(4);
                CambiarImagenBoton(sender, "maximizar", "ButtonStyleMaximizar");
            }
        }
        #endregion

        #region MenúPrincipal
        private void btnInicio_Click(object sender, RoutedEventArgs e)
        {
            ActivarBoton(sender, barraInicio, lblInicio, iconInicio);
        }

        private void btnProductos_Click(object sender, RoutedEventArgs e)
        {
            ActivarBoton(sender, barraProductos, lblProductos, iconProductos);
        }

        private void btnClientes_Click(object sender, RoutedEventArgs e)
        {
            ActivarBoton(sender, barraClientes, lblClientes, iconClientes);
        }

        private void btnVentas_Click(object sender, RoutedEventArgs e)
        {
            ActivarBoton(sender, barraVentas, lblVentas, iconVentas);
        }

        private void btnProveedores_Click(object sender, RoutedEventArgs e)
        {
            ActivarBoton(sender, barraProveedores, lblProveedores, iconProveedores);
        }

        private void btnCompras_Click(object sender, RoutedEventArgs e)
        {
            ActivarBoton(sender, barraCompras, lblCompras, iconCompras);
        }

        private void btnReportes_Click(object sender, RoutedEventArgs e)
        {
            ActivarBoton(sender, barraReportes, lblReportes, iconReportes);
        }

        /// <summary>
        /// Activa los estilos del botón al hacerle Click.
        /// </summary>
        /// <param name="btnNombre">Botón actual.</param>
        /// <param name="barraNombre">DockPanel del botón (barra de color).</param>
        /// <param name="lblNombre">Label del botón.</param>
        /// <param name="iconNombre">Ícono del botón.</param>
        private void ActivarBoton(object btnNombre, object barraNombre, object lblNombre, object iconNombre)
        {
            DesactivarBoton();

            if (btnNombre != null)
            {
                currentBtn = (Button)btnNombre;
                currentPanel = (DockPanel)barraNombre;
                currentLabel = (Label)lblNombre;
                currentIcon = (ImageAwesome)iconNombre;

                currentPanel.Background = barraClicked;
                currentLabel.Foreground = lblClicked;
                currentLabel.FontWeight = FontWeights.Bold;
                currentIcon.Foreground = iconClicked;
            }
        }

        /// <summary>
        /// Desactiva los estilos del botón y lo deja por defecto.
        /// </summary>
        private void DesactivarBoton()
        {
            if (currentBtn != null)
            {
                currentPanel.Background = barraDefault;
                currentLabel.Foreground = lblDefault;
                currentLabel.FontWeight = FontWeights.Normal;
                currentIcon.Foreground = iconDefault;
            }
        }
        #endregion

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Foco en el botón Inicio.
            btnInicio.Focus();
            ActivarBoton(btnInicio, barraInicio, lblInicio, iconInicio);

            // Reloj y Fecha
            // Timer
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
            // Fecha
            MostrarFechaConFormato(lblFecha);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lblHora.Content = DateTime.Now.ToLongTimeString();
        }
        
        private void MostrarFechaConFormato(Label label)
        {
            string fecha = DateTime.Now.ToString(@"dddd\, dd \de MMMM");
            string[] palabras = fecha.Split();

            string palabra1 = char.ToUpper(palabras[0][0]) + palabras[0].Substring(1);
            string palabra2 = palabras[1];
            string palabra3 = palabras[2];
            string palabra4 = char.ToUpper(palabras[3][0]) + palabras[3].Substring(1);

            label.Content = palabra1 + " " + palabra2 + " " + palabra3 + " " + palabra4;
        }
    }
}
