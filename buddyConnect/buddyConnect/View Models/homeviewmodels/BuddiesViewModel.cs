using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using buddyConnect.Models.homemodels;
using System.Collections.ObjectModel;

namespace buddyConnect.View_Models.homeviewmodels
{
    public class BuddiesViewModel : BaseViewModel
    {
        private ObservableCollection<Buddies> testItems = new ObservableCollection<Buddies>();
        public ObservableCollection<Buddies> TestItems
        {
            get { return testItems; }
            set
            {
                testItems = value;
                RaisePropertyChanged();
            }
        }

    }
}
