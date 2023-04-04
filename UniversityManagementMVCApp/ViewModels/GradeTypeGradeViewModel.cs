using UniversityManagementMVCApp.Models;

namespace UniversityManagementMVCApp.ViewModels
{
	public class GradeTypeGradeViewModel
	{
		public string Name { get; set; }

		public List<GradeModel> Grades = new List<GradeModel>();
	}
}
