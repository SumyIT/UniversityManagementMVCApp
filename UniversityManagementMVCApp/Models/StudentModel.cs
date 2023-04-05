using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityManagementMVCApp.Models
{
	public class StudentModel
	{
		[Key]
		public Guid IdStudent { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		[Display(Name = "Group")]
		public Guid IdGroup { get; set; }

		[ForeignKey("IdGroup")]
		public virtual GroupModel Group { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		[StringLength(250, ErrorMessage = "The Name field can contain a maximum of 250 characters.")]
		[Display(Name = "Student Name")]
		public string Name { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		[StringLength(1000, ErrorMessage = "The Description field can contain a maximum of 1000 characters.")]
		[Display(Name = "Description")]
		public string Description { get; set; }

		[Display(Name = "Grade Average")]
		[NotMapped]
		[RegularExpression(@"^\d+(\.\d{1,2})?$")]
		public decimal? GradeAverage { get; set; }
	}
}
