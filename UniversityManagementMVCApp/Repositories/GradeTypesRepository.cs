using Microsoft.EntityFrameworkCore;
using UniversityManagementMVCApp.DataContext;
using UniversityManagementMVCApp.Models;
using UniversityManagementMVCApp.ViewModels;

namespace UniversityManagementMVCApp.Repositories
{
	public class GradeTypesRepository //clasele repository sunt clase care implementeaza operatiile CRUD pe Baza de Date
	{
		private readonly UniversityManagementDataContext _context;
		public GradeTypesRepository(UniversityManagementDataContext context)
		{
			_context = context;
		}

		public DbSet<GradeTypeModel> GetGradeTypes()  //get all from table
		{
			return _context.GradeTypes;
		}

		public void Add(GradeTypeModel model)
		{
			model.IdGradeType = Guid.NewGuid(); //setam id-ul
			_context.GradeTypes.Add(model); //adaugam modelul in layer-ul ORM (ProgrammingClubDataContext)
			_context.SaveChanges(); //commit to database
		}

		public GradeTypeModel GetGradeTypeById(Guid id)  //get announcement for a cartain ID -> page Details
		{
			GradeTypeModel gradeType = _context.GradeTypes.FirstOrDefault(x => x.IdGradeType == id);
			return gradeType;
		}

		public void Update(GradeTypeModel model)
		{
			_context.GradeTypes.Update(model);
			_context.SaveChanges();
		}

		public void Delete(Guid id)
		{
			GradeTypeModel gradeType = GetGradeTypeById(id);
			if (gradeType != null)
			{
				_context.GradeTypes.Remove(gradeType);
				_context.SaveChanges();
			}
		}

		public GradeTypeGradeViewModel GetGradeTypeGrades(Guid id)
		{
			GradeTypeGradeViewModel gradeTypeGradesViewModel = new GradeTypeGradeViewModel();

			GradeTypeModel gradeType = _context.GradeTypes.FirstOrDefault(x => x.IdGradeType == id);
			if (gradeType != null)
			{
				gradeTypeGradesViewModel.Name = gradeType.Name;

				IQueryable<GradeModel> gradeTypeGrades = _context.Grades.Where(x => x.IdGradeType == id);

				foreach (GradeModel dbGrade in gradeTypeGrades)
				{
					gradeTypeGradesViewModel.Grades.Add(dbGrade);
				}
			}
			return gradeTypeGradesViewModel;
		}
	}
}
