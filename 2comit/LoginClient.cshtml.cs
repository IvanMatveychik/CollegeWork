using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

public class LoginClientModel : PageModel
{
    [BindProperty]
    public string Email { get; set; }
    [BindProperty]
    public string Password { get; set; }

    public string Message { get; set; } // ��� ������ ��������� ������������

    public IActionResult OnPost()
    {
        if (System.IO.File.Exists("clients.txt"))
        {
            var clients = System.IO.File.ReadAllLines("clients.txt");
            foreach (var client in clients)
            {
                var data = client.Split(',');
                if (data.Length == 3 && data[1] == Email && data[2] == Password)
                {
                    return RedirectToPage("/Catalog"); // ���������, ��� ����� ������������ RedirectToPage
                }
            }
        }

        Message = "�������� email ��� ������!";
        return Page(); // �������� �� ��� �� �������� ��� ������
    }


}
