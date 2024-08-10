using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDAspCoreWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUDAspCoreWebAPI.Controllers
{
    public class StudentController : Controller
    {

        private string url = "https://localhost:7182/api/StudentAPI/";

        private HttpClient client = new HttpClient();

        [HttpGet]
        public IActionResult Index()
        {
            List<Student> students = new List<Student>();
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<Student>>(result);
                if(data != null)
                {
                    students = data;
                }
            }
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student std)
        {
            // Construct the URL with query parameters
            var urlWithParams = $"{url}?StudentName={std.StudentName}&StudentGender={std.StudentGender}&Age={std.Age}&Standard={std.Standard}&FatherName={std.FatherName}";

            // Create an empty content since data is sent as query parameters
            StringContent content = new StringContent("", Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(urlWithParams, content).Result;

            if (response.IsSuccessStatusCode)
            {
                TempData["insert_message"] = "Student added successfully.";
                return RedirectToAction("Index");
            }
            else
            {
                // Log the response content for further analysis
                var responseContent = response.Content.ReadAsStringAsync().Result;
                ModelState.AddModelError(string.Empty, $"Server error (HTTP {response.StatusCode}): {responseContent}");
            }

            return View(std);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student std = new Student();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Student>(result);
                if (data != null)
                {
                    std = data;
                }
            }
            return View(std);
        }

        [HttpPost]
        public IActionResult Edit(Student std)
        {
            // Construct the URL with query parameters
            var urlWithParams = $"{url}?StudentName={std.StudentName}&StudentGender={std.StudentGender}&Age={std.Age}&Standard={std.Standard}&FatherName={std.FatherName}";

            // Create an empty content since data is sent as query parameters
            StringContent content = new StringContent("", Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(urlWithParams + std.Id, content).Result;

            if (response.IsSuccessStatusCode)
            {
                TempData["update_message"] = "Student updated successfully.";
                return RedirectToAction("Index");
            }
            else
            {
                // Log the response content for further analysis
                var responseContent = response.Content.ReadAsStringAsync().Result;
                ModelState.AddModelError(string.Empty, $"Server error (HTTP {response.StatusCode}): {responseContent}");
            }

            return View(std);
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            Student std = new Student();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Student>(result);
                if (data != null)
                {
                    std = data;
                }
            }
            return View(std);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            Student std = new Student();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Student>(result);
                if (data != null)
                {
                    std = data;
                }
            }
            return View(std);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            HttpResponseMessage response = client.DeleteAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["delete_message"] = "Student successfully Deleted !!! ";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

