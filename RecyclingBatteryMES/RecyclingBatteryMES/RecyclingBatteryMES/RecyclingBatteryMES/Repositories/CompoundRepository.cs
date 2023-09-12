using RecyclingBatteryMES.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using RecyclingBatteryMES.Models;
using System.Drawing.Text;
using System.Data.OracleClient;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Diagnostics;

namespace RecyclingBatteryMES.Repositories
{
    public class CompoundRepository : BaseRepository ,ICompoundRepository
    {
  
        public IEnumerable<Compound> GetAll()
        {
            var compoundList = new List<Compound>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"select * from BRCOMPOUND order by 무게";

                Trace.Write(command.CommandText);
                MessageBox.Show(command.CommandText);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var compound = new Compound();
                        compound.Id = (int)reader[0];
                        compound.Name = reader[1].ToString();
                        compound.Weight = (int)reader[2];
                    }
                }
            }
            return compoundList;
        } 
    }
}

