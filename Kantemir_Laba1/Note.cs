using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1_Kantemir
{
    class Note
    {
        //Основные методы
        //Создание
        public static void CreateNote()
        {
            Book a = new Book();

            Console.WriteLine("***********************************************************************************************************************");
            Console.WriteLine("Просим заполнить обязательные поля.");
            Console.WriteLine("Обязательными для заполнения являются: имя, фамилия, номер телефона и страна");
            Console.WriteLine("Остальные поля заполняются по вашему усмотрению");
            Console.WriteLine("***********************************************************************************************************************");
            Console.WriteLine("Введите имя:");
            a.Firstname = CheckName(Console.ReadLine(), "имя:");
            Console.WriteLine("***********************************************************************************************************************");
            Console.WriteLine("Введите фамилию:");
            a.Middlename = CheckName(Console.ReadLine(), "фамилию:");
            Console.WriteLine("***********************************************************************************************************************");
            Console.WriteLine("Введите отчество:");
            a.Lastname = CaseEmpty();
            Console.WriteLine("***********************************************************************************************************************");
            Console.WriteLine("Введите телефон (номер телефона должен состоять только из цифр):");
            while (true)
            {
                if (!Int32.TryParse(Console.ReadLine(), out int tel))
                {
                    Console.WriteLine("Введите телефон (обязательно). Телефон должен содержать только цифры.");
                }
                else
                {
                    a.Phonenumber = tel;
                    break;
                }
            }
            Console.WriteLine("***********************************************************************************************************************");
            Console.WriteLine("Введите страну проживания:");
            a.Address = CheckName(Console.ReadLine(), "страну:");
            Console.WriteLine("***********************************************************************************************************************");
            Console.WriteLine("Название вашей организации:");
            a.Org = CaseEmpty();
            Console.WriteLine("***********************************************************************************************************************");
            Console.WriteLine("Ваша должность:");
            a.Position = CaseEmpty();
            Console.WriteLine("***********************************************************************************************************************");
            Console.WriteLine("Ваши заметки:");
            a.Notes = CaseEmpty();
            Console.WriteLine("***********************************************************************************************************************");
            Console.WriteLine("Дата вашего рождения:");
            a.Birthdate = CaseEmpty();
            Console.WriteLine("***********************************************************************************************************************");
            Notebook.book.Add(a);
            Console.Clear();
        }

        //Редактирование
        public static void NoteEditor()
        {
            Book book1 = new Book();
            int Id = CheckBook("изменение записи невозможно", "изменить");
            if (Id == -1)
            {
                return;
            }
            var currentBook = Notebook.book.Find(x => x.Id == Id);
            Console.Clear();

            Console.WriteLine("Напишите что именно вы хотите изменить (имя, фамилию, отчество и т.д.):");
            string a = Console.ReadLine();
            if (a == "Имя" || a == "имя")
            {
                Console.WriteLine("Введите имя:");
                currentBook.Firstname = CheckName(Console.ReadLine(), "имя:");

            }
            if (a == "Фамилия" || a == "фамилия" || a == "Фамилию" || a == "фамилию")
            {
                Console.WriteLine("Введите фамилию:");
                currentBook.Lastname = CheckName(Console.ReadLine(), "фамилия:");
            }
            if (a == "Отчество" || a == "отчество")
            {
                Console.WriteLine("Введите отчество:");
                currentBook.Middlename = CheckName(Console.ReadLine(), "отчество:");
            }
            if (a == "дата рождения" || a == "дата" || a == "дату" || a == "др" || a == "ДР" || a == "дату рождения"

            || a == "Дата рождения" || a == "Дата" || a == "Дату" || a == "Дату рождения")
            {
                Console.WriteLine("Введите дату рождения:");
                currentBook.Birthdate = CheckName(Console.ReadLine(), "дата рождения:");
            }
            if (a == "страна" || a == "Страна" || a == "страну" || a == "Страну")
            {
                Console.WriteLine("Введите страну:");
                currentBook.Address = CheckName(Console.ReadLine(), "страна:");
            }
            if (a == "Номер телефона" || a == "номер телефона" || a == "номер" || a == "телефон" || a == "Номер" || a == "Телефон")
            {
                Console.WriteLine("Введите номер телефона (должен состоять только из цифр):");
                while (true)
                {
                    if (!Int32.TryParse(Console.ReadLine(), out int tel))
                    {
                        Console.WriteLine("Введите телефон (обязательно). Телефон должен содержать только цифры.");
                    }
                    else
                    {
                        currentBook.Phonenumber = tel;
                        break;
                    }
                }
            }
            if (a == "организация" || a == "организацию" || a == "Организацию" || a == "Организация")
            {
                Console.WriteLine("Введите название организации:");
                currentBook.Org = CheckName(Console.ReadLine(), "организация:");
            }
            if (a == "Должность" || a == "должность")
            {
                Console.WriteLine("Введите должность:");
                currentBook.Position = CheckName(Console.ReadLine(), "должность:");
            }
            if (a == "Заметки" || a == "заметки" || a == "заметку" || a == "Заметку")
            {
                Console.WriteLine("Введите заметки:");
                currentBook.Notes = CheckName(Console.ReadLine(), "заметки:");
            }
            Console.WriteLine("Редактирование завершено. Нажмите любую клавишу.");
            Console.ReadKey();
            Console.Clear();
        }


        //Показ всех записей
        public static void NoteDisplay()
        {
            if (Notebook.book.Count == 0)
            {
                Console.WriteLine($"К сожалению, записи отсутствуют. Нажмите Enter, чтобы продолжить.");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            Console.WriteLine("Все записи:\n");
            foreach (var item in Notebook.book)
            {
                Console.WriteLine($"ID: {item.Id}\nИмя: {item.Firstname}\nФамилия: {item.Lastname}\nНомер телефона: {item.Phonenumber}");
                Console.WriteLine("***********************************************************************************************************************");
            }
            Console.ReadKey();
            Console.Clear();
        }


        //Просмотр записи по ID
        public static void ViewWithId()
        {
            int Id = CheckBook("показывать, к сожалению, нечего", "просмотреть");
            if (Id == -1)
            {
                return;
            }
            Console.WriteLine("Запись:");
            var a = Notebook.book.Find(x => x.Id == Id);
            ViewId(a);
            Console.ReadKey();
            Console.Clear();
        }


        //Удаление записи
        public static void DeleteNote()
        {
            int Id = CheckBook("удалять нечего", "удалить");
            if (Id == -1)
            {
                return;
            }
            Console.Clear();
            Notebook.book.Remove(Notebook.book.Find(x => x.Id == Id));
            Console.WriteLine("Удаление прошло успешно.");
            Console.ReadKey();
            Console.Clear();
        }

        //Вспомогательные методы
        //Вывод всех полей
        public static void ViewId(Book currentBook)
        {
            Console.WriteLine($"ID записи: {currentBook.Id}\nИмя: {currentBook.Firstname}\nФамилия: {currentBook.Lastname}\nОтчество: {currentBook.Middlename}\nТелефон: {currentBook.Phonenumber}\n" +
            $"Страна: {currentBook.Address}\nДата рождения: {currentBook.Birthdate}\nОрганизация: {currentBook.Org}\nДолжность: {currentBook.Position}\nЗаметки: {currentBook.Notes}");
        }

        //Проверка обязательных полей на пустоту
        public static string CheckName(string s, string p)
        {
            while (true)
            {
                if (s == "")
                {
                    Console.WriteLine($"Введите {p}");
                    s = Console.ReadLine();
                }
                else if (s.IndexOf(' ') > -1)
                {
                    Console.WriteLine($"Здесь не должно быть пробелов. Введите {p}\b заново.");
                    s = Console.ReadLine();
                }
                else
                {
                    break;
                }
            }
            return s;
        }

        //Пустые поля
        public static string CaseEmpty()
        {
            string a = Console.ReadLine();
            if (a == "" || a == null)
            {
                return "Не указано";
            }
            return a;
        }

        //Проверка книжки на пустоту
        public static int CheckBook(string a, string b)
        {
            while (true)
            {
                if (Notebook.book.Count == 0)
                {
                    Console.WriteLine($"Записей нет, {a}. Нажмите Enter для продолжения.");
                    Console.ReadKey();
                    Console.Clear();

                    return -1;
                }
                Console.WriteLine($"Введите Id записи в диапазоне от 1 до {Notebook.book.Count}, чтобы её {b}.");
                if (!Int32.TryParse(Console.ReadLine(), out int Id))
                {
                    Console.WriteLine("Введено что-то кроме цифр.");
                }
                else if (!Notebook.book.Exists(x => x.Id == Id))
                {
                    Console.WriteLine($"Такого ID нет. Невозможно {b} несуществующее. Нажмите Enter для продолжения.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    return Id;
                }
            }
        }
    }
}
