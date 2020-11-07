using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//1) К предыдущей лабораторной работе(л.р. 5) добавьте к существующим
//классам перечисление и структуру.
//2) Один из классов сделайте partial и разместите его в разных файлах.
//3) Определить класс-Контейнер(указан в вариантах жирным шрифтом)
//для хранения разных типов объектов(в пределах иерархии) в виде
//списка или массива(использовать абстрактный тип данных). Класс-
//контейнер должен содержать методы get и set для управления
//списком/массивом, методы для добавления и удаления объектов в
//список/массив, метод для вывода списка на консоль.
//4) Определить управляющий класс-Контроллер, который управляет
//объектом- Контейнером и реализовать в нем запросы по варианту.При
//необходимости используйте стандартные интерфейсы (IComparable,
//ICloneable,….)

//Создать Библиотеку с книгами, журналами и учебниками.
//Вывести наименование всех книг в библиотеке, вышедших не
//ранее указанного года; найти суммарное количество
//учебников в библиотеке, подсчитать стоимость изданий

namespace lab_6_1_
{
    abstract class GeneralInfo
    {
        public string Title { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }
        public string Cover { get; set; }
        public double Price { get; set; }
    }
    interface ICommentable
    {
        void Comment();
    }
    abstract class Comments
    {
        public abstract void Comment();
    }
    partial class PrintEdition
    {
        public string NameOfEdition { get; set; }
        public int HashCode { get; set; }
        public PrintEdition(string name)
        {
            NameOfEdition = name;
            HashCode = GetHashCode();
        }
        //public override string ToString()
        //{
        //    return NameOfEdition + "(hash code: " + HashCode + ")";
        //}
        //public override bool Equals(object obj)
        //{
        //    if (obj.GetType() != this.GetType())
        //    {
        //        return false;
        //    }
        //    PrintEdition print = (PrintEdition)obj;
        //    return (this.NameOfEdition == print.NameOfEdition);
        //}
        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}
        //Get type переписать нельзя
    }
    class Book : GeneralInfo
    {
        public Book(string title, string country, int year, int pages, string cover, double price)
        {
            Title = title;
            Country = country;
            Year = year;
            Pages = pages;
            Cover = cover;
            Price = price;
        }
        public override string ToString()
        {
            return "~~~~~~~~~~Information about book~~~~~~~~~~\nTitle: " + Title + "\nYear: " + Year + "\nPages: " + Pages + "\nCountry: " + Country + "\nPrice: " + Price;
        }
    }
    class Magazin : GeneralInfo
    {
        public Magazin(string title, string country, int year, int pages, string cover, double price)
        {
            Title = title;
            Country = country;
            Year = year;
            Pages = pages;
            Cover = cover;
            Price = price;
        }
        public override string ToString()
        {
            return "~~~~~~~~~~Information about magazin~~~~~~~~~~\nTitle: " + Title + "\nYear: " + Year + "\nPages: " + Pages + "\nCountry: " + Country + "\nPrice: " + Price;
        }
    }
    class SchoolBook : GeneralInfo
    {
        public SchoolBook(string title, string country, int year, int pages, string cover, double price)
        {
            Title = title;
            Country = country;
            Year = year;
            Pages = pages;
            Cover = cover;
            Price = price;
        }
        public override string ToString()
        {
            return "~~~~~~~~~~Information about school book~~~~~~~~~~\nTitle: " + Title + "\nYear: " + Year + "\nPages: " + Pages + "\nCountry: " + Country + "\nPrice: " + Price;
        }
    }
    sealed class Author : Comments, ICommentable
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public Author(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
        public override string ToString()
        {
            return "Author: " + Name + " " + Surname;
        }
        public override void Comment()
        {
            Console.WriteLine("The famous author!");
        }
    }
    class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Person(string name = "Good", string surname = "Man")
        {
            Name = name;
            Surname = surname;
        }
        public override string ToString()
        {
            return "Person: " + Name + " " + Surname;
        }
    }
    class Publishing : Comments, ICommentable
    {
        public string NamePublish { get; set; }
        public Publishing(string publish)
        {
            NamePublish = publish;
        }
        public override string ToString()
        {
            return "Publishing house: " + NamePublish + "\n";
        }
        public override void Comment()
        {
            Console.WriteLine("The best publishing house!");
        }
    }
    public class Printer
    {
        public string IAmPrinting(Object obj)
        {
            return obj.ToString();
        }
    }
    class Library
    {
        private List<GeneralInfo> info = new List<GeneralInfo>();
        public static int count = 0;
        public static double fullpr = 0;
        public List<GeneralInfo> Info
        {
            get
            {
                return info;
            }
            set
            {
                info = value;
            }
        }
        public void Add(GeneralInfo element)
        {
            Info.Add(element);
            if (element as SchoolBook != null)
            {
                count++;
            }
            fullpr = fullpr + element.Price;
        }
        public void Delete(GeneralInfo element)
        {
            Info.Remove(element);
            if (element as SchoolBook != null)
            {
                count--;
            }
            fullpr = fullpr - element.Price;
        }
        public void ListOut()
        {

            foreach (GeneralInfo x in Info)
            {
                if (x as Book != null)
                {
                    Book book = x as Book;
                    Console.WriteLine(book.ToString());
                }
                else if (x as SchoolBook != null)
                {
                    SchoolBook school = x as SchoolBook;
                    Console.WriteLine(school.ToString());
                }
                else if (x as Magazin != null)
                {
                    Magazin magazin = x as Magazin;
                    Console.WriteLine(magazin.ToString());
                }
            }
        }
    }
    class Control : Library
    {
        public void CountSchool()
        {
            Console.WriteLine("Number of school books in library: " + count);
        }
        public void FullPrice()
        {
            Console.WriteLine("Price of all: " + fullpr);
        }
    }
    enum DaysOfWork //перечисление
    {
        Monday = 1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday = Saturday
    }
    struct LibraryAddress //cтруктура
    {
        public int House;
        public string Street;
        public string City;
        public LibraryAddress(string city, string street, int house)
        {
            City = city;
            Street = street;
            House = house;
        }
        public void AddressInfo()
        {
            Console.WriteLine($"Address of library: {City}, {Street}, {House}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PrintEdition printEdition1 = new PrintEdition("Book");
            Book book1 = new Book("Harry Potter and the Prisoner of Azkaban", "United Kingdom", 1999, 464, "hard", 30);
            Author author1 = new Author("Joanne", "Rowling");
            Publishing publishing1 = new Publishing("Bloomsbury");

            PrintEdition printEdition2 = new PrintEdition("Magazin");
            Magazin magazin2 = new Magazin("Vogue", "USA", 1998, 73, "soft", 10.5);
            Author author2 = new Author("Alena", "Doletskaya");
            Publishing publishing2 = new Publishing("Condé Nast");

            PrintEdition printEdition3 = new PrintEdition("School Book");
            SchoolBook schoolBook3 = new SchoolBook("Upstream. Elementary A2 Student's Book", "United Kingdom", 2005, 128, "soft", 12.5);
            Author author3 = new Author("Virginia", "Evans");
            Publishing publishing3 = new Publishing("Express Publishing");

            Printer Printer = new Printer();
            Object[] arr = new Object[] { printEdition1, book1, author1, publishing1, printEdition2, magazin2, author2, publishing2, printEdition3, schoolBook3, author3, publishing3 };

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(Printer.IAmPrinting(arr[i]));
            }
            author1.Comment();
            publishing3.Comment();

            Console.WriteLine();
            Console.Write(author1.Name + " " + author1.Surname);
            if (author1 is ICommentable)
                Console.WriteLine(" is a very famous author");
            else
                Console.WriteLine("is a beginner");

            Console.WriteLine();
            printEdition1.Equals(magazin2);

            Console.WriteLine("\n\n\n\n\n~~~~~LAB_6~~~~~\n");

            Library lib1 = new Library();
            lib1.Add(book1);
            lib1.Add(magazin2);
            lib1.Add(schoolBook3);
            lib1.ListOut();

            Console.WriteLine("\n\nControl: ");
            Control control = new Control();
            control.CountSchool();
            control.FullPrice();
        }
    }
}
