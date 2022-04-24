using HRIS.Database;
using HRIS.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HRIS.Controller
{
    class StaffController
    {
        public List<Staff> Staff { get; set; }
        public ObservableCollection<Staff> viewableStaff { get; set; }

        public StaffController()
        {
            
            Staff = DBAdapter.GetStaffDetails();
            viewableStaff = new ObservableCollection<Staff>(Staff);
            
        }

        public ObservableCollection<Staff> GetViewableList()
        {
            return viewableStaff;
        }
        public void Add(string ID, string GivenName, string FamilyName)
        {
            DBAdapter.AddStaff(ID, GivenName, FamilyName);
        }
    }
}
