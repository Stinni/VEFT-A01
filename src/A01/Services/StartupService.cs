using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using A01.Models;

namespace A01.Services
{
    public class StartupService
    {
        public List<Course> FillCoursesList()
        {
            return new List<Course>
            {
                new Course()
                {
                    Name = "Web Services",
                    TemplateID = "T-514-VEFT",
                    ID = 1,
                    StartDate = Convert.ToDateTime("17/08/2016"),
                    EndDate = Convert.ToDateTime("08/11/2016")
                },
                new Course()
                {
                    Name = "Computer Networking",
                    TemplateID = "T-409-TSAM",
                    ID = 2,
                    StartDate = Convert.ToDateTime("17/08/2016"),
                    EndDate = Convert.ToDateTime("08/11/2016")
                }
            };
        }
        public List<Student> FillStudentsList()
        {
            return null; // TODO: útbúa nokkra nemendur o.s.frv.
        }
    }
}
