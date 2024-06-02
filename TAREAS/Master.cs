using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TAREAS.datos;
using TAREAS.modelos;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TAREAS
{
    public partial class Master : Form
    {
        private int idUsuario;
        private dataUsuarios DataUsuarios;

        public Master(int idUsuario_esperado = 0)
        {
            InitializeComponent();
            idUsuario = idUsuario_esperado;
            DataUsuarios = new dataUsuarios();
        }

        private void Master_Load(object sender, EventArgs e)
        {
            List<modelos.Menus> permisos_esperados = DataUsuarios.ObtenerPermisos(idUsuario);

            MenuStrip miMenu = new MenuStrip();

            // para mostrar el menu

            foreach (modelos.Menus objMenu in permisos_esperados)
            {
                ToolStripMenuItem menuPadre = new ToolStripMenuItem(objMenu.Nombre);
                menuPadre.TextImageRelation = TextImageRelation.ImageAboveText;
                menuPadre.TextImageRelation = TextImageRelation.ImageAboveText;

                string rutaImagen = Path.GetFullPath(Path.Combine(Application.StartupPath, @"../../../" + objMenu.Icono));

                frmCrearUsuario frUs = new frmCrearUsuario();

                // Comprueba si el archivo de la imagen existe
                if (File.Exists(rutaImagen))
                {
                    try
                    {
                        Bitmap originalBitmap = new Bitmap(rutaImagen);
                        Bitmap resizedBitmap = ResizeImage(originalBitmap, 40, 40); // Tamaño deseado 16x16
                        menuPadre.Image = resizedBitmap;
                        menuPadre.ImageScaling = ToolStripItemImageScaling.None;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar la imagen: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("La imagen no se encontró en la ruta: " + rutaImagen);
                }

                // para mostrar los submenu
                foreach (var submenu in objMenu.ListaSubMenu)
                {
                    //frUs.ValidarPermisosFormulario(submenu.Nombre);
                    ToolStripMenuItem subMenuItem = new ToolStripMenuItem(submenu.Nombre,null, click_en_menu, submenu.NombreFormulario);
                    menuPadre.DropDownItems.Add(subMenuItem);
                }
                miMenu.Items.Add(menuPadre);

                miMenu.Items.Add(menuPadre);
            }

            this.MainMenuStrip = miMenu;
            this.Controls.Add(miMenu);
        }

        // para modificar el tamaño de la imagen
        private Bitmap ResizeImage(Bitmap originalImage, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.DrawImage(originalImage, 0, 0, width, height);
            }
            return resizedImage;
        }
        // click en menu
        private void click_en_menu(object sender, System.EventArgs e)
        {
            try
            {
                ToolStripMenuItem menuSeleccionado = (ToolStripMenuItem)sender;

                // Obtiene el ensamblado de entrada del proyecto
                Assembly asm = Assembly.GetEntryAssembly();

                // Obtiene el tipo del formulario basado en el nombre del menú seleccionado
                Type elemento = asm.GetType(asm.GetName().Name + "." + menuSeleccionado.Name);

                if (elemento != null)
                {
                    // Crear una instancia del formulario
                    ConstructorInfo constructor = elemento.GetConstructor(Type.EmptyTypes);
                    Form FormularioCreado;

                    //IMPORTANTE CAMBIAR EL TEXTO DEL FORMULARIO CUANDO SE CREA , TIENE QUE SER DIFERENTE EN EL NAME
                    if (constructor != null)
                    {
                        // Crea una instancia del formulario usando el constructor sin parámetros
                        FormularioCreado = (Form)Activator.CreateInstance(elemento);
                    }
                    else
                    {
                        // Si no tiene un constructor sin parámetros, crea una instancia usando el constructor con parámetros
                        object[] args = { 0 }; // Puedes pasar los argumentos necesarios aquí
                        FormularioCreado = (Form)Activator.CreateInstance(elemento, args);
                    }

                    // Verificar si ya está abierto el formulario
                    bool encontrado = Application.OpenForms.Cast<Form>().Any(x => x.Name == FormularioCreado.Name);

                    if (encontrado)
                    {
                        // Si ya está abierto, traerlo al frente y restaurar el estado si estaba minimizado
                        Form formularioExistente = Application.OpenForms[FormularioCreado.Name];
                        formularioExistente.WindowState = FormWindowState.Normal;
                        formularioExistente.BringToFront();
                    }
                    else
                    {
                        // Mostrar el formulario como ventana independiente
                        FormularioCreado.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Formulario no encontrado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
         
    }
}
