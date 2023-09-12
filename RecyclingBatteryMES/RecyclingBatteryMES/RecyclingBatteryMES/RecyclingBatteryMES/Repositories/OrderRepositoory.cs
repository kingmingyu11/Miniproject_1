using RecyclingBatteryMES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecyclingBatteryMES.Models;
using System.Data.SqlClient;

namespace RecyclingBatteryMES.Repositories
{
    public class OrderRepositoory : BaseRepository, IOrderRepository
    {
        public IEnumerable<Order> GetAll()
        {
            var orderList = new List<Order>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"select * from BRORDER order by 무게";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var order = new Order();
                        order.Id = (int)reader[0];
                        order.Date = (DateTime)reader[1];
                        order.CompanyName = reader[2].ToString();
                        order.Weight = (int)reader[3];
                        order.Checking = (bool)reader[4];
                    }
                }
            }
            return orderList;
        }
    }
}
