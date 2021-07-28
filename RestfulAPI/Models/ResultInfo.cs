using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAPI.Models
{
    public class ResultInfo
    {
        /// <summary>
        ///  200 success, 300 fail
        /// </summary>
        public string ResultCode { get; set; }

        public string ResultMessage { get; set; }

        public object ResultData { get; set; }
    }
}
