namespace DataLayer
{
    using DataLayer.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class ProductsDAO
    {
        private string connectionString;

        public ProductsDAO(string dataConnection)
        {
            connectionString = dataConnection;
        }

        //Instantiating
        List<ProductsDO> products = new List<ProductsDO>();

        //Read
        public List<ProductsDO> ReadProducts()
        {
            try
            {
                //Opening connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    //Use stored procedure to view all albums
                    SqlCommand command = new SqlCommand("DISPLAY_PRODUCTS", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    //Using adapter to get table from the datbase
                    DataTable dataTable = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                        adapter.Dispose();
                    }
                    //Put datarow into a list of AlbumDO
                    foreach (DataRow row in dataTable.Rows)
                    {
                        ProductsDO mappedProducts = MapProducts(row);
                        products.Add(mappedProducts);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return products;
        }

        //Map all products from a datarow to an ProductsDO
        public ProductsDO MapProducts(DataRow row)
        {
            ProductsDO mappedProducts = new ProductsDO();
            try
            {
                mappedProducts.ProductName = row["ProductName"].ToString();
                mappedProducts.ProductQuanity = row["QuantityPerUnit"].ToString();
                mappedProducts.UnitPrice = (decimal)row["UnitPrice"];
                mappedProducts.UnitsInStock = (short)row["UnitsInStock"];
                mappedProducts.UnitsOnOrder= (short)row["UnitsOnOrder"];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mappedProducts;
        }
    }
}
