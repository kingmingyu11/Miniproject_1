using RecyclingBatteryMES.Models;
using RecyclingBatteryMES.Views;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*namespace RecyclingBatteryMES.Repositories
{
    internal class DashBoardRepository : BaseRepository, IDashboardRepository
    {
        // Constructor
        public DashBoardRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void DisplayResource()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Compound> GetBytotalWeightValue()
        {
            var compoundWeightList = new List<Compound>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"select 화합물이름, sum(무게) 
                                        from 화합물 
                                        group by 화합물이름";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var compoundModel = new Compound();
                        compoundModel.Weight = reader[0].ToString();
                        compoundWeightList.Add(compoundModel);
                    }
                }
                return compoundWeightList;
            }
        }
    }
}*/