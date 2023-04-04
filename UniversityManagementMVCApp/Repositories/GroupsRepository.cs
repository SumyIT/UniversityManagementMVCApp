using Microsoft.EntityFrameworkCore;
using UniversityManagementMVCApp.DataContext;
using UniversityManagementMVCApp.Models;
using UniversityManagementMVCApp.ViewModels;

namespace UniversityManagementMVCApp.Repositories
{
	public class GroupsRepository //clasele repository sunt clase care implementeaza operatiile CRUD pe Baza de Date
	{
		private readonly UniversityManagementDataContext _context;
		public GroupsRepository(UniversityManagementDataContext context)
		{
			_context = context;
		}

		public DbSet<GroupModel> GetGroups()  //get all from table
		{
			return _context.Groups;
		}

		public void Add(GroupModel model)
		{
			model.IdGroup = Guid.NewGuid(); //setam id-ul
			_context.Groups.Add(model); //adaugam modelul in layer-ul ORM (ProgrammingClubDataContext)
			_context.SaveChanges(); //commit to database
		}

		public GroupModel GetGroupById(Guid id)  //get announcement for a cartain ID -> page Details
		{
			GroupModel group = _context.Groups.FirstOrDefault(x => x.IdGroup == id);
			return group;
		}

		public void Update(GroupModel model)
		{
			_context.Groups.Update(model);
			_context.SaveChanges();
		}

		public void Delete(Guid id)
		{
			GroupModel group = GetGroupById(id);
			if (group != null)
			{
				_context.Groups.Remove(group);
				_context.SaveChanges();
			}
		}

		public GroupStudentViewModel GetGroupStudents(Guid id)
		{
			GroupStudentViewModel groupStudentsViewModel = new GroupStudentViewModel();

			GroupModel group = _context.Groups.FirstOrDefault(x => x.IdGroup == id);
			if (group != null)
			{
				groupStudentsViewModel.Name = group.Name;

				IQueryable<StudentModel> groupStudents = _context.Students.Where(x => x.IdGroup == id);

				foreach (StudentModel dbStudent in groupStudents)
				{
					groupStudentsViewModel.Students.Add(dbStudent);
				}
			}
			return groupStudentsViewModel;
		}
	}
}
