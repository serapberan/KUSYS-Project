using KUSYS_Demo.Core.DataAccess.EntityFramework;
using KUSYS_Demo.DataAccess.Abstract;
using KUSYS_Demo.Entities.Concrete;
using KUSYS_Demo.Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.DataAccess.Concrete.EntityFramework
{
    /// <summary>
    /// Student Tablomuz için  EfEntityRepositoryBase --> ile generic olarak VT operasyon islemlerini gerceklestir.
    /// <br/> Kendine özgü metodlar tanımlaya biliriz.
    /// </summary>
    public class EfStudentDal : EfEntityRepositoryBase<Student, KusysContext>, IStudentDal
    {
        public List<StudentDetailDto> GetDetailsById(int id)
        {
            using (var context = new KusysContext())
            {
                var students = context.Students
                    .Include(s => s.Courses)
                    .Where(s => s.StudentId == id)
                    .ToList();

                var studentList = students.Select(values => new StudentDetailDto
                {
                    FirstName = values.FirstName,
                    LastName = values.LastName,
                    BirthDate = values.BirthDate,
                    CourseCode = values.Courses.CourseCode,
                    CourseName = values.Courses.CourseName
                }).ToList();

                return studentList;
            }
        }

    }
}