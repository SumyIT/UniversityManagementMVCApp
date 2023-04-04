using Microsoft.AspNetCore.Mvc;
using UniversityManagementMVCApp.Models;
using UniversityManagementMVCApp.Repositories;

namespace UniversityManagementMVCApp.Controllers
{
	public class GradesController : Controller
	{
		private readonly GradesRepository _repository;
		private readonly GradeTypesRepository _gradeTypesRepository;
		private readonly StudentsRepository _studentsRepository;
		private readonly SubjectsRepository _subjectsRepository;
		public GradesController(GradesRepository repository, GradeTypesRepository gradeTypesRepository, StudentsRepository studentsRepository, SubjectsRepository subjectsRepository)
		{
			_repository = repository;
			_gradeTypesRepository = gradeTypesRepository;
			_studentsRepository = studentsRepository;
			_subjectsRepository = subjectsRepository;
		}

		public IActionResult Index()
		{
			var grades = _repository.GetGrades();
			return View("Index", grades);
		}

		public IActionResult Create()
		{
			var gradeTypes = _gradeTypesRepository.GetGradeTypes();
			ViewBag.gradeTypes = gradeTypes;
			var students = _studentsRepository.GetStudents();
			ViewBag.students = students;
			var subjects = _subjectsRepository.GetSubjects();
			ViewBag.subjects = subjects;
			return View("Create");
		}

		[HttpPost]
		public IActionResult Create(IFormCollection collection)
		{
			GradeModel grade = new GradeModel();
			if (ModelState.IsValid)
			{
				TryUpdateModelAsync(grade); //se mapeaza datele din formular pe modelul announcement
				_repository.Add(grade);
			}
			return RedirectToAction("Index");
		}

		public IActionResult Edit(Guid id)
		{
			var gradeTypes = _gradeTypesRepository.GetGradeTypes();
			ViewBag.gradeTypes = gradeTypes;
			var students = _studentsRepository.GetStudents();
			ViewBag.students = students;
			var subjects = _subjectsRepository.GetSubjects();
			ViewBag.subjects = subjects;
			GradeModel grade = _repository.GetGradeById(id);
			return View("Edit", grade);
		}

		[HttpPost]
		public IActionResult Edit(Guid id, IFormCollection collection)
		{
			GradeModel grade = new();
			TryUpdateModelAsync(grade);
			_repository.Update(grade);

			return RedirectToAction("Index");
		}

		public IActionResult Delete(Guid id)
		{
			GradeModel grade = _repository.GetGradeById(id);
			return View("Delete", grade);
		}

		[HttpPost]
		public IActionResult Delete(Guid id, IFormCollection collection)
		{
			_repository.Delete(id);
			return RedirectToAction("Index");
		}

		public IActionResult Details(Guid id)
		{
			GradeModel grade = _repository.GetGradeById(id);
			return View("Details", grade);
		}
	}
}
