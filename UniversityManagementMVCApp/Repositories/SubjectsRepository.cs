using Microsoft.EntityFrameworkCore;
using UniversityManagementMVCApp.DataContext;
using UniversityManagementMVCApp.Models;
using UniversityManagementMVCApp.ViewModels;

namespace UniversityManagementMVCApp.Repositories
{
	public class SubjectsRepository //clasele repository sunt clase care implementeaza operatiile CRUD pe Baza de Date
	{
		private readonly UniversityManagementDataContext _context;
		public SubjectsRepository(UniversityManagementDataContext context)
		{
			_context = context;
		}

		public DbSet<SubjectModel> GetSubjects()  //get all from table
		{
			return _context.Subjects;
		}

		public void Add(SubjectModel model)
		{
			model.IdSubject = Guid.NewGuid(); //setam id-ul
			_context.Subjects.Add(model); //adaugam modelul in layer-ul ORM (ProgrammingClubDataContext)
			_context.SaveChanges(); //commit to database
		}

		public SubjectModel GetSubjectById(Guid id)  //get announcement for a cartain ID -> page Details
		{
			SubjectModel subject = _context.Subjects.FirstOrDefault(x => x.IdSubject == id);
			return subject;
		}

		public void Update(SubjectModel model)
		{
			_context.Subjects.Update(model);
			_context.SaveChanges();
		}

		public void Delete(Guid id)
		{
			SubjectModel subject = GetSubjectById(id);
			if (subject != null)
			{
				_context.Subjects.Remove(subject);
				_context.SaveChanges();
			}
		}

		public SubjectTeacherViewModel GetSubjectTeachers(Guid id)
		{
			SubjectTeacherViewModel subjectTeachersViewModel = new SubjectTeacherViewModel();

			SubjectModel subject = _context.Subjects.FirstOrDefault(x => x.IdSubject == id);
			if (subject != null)
			{
				subjectTeachersViewModel.Name = subject.Name;

				IQueryable<TeacherModel> subjectTeachers = _context.Teachers.Where(x => x.IdSubject == id);

				foreach (TeacherModel dbTeacher in subjectTeachers)
				{
					subjectTeachersViewModel.Teachers.Add(dbTeacher);
				}
			}
			return subjectTeachersViewModel;
		}

		public SubjectGradeViewModel GetSubjectGrades(Guid id)
		{
			SubjectGradeViewModel subjectGradesViewModel = new SubjectGradeViewModel();

			SubjectModel subject = _context.Subjects.FirstOrDefault(x => x.IdSubject == id);
			if (subject != null)
			{
				subjectGradesViewModel.Name = subject.Name;

				IQueryable<GradeModel> subjectGrades = _context.Grades.Where(x => x.IdSubject == id);

				foreach (GradeModel dbGrade in subjectGrades)
				{
					subjectGradesViewModel.Grades.Add(dbGrade);
				}
			}
			return subjectGradesViewModel;
		}
	}
}
