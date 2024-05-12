namespace SuperFitnes.Controllers
{
    using Classes.models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using SuperFitnes.Features.DtoModels.User;
    using SuperFitnes.Features.Interfaces;

    [Route("Account")]
    public class AccountController : Controller
    {

        private readonly IUserManager userManager;

        public AccountController(IUserManager userManager)
        {
            this.userManager = userManager;
        }


        [HttpGet, Route("Register")]
        public async Task<ActionResult> Register()
        {
            return View();
        }

        [HttpPost(nameof(CreateRegister), Name = "CreateRegister")]
        public async Task<ActionResult> CreateRegister(EditUser model)
        {
            if (ModelState.IsValid)
            {

                // Добавление пользователя в контекст данных и сохранение его в базе данных
                userManager.Create(model);

                // Пример редиректа на главную страницу после регистрации
                return RedirectToAction("Index", "Home");
            }

            // Если валидация модели не удалась, вернуть представление с ошибками
            return View(nameof(Register), model);
        }


        [HttpGet, Route("Login")]
        public async Task<ActionResult> Login()
        {
            return View();
        }

        [HttpPost(nameof(CreateLogin), Name = "CreateLogin")]
        public async Task<ActionResult> CreateLogin(string firstName)
        {
            bool user = userManager.FindByFirstName(firstName);

            // Если пользователь найден, аутентифицировать его и перенаправить на главную страницу
            if (user)
            {
                // Реализуйте аутентификацию пользователя
                // Например, можно использовать HttpContext.SignInAsync() для аутентификации пользователя

                // Перенаправить на главную страницу
                return RedirectToAction("Index", "Home");
            }

            // Если пользователь не найден, вернуть представление с сообщением об ошибке
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View();
        }

        
    }
}
