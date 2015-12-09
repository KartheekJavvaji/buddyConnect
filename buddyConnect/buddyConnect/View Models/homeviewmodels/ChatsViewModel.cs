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
            private buddieshome selectedItem;

            public buddieshome SelectedItem
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

                SelectedItem  = new buddieshome();
                SelectedItem.data[0].age = "19";
                SelectedItem.data[0].createddate = "";
                SelectedItem.data[0].email = "iroozegar@hotmail.com";
                SelectedItem.data[0].gender = "male";
                SelectedItem.data[0].latitude = "0";
                SelectedItem.data[0].longitude = "0";
                SelectedItem.data[0].password = "iman2022";
                SelectedItem.data[0].profile_imgurl = "http://www.graylogictech.com/glt_cs/upload_images/buddytracker/conner.jpg";
                SelectedItem.data[0].result = "true";
                SelectedItem.data[0].sno = "4960";
                 SelectedItem.data[0].status = "single";
                SelectedItem.data[0].username = "conner";
            }
        }

    }
}
