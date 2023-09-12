using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecyclingBatteryMES.Views
{
    public interface IDashboardView
    {
        // Fields
        string ResourceOption { get; set; }

        // Events
        event EventHandler OnDisplay;

        // Methods
        void SetResourceListBindSource(BindingSource ResourceList);
        void Show(); 
    }
}
