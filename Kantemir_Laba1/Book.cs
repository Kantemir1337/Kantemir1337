using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1_Kantemir
{
    class Book
    {
        public int Id { set; get; } //Айди
        public string Firstname { set; get; } //Имя
        public string Lastname { set; get; } //Фамилия
        public string Middlename { set; get; } //Отчество
        public string Birthdate { set; get; } //Дата рождения
        public int Phonenumber { set; get; } //Номер телевона
        public string Address { set; get; } //Страна
        public string Org { set; get; } //Организация
        public string Position { set; get; } //Должность
        public string Notes { set; get; } //Заметки
        internal static int count = 0;

        public Book()
        {
            count++;
            Id = count;
        }
    }
}

