using UniversityManagementMVCApp.Models;

namespace UniversityManagementMVCApp.ViewModels
{
	public class StudentGradeViewModel
	{
		public string Name { get; set; }

		public List<GradeModel> Grades = new List<GradeModel>();
	}
}
