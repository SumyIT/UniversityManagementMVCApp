using Microsoft.AspNetCore.Mvc;
using UniversityManagementMVCApp.Models;
using UniversityManagementMVCApp.Repositories;
using UniversityManagementMVCApp.ViewModels;

namespace UniversityManagementMVCApp.Controllers
{
	public class GroupsController : Controller
	{
		private readonly GroupsRepository _repository;
		public GroupsController(GroupsRepository repository)
		{
			_repository = repository;
		}

		public IActionResult Index()
		{
			var groups = _repository.GetGroups();
			return View("Index", groups);
		}

		public IActionResult Create()
		{
			return View("Create");
		}

		[HttpPost]
		public IActionResult Create(IFormCollection collection)
		{
			GroupModel group = new GroupModel();
			if (ModelState.IsValid)
			{
				TryUpdateModelAsync(group); //se mapeaza datele din formular pe modelul announcement
				_repository.Add(group);
			}
			return RedirectToAction("Index");
		}

		public IActionResult Edit(Guid id)
		{
			GroupModel group = _repository.GetGroupById(id);
			return View("Edit", group);
		}

		[HttpPost]
		public IActionResult Edit(Guid id, IFormCollection collection)
		{
			GroupModel group = new();
			TryUpdateModelAsync(group);
			_repository.Update(group);

			return RedirectToAction("Index");
		}

		public IActionResult Delete(Guid id)
		{
			GroupModel group = _repository.GetGroupById(id);
			return View("Delete", group);
		}

		[HttpPost]
		public IActionResult Delete(Guid id, IFormCollection collection)
		{
			_repository.Delete(id);
			return RedirectToAction("Index");
		}

		public IActionResult Details(Guid id)
		{
			GroupModel group = _repository.GetGroupById(id);
			return View("Details", group);
		}

		public IActionResult DetailsWithStudents(Guid id)
		{
			GroupStudentViewModel viewModel = _repository.GetGroupStudents(id);
			return View("DetailsWithStudents", viewModel);
		}
	}
}
