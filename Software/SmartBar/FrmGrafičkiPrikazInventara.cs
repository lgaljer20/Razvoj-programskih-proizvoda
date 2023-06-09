﻿using BusinessLogicLayer.Services;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SmartBar
{
    public partial class FrmGrafičkiPrikazInventara : Form
    {

        private ProductRepository repo = new ProductRepository();
   
        public FrmGrafičkiPrikazInventara()
        {
            InitializeComponent();
         
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void FrmGraphProduct_Load(object sender, EventArgs e)
        {
           
            var products = repo.GetProducts();

            List<Tuple<string, int, string>> data = new List<Tuple<string, int, string>>();

            foreach (var product in products)
            {
                data.Add(new Tuple<string, int, string>(product.Name, (int)product.Amount, product.MeasurementUnit));
            }

            MakeChart(data);
         
        }

        private void MakeChart(List<Tuple<string, int, string>> data)
        {
            chartProducts.Series[0].Points.DataBindXY(data, "Item1", data, "Item2");
            chartProducts.Series[0].XValueMember = "ProductName";
            chartProducts.Series[0].YValueMembers = "ProductAmount";
            chartProducts.Series[0].Label = "#VALX";

            for (int i = 0; i < chartProducts.Series[0].Points.Count; i++)
            {
                DataPoint point = chartProducts.Series[0].Points[i];
                point.ToolTip = string.Format("Količina: {0}", point.YValues[0]+" "+data[i].Item3);
            }

            chartProducts.Series[0].ChartType = SeriesChartType.Pie;
            chartProducts.DataBind();
        }
    }
}
