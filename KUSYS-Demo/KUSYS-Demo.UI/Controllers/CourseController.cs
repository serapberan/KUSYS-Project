using FluentValidation.Results;
using KUSYS_Demo.Business.Abstract;
using KUSYS_Demo.Business.ValidationRules;
using KUSYS_Demo.DataAccess.Concrete.EntityFramework;
using KUSYS_Demo.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace KUSYS_Demo.UI.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        /// <summary>
        /// Ders Listeleme İşlemi
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
           var values = _courseService.TGetList();
           return View(values);
        }

        /// <summary>
        /// Yeni Ders Ekleme İşlemi
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddCourse() 
        {
            return View();
        }
        /// <summary>
        /// Yeni Ders Ekleme İşlemi
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddCourse(Course course)
        {

            CourseValidator courseValidator = new CourseValidator();
            ValidationResult result = courseValidator.Validate(course);

            if (result.IsValid)
            {
                 _courseService.TAdd(course);
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

        /// <summary>
        /// Ders Silme işlemi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteCourse(int id) 
        {
            var values = _courseService.TGetByID(id);
            _courseService.TDelete(values);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Ders Güncelleme İşlemi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult UpdateCourse(int id)
        {
            var values = _courseService.TGetByID(id);
            return View(values);
        }


        /// <summary>
        /// Ders Güncelleme İşlemi
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateCourse(Course course)
        {
            _courseService.TUpdate(course);

            return RedirectToAction("Index");

        }

    }
}
