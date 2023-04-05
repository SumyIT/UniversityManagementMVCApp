using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace UniversityManagementMVCApp.Models
{
	public class GradeModel
	{
		[Key]
		public Guid IdGrade { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		[Display(Name = "Grade Type")]
		public Guid IdGradeType { get; set; }

		[ForeignKey("IdGradeType")]
		public virtual GradeTypeModel GradeType { get; set; } 

		[Required(ErrorMessage = "This field is required!")]
		[Display(Name = "Student Name")]
		public Guid IdStudent { get; set; }

		[ForeignKey("IdStudent")]
		public virtual StudentModel Student {  get; set; }

		[Required(ErrorMessage = "This field is required!")]
		[Display(Name = "Subject")]
		public Guid IdSubject { get; set; }

		[ForeignKey("IdSubject")]
		public virtual SubjectModel Subject { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		[Range(1, 10, ErrorMessage = "The Value field must be between 1 and 10!")]
		[Display(Name = "Value")]
		public int Value { get; set; }
	}
}
