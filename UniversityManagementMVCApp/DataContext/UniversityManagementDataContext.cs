using Microsoft.EntityFrameworkCore;
using UniversityManagementMVCApp.Models;

namespace UniversityManagementMVCApp.DataContext
{
	public class UniversityManagementDataContext : DbContext
	{
		public UniversityManagementDataContext(DbContextOptions<UniversityManagementDataContext> options) : base(options) { }

		public DbSet<GradeModel> Grades { get; set; }

		public DbSet<GradeTypeModel> GradeTypes { get; set; }

		public DbSet<GroupModel> Groups { get; set; }

		public DbSet<StudentModel> Students { get; set; }

		public DbSet<SubjectModel> Subjects { get; set; }

		public DbSet<TeacherModel> Teachers { get; set; }

		public DbSet<TeacherTypeModel> TeacherTypes { get; set; }
	}
}
