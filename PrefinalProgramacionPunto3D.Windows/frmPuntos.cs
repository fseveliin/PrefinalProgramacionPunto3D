using PrefinalProgramacionPunto3D.Datos;
using PrefinalProgramacionPunto3D.entidades;


namespace PrefinalProgramacionPunto3D.Windows
{
    public partial class frmPuntos : Form
    {
        public frmPuntos()
        {
            InitializeComponent();
        }

        private void frmPuntos_Load(object sender, EventArgs e)
        {
            repositorio.CargarDatos("puntos.txt");
            ActualizarGrilla();
            txtCantidad.Text = repositorio.Cantidad.ToString();
        }

        private void ActualizarGrilla()
        {
            dgvPuntos.DataSource = null;
            dgvPuntos.DataSource = repositorio.ObtenerPuntos();
            txtCantidad.Text = repositorio.Cantidad.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPuntos.CurrentRow == null) return;

            var puntoSeleccionado = (Punto3D)dgvPuntos.CurrentRow.DataBoundItem;
            if (repositorio.EliminarPunto(puntoSeleccionado))
            {
                ActualizarGrilla();
                MessageBox.Show("Punto eliminado con éxito.", "Información");
            }
            else
            {
                MessageBox.Show("Error al eliminar el punto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var form = new frmPunto3DAe())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (repositorio.AgregarPunto(form.Punto))
                    {
                        ActualizarGrilla();

                    
                    }
                    else
                    {
                        MessageBox.Show("El punto ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }




    }
}
