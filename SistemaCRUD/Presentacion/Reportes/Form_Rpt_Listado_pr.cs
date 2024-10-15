using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCRUD.Presentacion.Reportes
{
    public partial class Form_Rpt_Listado_pr : Form
    {
        public Form_Rpt_Listado_pr()
        {
            InitializeComponent();
        }


        //Definición de Evento.
        private void Form_Rpt_Listado_pr_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DS_Reportes.USP_LISTADO_PR' Puede moverla o quitarla según sea necesario.
            //this.USP_LISTADO_PRTableAdapter.Fill(this.DS_Reportes.USP_LISTADO_PR);

            //Aquí aplicamos el Enganche de la Información.
            this.uSP_LISTADO_PRTableAdapter.Fill(this.DS_Reportes.USP_LISTADO_PR, cTexto:txt_Reporte.Text);
            this.reportViewer1.RefreshReport();
        }
    }
}
