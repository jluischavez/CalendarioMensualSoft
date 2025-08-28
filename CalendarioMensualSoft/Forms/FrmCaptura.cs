using CalendarioMensualSoft.Clases;
using CalendarioMensualSoft.Forms;

namespace CalendarioMensualSoft
{
    public partial class FrmCaptura : Form
    {

        List<DiaFestivo> ldiasFestivos;
        List<Mes> lMeses;
        public FrmCaptura()
        {
            InitializeComponent();
            LlenarComboBox();
            CBDias.Enabled = false;
            btnGenerarCalendario.Enabled = false;
            SuscripcionEventos();
            CBDias.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        
        private void SuscripcionEventos()
        {
            CBMes.SelectedIndexChanged += (s, e) => ActualizarDias();
            TxtYear.TextChanged += (s, e) => ActualizarDias();
            txtDiasAMostrar.TextChanged += (s, e) => ValidarCampos();
            CBDias.SelectedIndexChanged += (s, e) => ValidarCampos();
            TxtYear.KeyPress += SoloNumeros_KeyPress;
            txtDiasAMostrar.KeyPress += SoloNumeros_KeyPress;
        }
        private void LlenarComboBox()
        {
            lMeses = new List<Mes>
            {
                new Mes { Id = 1, Nombre = "Enero" },
                new Mes { Id = 2, Nombre = "Febrero" },
                new Mes { Id = 3, Nombre = "Marzo" },
                new Mes { Id = 4, Nombre = "Abril" },
                new Mes { Id = 5, Nombre = "Mayo" },
                new Mes { Id = 6, Nombre = "Junio" },
                new Mes { Id = 7, Nombre = "Julio" },
                new Mes { Id = 8, Nombre = "Agosto" },
                new Mes { Id = 9, Nombre = "Septiembre" },
                new Mes { Id = 10, Nombre = "Octubre" },
                new Mes { Id = 11, Nombre = "Noviembre" },
                new Mes { Id = 12, Nombre = "Diciembre" }
            };

            CBMes.DataSource = lMeses;
            CBMes.DropDownStyle = ComboBoxStyle.DropDownList;
            
        }

        private void ActualizarDias()
        {
            if (CBMes.SelectedIndex == -1 || string.IsNullOrWhiteSpace(TxtYear.Text) || !int.TryParse(TxtYear.Text, out int año))
            {
                CBDias.Enabled = false;
                ValidarCampos(); // ← asegúrate de deshabilitar el botón si no hay año válido
                return;
            }

            int mes = CBMes.SelectedIndex + 1;
            int diasEnMes = DateTime.DaysInMonth(año, mes);

            CBDias.Items.Clear();
            for (int i = 1; i <= diasEnMes; i++)
            {
                CBDias.Items.Add(i.ToString());
            }

            CBDias.Enabled = true;
            CBDias.SelectedIndex = 0;

            ValidarCampos();
        }

        private void btnGenerarCalendario_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtYear.Text) && !string.IsNullOrEmpty(txtDiasAMostrar.Text))
            {
                DateTime fechaInicio = new DateTime(Convert.ToInt32(TxtYear.Text), ((Mes)CBMes.SelectedItem).Id, Convert.ToInt32(CBDias.Text));
                DateTime fechaFin = fechaInicio.AddDays(Convert.ToInt32(txtDiasAMostrar.Text) - 1);
                FrmCalendario lFrmCaptura = new FrmCalendario(fechaInicio, fechaFin);
                lFrmCaptura.ShowDialog();
            }
            else
            {
                MessageBox.Show("Las cajas de texto 'Año' y 'Dias a mostrar' no pueden estar vacías. ","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
           
        }
        private void ValidarCampos()
        {
            bool añoValido = !string.IsNullOrWhiteSpace(TxtYear.Text) && int.TryParse(TxtYear.Text, out _);
            bool diasMostrarValido = !string.IsNullOrWhiteSpace(txtDiasAMostrar.Text) && int.TryParse(txtDiasAMostrar.Text, out int dias) && dias > 0;
            bool diaSeleccionado = CBDias.SelectedIndex >= 0;

            btnGenerarCalendario.Enabled = añoValido && diasMostrarValido && diaSeleccionado;
        }


        private void CBDias_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnGenerarCalendario.Enabled = CBDias.SelectedIndex >= 0;
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite dígitos y teclas de control (como backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea la tecla
            }
        }
    }
}