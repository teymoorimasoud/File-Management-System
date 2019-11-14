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
                Console.WriteLine("(C:CreateFolder, F:AddFile, D:Delete, S:Size, R:Rename, T:Tree, E:Exit):");
                Console.ResetColor();
                var documetType = Char.ToUpper(Console.ReadKey().KeyChar);
                Console.SetCursorPosition(0, Console.CursorTop);
                switch (documetType)
                {
                    case 'C':
                        fileManager.Go4CreateFolder();
                        break;
                    case 'F':
                        fileManager.Go4CreateFile();
                        break;
                    case 'D':
                        fileManager.Go4Delete();
                        break;
                    case 'S':
                        fileManager.Go4GetSize();
                        break;
                    case 'R':
                        fileManager.Go4GetRename();
                        break;
                    case 'T':
                        fileManager.ShowTree();
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
