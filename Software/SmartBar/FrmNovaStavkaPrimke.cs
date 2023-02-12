﻿using BusinessLogicLayer.Services;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace SmartBar
{
    public partial class FrmNovaStavkaPrimke : Form
    {
        private Docket selectedDocket;

        DocketItemService docketServis = new DocketItemService();

        ProductRepository repo = new ProductRepository();
        public FrmNovaStavkaPrimke(Docket docket)
        {
            InitializeComponent();
            selectedDocket = docket;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            KreirajStavku();      
            
        }

        private void KreirajStavku()
        {
            try
            {
                int kolicina = Convert.ToInt32(txtKolicina.Text);
                Product selectedProduct = cmbProizvodi.SelectedItem as Product;

                int uspjesno = docketServis.CheckIfProductExists(selectedDocket,selectedProduct);

                if (uspjesno > 0)
                {
                    MessageBox.Show("Stavka za uneseni proizvod već postoji");

                }
                else
                {
                    DocketItem newStavka = new DocketItem
                    {
                        DocketId = selectedDocket.Id,
                        Amount = kolicina,
                        ProductId = selectedProduct.Id
                    };

                    docketServis.AddDocketItem(newStavka);
                    Close();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Niste ispunili sva polja.");
            }



        }

        private void FrmNovaStavkaPrimke_Load(object sender, EventArgs e)
        {
            DohvatiProizvode();
        }

        private void DohvatiProizvode()
        {
            cmbProizvodi.DataSource = repo.GetProducts();
        }
    }
}
