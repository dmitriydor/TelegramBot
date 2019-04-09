using System.Collections.Generic;
using System.Net;
using Telegram.Bot;
using TestBot.Models.Commands;

namespace TestBot.Services
{
    public sealed class Bot
    {
        public readonly TelegramBotClient client  = new TelegramBotClient("Token", wp); //токен полученный от BotFather
        private static readonly WebProxy wp = new WebProxy("206.109.4.94:8080", true); // прокси т.к. заблокирован доступ к телеграму
        private static string whook = string.Concat("url_host", "/api/registration"); //адрес где развернут бот
        private List<Command> commandsList = new List<Command>(); // лист команд
        public IReadOnlyList<Command> Commands => commandsList.AsReadOnly(); // обертка для листа команд

        public Bot()
        {
            //инициализация команд бота
            commandsList.Add(new RegCommand()); 
            commandsList.Add(new DelCommand()); 
            commandsList.Add(new InfoCommand()); 
            client.SetWebhookAsync(whook); //установка webhook
        }
    }
}
