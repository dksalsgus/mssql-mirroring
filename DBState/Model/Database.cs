using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBState.Model
{
    public class Database
    {
        /// <summary>
        /// 데이터베이스 id
        /// </summary>
        public int dbid { get; set; }

        /// <summary>
        /// 데이터베이스 이름
        /// </summary>
        public string name { get; set; }
    }
}