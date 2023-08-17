using KUSYS_Demo.Business.Abstract;
using KUSYS_Demo.Core.Entities;
using KUSYS_Demo.DataAccess.Abstract;
using KUSYS_Demo.Entities.Concrete;
using KUSYS_Demo.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Business.Concrete
{
    public class StudentManager : IStudentService
    {
        IStudentDal _studentDal;
        ICourseService _courseService;
        public StudentManager(IStudentDal studentDal, ICourseService courseService)
        {
            _studentDal = studentDal;
            _courseService = courseService;
        }

        public void TAdd(Student t)
        {
            _studentDal.Add(t);
        }

        public void TDelete(Student t)
        {
            _studentDal.Delete(t);
        }

        public Student TGetByID(int id)
        {
            return _studentDal.Get(s => s.StudentId == id);
        }

        public List<Student> TGetList()
        {
            return _studentDal.GetAll();
        }

        public void TUpdate(Student t)
        {
            _studentDal.Update(t);
        }

        public List<StudentDetailDto> TGetDetailsById(int id)
        {
            return _studentDal.GetDetailsById(id);
        }



        public List<StudentDetailDto> TGetAvailableCourses(int studentId)
        {
            List<int> selectedCourseIds = _studentDal.GetSelectedCourseIds(studentId);
            List<Course> allCourses = _courseService.TGetList();

            var availableCourses = allCourses
                .Where(course => !selectedCourseIds.Contains(course.CourseId))
                .Select(course => new StudentDetailDto
                {
                    StudentId = studentId,
                    CourseId = course.CourseId,
                    //FirstName =  "", // Öğrencinin adı ve soyadı, ders bilgileri gibi alanları buradan almanız gerekecektir.
                    //LastName = "",
                    //BirthDate = DateTime.Now,
                    CourseCode = course.CourseCode,
                    CourseName = course.CourseName
                })
                .ToList();

            return availableCourses;
        }

        public void TAssignCoursesToStudent(int studentId, List<int> courseIds)
        {
            // Seçilen dersleri öğrenciye atama işlemi burada gerçekleştirilir.
             _studentDal.AssignCoursesToStudent(studentId, courseIds);
        }


    }
}
