using KUSYS_Demo.Core.Business;
using KUSYS_Demo.Entities.Concrete;
using KUSYS_Demo.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Business.Abstract
{
    /// <summary>
    /// Temel Crud işlemleri ve kendine özgü metodları tanımlar.
    /// </summary>
    public interface IStudentService : IGenericService<Student>
    {
        /// <summary>
        /// Seçilen öğrenci detay bilgisini verir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<StudentDetailDto> TGetDetailsById(int id);
    }
}
