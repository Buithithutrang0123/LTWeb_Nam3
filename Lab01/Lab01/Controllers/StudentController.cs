using Lab01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.CodeAnalysis.Options;
using System.Net;
using System.Reflection;
using System.Xml.Linq;
namespace Lab01.Controllers

{
    // cú pháp đặt route là: [Route("<Tên_route_muon_dat>")], mỗi tên route chỉ tồn tại 1 dấu "/" ở trong

    // Cú pháp:   [Route("Admin")] phía dưới là đặt route cho Controller này là controller StudentController
    [Route("Admin")]
    public class StudentController : Controller
    {
        private List<Student> listStudents = new List<Student>();

        

        public StudentController()
        {
           
            // Tạo danh sách sinh viên với 4 dữ liệu mẫu
            listStudents = new List<Student>()
            {
                new Student() {Id=101,Name="Hải Nam",Branch=Branch.IT,Gender=Gender.Male,IsRegular=true,
                Address="A1-2018",Email="nam@g.com"
                },
                new Student() {Id=102,Name="Minh Tú",Branch=Branch.BE,Gender=Gender.Female,IsRegular=true,
                Address="A1-2019",Email="tu@g.com"
                },
                new Student() {Id=103,Name="Hoàng Phong",Branch=Branch.CE,Gender=Gender.Male,IsRegular=false,
                Address="A1-2020",Email="phong@g.com"
                },
                new Student() {Id=104,Name="Xuân Mai",Branch=Branch.EE,Gender=Gender.Female,IsRegular=false,
                Address="A1-2021",Email="mai@g.com"
                }



            };
        }

        // khi dùng route để chạy ts hàm này trên web ta lm như sau: <hostname_hiện_tại_trang_dang_chay>/Admin/Student/List-> khi đó sẽ chạy ts hàm Index
        // lí do thêm Admin là do ta đã đặt route cho controllers này ở dòng trên dòng code thứ 10 của file code này, lướt lên dòng 14 sẽ thấy:
        [Route("Student/List")]
        public IActionResult Index()
        {
            // Trả về View Index.cshtml cùng Model là danh sách sv listStudents
            return View(listStudents);
        }


        // Tạo route cho Create: 
        // Do có 2 hàm Create lên 1 cái sẽ để HttpGet, còn hàm dưới để HttpPost 
        // [HttpGet("Student/Add")] là cách viết gọn của 
        // [Route("Student/Add")]
        // [HttpGet]    
        // khi dùng route để chạy ts hàm này trên web ta lm như sau: <hostname_hiện_tại_trang_dang_chay>/Admin/Student/Add -> khi đó sẽ chạy ts hàm create


        [HttpGet("Student/Add")]
        public IActionResult Create()
        {
            // lấy danh sách các giá trị Gender để hiển thị radio button trên form
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            // lấy danh sách các giá trị Branch để hiển thị select - option trên form
            //Để hiển thị select-option trên View cầm dùng List<SelectListItem>
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem {Text="IT", Value="1"},
                new SelectListItem {Text="BE", Value="2"},
                new SelectListItem {Text="CE", Value="3"},
                new SelectListItem { Text = "EE", Value="4"}
            };

            return View();
        }

        [HttpPost("Student/Add")]
        public IActionResult Create(Student s,IFormFile Image)
        {
            //giải thích: Câu 9: Nếu thông tin file trong input ở trong file create mà khác rỗng tức đã lấy
            //file thì sẽ lấy tên file ở dòng lệnh 76 và 77
            
            if (Image!= null)
            {
                var fileName = Image.FileName;
                fileName = Path.GetFileName(fileName);
               
                // giải thích: Câu 9: gán tên file vào cột Anh đã tạo ở bên file Index
                s.Anh =fileName;

              
            }
            //giải thích: Câu 9: Nếu thông tin file trong input ở trong file create mà rỗng tức chưa truyền link file vào thì sẽ hiển thị ra 
            // "Chưa chọn file ảnh đại diện" ở cột Anh đã tạo ở bên file Index
            else
            {
                s.Anh = "Chưa chọn file ảnh đại diện!";
            }
           
            s.Id = listStudents.Last<Student>().Id+1;
            listStudents.Add(s);
            return View("Index", listStudents);
        }
    }
}
