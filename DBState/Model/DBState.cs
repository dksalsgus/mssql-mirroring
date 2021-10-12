using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBState.Model
{
    public class DBState
    {
        /// <summary>
        /// 데이터베이스 ID
        /// </summary>
        public int database_id { get; set; }
        /// <summary>
        /// Mirroring 상태
        /// </summary>
        public string mirroring_state_desc { get; set; }
        /// <summary>
        /// Mirroring 여부
        /// </summary>
        public string mirroring_role_desc { get; set; }
    }
}
