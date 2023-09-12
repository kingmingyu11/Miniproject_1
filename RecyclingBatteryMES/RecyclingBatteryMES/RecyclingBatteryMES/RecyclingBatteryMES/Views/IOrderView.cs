using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecyclingBatteryMES.Views
{
    internal interface IOrderView
    {
        // Fields
        string ResourceOption { get; set; }

        // Events
        event EventHandler InsertValue;

        // Methods
        void SetResourceListBindSource(BindingSource ResourceList);
        void ShowData(string data);
        void Show();

    }
}
