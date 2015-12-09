using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using buddyConnect.Models.homemodels;

namespace buddyConnect.View_Models.homeviewmodels
{
    public class ChatsViewModel : BaseViewModel
    {
        public class SecondPageViewModel : BaseViewModel
        {
            private Buddies selectedItem;

            public Buddies SelectedItem
            {
                get { return selectedItem; }
                set
                {
                    selectedItem = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
