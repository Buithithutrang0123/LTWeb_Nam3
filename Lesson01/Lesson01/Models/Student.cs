using System.ComponentModel.DataAnnotations;

namespace Lesson01.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Branch? Branch { get; set; }
        public Gender? Gender { get; set; }
        public bool IsRegular { get; set; } //true - chinhquy, false - phichinhquy
        public string? Address { get; set; }
        public DateTime DateOfBorth { get; set; }

        [FileExtensions(Extensions = "png,jpg,jpeg,gif")]
        public IFormFile? ImageURL { get; set; }
        public string ImagePath { get; set; }


    }
}
