using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


namespace FSSimpleLib
{
    public class Folder : FileSystemElement
    {
        public Folder Parent { get; set; }

        private List<FileSystemElement> Items { get; set; }

        public List<File> Files
        {
            get { return Items.FindAll(x => x.GetType() == typeof(File)).ConvertAll(x => (File)x); }
        }

        public List<Folder> Folders
        {
            get { return Items.FindAll(x => x.GetType() == typeof(Folder)).ConvertAll(x => (Folder)x); }
        }

        public Folder(string name, string creator) : base(name, creator)
        {
            Items = new List<FileSystemElement>();
        }

        public void AddFile(File file)
        {
            if (Items.Any(x => x.GetType() == typeof(File) && x.Name == file.Name))
                throw new Exception("File Has Exists");

            Items.Add(file);
            file.Parent = this;
        }
        public void AddFolder(Folder folder)
        {
            if (Items.Any(x => x.GetType() == typeof(Folder) && x.Name == folder.Name))
                throw new Exception("Folder Has Exists");

            Items.Add(folder);
            folder.Parent = this;
        }
        public void Remove(FileSystemElement fileSystemElement)
        {
            Items.Remove(fileSystemElement);
        }


        public override void Delete()
        {
            if (Parent != null)
                Parent.Remove(this);
        }

        public override decimal GetSize()
        {
            decimal size = 0;


            foreach (var item in Items)
                size += item.GetSize();

            return size;
        }

        public FileSystemElement GetLastElementFromPath(string path)
        {
            if (path == "")
                return this;

            int speratorIndex = path.IndexOf("\\");
            string lastElement;
            if (speratorIndex == -1)
                lastElement = path;
            else
                lastElement = path.Substring(0, speratorIndex);

            if (lastElement.IndexOf('.') == -1)

            {
                Folder parentDir = Folders.FirstOrDefault(x => x.Name == lastElement);
                if (parentDir is null)
                    throw new Exception(string.Format("There is no {0} Directory in {1}", lastElement, this.Name));
                string subPath;
                if (speratorIndex == -1)
                    subPath = "";
                else
                    subPath = path.Substring(speratorIndex + 1, path.Length - speratorIndex - 1);
                return parentDir.GetLastElementFromPath(subPath);
            }
            else
            {
                var fileArry = path.Split('.');
                var file = Files.FirstOrDefault(x => x.Name == fileArry[0] && x.Format == fileArry[1]);

                if (file is null)
                    throw new Exception(string.Format("There is no {0} Directory in {1}", lastElement, this.Name));

                return file;
            }
        }
    }
}
