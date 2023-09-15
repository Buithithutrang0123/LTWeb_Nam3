using Microsoft.AspNetCore.WebUtilities;
using System.IO.Enumeration;

namespace Lab01.Models
{
    public class Student
    {
        public int Id { get; set; } // 

        public string? Name { get; set; }// Họ tên

        public string? Email { get; set; } // Email

        public string? Password { get; set; }// Mật khẩu

        public Branch? Branch { get; set; }// Ngành học
        public Gender? Gender { get; set; }// giới tính

        public bool IsRegular { get; set; }// Hệ: true - chính quy, false -phi cq

        public string? Address { get; set; }// Địa chỉ

        public DateTime DateOfBorth { get; set; }// Ngày sinh

        public string?  Anh { get; set; }
    }
}
