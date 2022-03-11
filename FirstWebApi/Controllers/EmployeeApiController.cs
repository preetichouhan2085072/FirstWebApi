using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWebApi.Models;

namespace FirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeApiController : ControllerBase
    {
        [HttpGet]
        public List<Emp> GetEmployees()
        {
            List<Emp> empList = new List<Emp>() {
                    new Emp() { Empno = 1005, Ename = "Scott", Job = "Manager" },
                    new Emp() { Empno = 1006, Ename = "Smith", Job = "Lead" },
                    new Emp() { Empno = 1007, Ename = "Sandy", Job = "Programmer" },
                    new Emp() { Empno = 1008, Ename = "Sam", Job = "Lead" }
            };

            return empList;
        }

        [HttpGet("{id}")]
        public Emp GetEmployeeById(int id)
        {
            List<Emp> empList = new List<Emp>() {

                    new Emp() { Empno = 1005, Ename = "Scott", Job = "Manager" },
                    new Emp() { Empno = 1006, Ename = "Smith", Job = "Lead" },
                    new Emp() { Empno = 1007, Ename = "Sandy", Job = "Programmer" },
                    new Emp() { Empno = 1008, Ename = "Sam", Job = "Lead" }
            };

            Emp obj = empList.SingleOrDefault(item => item.Empno == id);
            return obj;
        }

    }
}
