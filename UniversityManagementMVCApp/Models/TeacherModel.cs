﻿using System.ComponentModel.DataAnnotations;

namespace UniversityManagementMVCApp.Models
{
	public class TeacherModel
	{
		[Key]
		public Guid IdTeacher { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		public Guid IdTeacherType { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		public Guid IdSubject { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		[StringLength(250, ErrorMessage = "Campul Name poate sa contina maxim 250 caractere.")]
		public string Name { get; set; }

		[Required(ErrorMessage = "This field is required!")]
		[StringLength(1000, ErrorMessage = "Campul Name poate sa contina maxim 1000 caractere.")]
		public string Description { get; set; }
	}
}
