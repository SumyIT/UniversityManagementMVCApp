using Microsoft.EntityFrameworkCore;
using UniversityManagementMVCApp.DataContext;
using UniversityManagementMVCApp.Models;
using UniversityManagementMVCApp.ViewModels;

namespace UniversityManagementMVCApp.Repositories
{
	public class TeacherTypesRepository //clasele repository sunt clase care implementeaza operatiile CRUD pe Baza de Date
	{
		private readonly UniversityManagementDataContext _context;
		public TeacherTypesRepository(UniversityManagementDataContext context)
		{
			_context = context;
		}

		public DbSet<TeacherTypeModel> GetTeacherTypes()  //get all from table
		{
			return _context.TeacherTypes;
		}

		public void Add(TeacherTypeModel model)
		{
			model.IdTeacherType = Guid.NewGuid(); //setam id-ul
			_context.TeacherTypes.Add(model); //adaugam modelul in layer-ul ORM (ProgrammingClubDataContext)
			_context.SaveChanges(); //commit to database
		}

		public TeacherTypeModel GetTeacherTypeById(Guid id)  //get announcement for a cartain ID -> page Details
		{
			TeacherTypeModel teacherType = _context.TeacherTypes.FirstOrDefault(x => x.IdTeacherType == id);
			return teacherType;
		}

		public void Update(TeacherTypeModel model)
		{
			_context.TeacherTypes.Update(model);
			_context.SaveChanges();
		}

		public void Delete(Guid id)
		{
			TeacherTypeModel teacherType = GetTeacherTypeById(id);
			if (teacherType != null)
			{
				_context.TeacherTypes.Remove(teacherType);
				_context.SaveChanges();
			}
		}

		public TeacherTypeTeacherViewModel GetTeacherTypeTeachers(Guid id)
		{
			TeacherTypeTeacherViewModel teacherTypeTeachersViewModel = new TeacherTypeTeacherViewModel();

			TeacherTypeModel teacherType = _context.TeacherTypes.FirstOrDefault(x => x.IdTeacherType == id);
			if (teacherType != null)
			{
				teacherTypeTeachersViewModel.Name = teacherType.Name;

				IQueryable<TeacherModel> teacherTypeTeachers = _context.Teachers.Where(x => x.IdTeacherType == id);

				foreach (TeacherModel dbTeacher in teacherTypeTeachers)
				{
					teacherTypeTeachersViewModel.Teachers.Add(dbTeacher);
				}
			}
			return teacherTypeTeachersViewModel;
		}
	}
}
