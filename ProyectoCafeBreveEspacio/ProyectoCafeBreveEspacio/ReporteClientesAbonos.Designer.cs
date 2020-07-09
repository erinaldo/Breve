namespace ProyectoCafeBreveEspacio
{
    partial class ReporteClientesAbonos
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
            this.Reporte_Clientes_AbonosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet1 = new ProyectoCafeBreveEspacio.DataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Reporte_Clientes_AbonosTableAdapter = new ProyectoCafeBreveEspacio.DataSet1TableAdapters.Reporte_Clientes_AbonosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Reporte_Clientes_AbonosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // Reporte_Clientes_AbonosBindingSource
            // 
            this.Reporte_Clientes_AbonosBindingSource.DataMember = "Reporte_Clientes_Abonos";
            this.Reporte_Clientes_AbonosBindingSource.DataSource = this.DataSet1;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Reporte_Clientes_AbonosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ProyectoCafeBreveEspacio.ReporteClientesAbonoDiseño.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(725, 461);
            this.reportViewer1.TabIndex = 0;
            // 
            // Reporte_Clientes_AbonosTableAdapter
            // 
            this.Reporte_Clientes_AbonosTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteClientesAbonos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 461);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReporteClientesAbonos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReporteClientesAbonos";
            this.Load += new System.EventHandler(this.ReporteClientesAbonos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Reporte_Clientes_AbonosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Reporte_Clientes_AbonosBindingSource;
        private DataSet1 DataSet1;
        private DataSet1TableAdapters.Reporte_Clientes_AbonosTableAdapter Reporte_Clientes_AbonosTableAdapter;
    }
}