using KUSYS_Demo.Core.Business;
using KUSYS_Demo.Entities.Concrete;
using KUSYS_Demo.Entities.DTOs;

namespace KUSYS_Demo.Business.Abstract
{
    public interface IStudentService : IGenericService<Student>
    {
        /// <summary>
        ///Seçilen öğrenci için  Detaylı listeleme işlemlerini gerçekleştirir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<StudentDetailDto> TGetDetailsById(int id);

        /// <summary>
        /// Öğrencinin seçtiği dersleri VT kaydet
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseIds"></param>
        void TAssignCoursesToStudent(int studentId, List<int> courseIds);

        /// <summary>
        /// Öğrencinin hangi dersleri sectiğini buluyoruz.
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        List<int> GetSelectedCourseIds(int studentId);

        /// <summary>
        /// Öğrencinin seçtiği çoklu dersler
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        List<StudentDetailDto> TGetAvailableCourses(int studentId);
    }
}
