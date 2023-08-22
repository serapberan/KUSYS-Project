using FluentValidation.Results;
using KUSYS_Demo.Business.Abstract;
using KUSYS_Demo.Business.ValidationRules;
using KUSYS_Demo.Entities.Concrete;
using KUSYS_Demo.Entities.DTOs;
using KUSYS_Demo.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KUSYS_Demo.UI.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;
        private readonly IStudentCourseService _studentCourseService;
        public StudentController(IStudentService studentService, ICourseService courseService, IStudentCourseService studentCourseService)
        {
            _studentService = studentService;
            _courseService = courseService;
            _studentCourseService = studentCourseService;
        }

        /// <summary>
        /// Tüm Ögrenci Listeleme İşlemleri
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var values = _studentService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            var values = _studentService.TGetList();
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            StudentValidator studentValidation = new StudentValidator();
            ValidationResult result = studentValidation.Validate(student);

            if (result.IsValid)
            {
                _studentService.TAdd(student);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateStudent(int id)
        {
            var values = _studentService.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateStudent(Student student)
        {
            _studentService.TUpdate(student);

            return RedirectToAction("Index");

        }

        /// <summary>
        /// Öğrenci Detay İşlemleri
        /// </summary>
        /// <returns></returns>
        public IActionResult Details(int id)
        {
            var values = _studentService.TGetDetailsById(id);
            return View(values);
        }

        /// <summary>
        /// Öğrenci Silme işlemi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteStudent(int id)
        {
            var values = _studentService.TGetByID(id);
            _studentService.TDelete(values);
            return RedirectToAction("Index");
        }


        /// <summary>
        /// Ders Seçme işlemi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SelectCourses(int id)
        {
            List<StudentDetailDto> availableCourses = _studentService.TGetAvailableCourses(id);

            var viewModel = new SelectCoursesViewModel
            {
                StudentId = id,
                AvailableCourses = availableCourses,
                SelectedCourseIds = new List<int>()
            };

            return View(viewModel);
        }


        /// <summary>
        /// Ders seçme işlemleri
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SelectCourses(SelectCoursesViewModel model)
        {
              
                _studentService.TAssignCoursesToStudent(model.StudentId, model.SelectedCourseIds);

                return RedirectToAction("Index", "Student");
        
            return View(model); 
        }


    }
}
