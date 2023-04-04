using Microsoft.AspNetCore.Mvc;
using UniversityManagementMVCApp.Models;
using UniversityManagementMVCApp.Repositories;
using UniversityManagementMVCApp.ViewModels;

namespace UniversityManagementMVCApp.Controllers
{
	public class GradeTypesController : Controller
	{
		private readonly GradeTypesRepository _repository;
		public GradeTypesController(GradeTypesRepository repository)
		{
			_repository = repository;
		}

		public IActionResult Index()
		{
			var gradeTypes = _repository.GetGradeTypes();
			return View("Index", gradeTypes);
		}

		public IActionResult Create()
		{
			return View("Create");
		}

		[HttpPost]
		public IActionResult Create(IFormCollection collection)
		{
			GradeTypeModel gradeType = new GradeTypeModel();
			if (ModelState.IsValid)
			{
				TryUpdateModelAsync(gradeType); //se mapeaza datele din formular pe modelul announcement
				_repository.Add(gradeType);
			}
			return RedirectToAction("Index");
		}

		public IActionResult Edit(Guid id)
		{
			GradeTypeModel gradeType = _repository.GetGradeTypeById(id);
			return View("Edit", gradeType);
		}

		[HttpPost]
		public IActionResult Edit(Guid id, IFormCollection collection)
		{
			GradeTypeModel gradeType = new();
			TryUpdateModelAsync(gradeType);
			_repository.Update(gradeType);

			return RedirectToAction("Index");
		}

		public IActionResult Delete(Guid id)
		{
			GradeTypeModel gradeType = _repository.GetGradeTypeById(id);
			return View("Delete", gradeType);
		}

		[HttpPost]
		public IActionResult Delete(Guid id, IFormCollection collection)
		{
			_repository.Delete(id);
			return RedirectToAction("Index");
		}

		public IActionResult Details(Guid id)
		{
			GradeTypeModel gradeType = _repository.GetGradeTypeById(id);
			return View("Details", gradeType);
		}

		public IActionResult DetailsWithGrades(Guid id)
		{
			GradeTypeGradeViewModel viewModel = _repository.GetGradeTypeGrades(id);
			return View("DetailsWithGrades", viewModel);
		}
	}
}
