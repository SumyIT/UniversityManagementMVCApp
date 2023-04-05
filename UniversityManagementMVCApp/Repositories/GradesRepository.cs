using Microsoft.EntityFrameworkCore;
using UniversityManagementMVCApp.DataContext;
using UniversityManagementMVCApp.Models;
using UniversityManagementMVCApp.ViewModels;

namespace UniversityManagementMVCApp.Repositories
{
	public class GradesRepository //clasele repository sunt clase care implementeaza operatiile CRUD pe Baza de Date
	{
		private readonly UniversityManagementDataContext _context;
		public GradesRepository(UniversityManagementDataContext context)
		{
			_context = context;
		}

		public List<GradeModel> GetGrades()  //get all from table
		{
			return _context.Grades.Include(x => x.Student).Include(x => x.Subject).Include(x => x.GradeType).ToList();
		}

		public void Add(GradeModel model)
		{
			model.IdGrade = Guid.NewGuid(); //setam id-ul
			_context.Grades.Add(model); //adaugam modelul in layer-ul ORM (UniversityManagementDataContext)
			_context.SaveChanges(); //commit to database
		}

		public GradeModel GetGradeById(Guid id)  //get grade for a cartain ID -> page Details
		{
			GradeModel grade = _context.Grades.Include(x => x.Student).Include(x => x.Subject).Include(x => x.GradeType).FirstOrDefault(x => x.IdGrade == id);
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

		public decimal GetStudentGradeAverage(Guid studentId)
		{
			decimal sum = 0;

			List<GradeModel> grades = _context.Grades.Where(x => x.IdStudent == studentId).ToList();
			
			if (grades.Count != 0)
			{
				foreach (GradeModel grade in grades)
				{
					sum = sum + grade.Value;
				}

				return sum/grades.Count();
			}

			return 0;
		}
	}
}
