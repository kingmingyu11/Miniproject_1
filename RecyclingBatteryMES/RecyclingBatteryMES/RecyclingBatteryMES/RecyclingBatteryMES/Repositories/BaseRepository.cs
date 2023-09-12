using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecyclingBatteryMES.Repositories
{
    public abstract class BaseRepository
    {
        readonly protected string connectionString = "Data Source=(DESCRIPTION=" +
                                                     "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                                                     "(HOST=127.0.0.1)(PORT=1521)))" +
                                                     "(CONNECT_DATA=(SERVER=DEDICATED)" +
                                                     "(SERVICE_NAME=xe)));" +
                                                     "User Id=hr;Password=hr;";
        
        protected OracleConnection connection = null;
        protected OracleCommand command = null;
        protected OracleDataReader reader = null;
    }
}
