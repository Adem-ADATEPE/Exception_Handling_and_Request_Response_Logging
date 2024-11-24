using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Middleware.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {


        [HttpGet]
        public String Get()
        {
            //throw new Exception("Test hatası");
            return "ok";
        }

        [HttpGet("Student")]
        public Student GetStudent()
        {

            return new Student()
            {
                Id = 1,
                FullName = "Adem Adatepe"
            };
        }

        [HttpPost("Student")]
        public String CreateStudent([FromBody] Student student)
        {

            return "Ogrenci olusturuldu.";
        }

    }

    public class Student
    {
        public int Id { get; set; }
        public String FullName { get; set; }
    }
}
