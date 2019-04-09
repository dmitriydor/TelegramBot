using Telegram.Bot;
using Telegram.Bot.Types;

namespace TestBot.Models.Commands
{
    public interface Command
    {
        string Name { get; set; } // строковое представление команды
        void LogicCommand(Update update, TelegramBotClient client, UserContext context); // метод для выполнения логики команды
    }
}
