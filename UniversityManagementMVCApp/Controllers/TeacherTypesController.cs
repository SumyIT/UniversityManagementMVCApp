using Microsoft.AspNetCore.Mvc;
using UniversityManagementMVCApp.Models;
using UniversityManagementMVCApp.Repositories;
using UniversityManagementMVCApp.ViewModels;

namespace UniversityManagementMVCApp.Controllers
{
	public class TeacherTypesController : Controller
	{
		private readonly TeacherTypesRepository _repository;
		public TeacherTypesController(TeacherTypesRepository repository)
		{
			_repository = repository;
		}

		public IActionResult Index()
		{
			var teacherTypes = _repository.GetTeacherTypes();
			return View("Index", teacherTypes);
		}

		public IActionResult Create()
		{
			return View("Create");
		}

		[HttpPost]
		public IActionResult Create(IFormCollection collection)
		{
			TeacherTypeModel teacherType = new TeacherTypeModel();
			if (ModelState.IsValid)
			{
				TryUpdateModelAsync(teacherType); //se mapeaza datele din formular pe modelul announcement
				_repository.Add(teacherType);
			}
			return RedirectToAction("Index");
		}

		public IActionResult Edit(Guid id)
		{
			TeacherTypeModel teacherType = _repository.GetTeacherTypeById(id);
			return View("Edit", teacherType);
		}

		[HttpPost]
		public IActionResult Edit(Guid id, IFormCollection collection)
		{
			TeacherTypeModel teacherType = new();
			TryUpdateModelAsync(teacherType);
			_repository.Update(teacherType);

			return RedirectToAction("Index");
		}

		public IActionResult Delete(Guid id)
		{
			TeacherTypeModel teacherType = _repository.GetTeacherTypeById(id);
			return View("Delete", teacherType);
		}

		[HttpPost]
		public IActionResult Delete(Guid id, IFormCollection collection)
		{
			_repository.Delete(id);
			return RedirectToAction("Index");
		}

		public IActionResult Details(Guid id)
		{
			TeacherTypeModel teacherType = _repository.GetTeacherTypeById(id);
			return View("Details", teacherType);
		}

		public IActionResult DetailsWithTeachers(Guid id)
		{
			TeacherTypeTeacherViewModel viewModel = _repository.GetTeacherTypeTeachers(id);
			return View("DetailsWithTeachers", viewModel);
		}
	}
}
