﻿namespace SmartBar
{
    partial class FrmIzvjestajInventurniZapisnik
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
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewerInventura = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataSource = typeof(EntitiesLayer.Entities.Product);
            // 
            // reportViewerInventura
            // 
            this.reportViewerInventura.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DsProducts";
            reportDataSource1.Value = this.productBindingSource;
            this.reportViewerInventura.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewerInventura.LocalReport.ReportEmbeddedResource = "SmartBar.reportAllProducts.rdlc";
            this.reportViewerInventura.Location = new System.Drawing.Point(0, 0);
            this.reportViewerInventura.Name = "reportViewerInventura";
            this.reportViewerInventura.ServerReport.BearerToken = null;
            this.reportViewerInventura.Size = new System.Drawing.Size(1122, 618);
            this.reportViewerInventura.TabIndex = 0;
            // 
            // FrmIzvjestajInventurniZapisnik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 618);
            this.Controls.Add(this.reportViewerInventura);
            this.Name = "FrmIzvjestajInventurniZapisnik";
            this.Text = "TestnaForma";
            this.Load += new System.EventHandler(this.TestnaForma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerInventura;
        private System.Windows.Forms.BindingSource productBindingSource;
    }
}