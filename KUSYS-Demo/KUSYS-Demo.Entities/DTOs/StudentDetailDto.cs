using KUSYS_Demo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Entities.DTOs
{
    public class StudentDetailDto : IDto
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
    }
}
