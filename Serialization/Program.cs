using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Xml;
using System.Xml.Serialization;


namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> list = new List<Book>
            {
                new Book(){Name="Стрекоза",Year=1990,Autor="Пушкин",Price=1000},
                new Book(){Name="Муравей",Year=1991,Autor="Лермонтов",Price=9000},
                new Book(){Name="Собака",Year=1992,Autor="Чехов",Price=8000}
            };            


            BinaryFormatter formatter = new BinaryFormatter();
            if (!Directory.Exists(@"C:/data"))
                Directory.CreateDirectory(@"C:/data");

            using (FileStream stream = File.Create(@"C:/data/file.bin"))
            {
                
                    formatter.Serialize(stream, list);
                              
            }

            List<Book> checkBook = new List<Book>();
            using (FileStream stream = File.OpenRead(@"C:/data/file.bin"))
            {                
              checkBook = formatter.Deserialize(stream) as List<Book>;                                                                   
            }
            foreach(Book book in checkBook)
            {
                Console.WriteLine(book.Name);
                Console.WriteLine(book.Autor);
                Console.WriteLine(book.Price);
                Console.WriteLine(book.Year);
                Console.WriteLine("--------------------");
            }

            var customAttributes = (MyCustomAttribute[])typeof(Book).
                GetCustomAttributes(typeof(MyCustomAttribute), true);

            if (customAttributes.Length > 0)
            {
                var myAttribute = customAttributes[0];
                string value = myAttribute.SomeProperty;
                Console.WriteLine(value);
            }

        }
    }
}









//namespace Serialization
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Person person = new Person
//            {
//                FullName = "Админович Админ Админов",
//                Age = 35
//            };


//            XmlSerializer formatterXml = new XmlSerializer(typeof(Person));


//            BinaryFormatter formatter = new BinaryFormatter();
//            if (!Directory.Exists(@"C:/data"))
//                Directory.CreateDirectory(@"C:/data");

//            using (FileStream stream = File.Create(@"C:/data/file.bin"))
//            {
//                formatter.Serialize(stream, person);
//            }


//            using (FileStream stream = File.OpenRead(@"C:/data/file.bin"))
//            {
//                var resultPerson = formatter.Deserialize(stream) as Person;
//                Console.WriteLine(resultPerson.FullName);
//                Console.WriteLine(resultPerson.Age);
//            }



//            // SoapFormatter formatterSoap = new SoapFormatter();




//            if (!Directory.Exists(@"C:/dataXml"))
//                Directory.CreateDirectory(@"C:/dataXml");

//            using (FileStream stream = File.Create(@"C:/dataXml/file.xml"))
//            {
//                formatterXml.Serialize(stream, person);
//            }


//            using (FileStream stream = File.OpenRead(@"C:/dataXml/file.xml"))
//            {
//                var resultPerson = formatterXml.Deserialize(stream) as Person;
//            }


            // json


            //  List<Person> people = new List<Person>
            //  {
            //      new Person
            //      {
            //          FullName="Admin",
            //          Age=35
            //      },
            //      new Person
            //      {
            //          FullName="Admin1",
            //          Age=35
            //      },
            //      new Person
            //      {
            //          FullName="Admin2",
            //          Age=35
            //      }
            //  };
            //
            //  var reslutJson = JsonConvert.SerializeObject(people);
            //
            //  var desirialize = JsonConvert.DeserializeObject<List<Person>>(reslutJson);

//        }
//    }
//}
