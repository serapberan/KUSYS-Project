using FluentValidation;
using KUSYS_Demo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Business.ValidationRules
{
    public class CourseValidator : AbstractValidator<Course>
    {
        public CourseValidator()
        {
                RuleFor(x => x.CourseCode).NotEmpty().WithMessage("Ders Kodu Boş Geçilemez!");
                RuleFor(x => x.CourseName).NotEmpty().WithMessage("Ders Adı Boş Geçilemez!");
                RuleFor(x => x.CourseName).MinimumLength(2).WithMessage("Ders Adı Enaz 2 Karekter Olmalı.");
                RuleFor(x => x.CourseName).MaximumLength(35).WithMessage("Ders Adı Enfazla 35 Karekter Olmalı.");
        }
    }
}
