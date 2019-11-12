using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   


using FSSimpleClient;

namespace Fs.Client
{
    class Program
    {
        static void Main()
        {
            FileManager fileManager = new FileManager();
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Document Type(D:CreateFolder,F:File,R:Delete, S:Size,N:Rename T:Tree, E:Exit):");
                Console.ResetColor();
                var documetType = Char.ToUpper(Console.ReadKey().KeyChar);
                Console.SetCursorPosition(0, Console.CursorTop);
                switch (documetType)
                {
                    case 'D':
                        fileManager.Go4CreateFolder();
                        break;
                    case 'F':
                        fileManager.Go4CreateFile();
                        break;
                    case 'R':
                        fileManager.Go4Delete();
                        break;
                    case 'T':
                        fileManager.ShowTree();
                        break;
                    case 'S':
                        fileManager.Go4GetSize();
                        break;
                    case 'N':
                        fileManager.Go4GetRename();
                        break;
                    case 'E':
                        Environment.Exit(0);
                        break;
                }
            }
            // ReSharper disable once FunctionNeverReturns
        }
    }
}
