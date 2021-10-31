using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace zadanie2
{
    class Program
    {
        static void Main(string[] args)
        {
            //создаем массив строк и записываем даные из файла
            string path = "G:/Проверка проекта/Products.json";
            StreamReader sr = new StreamReader(path);
            string[] jsonstring = new string [5];
            
            for (int i=0;i<5;i++)
            {
                jsonstring[i] = sr.ReadLine();
            }
            sr.Close();
         
            //передаем значения строк в массив классов
            Tovar[] tovar = new Tovar[5];
            for (int i =0; i<5;i++)
            {
                tovar[i] = JsonSerializer.Deserialize<Tovar>(jsonstring[i]);
            }


            //ищем самый дорогой товар
            double maxCena = 0;
            string maxNazvanie = null;
            for (int i = 0; i<5;i++)
            {
                if (tovar[i].Cena > maxCena)
                {
                    maxCena = tovar[i].Cena;
                    maxNazvanie = tovar[i].Nazvanie;
                }
            }
            Console.WriteLine(maxNazvanie);

            Console.ReadKey();
        }
    }
    class Tovar
    {
        public int Kod { get; set; }
        public string Nazvanie { get; set; }
        public double Cena { get; set; }
    }
}
