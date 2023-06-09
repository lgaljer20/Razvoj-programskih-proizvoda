﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using EntitiesLayer.Entities;

namespace DataAccessLayer.Repositories
{
    //DataBaseModel
    public class OrderFormRepository : IDisposable
    {
        private readonly SqlConnection connection;
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DataBaseModel"].ConnectionString;
        private readonly SupplierRepository _supplierRepository = new SupplierRepository();

        public OrderFormRepository()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public List<OrderForm> GetOrderForms()
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[OrderForm]", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<OrderForm> products = new List<OrderForm>();

                    while (reader.Read())
                    {
                        OrderForm product = new OrderForm
                        {
                            Id = reader.GetInt32(0),
                            Date = reader.GetDateTime(1),
                            UserId = reader.GetInt32(2),
                            Supplier = _supplierRepository.GetSupplierById(reader.GetInt32(3))
                        };
                        products.Add(product);
                    }

                    return products;
                }
            }

        }

        public int CreateOrderForm(OrderForm product)
        {
            int orderId;
            using (SqlCommand command = new SqlCommand("INSERT INTO [dbo].[OrderForm] (Date, UserId, SupplierId) OUTPUT INSERTED.Id VALUES (@Date, @UserId, @SupplierId)", connection))
            {
                command.Parameters.AddWithValue("@Date", product.Date);
                command.Parameters.AddWithValue("@UserId", product.UserId);
                command.Parameters.AddWithValue("@SupplierId", product.SupplierId);
                orderId = (int)command.ExecuteScalar();
            }
            return orderId;
        }


        public void UpdateOrderForm(OrderForm product)
        {

            using (SqlCommand command = new SqlCommand("UPDATE [dbo].[OrderForm] SET Date = @Date, UserId = @UserId, SupplierId = @SupplierId WHERE Id = @Id", connection))
            {
                command.Parameters.AddWithValue("@Id", product.Id);
                command.Parameters.AddWithValue("@Date", product.Date);
                command.Parameters.AddWithValue("@UserId", product.UserId);
                command.Parameters.AddWithValue("@SupplierId", product.SupplierId);

                command.ExecuteNonQuery();
            }

        }

        public void DeleteOrderForm(int id)
        {

            using (SqlCommand command = new SqlCommand("DELETE FROM [dbo].[OrderItem] WHERE OrderFormId = @Id", connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }

            using (SqlCommand command = new SqlCommand("DELETE FROM [dbo].[OrderForm] WHERE Id = @Id", connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }

        }

        public OrderForm GetOrderFormById(int id)
        {

            using (SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[OrderForm] WHERE Id = @Id", connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    OrderForm product = new OrderForm();

                    while (reader.Read())
                    {
                        product.Id = reader.GetInt32(0);
                        product.Date = reader.GetDateTime(1);
                        product.UserId = reader.GetInt32(2);
                        product.Supplier = _supplierRepository.GetSupplierById(reader.GetInt32(3));
                    }

                    return product;
                }
            }

        }

        public void Dispose()
        {
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }

            connection.Dispose();
        }
        //Luka Galjer
        public List<OrderForm> GetAllOrders()
        {
            using (var context = new DataBaseModel())
            {
                return context.OrderForms.ToList();
            }
        }
    }
}

