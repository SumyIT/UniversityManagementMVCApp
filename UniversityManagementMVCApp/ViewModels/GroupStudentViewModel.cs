using UniversityManagementMVCApp.Models;

namespace UniversityManagementMVCApp.ViewModels
{
	public class GroupStudentViewModel
	{
		public string Name { get; set; }

		public List<StudentModel> Students = new List<StudentModel>();
	}
}
