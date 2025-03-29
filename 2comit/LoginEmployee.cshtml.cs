using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

public class LoginEmployeeModel : PageModel
{
    [BindProperty]
    public string Email { get; set; }
    [BindProperty]
    public string Password { get; set; }

    public string Message { get; set; } // ��� ������ ��������� ������������

    public IActionResult OnPost()
    {
        if (System.IO.File.Exists("employees.txt"))
        {
            var employees = System.IO.File.ReadAllLines("employees.txt");
            foreach (var employee in employees)
            {
                var data = employee.Split(',');
                if (data.Length == 3 && data[1] == Email && data[2] == Password)
                {
                    return RedirectToPage("/Catalog"); // ������� �� �������� "�������"
                }
            }
        }

        Message = "�������� email ��� ������!";
        return Page(); // �������� �� ������� �������� ��� ������
    }


}
