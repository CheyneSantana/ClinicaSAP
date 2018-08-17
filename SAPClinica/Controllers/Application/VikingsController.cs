using SAPClinica.Command;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SAPClinica.Controllers.Application
{
    public class VikingsController : Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
            base.Initialize(requestContext);
        }

        protected CoViking _CoViking = null;
        public CoViking aCoViking
        {
            get
            {
                if (_CoViking == null)
                    _CoViking = new CoViking();
                return _CoViking;
            }
        }
    }
}