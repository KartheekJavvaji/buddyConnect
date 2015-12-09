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

        protected override void LoadDesignTimeData()
        {
            base.LoadDesignTimeData();

            for (var i = 1; i < 10; i++)
            {
                var color = string.Join("", Enumerable.Repeat(i.ToString(), 6));
                var testItem = new Buddies() { Id = i, Title = "Test Item " + i, Subtitle = "Subtitle " + i, HexColor = string.Concat("#", color) };
                TestItems.Add(testItem);
            }
        }
    }
}
