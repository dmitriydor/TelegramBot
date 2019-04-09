using System;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TestBot.Models.Commands
{
    public class RegCommand : Command
    {
        public string Name { get; set; } = "/registration";

        public void LogicCommand(Update update, TelegramBotClient client, UserContext context)
        {
            //сообщение приходит в формате "/registration Фамилия Имя Отчество ДатаРождения"
            // разделение сообщения на подстроки
            string[] textMessage = update.Message.Text.Split(new[] { ' ' }); 
            //формирование сущности пользователя
            User user = new User { From = update.Message.From.Id, FirstName = textMessage[2], Surname = textMessage[1], MiddleName = textMessage[3], BirthDate = DateTime.Parse(textMessage[4]).Date };

            if (update.Message.Text.StartsWith(Name))
            {
                if (context.Users.Find(update.Message.From.Id) == null)
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                    client.SendTextMessageAsync(update.Message.Chat.Id, "registration");
                }
                else client.SendTextMessageAsync(update.Message.Chat.Id, "This user is already registered");
                
            }
        }
    }
}
