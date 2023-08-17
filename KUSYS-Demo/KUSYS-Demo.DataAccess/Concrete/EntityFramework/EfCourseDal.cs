using KUSYS_Demo.Core.DataAccess.EntityFramework;
using KUSYS_Demo.DataAccess.Abstract;
using KUSYS_Demo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.DataAccess.Concrete.EntityFramework
{
    /// <summary>
    /// Course Tablomuz için  EfEntityRepositoryBase --> ile generic olarak VT operasyon islemlerini gerceklestir.
    /// </summary>
    public class EfCourseDal : EfEntityRepositoryBase<Course,KusysContext>,ICourseDal
    {
       
    }
}
