using HRIS.Database;
using HRIS.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HRIS.Controller
{
    class UnitController
    {

        public List<Unit> UnitList { get; set; }
        public ObservableCollection<Unit> ViewableUnits { get; set; }

        public UnitController()
        {
            UnitList = DBAdapter.GetUnitDetails(123456);
            ViewableUnits = new ObservableCollection<Unit>(UnitList);
        }

        public ObservableCollection<Unit> GetViewableUnits()
        {
            return ViewableUnits;
        }
    }
}
