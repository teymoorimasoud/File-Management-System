using System;
using System.Collections.Generic;
using System.IO;
using FSSimpleLib;
using File = FSSimpleLib.File;


namespace FSSimpleClient
{
    public class FileManager
    {
        Folder rootFolder = new Folder("root","admin");
        private List<FileSystemElement> _fileSystemElements = new List<FileSystemElement>();
        public void Go4CreateFolder()
        {
            Console.Write("Parent Directory Folder:");
            string path = Console.ReadLine();
            Console.Write("Folder Name:");
            string folderName = Console.ReadLine();
            Console.Write("Creator :");
            string creator = Console.ReadLine();

            try
            {
                Folder folder = new Folder(folderName, creator);
                Folder parentFolder = (Folder)rootFolder.GetLastElementFromPath(path);
                parentFolder.AddFolder(folder);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
            
        }
       
        public void Go4CreateFile()
        {
            Console.Write("Parent Directory File:");
            string path = Console.ReadLine();
            Console.Write("File Name:");
            string fileName = Console.ReadLine();
            Console.Write("Creator :");
            string creator = Console.ReadLine();
            Console.Write("Format :");
            string format = Console.ReadLine();

            try
            {
                Console.Write("Size :");
                decimal size = Convert.ToDecimal(Console.ReadLine());
                File file = new File(fileName, creator, format, size);
                Folder parentFolder = (Folder)rootFolder.GetLastElementFromPath(path);
                parentFolder.AddFile(file);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
        }
        public void ShowTree()
        {
            TraverseFolder(rootFolder, 0);
        }
        private void TraverseFolder(Folder parentFolder, int level)
        {
            AddNodeText(parentFolder.Name, level);

            foreach (var folder in parentFolder.Folders)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                TraverseFolder(folder, level + 1);
                Console.ResetColor();
            }
            foreach (var file in parentFolder.Files)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                AddNodeText(file.Name +"."+ file.Format, level + 1);
                Console.ResetColor();
            }
        }
        private void AddNodeText(string text, int level)
        {
            
            string spaces = "";
            string lines = "";
            if (level > 0)
            {
                spaces = new String(' ', (level - 1) * 4);
                lines = "|___";
            }
            Console.Write(spaces + lines + text + Environment.NewLine);
           }

        public void Go4Delete()
        {
            Console.Write("Path:");
            string path = Console.ReadLine();
            try
            {
                var element = rootFolder.GetLastElementFromPath(path);
                element.Delete();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }

        }
        public void Go4GetSize()
        {
            Console.Write("Path:");
            string path = Console.ReadLine();
            try
            {
                var element = rootFolder.GetLastElementFromPath(path);
                Console.WriteLine(element.GetSize());
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
        }

        public void Go4GetRename()
        {
            Console.Write("Path:");
            string path = Console.ReadLine();
            try
            {
                var element = rootFolder.GetLastElementFromPath(path);
                Console.Write("New Name:");
                string newName = Console.ReadLine();
                element.Rename(newName);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
        }
        



    }

}
