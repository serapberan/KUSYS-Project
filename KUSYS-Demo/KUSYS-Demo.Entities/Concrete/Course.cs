using KUSYS_Demo.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Entities.Concrete
{
    /// <summary>
    /// Ders Bilgilerini Tuttugumuz VeriTabanı Tablomuzu Belirtir.
    /// </summary>
    public class Course : IEntity
    {
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }
    }
}
