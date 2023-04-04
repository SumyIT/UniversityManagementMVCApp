using Microsoft.EntityFrameworkCore;
using UniversityManagementMVCApp.DataContext;
using UniversityManagementMVCApp.Models;

namespace UniversityManagementMVCApp.Repositories
{
	public class GradesRepository //clasele repository sunt clase care implementeaza operatiile CRUD pe Baza de Date
	{
		private readonly UniversityManagementDataContext _context;
		public GradesRepository(UniversityManagementDataContext context)
		{
			_context = context;
		}

		public DbSet<GradeModel> GetGrades()  //get all from table
		{
			return _context.Grades;
		}

		public void Add(GradeModel model)
		{
			model.IdGrade = Guid.NewGuid(); //setam id-ul
			_context.Grades.Add(model); //adaugam modelul in layer-ul ORM (ProgrammingClubDataContext)
			_context.SaveChanges(); //commit to database
		}

		public GradeModel GetGradeById(Guid id)  //get announcement for a cartain ID -> page Details
		{
			GradeModel grade = _context.Grades.FirstOrDefault(x => x.IdGrade == id);
			return grade;
		}

		public void Update(GradeModel model)
		{
			_context.Grades.Update(model);
			_context.SaveChanges();
		}

		public void Delete(Guid id)
		{
			GradeModel grade = GetGradeById(id);
			if (grade != null)
			{
				_context.Grades.Remove(grade);
				_context.SaveChanges();
			}
		}
	}
}
