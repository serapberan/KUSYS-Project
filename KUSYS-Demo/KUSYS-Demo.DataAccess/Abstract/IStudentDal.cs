using KUSYS_Demo.Core.DataAccess;
using KUSYS_Demo.Entities.Concrete;
using KUSYS_Demo.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.DataAccess.Abstract
{
    /// <summary>
    /// Student --> Kendine özel  VeriTabanı Operasyonlarını yapmamızı saglar.
    /// </summary>
    public interface IStudentDal : IEntityRepository<Student>
    {
        /// <summary>
        /// //Seçilen öğrenci için  Detay listesi işlemlerini gerçekleştirir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<StudentDetailDto> GetDetailsById(int id);
        
        
        /// <summary>
        /// Öğrencinin hangi dersleri sectiğini buluyoruz.
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        List<int> GetSelectedCourseIds(int studentId);


        /// <summary>
        /// Öğrencinin seçtiği dersleri VT kaydet
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseIds"></param>
        void AssignCoursesToStudent(int studentId, List<int> courseIds);

    }
}
