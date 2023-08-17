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
    public interface IStudentService : IGenericService<Student>
    {
        List<StudentDetailDto> TGetDetailsById(int id);

        List<StudentDetailDto> TGetAvailableCourses(int studentId);
        void TAssignCoursesToStudent(int studentId, List<int> courseIds);

    }
}
