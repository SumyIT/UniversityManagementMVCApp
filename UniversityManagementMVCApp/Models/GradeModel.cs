using System.ComponentModel.DataAnnotations;

namespace UniversityManagementMVCApp.Models
{
	public class GradeModel
	{
		[Key]
		public Guid IdGrade { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		public Guid IdGradeType { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		public Guid IdStudent { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		public Guid IdSubject { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		[Range(1, 10, ErrorMessage = "The Value field must be between 1 and 10!")]
		public int Value { get; set; }
	}
}
