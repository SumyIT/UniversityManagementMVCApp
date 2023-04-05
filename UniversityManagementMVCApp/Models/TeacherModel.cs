using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityManagementMVCApp.Models
{
	public class TeacherModel
	{
		[Key]
		public Guid IdTeacher { get; set; }

		[Required(ErrorMessage = "This field is required!")]
        [Display(Name = "Teacher Type")]
        public Guid IdTeacherType { get; set; }

        [ForeignKey("IdTeacherType")]
        public virtual TeacherTypeModel TeacherType { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [Display(Name = "Subject")]
        public Guid IdSubject { get; set; }

        [ForeignKey("IdSubject")]
        public virtual SubjectModel Subject { get; set; }

        [Required(ErrorMessage = "This field is required!")]
		[StringLength(250, ErrorMessage = "The Name field can contain a maximum of 250 characters.")]
        [Display(Name = "Teacher Name")]
        public string Name { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		[StringLength(1000, ErrorMessage = "The Description field can contain a maximum of 1000 characters.")]
        [Display(Name = "Description")]
        public string Description { get; set; }
	}
}
