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
        private ObservableCollection<buddieshome> testItems = new ObservableCollection<buddieshome>();
        public ObservableCollection<buddieshome> TestItems
        {
            get { return testItems; }
            set
            {
                testItems = value;
                RaisePropertyChanged();
            }
        }

        protected override void LoadDesignTimeData()
        {
            base.LoadDesignTimeData();


           
        }
    }
}
