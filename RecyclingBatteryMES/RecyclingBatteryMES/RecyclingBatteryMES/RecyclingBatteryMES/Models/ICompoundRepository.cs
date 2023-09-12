using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingBatteryMES.Models
{
    public interface ICompoundRepository
    {
        IEnumerable<Compound> GetAll();
    }
}
