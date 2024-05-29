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

                var _model = new EditUser
                {
                    IsnNode = model.IsnNode == Guid.Empty ? Guid.NewGuid() : model.IsnNode,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Password = model.Password,
                };
                userManager.Create(_model);

                
                return RedirectToAction("Index", "Main", new { id = _model.IsnNode});
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
        public async Task<ActionResult> CreateLogin(EditUser USER)
        {
            User user = userManager.FindByFirstName(USER.FirstName, USER.Password);

            // Если пользователь найден, аутентифицировать его и перенаправить на главную страницу
            if (user!=null)
            {
                // Реализуйте аутентификацию пользователя
                // Например, можно использовать HttpContext.SignInAsync() для аутентификации пользователя

                // Перенаправить на главную страницу
                return RedirectToAction("Index", "Main", new { id = user.IsnNode });
            }

            // Если пользователь не найден, вернуть представление с сообщением об ошибке
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View("Login", USER);
        }

        
    }
}
