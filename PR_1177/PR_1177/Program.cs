
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr_17_
{
    internal class Program
    {
        static void Errors(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ошибочка: Что-то пошло не так");
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();
        }
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Здравствуйте!\nПрактическая работа № 17. \n");
                    Console.ResetColor();

                    File file = new File();
                    file = new File(ref file);

                    Console.ReadKey();
                    Console.Clear();
                }
                catch (Exception e)
                {
                    Errors(e);
                    continue;
                }
                Console.WriteLine("Введите Y чтобы выйти из программы: ");
                if (Console.ReadKey().Key == ConsoleKey.Y)
                    break;
                Console.Clear();
            }
        }
    }
    class File
    {
        string fileName;
        long fileSize;
        string fileType;
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        public long FileSize
        {
            get { return fileSize; }
            set { fileSize = value; }
        }
        public string FileType
        {
            get { return fileType; }
            set { fileType = value; }
        }
        public File() { }
        public File(ref File file)
        {
            file.InputFileData(ref file);
            file.DisplayFileInfo();
        }
        ~File()
        {
            Console.WriteLine("Сработал деструктор.");
            Console.ReadKey();
        }
        private void InputFileData(ref File file)
        {
            Console.Write("Введите имя файла: ");
            string inputFileName = Console.ReadLine();
            file.RenameFile(inputFileName);
            Console.Write("Введите размер файла (в байтах): ");
            long size;
            while (!long.TryParse(Console.ReadLine(), out size) || size < 0)
                Console.Write("Неверный ввод. Пожалуйста, введите размер файла (в байтах): ");
            FileSize = size;
            Console.Write("Введите тип файла: ");
            string inputFileType = Console.ReadLine();
            if (string.IsNullOrEmpty(inputFileType) || inputFileType[0] == ' ')
                throw new Exception("Тип файла не может быть пустым или указно не корректно");
            FileType = inputFileType;
        }
        private void DisplayFileInfo()
        {
            Console.WriteLine($"\nИнформация о файле:");
            Console.WriteLine($"Имя файла: {FileName}");
            Console.WriteLine($"Размер файла: {FileSize} байт");
            Console.WriteLine($"Тип файла: {FileType}");
        }
        private void RenameFile(string newFileName)
        {
            if (String.IsNullOrWhiteSpace(newFileName))
                throw new Exception("Новое имя файла не может быть пустым");
            FileName = newFileName;
            Console.WriteLine($"Файл переименован в: {newFileName}");
        }
    }
}
