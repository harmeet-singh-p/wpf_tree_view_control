using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTreeViewControl.ViewModels
{
    public interface IViewModelItem : INotifyPropertyChanged
    {
        IViewModelItem Parent { get; }
    }
}
