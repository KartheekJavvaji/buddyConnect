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


            var testItem = new buddieshome();
            testItem.data[0].age = "19";
            testItem.data[0].createddate = "";
            testItem.data[0].email = "iroozegar@hotmail.com";
            testItem.data[0].gender = "male";
            testItem.data[0].latitude = "0";
            testItem.data[0].longitude = "0";
            testItem.data[0].password = "iman2022";
            testItem.data[0].profile_imgurl = "http://www.graylogictech.com/glt_cs/upload_images/buddytracker/conner.jpg";
            testItem.data[0].result = "true";
            testItem.data[0].sno = "4960";
            testItem.data[0].status = "single";
            testItem.data[0].username = "conner";
        }
    }
}
