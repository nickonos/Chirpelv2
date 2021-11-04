using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chirpel2._0_Common.Models
{
    public class HttpException : Exception
    {
        public int StatusCode { get; set; }
        public HttpMessage? Message {  get; set; }

        public HttpException(int statusCode, HttpMessage? message = null)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
