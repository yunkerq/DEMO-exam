using Demo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class ShiftController
    {
        List<Shift> shifts = new List<Shift>();
        public Shift CurrentShift { 
            get {
                foreach (Shift shift in shifts)
                {
                    if(shift.DateTime.Date == DateTime.Now.Date) return shift;
                }

                return null;
            } 
        }

        public ShiftController()
        {
            AddShift(DateTime.Now, new List<string>{"chef"});
        }

        public List<Shift> Shifts { 
            get { return shifts; }
        }

        public void AddShift(DateTime time, List<string> users)
        {
            shifts.Add(new Shift { DateTime = time, users = users });
        }

        public void AddShift(DateTime time, string user)
        {
            foreach (Shift shift in shifts)
            {
                if (shift.DateTime.Date == time.Date)
                {
                    shift.users.Add(user);
                    return;
                }
            }

            shifts.Add(new Shift { DateTime = time, users = new List<string> { user } });
        }

        public bool IsUserOnShiftToday(string name)
        {
            Shift shift = CurrentShift;
            if(shift == null) return false;

            return shift.users.Contains(name);
        }
    }
}
