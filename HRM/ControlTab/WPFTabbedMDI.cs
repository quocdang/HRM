using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HRM
{
    public interface WPFTabbedMDI
    {
        UserControl CurrType { get; }
        bool Active { get; }

        string UniqueTabName { get; }

        string Title { get; }

        void Save();

        void Delete();
        
    }
}
