
namespace SistemaCRUD.Presentacion.Reportes
{
    partial class Form_Rpt_Listado_pr
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.dSReportesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DS_Reportes = new SistemaCRUD.Presentacion.Reportes.DS_Reportes();
            this.uSPLISTADOPRBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.txt_Reporte = new System.Windows.Forms.TextBox();
            this.uSP_LISTADO_PRTableAdapter = new SistemaCRUD.Presentacion.Reportes.DS_ReportesTableAdapters.USP_LISTADO_PRTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dSReportesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS_Reportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPLISTADOPRBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dSReportesBindingSource
            // 
            this.dSReportesBindingSource.DataSource = this.DS_Reportes;
            this.dSReportesBindingSource.Position = 0;
            // 
            // DS_Reportes
            // 
            this.DS_Reportes.DataSetName = "DS_Reportes";
            this.DS_Reportes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // uSPLISTADOPRBindingSource
            // 
            this.uSPLISTADOPRBindingSource.DataMember = "USP_LISTADO_PR";
            this.uSPLISTADOPRBindingSource.DataSource = this.DS_Reportes;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.uSPLISTADOPRBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SistemaCRUD.Presentacion.Reportes.Rpt_Listado_pr.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1124, 541);
            this.reportViewer1.TabIndex = 0;
            // 
            // txt_Reporte
            // 
            this.txt_Reporte.Location = new System.Drawing.Point(40, 80);
            this.txt_Reporte.Name = "txt_Reporte";
            this.txt_Reporte.Size = new System.Drawing.Size(100, 20);
            this.txt_Reporte.TabIndex = 1;
            this.txt_Reporte.Visible = false;
            // 
            // uSP_LISTADO_PRTableAdapter
            // 
            this.uSP_LISTADO_PRTableAdapter.ClearBeforeFill = true;
            // 
            // Form_Rpt_Listado_pr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 541);
            this.Controls.Add(this.txt_Reporte);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Rpt_Listado_pr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Rpt_Listado_pr";
            this.Load += new System.EventHandler(this.Form_Rpt_Listado_pr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSReportesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS_Reportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPLISTADOPRBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DS_Reportes DS_Reportes;
        private System.Windows.Forms.BindingSource uSPLISTADOPRBindingSource;
        internal System.Windows.Forms.TextBox txt_Reporte;
        private System.Windows.Forms.BindingSource dSReportesBindingSource;
        private DS_ReportesTableAdapters.USP_LISTADO_PRTableAdapter uSP_LISTADO_PRTableAdapter;
    }
}