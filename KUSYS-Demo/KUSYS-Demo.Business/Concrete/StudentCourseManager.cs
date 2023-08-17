using KUSYS_Demo.Business.Abstract;
using KUSYS_Demo.DataAccess.Abstract;
using KUSYS_Demo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Business.Concrete
{
    public class StudentCourseManager : IStudentCourseService
    {
        IStudentCourseDal _studentCourseDal;

        public StudentCourseManager(IStudentCourseDal studentCourseDal)
        {
            _studentCourseDal = studentCourseDal;
        }

        public void TAdd(StudentCourse t)
        {
            _studentCourseDal.Add(t);
        }

      

        public void TDelete(StudentCourse t)
        {
            _studentCourseDal.Delete(t);
        }

        public StudentCourse TGetByID(int id)
        {
            return _studentCourseDal.Get(x => x.StudentId == id);
        }

        public List<StudentCourse> TGetList()
        {
            return _studentCourseDal.GetAll();
        }

        public void TUpdate(StudentCourse t)
        {
            _studentCourseDal.Update(t);
        }
    }
}
