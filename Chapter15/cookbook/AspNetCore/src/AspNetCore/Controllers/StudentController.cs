using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCore.Models;

namespace AspNetCore.Controllers
{
    [Route("Student")]
    public class StudentController : Controller
    {
        [Route("Find")]
        public IActionResult Find()
        {
            var studentModel = new Student
            {
                StudentNumber = 123
                , FirstName = "Dirk"
                , LastName = "Strauss"
            };

            return View(studentModel);
        }
    }
}
