using System;
using System.Xml.Linq;
using System.IO;
using System.Linq;

namespace Lab_7
{

    public partial class Phones
    {
        private int id;
        private String name;
        private String company;
        private long price;
        


        public int GetId()
        {
            return id;
        }
        
        public string GetName()
        {
            return name;
        }
        public string GetCompany()
        {
            return company;
        }
        public long GetPrice()
        {
            return price;
        }
    }

    class Program
    {

        public static void GetInfo()
        {
            Console.Clear();
            XDocument xdoc = XDocument.Load("phones.xml");
            foreach (XElement phoneElement in xdoc.Element("phones").Elements("phone"))
            {
                XAttribute idElement = phoneElement.Attribute("id");
                XElement nameAttribute = phoneElement.Element("name");
                XElement companyElement = phoneElement.Element("company");
                XElement priceElement = phoneElement.Element("price");

                if (idElement != null && nameAttribute != null && companyElement != null && priceElement != null)
                {
                    Console.WriteLine($"Id: {idElement.Value}");
                    Console.WriteLine($"Смартфон: {nameAttribute.Value}");
                    Console.WriteLine($"Компания: {companyElement.Value}");
                    Console.WriteLine($"Цена: {priceElement.Value}");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        public static void AddPhone()
        {
            Console.Write("Название id: ");
            int id = System.Int32.Parse(Console.ReadLine());
            Console.Write("Название телефона: ");
            string name = Console.ReadLine();
            Console.Write("Название компании: ");
            string company = Console.ReadLine();
            Console.Write("Стоимость телефона: ");
            long price = System.Int64.Parse(Console.ReadLine());
            Phones phone = new Phones(id, name,company,price);

            XDocument xdoc = XDocument.Load("phones.xml");
            XElement root = xdoc.Element("phones");
            root.Add(new XElement("phone",
                new XAttribute("id", phone.GetId()),
                new XElement("name",phone.GetName()),
                new XElement("company",phone.GetCompany()),
                new XElement("price",phone.GetPrice()))
                );
            xdoc.Save("phones.xml");
        }
        public static void DeletePhone()
        {
            Console.Clear();
            Console.WriteLine("Айди таксофона:");
            XDocument xdoc = XDocument.Load("phones.xml");
            XElement root = xdoc.Element("phones");
            int id = System.Int32.Parse(Console.ReadLine());
            foreach (XElement xe in root.Elements("phone").ToList())
            {


                if (xe.Attribute("id").Value == id.ToString())
                     
                {
                    xe.Remove();
                }
            }
          Console.Write("Телефон удален из базы");
          xdoc.Save("phones.xml");
        }

        public static void UpdatePhone()
        {
            Console.Clear();
            Console.WriteLine("Айди таксофона:");
            
            XDocument xdoc = XDocument.Load("phones.xml");
            XElement root = xdoc.Element("phones");
            int id = System.Int32.Parse(Console.ReadLine());
            Console.WriteLine("Название телефона:");
            String name = Console.ReadLine();
            Console.WriteLine("Цена:");
            long price = System.Int64.Parse(Console.ReadLine());
            Console.WriteLine("Название компании:");
            String company = Console.ReadLine();

            foreach (XElement xe in root.Elements("phone").ToList())
            {
                // изменяем название и цену
                if (xe.Attribute("id").Value == id.ToString())
                {
                    xe.Element("name").Value = name;
                    xe.Element("price").Value = price.ToString();
                    xe.Element("company").Value = company;
                }
                
            }
            xdoc.Save("phones.xml");
        }
        static void Main(string[] args)
        {

            int choise = 0;
            while (choise != 5)
            {

                Console.Clear();
                Console.WriteLine("1)Просмотреть файл");
                Console.WriteLine("2)Добавить");
                Console.WriteLine("3)Удаление");
                Console.WriteLine("4)Изменение");
                Console.WriteLine("5)Выход");
                choise = System.Int32.Parse(Console.ReadLine());

                switch (choise)
                {
                    case 1:
                        {
                            GetInfo();
                            break;
                        }
                    case 2:
                        {
                            AddPhone();
                            break;
                        }
                    case 3:
                        {
                            DeletePhone();
                            break;
                        }
                    case 4:
                        {
                            UpdatePhone();
                            break;
                        }
                }

            }            
        }
    }
}
