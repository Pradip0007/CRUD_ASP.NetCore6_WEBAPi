using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDAspCoreWebAPI.Models
{
	public class Student
	{
        public int Id { get; set; }

        [Required]
        public string StudentName { get; set; } = null!;
        [Required]
        public string StudentGender { get; set; } = null!;
        [Required]
        public int Age { get; set; }
        [Required]
        public int Standard { get; set; }
        [Required]
        public string FatherName { get; set; } = null!;
    }
}


