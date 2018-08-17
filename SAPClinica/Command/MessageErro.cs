using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SAPClinica.Command
{
    public class MessageErro
    {
        public string aErro;

        [DebuggerStepThrough]
        public MessageErro()
        {
        }
    }
}