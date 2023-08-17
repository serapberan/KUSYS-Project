using KUSYS_Demo.Business.Abstract;
using KUSYS_Demo.DataAccess.Abstract;
using KUSYS_Demo.DataAccess.Concrete.EntityFramework;
using KUSYS_Demo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Business.Concrete
{
    public class CourseManager : ICourseService
    {
       
        ICourseDal _courseDal;

        public CourseManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }

        public void TAdd(Course t)
        {
            _courseDal.Add(t);
          
        }

        public void TDelete(Course t)
        {
            _courseDal.Delete(t);
        }

        public Course TGetByID(int id)
        {
            return _courseDal.Get(c => c.CourseId == id);
        }

        public List<Course> TGetList()
        {
           return _courseDal.GetAll();
        }

        public void TUpdate(Course t)
        {
            _courseDal.Update(t);
         
        }
    }
}
