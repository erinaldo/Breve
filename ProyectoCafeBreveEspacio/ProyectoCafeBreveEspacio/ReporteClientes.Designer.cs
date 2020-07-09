namespace ProyectoCafeBreveEspacio
{
    partial class ReporteClientes
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.Reporte_Clientes_AdeudosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet1 = new ProyectoCafeBreveEspacio.DataSet1();
            this.Reporte_Clientes_AbonosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Reporte_Clientes_AdeudosTableAdapter = new ProyectoCafeBreveEspacio.DataSet1TableAdapters.Reporte_Clientes_AdeudosTableAdapter();
            this.Reporte_Clientes_AbonosTableAdapter = new ProyectoCafeBreveEspacio.DataSet1TableAdapters.Reporte_Clientes_AbonosTableAdapter();
            this.datosclientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.datosclientesTableAdapter = new ProyectoCafeBreveEspacio.DataSet1TableAdapters.datosclientesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Reporte_Clientes_AdeudosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporte_Clientes_AbonosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datosclientesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Reporte_Clientes_AdeudosBindingSource
            // 
            this.Reporte_Clientes_AdeudosBindingSource.DataMember = "Reporte_Clientes_Adeudos";
            this.Reporte_Clientes_AdeudosBindingSource.DataSource = this.DataSet1;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Reporte_Clientes_AbonosBindingSource
            // 
            this.Reporte_Clientes_AbonosBindingSource.DataMember = "Reporte_Clientes_Abonos";
            this.Reporte_Clientes_AbonosBindingSource.DataSource = this.DataSet1;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Reporte_Clientes_AdeudosBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.Reporte_Clientes_AbonosBindingSource;
            reportDataSource3.Name = "DataSet3";
            reportDataSource3.Value = this.datosclientesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ProyectoCafeBreveEspacio.ReporteClientesDiseño.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(740, 461);
            this.reportViewer1.TabIndex = 0;
            // 
            // Reporte_Clientes_AdeudosTableAdapter
            // 
            this.Reporte_Clientes_AdeudosTableAdapter.ClearBeforeFill = true;
            // 
            // Reporte_Clientes_AbonosTableAdapter
            // 
            this.Reporte_Clientes_AbonosTableAdapter.ClearBeforeFill = true;
            // 
            // datosclientesBindingSource
            // 
            this.datosclientesBindingSource.DataMember = "datosclientes";
            this.datosclientesBindingSource.DataSource = this.DataSet1;
            // 
            // datosclientesTableAdapter
            // 
            this.datosclientesTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 461);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReporteClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReporteClientes";
            this.Load += new System.EventHandler(this.ReporteClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Reporte_Clientes_AdeudosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporte_Clientes_AbonosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datosclientesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Reporte_Clientes_AdeudosBindingSource;
        private DataSet1 DataSet1;
        private DataSet1TableAdapters.Reporte_Clientes_AdeudosTableAdapter Reporte_Clientes_AdeudosTableAdapter;
        private System.Windows.Forms.BindingSource Reporte_Clientes_AbonosBindingSource;
        private DataSet1TableAdapters.Reporte_Clientes_AbonosTableAdapter Reporte_Clientes_AbonosTableAdapter;
        private System.Windows.Forms.BindingSource datosclientesBindingSource;
        private DataSet1TableAdapters.datosclientesTableAdapter datosclientesTableAdapter;
    }
}