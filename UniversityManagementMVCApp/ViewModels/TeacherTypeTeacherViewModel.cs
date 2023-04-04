using UniversityManagementMVCApp.Models;

namespace UniversityManagementMVCApp.ViewModels
{
	public class TeacherTypeTeacherViewModel
	{
		public string Name { get; set; }

		public List<TeacherModel> Teachers = new List<TeacherModel>();
	}
}
