using CalendarioMensualSoft.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalendarioMensualSoft.Forms
{
    public partial class FrmCalendario : Form
    {
        private DateTime lFechaInicio, lFechaFin;
        TabControl tabControlMeses = new TabControl();
        List<DiaFestivo> ldiasFestivos;
        public FrmCalendario(DateTime fechaInicio, DateTime Fechafin)
        {
            InitializeComponent();
            lFechaInicio = fechaInicio;
            lFechaFin = Fechafin;
            LlenarListaDiasFestivos();
            DeterminaMesesYDias();
            GenerarControles();
        }
        private void GenerarControles()
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MinimumSize = new Size(800, 600); // Ajusta según lo que necesites
            this.Controls.Add(tabControlMeses);
            tabControlMeses.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Cuenta los meses para ver cuantos paneles va a dibujar y ejecuta el DibujaPaneles para dibujarlos.
        /// </summary>
        private void DeterminaMesesYDias()
        {
            List<DateTime> meses = new List<DateTime>();
            DateTime cursor = new DateTime(lFechaInicio.Year, lFechaInicio.Month, 1);

            while (cursor <= lFechaFin)
            {
                DateTime finMes = cursor.AddMonths(1).AddDays(-1);

                if (finMes >= lFechaInicio)
                    meses.Add(cursor);

                cursor = cursor.AddMonths(1);
            }

            foreach (DateTime mes in meses)
            {
                string tituloMes = mes.ToString("MMMM yyyy", new CultureInfo("es-MX"));
                TabPage tabMes = new TabPage(tituloMes);

                Panel panelMes = new Panel();
                panelMes.Dock = DockStyle.Fill;
                panelMes.AutoScroll = true;
                tabMes.Controls.Add(panelMes);

                DibujaPaneles(mes, panelMes);

                tabControlMeses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                tabControlMeses.TabPages.Add(tabMes);
                panelMes.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        /// <summary>
        /// Dibuja los encabezados: Días y Mes con Año.
        /// </summary>
        /// <param name="tlp"></param>
        /// <param name="filaBase"></param>
        private void DibujarEncabezado(TableLayoutPanel tlp, int filaBase)
        {
            string[] diasSemana = { "Lun", "Mar", "Mié", "Jue", "Vie", "Sáb", "Dom" };
            for (int col = 0; col < 7; col++)
            {
                Label lblEncabezado = new Label();
                lblEncabezado.Text = diasSemana[col];
                lblEncabezado.Dock = DockStyle.Fill;
                lblEncabezado.TextAlign = ContentAlignment.MiddleCenter;
                lblEncabezado.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                lblEncabezado.BackColor = Color.LightGray;
                tlp.Controls.Add(lblEncabezado, col, filaBase);
            }
        }

        /// <summary>
        /// Dibuja los paneles y los acomoda.
        /// </summary>
        /// <param name="mes"></param>
        /// <param name="destino"></param>
        private void DibujaPaneles(DateTime mes, Panel destino)
        {
            DateTime primerDiaMes = new DateTime(mes.Year, mes.Month, 1);
            int offset = ((int)primerDiaMes.DayOfWeek + 6) % 7;
            int diasEnMes = DateTime.DaysInMonth(mes.Year, mes.Month);
            int totalFilas = (int)Math.Ceiling((offset + diasEnMes) / 7.0);

            TableLayoutPanel tlp = new TableLayoutPanel();
            tlp.RowCount = totalFilas;
            tlp.ColumnCount = 7;
            tlp.Dock = DockStyle.Fill;
            tlp.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tlp.RowCount = totalFilas + 2;
            tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 40)); 
            tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 30)); 

            Label lblTituloMes = new Label();
            lblTituloMes.Text = mes.ToString("MMMM yyyy", new CultureInfo("es-MX")).ToUpper();
            lblTituloMes.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTituloMes.TextAlign = ContentAlignment.MiddleCenter;
            lblTituloMes.Dock = DockStyle.Fill;
            lblTituloMes.BackColor = Color.WhiteSmoke;
            lblTituloMes.ForeColor = Color.DarkSlateGray;

            tlp.Controls.Add(lblTituloMes, 0, 0);
            tlp.SetColumnSpan(lblTituloMes, 7); 

            for (int i = 0; i < 7; i++)
                tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / 7));

            for (int i = 0; i < totalFilas; i++)
                tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / totalFilas));

            DibujarEncabezado(tlp, 1);

            int diaActual = 1;
            for (int fila = 0; fila < totalFilas; fila++)
            {
                for (int col = 0; col < 7; col++)
                {
                    int diaEnMes = diaActual - offset;
                    Label lbl = new Label();
                    lbl.Dock = DockStyle.Fill;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);


                    /*AQUI PINTA LOS LABELS*/
                    if (diaEnMes >= 1 && diaEnMes <= diasEnMes)
                    {
                        DateTime fecha = new DateTime(mes.Year, mes.Month, diaEnMes);
                        lbl.Text = diaEnMes.ToString();

                        if (fecha < lFechaInicio || fecha > lFechaFin)
                            lbl.BackColor = Color.Gray;
                        else if (EsFestivo(fecha))
                        {
                            lbl.BackColor = Color.Orange;

                            DiaFestivo festivo = ldiasFestivos.FirstOrDefault(f => f.Fecha.Month == fecha.Month);
                            if(festivo != null)
                                lbl.Text = lbl.Text + "\n" + festivo.Nombre;
                        }
                        else if (col >= 5)
                            lbl.BackColor = Color.Yellow;
                        else
                            lbl.BackColor = Color.Green;
                    }

                    tlp.Controls.Add(lbl, col, fila + 2);
                    diaActual++;
                }
            }

            destino.Controls.Add(tlp);
        }


        /// <summary>
        /// Valida si el día es festivo o no.
        /// </summary>
        /// <param name="FechaActual"></param>
        /// <returns></returns>
        private bool EsFestivo(DateTime FechaActual)
        {
            return ldiasFestivos.Any(f => f.Fecha.Month == FechaActual.Month && f.Fecha.Day == FechaActual.Day);
        }


        /// <summary>
        /// Registra los días festivos.
        /// </summary>
        private void LlenarListaDiasFestivos()
        {
            ldiasFestivos = new List<DiaFestivo>
            {
                new DiaFestivo { Nombre = "Año Nuevo", Fecha = new DateTime(2000, 1, 1) },
                new DiaFestivo { Nombre = "Día de la Constitución", Fecha = new DateTime(2000, 2, 5) },
                new DiaFestivo { Nombre = "Natalicio de Benito Juárez", Fecha = new DateTime(2000, 3, 18) },
                new DiaFestivo { Nombre = "Día del Trabajo", Fecha = new DateTime(2000, 5, 1) },
                new DiaFestivo { Nombre = "Día de la Independencia", Fecha = new DateTime(2000, 9, 16) },
                new DiaFestivo { Nombre = "Día de la Revolución", Fecha = new DateTime(2000, 11, 20) },
                new DiaFestivo { Nombre = "Navidad", Fecha = new DateTime(2000, 12, 25) }
            };
        }
    }
}
