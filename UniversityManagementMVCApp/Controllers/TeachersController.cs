using Microsoft.AspNetCore.Mvc;
using UniversityManagementMVCApp.Models;
using UniversityManagementMVCApp.Repositories;

namespace UniversityManagementMVCApp.Controllers
{
	public class TeachersController : Controller
	{
		private readonly TeachersRepository _repository;
		private readonly TeacherTypesRepository _teacherTypesRepository;
		private readonly SubjectsRepository _subjectsRepository;
		public TeachersController(TeachersRepository repository, TeacherTypesRepository teacherTypesRepository, SubjectsRepository subjectsRepository)
		{
			_repository = repository;
			_teacherTypesRepository = teacherTypesRepository;
			_subjectsRepository = subjectsRepository;
		}

		public IActionResult Index()
		{
			var teachers = _repository.GetTeachers();
			return View("Index", teachers);
		}

		public IActionResult Create()
		{
			var teacherTypes = _teacherTypesRepository.GetTeacherTypes();
			ViewBag.teacherTypes = teacherTypes;
			var subjects = _subjectsRepository.GetSubjects();
			ViewBag.subjects = subjects;
			return View("Create");
		}

		[HttpPost]
		public IActionResult Create(IFormCollection collection)
		{
			TeacherModel teacher = new TeacherModel();
			if (ModelState.IsValid)
			{
				TryUpdateModelAsync(teacher); //se mapeaza datele din formular pe modelul announcement
				_repository.Add(teacher);
			}
			return RedirectToAction("Index");
		}

		public IActionResult Edit(Guid id)
		{
			var teacherTypes = _teacherTypesRepository.GetTeacherTypes();
			ViewBag.teacherTypes = teacherTypes;
			var subjects = _subjectsRepository.GetSubjects();
			ViewBag.subjects = subjects;
			TeacherModel teacher = _repository.GetTeacherById(id);
			return View("Edit", teacher);
		}

		[HttpPost]
		public IActionResult Edit(Guid id, IFormCollection collection)
		{
			TeacherModel teacher = new();
			TryUpdateModelAsync(teacher);
			_repository.Update(teacher);

			return RedirectToAction("Index");
		}

		public IActionResult Delete(Guid id)
		{
			TeacherModel teacher = _repository.GetTeacherById(id);
			return View("Delete", teacher);
		}

		[HttpPost]
		public IActionResult Delete(Guid id, IFormCollection collection)
		{
			_repository.Delete(id);
			return RedirectToAction("Index");
		}

		public IActionResult Details(Guid id)
		{
			TeacherModel teacher = _repository.GetTeacherById(id);
			return View("Details", teacher);
		}
	}
}
