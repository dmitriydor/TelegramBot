using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using TestBot.Services;
using TestBot.Models;
using TestBot.Models.Commands;

namespace TestBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private UserContext _context;
        private Bot _bot;

        public RegistrationController(UserContext context, Bot bot)
        {
            _context = context;
            _bot = bot;
        }

        //заглушка для проверки работоспособности приложения
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Hello");
        }

        [HttpPost]
        public void Update([FromBody]Update update)
        {
            foreach(Command command in _bot.Commands)
            {
                if (update.Message.Text.Contains(command.Name))
                {
                    command.LogicCommand(update, _bot.client, _context);
                    break;
                }
            }
        }
  
    }
}