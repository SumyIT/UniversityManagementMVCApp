using System.ComponentModel.DataAnnotations;

namespace UniversityManagementMVCApp.Models
{
	public class SubjectModel
	{
		[Key]
		public Guid IdSubject { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		[StringLength(250, ErrorMessage = "The Name field can contain a maximum of 250 characters.")]
		[Display(Name = "Subject")]
		public string Name { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		[StringLength(1000, ErrorMessage = "The Description field can contain a maximum of 1000 characters.")]
		[Display(Name = "Description")]
		public string Description { get; set; }
	}
}
