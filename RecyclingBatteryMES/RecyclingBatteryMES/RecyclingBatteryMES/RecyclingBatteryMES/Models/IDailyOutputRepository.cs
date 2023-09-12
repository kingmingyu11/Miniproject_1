using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecyclingBatteryMES.Models
{
    public interface IDailyOutputRepository
    {
        IEnumerable<DailyOutput> GetAll();
    }
}
