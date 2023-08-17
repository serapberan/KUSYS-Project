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
    /// </summary>
    public class EfStudentDal : EfEntityRepositoryBase<Student, KusysContext>, IStudentDal
    {

  
        public void AssignCoursesToStudent(int studentId, List<int> courseIds)
        {
            using (var context = new KusysContext())
            {
                foreach (var courseId in courseIds)
                {
                    context.StudentCourses.Add(new StudentCourse
                    {
                        StudentId = studentId,
                        CourseId = courseId
                    });
                }

                context.SaveChanges(); 
            }
        }


        public List<StudentDetailDto> GetDetailsById(int id)
        {
            using (var context = new KusysContext())
            {
                var studentDetails = context.StudentCourses
                    .Where(sc => sc.StudentId == id)
                    .Select(studentCourse => new StudentDetailDto
                    {
                        FirstName = studentCourse.Student.FirstName,
                        LastName = studentCourse.Student.LastName,
                        BirthDate = studentCourse.Student.BirthDate,
                        CourseCode = studentCourse.Course.CourseCode,
                        CourseName = studentCourse.Course.CourseName
                    })
                    .ToList();

                return studentDetails;
            }
        }




        //Kim hangi dersi seçti
        public List<int> GetSelectedCourseIds(int studentId)
        {
            using (var context = new KusysContext())
            {
                return context.StudentCourses.Where(s => s.StudentId == studentId).Select(sc => sc.CourseId).ToList();
            }
        }

    }
}
