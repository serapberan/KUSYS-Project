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
        ICourseDal _courseDal;

        public StudentManager(IStudentDal studentDal, ICourseDal courseDal = null)
        {
            _studentDal = studentDal;
            _courseDal = courseDal;
        }

        public void TAdd(Student student)
        {
            // Öğrencinin daha önce seçtiği dersleri al
            var selectedCourses = _studentDal.GetDetailsById(student.StudentId).Select(detail => detail.CourseId);

            // Eğer öğrenci zaten bu dersi seçmişse, hata fırlat
            if (selectedCourses.Contains(student.CourseId))
            {
                throw new InvalidOperationException("Öğrenci zaten bu dersi seçmiş.");
            }

            _studentDal.Add(student);
        }


        //public void TAdd(Student t)
        //{
        //    _studentDal.Add(t);
        //}

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

    }
}
