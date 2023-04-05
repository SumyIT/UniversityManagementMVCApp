﻿using Microsoft.EntityFrameworkCore;
using UniversityManagementMVCApp.DataContext;
using UniversityManagementMVCApp.Models;

namespace UniversityManagementMVCApp.Repositories
{
	public class TeachersRepository //clasele repository sunt clase care implementeaza operatiile CRUD pe Baza de Date
	{
		private readonly UniversityManagementDataContext _context;
		public TeachersRepository(UniversityManagementDataContext context)
		{
			_context = context;
		}

		public List<TeacherModel> GetTeachers()  //get all from table
		{
			return _context.Teachers.Include(x => x.Subject).Include(x => x.TeacherType).ToList();
		}

		public void Add(TeacherModel model)
		{
			model.IdTeacher = Guid.NewGuid(); //setam id-ul
			_context.Teachers.Add(model); //adaugam modelul in layer-ul ORM (UniversityManagementDataContext)
			_context.SaveChanges(); //commit to database
		}

		public TeacherModel GetTeacherById(Guid id)  //get teacher for a cartain ID -> page Details
		{
			TeacherModel teacher = _context.Teachers.Include(x => x.Subject).Include(x => x.TeacherType).FirstOrDefault(x => x.IdTeacher == id);
			return teacher;
		}

		public void Update(TeacherModel model)
		{
			_context.Teachers.Update(model);
			_context.SaveChanges();
		}

		public void Delete(Guid id)
		{
			TeacherModel teacher = GetTeacherById(id);
			if (teacher != null)
			{
				_context.Teachers.Remove(teacher);
				_context.SaveChanges();
			}
		}
	}
}
