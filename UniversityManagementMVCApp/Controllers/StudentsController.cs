using Microsoft.AspNetCore.Mvc;
using UniversityManagementMVCApp.Models;
using UniversityManagementMVCApp.Repositories;
using UniversityManagementMVCApp.ViewModels;

namespace UniversityManagementMVCApp.Controllers
{
	public class StudentsController : Controller
	{
		private readonly StudentsRepository _repository;
		private readonly GroupsRepository _groupsRepository;
		public StudentsController(StudentsRepository repository, GroupsRepository groupsRepository)
		{
			_repository = repository;
			_groupsRepository = groupsRepository;
		}

		public IActionResult Index()
		{
			var students = _repository.GetStudents();
			return View("Index", students);
		}

		public IActionResult Create()
		{
			var groups = _groupsRepository.GetGroups();
			ViewBag.groups = groups;
			return View("Create");
		}

		[HttpPost]
		public IActionResult Create(IFormCollection collection)
		{
			StudentModel student = new StudentModel();
			if (ModelState.IsValid)
			{
				TryUpdateModelAsync(student); //se mapeaza datele din formular pe modelul announcement
				_repository.Add(student);
			}
			return RedirectToAction("Index");
		}

		public IActionResult Edit(Guid id)
		{
			var groups = _groupsRepository.GetGroups();
			ViewBag.groups = groups;
			StudentModel student = _repository.GetStudentById(id);
			return View("Edit", student);
		}

		[HttpPost]
		public IActionResult Edit(Guid id, IFormCollection collection)
		{
			StudentModel student = new();
			TryUpdateModelAsync(student);
			_repository.Update(student);

			return RedirectToAction("Index");
		}

		public IActionResult Delete(Guid id)
		{
			StudentModel student = _repository.GetStudentById(id);
			return View("Delete", student);
		}

		[HttpPost]
		public IActionResult Delete(Guid id, IFormCollection collection)
		{
			_repository.Delete(id);
			return RedirectToAction("Index");
		}

		public IActionResult Details(Guid id)
		{
			StudentModel student = _repository.GetStudentById(id);
			return View("Details", student);
		}

		public IActionResult DetailsWithGrades(Guid id)
		{
			StudentGradeViewModel viewModel = _repository.GetStudentGrades(id);
			return View("DetailsWithGrades", viewModel);
		}
	}
}
