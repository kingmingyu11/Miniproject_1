using RecyclingBatteryMES.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecyclingBatteryMES.Repositories
{
    internal class DailyOutputRepository : BaseRepository, IDailyOutputRepository
    {
        public IEnumerable<DailyOutput> GetAll()
        {
            var dailyOutputList = new List<DailyOutput>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"select * from BRDAY order by 무게";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var dailyOutput = new DailyOutput();
                        dailyOutput.Id = (int)reader[0];
                        dailyOutput.Name = reader[1].ToString();
                        dailyOutput.Weight = (int)reader[2];
                    }
                }
            }
            return dailyOutputList;
        }
    }
}
