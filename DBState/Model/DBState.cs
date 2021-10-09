using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBState.Model
{
    public class DBState
    {
        public int database_id { get; set; }
        public string mirroring_state_desc { get; set; }
        public string mirroring_role_desc { get; set; }
    }
}
