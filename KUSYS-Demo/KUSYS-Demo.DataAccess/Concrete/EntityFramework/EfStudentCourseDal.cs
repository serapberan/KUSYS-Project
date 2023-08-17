using KUSYS_Demo.Core.DataAccess.EntityFramework;
using KUSYS_Demo.DataAccess.Abstract;
using KUSYS_Demo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.DataAccess.Concrete.EntityFramework
{
    public class EfStudentCourseDal : EfEntityRepositoryBase<StudentCourse, KusysContext>, IStudentCourseDal
    {
     
    }
}
