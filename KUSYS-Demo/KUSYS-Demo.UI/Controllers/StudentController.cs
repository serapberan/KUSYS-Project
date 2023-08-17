using KUSYS_Demo.Business.Abstract;
using KUSYS_Demo.Entities.Concrete;
using KUSYS_Demo.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KUSYS_Demo.UI.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;

        public StudentController(IStudentService studentService, ICourseService courseService)
        {
            _studentService = studentService;
            _courseService = courseService;
        }

        /// <summary>
        /// Kayıtlı Öğrenci Listeleme İşlemleri
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var values = _studentService.TGetList();
            return View(values);
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
        /// Yeni Öğrenci Kaydetme İşlemi
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddStudent()
        {
            //Dersleri sayfa yuklendiğinde  dropdown olarak listele
            List<SelectListItem> courseList = (from x in _courseService.TGetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CourseName,
                                                   Value = x.CourseId.ToString(),
                                               }).ToList();


            ViewBag.CourseList = courseList;
            return View();
        }

        /// <summary>
        /// Yeni Öğrenci Kaydetme İşlemi
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            _studentService.TAdd(student);
            student.StudentId = 4;
            return RedirectToAction("Index");
        }




        /// <summary>
        /// Öğrenci Güncelleme İşlemleri
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult UpdateStudent(int id)
        {
            var values = _studentService.TGetByID(id);
            List<SelectListItem> courseList = (from x in _courseService.TGetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CourseName,
                                                   Value = x.CourseId.ToString(),
                                               }).ToList();


            ViewBag.CourseList = courseList;
            return View(values);
        }

        /// <summary>
        /// Öğrenci Güncelleme İşlemleri
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateStudent(Student student)
        {
            _studentService.TUpdate(student);
            return RedirectToAction("Index");
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

    }
}
