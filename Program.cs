using System;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            Console.WriteLine("Digite Qual Opção Voce Quer:");
            Console.WriteLine("1 - Abrir");
            Console.WriteLine("2 - Editar");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("___________________________");
            int opcao = int.Parse(Console.ReadLine());
            
            switch (opcao)
            {
                case 0:System.Environment.Exit(0); break;
                case 1:Abrir();break;
                case 2:Editar();break;
            }
        }
        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual o Caminho do Arquivo?");
            string path = Console.ReadLine();
            
            using(var file = new StreamReader(path))
            {
                string texto = file.ReadToEnd();
                Console.WriteLine("");
                Console.WriteLine(texto);
            }
            Console.WriteLine("______________________________________");

            Menu();
        }
        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Digite o seu Texto Abaixo (ESC para sair)");
            Console.WriteLine("_______________________________________________");
            string texto = "";

            do
            {
                texto += Console.ReadLine();
                texto += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
                Console.WriteLine("________________________________");
                Console.Write(texto);
            Console.WriteLine("==========================================================");
            Salvar(texto);
            Menu();
        }
        static void Salvar(string texto)
        {
            Console.Clear();
            Console.WriteLine("DIGITE O CAMINHO PARA SALVAR O DOCUMENTO!");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(texto);
            }
            Console.WriteLine("Arquivo Salvo com Sucesso!!");
            Console.WriteLine($"Caminho Salvo {path}");
            Console.ReadLine();
            Menu();


        }
    }
}
