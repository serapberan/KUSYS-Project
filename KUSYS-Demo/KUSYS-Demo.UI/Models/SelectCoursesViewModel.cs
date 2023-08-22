
using KUSYS_Demo.Entities.Concrete;
using KUSYS_Demo.Entities.DTOs;

namespace KUSYS_Demo.UI.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class SelectCoursesViewModel
    {
        public int StudentId { get; set; }
        public List<StudentDetailDto> AvailableCourses { get; set; }
        public List<int> SelectedCourseIds { get; set; }
    }
}
