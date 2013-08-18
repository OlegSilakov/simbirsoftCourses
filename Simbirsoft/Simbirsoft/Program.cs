using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbirsoft {

    class Program {
        static bool checkForTypeOfFile(string inputStr, string typeOfFile) {
            string[] parceStr = inputStr.Split('.');
            return (parceStr[parceStr.Length - 1] == typeOfFile) ? true : false;
        }

        static void Main(string[] args) {
            init(); 
        }

        static void init() {
            Console.WriteLine("Введите название входного файла:");
            string input = Console.ReadLine();
            Console.WriteLine("Введите название выходного файла:");
            string output = Console.ReadLine();
            Console.WriteLine("Введите название файла словаря:");
            string dict = Console.ReadLine();
            if (!checkForTypeOfFile(input, "txt")) {
                input += ".txt";
            }
            if (!checkForTypeOfFile(output, "html")) {
                output += ".html";
            }
            if (!checkForTypeOfFile(dict, "txt")) {
                dict += ".txt";
            }
            TextWorker t = new TextWorker(input, output, dict);
            t.readFile();
            Console.ReadKey();
        }
    }
}
