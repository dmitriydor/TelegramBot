using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestBot.Models
{
    //класс-сущность для EntityFramework
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int From { get; set; }// from -> id получаемое из сообщения 
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }

    }
}
