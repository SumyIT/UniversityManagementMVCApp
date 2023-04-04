using Microsoft.AspNetCore.Mvc;
using UniversityManagementMVCApp.Models;
using UniversityManagementMVCApp.Repositories;
using UniversityManagementMVCApp.ViewModels;

namespace UniversityManagementMVCApp.Controllers
{
	public class SubjectsController : Controller
	{
		private readonly SubjectsRepository _repository;
		public SubjectsController(SubjectsRepository repository)
		{
			_repository = repository;
		}

		public IActionResult Index()
		{
			var subjects = _repository.GetSubjects();
			return View("Index", subjects);
		}

		public IActionResult Create()
		{
			return View("Create");
		}

		[HttpPost]
		public IActionResult Create(IFormCollection collection)
		{
			SubjectModel subject = new SubjectModel();
			if (ModelState.IsValid)
			{
				TryUpdateModelAsync(subject); //se mapeaza datele din formular pe modelul announcement
				_repository.Add(subject);
			}
			return RedirectToAction("Index");
		}

		public IActionResult Edit(Guid id)
		{
			SubjectModel subject = _repository.GetSubjectById(id);
			return View("Edit", subject);
		}

		[HttpPost]
		public IActionResult Edit(Guid id, IFormCollection collection)
		{
			SubjectModel subject = new();
			TryUpdateModelAsync(subject);
			_repository.Update(subject);

			return RedirectToAction("Index");
		}

		public IActionResult Delete(Guid id)
		{
			SubjectModel subject = _repository.GetSubjectById(id);
			return View("Delete", subject);
		}

		[HttpPost]
		public IActionResult Delete(Guid id, IFormCollection collection)
		{
			_repository.Delete(id);
			return RedirectToAction("Index");
		}

		public IActionResult Details(Guid id)
		{
			SubjectModel subject = _repository.GetSubjectById(id);
			return View("Details", subject);
		}

		public IActionResult DetailsWithTeachers(Guid id)
		{
			SubjectTeacherViewModel viewModel = _repository.GetSubjectTeachers(id);
			return View("DetailsWithTeachers", viewModel);
		}

		public IActionResult DetailsWithGrades(Guid id)
		{
			SubjectGradeViewModel viewModel = _repository.GetSubjectGrades(id);
			return View("DetailsWithGrades", viewModel);
		}
	}
}
