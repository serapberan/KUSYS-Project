using KUSYS_Demo.Core.Business;
using KUSYS_Demo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Business.Abstract
{
    /// <summary>
    /// Temel Crud işlemleri ve kendine özgü metodları tanımlar.
    /// </summary>
    public interface ICourseService : IGenericService<Course>
    {
       
    }
}
