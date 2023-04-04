using UniversityManagementMVCApp.Models;

namespace UniversityManagementMVCApp.ViewModels
{
	public class SubjectTeacherViewModel
	{
		public string Name { get; set; }

		public List<TeacherModel> Teachers = new List<TeacherModel>();
	}
}
