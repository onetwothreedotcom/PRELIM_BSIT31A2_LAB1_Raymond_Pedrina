using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private decimal ComputeNetFee(decimal tuition, decimal discountPercent)
        {
            return tuition - (tuition * discountPercent / 100);
        }

        public IActionResult Index()
        {
            string studentName = "Your Name";
            int score = 87;
            bool isPassed = (score >= 75);
            DateTime examDate = DateTime.Now;
            decimal tuitionFee = 15500.75m;

            string grade;
            if (score >= 90)
            {
                grade = "A";
            }
            else if (score >= 80)
            {
                grade = "B";
            }
            else if (score >= 75)
            {
                grade = "C";
            }
            else
            {
                grade = "F";
            }

            string message = isPassed ? "Congratulations, you passed!" : "Better luck next time.";

            string[] courses = { "Web Systems", "OOP", "DBMS", "UI/UX", "Networking" };

            string allCourses = "";
            int courseCount = 0;

            foreach (string course in courses)
            {
                allCourses += course + ", ";
                courseCount++;
            }

            if (allCourses.Length > 2)
            {
                allCourses = allCourses.Substring(0, allCourses.Length - 2);
            }

            decimal discount = 10;
            decimal netFee = ComputeNetFee(tuitionFee, discount);

            List<Student> students = new List<Student>
            {
                new Student { Name = "Juan Dela Cruz", Age = 20, Course = "BSIT" },
                new Student { Name = "Maria Santos", Age = 21, Course = "BSCS" },
                new Student { Name = "Jose Rizal", Age = 22, Course = "BSIS" }
            };

            ViewBag.StudentName = studentName;
            ViewBag.Score = score;
            ViewBag.IsPassed = isPassed;
            ViewBag.ExamDate = examDate;
            ViewBag.TuitionFee = tuitionFee;
            ViewBag.Grade = grade;
            ViewBag.Message = message;
            ViewBag.AllCourses = allCourses;
            ViewBag.CourseCount = courseCount;
            ViewBag.NetFee = netFee;
            ViewBag.Students = students;

            ViewBag.Today = DateTime.Now.ToString("MMMM dd, yyyy");

            return View();

        }

        public IActionResult AboutMe()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}