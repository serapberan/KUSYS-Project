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
        /// Seçilen öğrenci için Detay listesi işlemlerini gerçekleştirir.
        /// <br/> Seçilen Öğrenciye göre ders bilgilerine ulaşmamızı sağlar.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<StudentDetailDto> GetDetailsById(int id);

    }
}
