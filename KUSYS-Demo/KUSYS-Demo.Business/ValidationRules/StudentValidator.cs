using FluentValidation;
using KUSYS_Demo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Business.ValidationRules
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Öğrenci Adı Boş Geçilemez!");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Öğrenci SoyAdı Boş Geçilemez!");
            RuleFor(x => x.BirthDate).NotEmpty().WithMessage("Öğrenci Doğum Tarihi Boş Geçilemez!");
            RuleFor(x => x.FirstName).MinimumLength(2).WithMessage("Öğrenci Adı Enaz 2 Karekter Olmalıdır");
            RuleFor(x => x.FirstName).MaximumLength(20).WithMessage("Öğrenci Adı Enfazla 20 Karekter Olmalıdır");
            RuleFor(x => x.LastName).MinimumLength(2).WithMessage("Öğrenci SoyAdı Enaz 2 Karekter Olmalıdır");
            RuleFor(x => x.LastName).MaximumLength(20).WithMessage("Öğrenci SoyAdı Enfazla 20 Karekter Olmalıdır");
        }
    }
}
