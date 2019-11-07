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
            Console.Write("Folder Name:");
            string folderName = Console.ReadLine();
            Console.Write("Creator :");
            string creator = Console.ReadLine();
            Console.Write("Parent Directory:");
            string path = Console.ReadLine();


            Folder folder = new Folder(folderName, creator);
            Folder parentFolder = rootFolder.GetDirectoryFromPath(path);
            try
            {
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
            Console.Write("File Name:");
            string fileName = Console.ReadLine();
            Console.Write("Creator :");
            string creator = Console.ReadLine();
            Console.Write("Format :");
            string format = Console.ReadLine();
            Console.Write("Size :");
            decimal size = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Parent Directory:");
            string path = Console.ReadLine();


            File file = new File(fileName, creator, format, size);
            Folder parentFolder = rootFolder.GetDirectoryFromPath(path);
         

            try
            {
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
            Folder parentFolder = rootFolder.GetDirectoryFromPath(path);
            parentFolder.Delete();

        }
        public void Go4GetSize()
        {
            Console.Write("Path:");
            string path = Console.ReadLine();
            Folder parentFolder = rootFolder.GetDirectoryFromPath(path);
            Console.WriteLine(parentFolder.GetSize());
        }

        public void Go4GetRename()
        {
            Console.Write("Path:");
            string path = Console.ReadLine();
            Folder parentFolder = rootFolder.GetDirectoryFromPath(path);
            Console.Write("New Name:");
            string newName = Console.ReadLine();
            parentFolder.Rename(parentFolder,newName);
        }
        //public void Sync()
        //{
        //    SyncDocument(rootFolder, Folder.BasePath);
        //    SyncDocument(rootFolder, "//");

        //}
        //public void SyncDocument(Folder folder, string currentPath)
        //{
        //    Directory.CreateDirectory(currentPath + "\\" + folder.Name);

        //    foreach (var f in fileSystemElement.SubElement)
        //    {
        //        SyncDocument(f, currentPath + "\\" + folder.Name);
        //    }

        //    foreach (var f in folder.)
        //    {
        //        System.IO.File.Create(currentPath + "\\" + folder.Name + "\\" + f.Name);
        //    }
        //}



    }

}
