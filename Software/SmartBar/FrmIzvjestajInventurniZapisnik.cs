﻿using BusinessLogicLayer;
using BusinessLogicLayer.Services;
using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartBar
{
    public partial class FrmIzvjestajInventurniZapisnik : Form
    {
        private InventoryRecordService servisiRecord = new InventoryRecordService();
        private InventoryRecordItemService servisiItem= new InventoryRecordItemService();
        private ProductService productServices = new ProductService();
        private List<Product> listaProizvoda = new List<Product>();
        public FrmIzvjestajInventurniZapisnik()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void FrmIzvjestajInventurniZapisnik_Load(object sender, EventArgs e)
        {
            helpProvider1.HelpNamespace = System.Windows.Forms.Application.StartupPath + "\\Chm files/Zapisnik.chm";
            listaProizvoda = productServices.GetProducts();
            KreirajRecord();
          
            productBindingSource.DataSource = listaProizvoda;
            this.reportViewerInventura.RefreshReport();
        }

        private void KreirajRecord()
        {
            InventoryRecord newRecord = new InventoryRecord
            {
                Date = DateTime.Now,
                UserId =  CurrentUser.user.Id
            };
            
            servisiRecord.AddRecord(newRecord);
            KreirajItem(newRecord.Id);
        }

        private void KreirajItem(int id)
        {
            foreach (var proizvod in listaProizvoda)
            {
                InventoryRecordItem newItem = new InventoryRecordItem
                {
                    ProductId = proizvod.Id,
                    InventoryRecordId = id,
                    Amount = proizvod.Amount
                };

                servisiItem.AddRecord(newItem);
            }
        }

    }
}
