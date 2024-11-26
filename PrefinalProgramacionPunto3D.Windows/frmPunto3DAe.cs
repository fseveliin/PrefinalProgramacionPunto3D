using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrefinalProgramacionPunto3D.Datos;
using PrefinalProgramacionPunto3D.entidades;


namespace PrefinalProgramacionPunto3D.Windows
{
    public partial class frmPunto3DAe : Form
    {
        public frmPunto3DAe()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtX.Text, out int x) &&
                int.TryParse(txtY.Text, out int y) &&
                int.TryParse(txtZ.Text, out int z) &&
                !string.IsNullOrWhiteSpace(txtColor.Text))
            {
                var punto = new Punto3D(x, y, z, txtColor.Text.Trim());
                MessageBox.Show($"Se ingresó el punto:\n{punto}", "Información", MessageBoxButtons.OK);
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Ingrese datos válidos.");
            }
        }

    }
}
