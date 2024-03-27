using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Model
{
    public class Shift
    {
        public DateTime DateTime { get; set; }
        public List<string> users { get; set; }

        public string Users { 
            get
            {
                string res = "";
                int i = 0;
                foreach(string user in users)
                {
                    if(i == users.Count-1)
                    {
                        res += user;
                    }
                    else res += user + ",";
                    i += 1;

                }

                return res;
            }
        }

        public Shift() 
        { 
        
        }
    
        

    }
}
