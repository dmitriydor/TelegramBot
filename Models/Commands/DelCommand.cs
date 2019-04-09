using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TestBot.Models.Commands
{
    public class DelCommand : Command
    {
        public string Name { get; set; } = "/delete";

        public void LogicCommand(Update update, TelegramBotClient client, UserContext context)
        {
            //сообщение приходит в формате "/delete"
            if (update.Message.Text.StartsWith(Name))
            {
                //поиск пользователя в базе данных
                User u = context.Users.Find(update.Message.From.Id);
                if (u != null)
                {
                    //удаление пользователя если он найден
                    context.Users.Remove(context.Users.Find(update.Message.From.Id));
                    client.SendTextMessageAsync(update.Message.Chat.Id, "User deleted");
                    context.SaveChanges();
                }
                else client.SendTextMessageAsync(update.Message.Chat.Id, "No such user exists");
            }
        }
    }
}
