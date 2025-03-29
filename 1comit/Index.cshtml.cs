using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO; // Для работы с файлами

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
        // Сохраняем данные клиента в файл
        var clientData = $"{Name},{Email},{Password}\n";
        System.IO.File.AppendAllText("clients.txt", clientData);

        // Редирект на страницу "Каталог" после успешной регистрации
        return RedirectToPage("/Catalog");
    }

}
