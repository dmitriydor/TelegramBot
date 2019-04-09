using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TestBot.Models.Commands
{
    public class InfoCommand : Command
    {
        public string Name { get; set; } = "/info";

        public void LogicCommand(Update update, TelegramBotClient client, UserContext context)
        {
            //сообщение приходит в формате "/info"
            if (update.Message.Text.StartsWith(Name))
            {
                //поиск пользователя в базе данных
                User u = context.Users.Find(update.Message.From.Id);
                if (u != null)
                    //вывод информации о пользователе если он найден
                    client.SendTextMessageAsync(update.Message.Chat.Id, $"Information: first name = {u.FirstName} , surname = {u.Surname},middle name = {u.MiddleName},birthdate = {u.BirthDate.ToString()}");
                else client.SendTextMessageAsync(update.Message.Chat.Id, "Information not found");
            }
        }
    }
}
