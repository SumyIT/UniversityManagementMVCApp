using Microsoft.EntityFrameworkCore;
using UniversityManagementMVCApp.DataContext;
using UniversityManagementMVCApp.Models;
using UniversityManagementMVCApp.ViewModels;

namespace UniversityManagementMVCApp.Repositories
{
	public class StudentsRepository //clasele repository sunt clase care implementeaza operatiile CRUD pe Baza de Date
	{
		private readonly UniversityManagementDataContext _context;
		public StudentsRepository(UniversityManagementDataContext context)
		{
			_context = context;
		}

		public DbSet<StudentModel> GetStudents()  //get all from table
		{
			return _context.Students;
		}

		public void Add(StudentModel model)
		{
			model.IdStudent = Guid.NewGuid(); //setam id-ul
			_context.Students.Add(model); //adaugam modelul in layer-ul ORM (ProgrammingClubDataContext)
			_context.SaveChanges(); //commit to database
		}

		public StudentModel GetStudentById(Guid id)  //get announcement for a cartain ID -> page Details
		{
			StudentModel student = _context.Students.FirstOrDefault(x => x.IdStudent == id);
			return student;
		}

		public void Update(StudentModel model)
		{
			_context.Students.Update(model);
			_context.SaveChanges();
		}

		public void Delete(Guid id)
		{
			StudentModel student = GetStudentById(id);
			if (student != null)
			{
				_context.Students.Remove(student);
				_context.SaveChanges();
			}
		}

		public StudentGradeViewModel GetStudentGrades(Guid id)
		{
			StudentGradeViewModel studentGradesViewModel = new StudentGradeViewModel();

			StudentModel student = _context.Students.FirstOrDefault(x => x.IdStudent == id);
			if (student != null)
			{
				studentGradesViewModel.Name = student.Name;

				IQueryable<GradeModel> studentGrades = _context.Grades.Where(x => x.IdStudent == id);

				foreach (GradeModel dbGrade in studentGrades)
				{
					studentGradesViewModel.Grades.Add(dbGrade);
				}
			}
			return studentGradesViewModel;
		}
	}
}
