using KUSYS_Demo.Business.Abstract;
using KUSYS_Demo.DataAccess.Abstract;
using KUSYS_Demo.Entities.Concrete;
using KUSYS_Demo.Entities.DTOs;

namespace KUSYS_Demo.Business.Concrete
{
    public class StudentManager : IStudentService
    {
        IStudentDal _studentDal;
        ICourseDal _courseDal;
        public StudentManager(IStudentDal studentDal, ICourseDal courseDal)
        {
            _studentDal = studentDal;
            _courseDal = courseDal;
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


        public void TAssignCoursesToStudent(int studentId, List<int> courseIds)
        {
            _studentDal.AssignCoursesToStudent(studentId, courseIds);
        }

        public List<int> GetSelectedCourseIds(int studentId)
        {
            return _studentDal.GetSelectedCourseIds(studentId);
        }

     
        public List<StudentDetailDto> TGetAvailableCourses(int studentId)
        {
            return _studentDal.GetAvailableCourses(studentId);
        }

    }
}
