﻿namespace ProyectoCafeBreveEspacio
{
    partial class ReporteCortesCajacs
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
            this.Historial_CCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet1 = new ProyectoCafeBreveEspacio.DataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Historial_CCTableAdapter = new ProyectoCafeBreveEspacio.DataSet1TableAdapters.Historial_CCTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Historial_CCBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // Historial_CCBindingSource
            // 
            this.Historial_CCBindingSource.DataMember = "Historial_CC";
            this.Historial_CCBindingSource.DataSource = this.DataSet1;
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
            reportDataSource1.Value = this.Historial_CCBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ProyectoCafeBreveEspacio.ReportCorteCajaDiseño.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(833, 461);
            this.reportViewer1.TabIndex = 0;
            // 
            // Historial_CCTableAdapter
            // 
            this.Historial_CCTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteCortesCajacs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 461);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReporteCortesCajacs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReporteCortesCajacs";
            this.Load += new System.EventHandler(this.ReporteCortesCajacs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Historial_CCBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Historial_CCBindingSource;
        private DataSet1 DataSet1;
        private DataSet1TableAdapters.Historial_CCTableAdapter Historial_CCTableAdapter;
    }
}