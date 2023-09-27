using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson01.Models
{
    public class Student
    {
        public int Id { get; set; }//Mã sinh viên
        [Required(ErrorMessage = "Name không được để trống.")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Name phải có tối thiểu 4 kí tự và không được vượt quá 100 kí tự.")]
        public string? Name { get; set; } //Họ tên
       
        [Required(ErrorMessage = "Email bắt buộc phải được nhập")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string? Email { get; set; } //Email
       
        
        [StringLength(100, MinimumLength = 8)]
        [Required(ErrorMessage = "Mật khẩu không được để trống.Mật khẩu là bắt buộc và có độ dài ít nhất 8 ký tự")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&+=!]).*$",
        ErrorMessage = "Mật khẩu phải chứa ít nhất một ký tự viết hoa, viết thường, chữ số và ký tự đặc biệt.")]
        public string? Password { get; set; }//Mật khẩu

        [Required(ErrorMessage = "Ngành không được để trống")]
        public Branch? Branch { get; set; }//Ngành học
        [Required(ErrorMessage = "Giới tính không được để trống")]
        public Gender? Gender { get; set; }//Giới tính
        [Required(ErrorMessage = "Phải chọn hệ bạn đang học.")]
        public bool IsRegular { get; set; }//Hệ: true-chính quy, false-phi chính quy
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string? Address { get; set; }//Địa chỉ
        [Range(typeof(DateTime), "1/1/1963", "12/31/2005")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        public DateTime DateOfBorth { get; set; }//Ngày sinh

        [Required(ErrorMessage = "Điểm không được để trống!")]
        [Range(0, 10, ErrorMessage = "Điểm phải nằm trong khoảng từ 0 đến 10.")]
        [Column(TypeName = "decimal(2,2)")]
        public int Score { get; set; }

        //[FileExtensions(Extensions = "png,jpg,jpeg,gif")]
        //public IFormFile? ImageURL { get; set; }
        //public string ImagePath { get; set; }


    }
}
