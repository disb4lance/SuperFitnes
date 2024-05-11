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

        [HttpPost]
        public async Task<ActionResult> Register(EditUser model)
        {
            if (ModelState.IsValid)
            {

                // Добавление пользователя в контекст данных и сохранение его в базе данных
                userManager.Create(model);

                // Пример редиректа на главную страницу после регистрации
                return RedirectToAction("Index", "Home");
            }

            // Если валидация модели не удалась, вернуть представление с ошибками
            return View(model);
        }


        [HttpGet]
        public async Task<ActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(EditUser model)
        {
            // Ваша логика аутентификации здесь

            // Пример редиректа на главную страницу после входа
            return RedirectToAction("Index", "Home");
        }

        
    }
}
