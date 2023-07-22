using LiveShop.Model;
using System.Data;
using System.Data.SqlClient;

namespace LiveShop.Repositories
{
    public class ProductRepository
    {
        string connectionString;
        public ProductRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Car> GetProducts()
        {
            List<Car> products = new List<Car>();
            Car product;
            var data = GetProductDetailsFromDb();
            foreach (DataRow row in data.Rows)
            {
                product = new Car
                {
                    ID = Convert.ToInt32(row["CarID"]),
                    Name = row["CarName"].ToString(),
                    Manufacturer = row["Manufacturer"].ToString(),
                    Price = Convert.ToDecimal(row["Price"]),
                    ReleasedYear = Convert.ToInt32(row["ReleasedYear"])
                };
                products.Add(product);
            }
            return products;
        }

        public Car GetProductByID(int id)
        {
            List<Car> products = GetProducts();
            foreach (Car car in products)
            {
                if (car.ID == id)
                {
                    return car;
                }
            }
            return null;
        }

        public void RemoveProduct(Car car)
        {
            var product = GetProductByID(car.ID);
            if (product != null)
            {
                var query = "DELETE FROM Car WHERE CarID = " + car.ID;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally { connection.Close(); }
                }
            }
        }

        public void UpdateProduct(Car car)
        {
            var product = GetProductByID(car.ID);
            if (product != null)
            {
                var query = "UPDATE Car" +
                    "\r\nSET " +
                    "\r\nCarName = '"+car.Name+"'," +
                    "\r\nManufacturer = '"+car.Manufacturer+"'," +
                    "\r\nPrice = "+car.Price+"," +
                    "\r\nReleasedYear = "+car.ReleasedYear+"" +
                    "\r\nWHERE CarID = "+car.ID+";";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally { connection.Close(); }
                }
            }
        }
        public DataTable GetProductDetailsFromDb()
        {
            var query = "SELECT CarID, CarName, Manufacturer, Price, ReleasedYear FROM Car";
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dataTable.Load(reader);
                        }
                    }
                    return dataTable;
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally { connection.Close(); }
            }
        }
    }
}
