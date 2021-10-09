using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBState.Cls
{
    public class Enumcls
    {
        public enum EnState
        {
            SYNCHRONIZED,
            DISCONNECTED
        }

        public enum EnRole
        {   
            PRINCIPAL=0,
            MIRROR
        }
    }
}
