using SistemaCRUD.Datos;
using SistemaCRUD.Entidades;
using SistemaCRUD.Presentacion.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCRUD.Presentacion
{
    public partial class Form_Productos : Form
    {
        public Form_Productos()
        {
            InitializeComponent();
        }

        //Definición de Región que contendrá todas las Variables para trabajar con el Formulario de Windows Forms.
        #region "MIS VARIABLES"
        int nEstadoguarda = 0;
        int vCodigo_pr = 0;
        #endregion

        //Definición de Región que contendrá todos los Métodos para trabajar con el Formulario de Windows Forms.
        #region "MIS METODOS"
        //Definición de Método.
        private void LimpiaTexto()
        {
            txtDescripcion_pr.Text = "";
            txtMarca_pr.Text = "";
            txtStockactual.Text = "0.00";
            cmbMedidas.Text = "";
            cmbCategorias.Text = "";
        }

        //Definición de Método.
        private void EstadoTexto(bool lEstado)
        {
            txtDescripcion_pr.Enabled = lEstado;
            txtMarca_pr.Enabled = lEstado;
            txtStockactual.Enabled = lEstado;
            cmbMedidas.Enabled = lEstado;
            cmbCategorias.Enabled = lEstado;
        }

        //Definición de Método.
        private void EstadoBotones(bool lEstado)
        {
            btnCancelar.Visible = !lEstado;
            btnGuardar.Visible = !lEstado;

            btnNuevo.Enabled = lEstado;
            btnActualizar.Enabled = lEstado;
            btnEliminar.Enabled = lEstado;
            btnReporte.Enabled = lEstado;
            btnSalir.Enabled = lEstado;

            btnBuscar.Enabled = lEstado;
            txtBuscar.Enabled = lEstado;
            dgvListado_pr.Enabled = lEstado;
        }

        //Definición de Método.
        private void Cargar_Medidas()
        {
            //Definición de Variable (Instanciar).
            D_Productos Datos = new D_Productos();
            cmbMedidas.DataSource = Datos.Listado_me();
            cmbMedidas.ValueMember = "codigo_me";
            cmbMedidas.DisplayMember = "descripcion_me";
        }

        //Definición de Método.
        private void Cargar_Categorias()
        {
            //Definición de Variable(Instanciar).
            D_Productos Datos = new D_Productos();
            cmbCategorias.DataSource = Datos.Listado_ca();
            cmbCategorias.ValueMember = "codigo_ca";
            cmbCategorias.DisplayMember = "descripcion_ca";
        }

        //Definición de Método para darle formato al DataGridView.
        private void Formato_pr()
        {
            dgvListado_pr.Columns[0].Width = 100;
            dgvListado_pr.Columns[0].HeaderText = "CODIGO PR";
            dgvListado_pr.Columns[1].Width = 210;
            dgvListado_pr.Columns[1].HeaderText = "PRODUCTO";
            dgvListado_pr.Columns[2].Width = 110;
            dgvListado_pr.Columns[2].HeaderText = "MARCA";
            dgvListado_pr.Columns[3].Width = 110;
            dgvListado_pr.Columns[3].HeaderText = "MEDIDA";
            dgvListado_pr.Columns[4].Width = 110;
            dgvListado_pr.Columns[4].HeaderText = "CATEGORIA";
            dgvListado_pr.Columns[5].Width = 120;
            dgvListado_pr.Columns[5].HeaderText = "STOCK ACTUAL";
            dgvListado_pr.Columns[6].Visible = false;
            dgvListado_pr.Columns[7].Visible = false;
        }

        //Definición de Método.
        private void Listado_pr(string cTexto)
        {
            //Definición de Variable(Instanciar).
            D_Productos Datos = new D_Productos();
            dgvListado_pr.DataSource = Datos.Listado_pr(cTexto);
            this.Formato_pr();
        }

        //Definición de Método
        private void Selecciona_Item_pr()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgvListado_pr.CurrentRow.Cells["codigo_pr"].Value)))
            {
                MessageBox.Show("NO SE TIENE NADA DE DATOS PARA PODER VISUALIZARLOS",
                                "AVISO DEL SISTEMA",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            else
            {
                this.vCodigo_pr = Convert.ToInt32(dgvListado_pr.CurrentRow.Cells["codigo_pr"].Value);
                txtDescripcion_pr.Text = Convert.ToString(dgvListado_pr.CurrentRow.Cells["descripcion_pr"].Value);
                txtMarca_pr.Text = Convert.ToString(dgvListado_pr.CurrentRow.Cells["marca_pr"].Value);
                cmbMedidas.Text = Convert.ToString(dgvListado_pr.CurrentRow.Cells["descripcion_me"].Value);
                cmbCategorias.Text = Convert.ToString(dgvListado_pr.CurrentRow.Cells["descripcion_ca"].Value);
                txtStockactual.Text = Convert.ToString(dgvListado_pr.CurrentRow.Cells["stock_actual"].Value);
            }
        }
        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        //Definición de Evento.
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.nEstadoguarda = 1; //Acción de Nuevo Registro.
            this.vCodigo_pr = 0;
            this.LimpiaTexto();
            this.EstadoTexto(true);
            this.EstadoBotones(false);
            txtDescripcion_pr.Select();
        }

        //Definición de Evento.
        private void Form_Productos_Load(object sender, EventArgs e)
        {
            this.Cargar_Medidas();
            this.Cargar_Categorias();
            this.Listado_pr("%");
        }

        //Definición de Evento.
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpiaTexto();
            this.EstadoBotones(false);
            this.EstadoBotones(true);
        }

        //Definición de Evento.
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Validación del Evento.
            if (txtDescripcion_pr.Text == string.Empty ||
                txtMarca_pr.Text == string.Empty ||
                cmbMedidas.Text == string.Empty ||
                cmbCategorias.Text == string.Empty ||
                txtStockactual.Text == string.Empty) //Proceso de validar que todos los datos estén correctos.
            {
                MessageBox.Show("FALTA QUE SE INGRESEN LOS DATOS REQUERIDOS (*)",
                                "AVISO DEL SISTEMA",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            else //Proceso de guardar toda la información.
            {
                //Definición de Variable.
                string Rpta = "";
                //Definición de Variable (Instanciar).
                E_Productos oPro = new E_Productos();
                oPro.Codigo_pr = this.vCodigo_pr;
                oPro.Descripcion_pr = txtDescripcion_pr.Text;
                oPro.Marca_pr = txtMarca_pr.Text;
                oPro.Codigo_me = Convert.ToInt32(cmbMedidas.SelectedValue);
                oPro.Codigo_ca = Convert.ToInt32(cmbCategorias.SelectedValue);
                oPro.Stock_actual = Convert.ToDecimal(txtStockactual.Text);

                //Definición de Variable (Instanciar).
                D_Productos Datos = new D_Productos();
                Rpta = Datos.Guardar_pr(this.nEstadoguarda, oPro);
                if (Rpta == "OK")
                {
                    this.Listado_pr("%");
                    MessageBox.Show("LOS DATOS HAN SIDO GUARDADOS CORRECTAMENTE",
                                    "AVISO DEL SISTEMA",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    this.vCodigo_pr = 0;
                    this.LimpiaTexto();
                    this.EstadoTexto(false);
                    this.EstadoBotones(true);
                }
            }
        }

        //Definición de Evento.
        private void dgvListado_pr_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Selecciona_Item_pr(); //Invocación del Método.
        }

        //Definición de Evento.
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.nEstadoguarda = 2; //Acción de Actualizar Registro.
            this.EstadoTexto(true);
            this.EstadoBotones(false);
            txtDescripcion_pr.Select();
        }

        //Definición de Evento.
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Listado_pr(txtBuscar.Text);
        }

        //Definición de Evento.
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvListado_pr.Rows.Count <= 0 ||
                string.IsNullOrEmpty(Convert.ToString(dgvListado_pr.CurrentRow.Cells["codigo_pr"].Value)))
            {
                MessageBox.Show("NO SE TIENE NADA DE DATOS PARA PODER ELIMINARLOS",
                                "AVISO DEL SISTEMA",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            else
            {
                //Definición de Variable.
                string Rpta = "";
                //Definición de Variable (Instanciar).
                D_Productos Datos = new D_Productos();
                Rpta = Datos.Activo_pr(vCodigo_pr, false);
                if (Rpta == "OK")
                {
                    this.Listado_pr("%");
                    this.LimpiaTexto();
                    vCodigo_pr = 0;
                    MessageBox.Show("LOS DATOS HAN SIDO ELIMINADOS CORRECTAMENTE",
                                    "AVISO DEL SISTEMA",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
        }

        //Definición de Evento.
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Definición de Evento.
        private void btnReporte_Click(object sender, EventArgs e)
        {
            //Definición de Variable (Instanciar) ó Definición de un Objeto.
            Form_Rpt_Listado_pr oForm_rpt = new Form_Rpt_Listado_pr();
            oForm_rpt.txt_Reporte.Text = txtBuscar.Text;
            oForm_rpt.ShowDialog();
        }
    }
}
