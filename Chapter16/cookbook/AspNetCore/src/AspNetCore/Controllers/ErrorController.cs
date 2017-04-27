using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.Controllers
{
    [Route("Error")]
    public class ErrorController
    {
        [Route("Support")]
        public string Support()
        {
            return "Content not found. Contact Support";
        }
    }
}
