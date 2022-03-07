using AcoraWeb.Data;
using AcoraWeb.Models;
using AcoraWeb.ModelView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AcoraWeb.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //IEnumerable<Employee> empList = _db.Employees.ToList();
            var result = from c in _db.Employees.Include("Department")
                    select c;

            return View(result);
        }

        public IActionResult Create()
        {
            EmployeeModelView obj = new EmployeeModelView();

            List<SelectListItem> departmentList = new()
            {
                new SelectListItem { Value = "1", Text = "HR" },
                new SelectListItem { Value = "2", Text = "IT" }
            };

            obj.Departments= departmentList;
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeModelView model)
        {
            if (ModelState.IsValid)
            {
                Employee obj = new Employee();
                obj.DateOfBirth = model.DateOfBirth;
                obj.DepartmentId = Convert.ToInt32(model.SelectedDepartment);
                obj.FirstName = model.FirstName;
                obj.LastName = model.LastName;
                obj.Address = model.Address;
                obj.City = model.City;

                _db.Employees.Add(obj);
                _db.SaveChanges();
            }



            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            var result = _db.Employees.Find(id);

            if (result == null)
            {
                 return NotFound();
            }

            EmployeeModelView emp = new EmployeeModelView();
            emp.Id = Convert.ToInt32(id);
            emp.DateOfBirth = result.DateOfBirth;
            emp.DepartmentId = result.DepartmentId;
            emp.FirstName = result.FirstName;
            emp.LastName = result.LastName;
            emp.Address = result.Address;
            emp.City = result.City;

            List<SelectListItem> departmentList = new()
            {
                new SelectListItem { Value = "1", Text = "HR" },
                new SelectListItem { Value = "2", Text = "IT" }
            };

            emp.Departments = departmentList;


            return View(emp);

         
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeModelView model)
        {
            if (ModelState.IsValid)
            {
                Employee obj = new Employee();
                obj.DateOfBirth = model.DateOfBirth;
                obj.DepartmentId = Convert.ToInt32(model.SelectedDepartment);
                obj.FirstName = model.FirstName;
                obj.LastName = model.LastName;
                obj.Address = model.Address;
                obj.City = model.City;

                _db.Employees.Update(obj);
                _db.SaveChanges();
            }



            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var result = _db.Employees.Find(id);

            if (result == null)
            {
                return NotFound();
            }

            EmployeeModelView emp = new EmployeeModelView();
            emp.Id = result.Id;
            emp.DateOfBirth = result.DateOfBirth;
            emp.DepartmentId = result.DepartmentId;
            emp.FirstName = result.FirstName;
            emp.LastName = result.LastName;
            emp.Address = result.Address;
            emp.City = result.City;

            List<SelectListItem> departmentList = new()
            {
                new SelectListItem { Value = "1", Text = "HR" },
                new SelectListItem { Value = "2", Text = "IT" }
            };

            emp.Departments = departmentList;


            return View(emp);


        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {

            var result = _db.Employees.Find(id);

            if (result == null)
            {
                return NotFound();
            }

            _db.Remove(result);
            _db.SaveChanges();



            return RedirectToAction("Index");


        }

    }
}
