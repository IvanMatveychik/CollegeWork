using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO; // ��� ������ � �������

public class RegisterModel : PageModel
{
    [BindProperty]
    public string Name { get; set; }
    [BindProperty]
    public string Email { get; set; }
    [BindProperty]
    public string Password { get; set; }

    public IActionResult OnPost()
    {
        // ��������� ������ ������� � ����
        var clientData = $"{Name},{Email},{Password}\n";
        System.IO.File.AppendAllText("clients.txt", clientData);

        // �������� �� �������� "�������" ����� �������� �����������
        return RedirectToPage("/Catalog");
    }

}
