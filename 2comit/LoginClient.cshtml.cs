using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

public class LoginClientModel : PageModel
{
    [BindProperty]
    public string Email { get; set; }
    [BindProperty]
    public string Password { get; set; }

    public string Message { get; set; } // Для вывода сообщения пользователю

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
                    return RedirectToPage("/Catalog"); // Убедитесь, что здесь используется RedirectToPage
                }
            }
        }

        Message = "Неверный email или пароль!";
        return Page(); // Остаемся на той же странице при ошибке
    }


}
