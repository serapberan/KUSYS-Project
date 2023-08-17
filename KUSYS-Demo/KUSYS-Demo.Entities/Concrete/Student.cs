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
    /// Ögrenci Bilgilerini Tuttugumuz VeriTabanı Tablomuzu Belirtir.
    /// </summary>
    public class Student : IEntity
    {
        [Key]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int CourseId { get; set; }
        public Course Courses { get; set; }

    }
}
