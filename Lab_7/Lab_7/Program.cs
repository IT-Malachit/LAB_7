using System;
using System.Xml.Linq;
using System.IO;

namespace Lab_7
{

    public partial class Phones
    {
        private String name;
        private String company;
        private long price;
        
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
                XAttribute nameAttribute = phoneElement.Attribute("name");
                XElement companyElement = phoneElement.Element("company");
                XElement priceElement = phoneElement.Element("price");

                if (nameAttribute != null && companyElement != null && priceElement != null)
                {
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
            Console.Write("Название телефона: ");
            string name = Console.ReadLine();
            Console.Write("Название компании: ");
            string company = Console.ReadLine();
            Console.Write("Стоимость телефона: ");
            long price = System.Int64.Parse(Console.ReadLine());
            Phones phone = new Phones(name,company,price);

            XDocument xdoc = XDocument.Load("phones.xml");
            XElement root = xdoc.Element("phones");
            root.Add(new XElement("phone",
                new XAttribute("name",phone.GetName()),
                new XElement("company",phone.GetCompany()),
                new XElement("price",phone.GetPrice()))
                );
            xdoc.Save("phones.xml");
        }

        static void Main(string[] args)
        {

            int choise = 0;
            while (choise != 6)
            {

                Console.Clear();
                Console.WriteLine("1)Просмотреть файл");
                Console.WriteLine("2)Добавить");
                Console.WriteLine("3)");
                Console.WriteLine("4)");
                Console.WriteLine("5)");
                Console.WriteLine("6)Выход");
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
                }

            }            
        }
    }
}
