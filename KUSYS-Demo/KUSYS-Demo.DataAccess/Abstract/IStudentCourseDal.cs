using KUSYS_Demo.Core.DataAccess;
using KUSYS_Demo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.DataAccess.Abstract
{
    public interface IStudentCourseDal : IEntityRepository<StudentCourse>
    {
       
    }
}
