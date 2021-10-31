 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.IO;

namespace zadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            //создание масиива и запись данных о товаре
            Tovar[] tovar = new Tovar[5];
            for (int i = 0; i < 5; i++)
            {
                tovar[i] = new Tovar();
                Console.WriteLine("Введите данные для {0} товара", i + 1);
                Console.WriteLine("Введите код товара");
                tovar[i].Kod = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите название товара");
                tovar[i].Nazvanie = Console.ReadLine();
                Console.WriteLine("Введите цену товара");
                tovar[i].Cena = double.Parse(Console.ReadLine());
            }

            //преобразование данных массива в массив строк json
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
            };

            string[] jsonString = new string [5];
            for (int i =0;i<5;i++)
            {
                jsonString[i] = JsonSerializer.Serialize(tovar[i], options);
            }
            

            //создание и запись файла
            string path = "G:/Проверка проекта/Products.json";
            StreamWriter sw = new StreamWriter(path);
            for (int i = 0; i < 5; i++)
            {
                sw.WriteLine(jsonString[i]);
            }
            sw.Close();


            Console.ReadKey();

        }
    }
    class Tovar
    {
        public int Kod { get; set; }
        public string Nazvanie { get; set; }
        public double Cena { get; set; }

       /* public Tovar(int kod, string nazvanie, double cena)
        {
            Kod = kod;
            Nazvanie = nazvanie;
            Cena = cena;
        }*/
    }
}
