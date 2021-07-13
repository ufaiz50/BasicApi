using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public class JwtTokenVM
    {
        public string Message { get; set; }
        public string Result { get; set; }
        public HttpStatusCode Status { get; set; }

        public JwtTokenVM() { }

        public JwtTokenVM(string message, string result, HttpStatusCode status)
        {
            this.Message = message;
            this.Result = result;
            this.Status = status;

        }
    }

}
