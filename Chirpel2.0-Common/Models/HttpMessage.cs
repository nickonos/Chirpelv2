using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chirpel2._0_Common.Models
{
    public class HttpMessage
    {
        public string Message { get; set; }
        public string? TechnicalMessage { get; set; }

        public HttpMessage(string message, string? technicalMessage = null)
        {
            Message = message;
            TechnicalMessage = technicalMessage;
        }
    }
}
