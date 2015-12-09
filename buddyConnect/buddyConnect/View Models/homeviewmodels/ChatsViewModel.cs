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

            protected override void LoadDesignTimeData()
            {
                base.LoadDesignTimeData();

                SelectedItem = new Buddies() { Title = "Design Time Selected Item", Subtitle = "Design subtitle", HexColor = "#333333" };
            }
        }

    }
}
