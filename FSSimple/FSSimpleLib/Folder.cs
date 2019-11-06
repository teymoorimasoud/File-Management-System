using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


namespace FSSimpleLib
{
    public class Folder:FileSystemElement
    {
        public Folder Parent{ get; set; }

        private List<FileSystemElement> _Items;
        public List<FileSystemElement> Items
        {
            get { return _Items; }
        }

        public List<File> Files
        {
            get { return Items.FindAll(x => x.GetType() == typeof(File)).ConvertAll(x => (File)x); }
        }

        public List<Folder> Folders
        {
            
            get { return Items.FindAll(x => x.GetType() == typeof(Folder)).ConvertAll(x => (Folder)x); }
        }

        public Folder(string name,string creator):base(name,creator)
        {
            _Items = new List<FileSystemElement>();
        }


        private bool ElementExists(FileSystemElement element)
        {
            return Items.Any(x => x.Name == element.Name);
        }

        public void AddFile(File file)
        {
            if (ElementExists(file))
                throw new Exception("File Has Exists");
            Items.Add(file);
            file.Parent = this;
        }
        public void AddFolder(Folder folder)
        {
            if (ElementExists(folder))
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
            Parent.Remove(this);
        }

        public override decimal GetSize()
        {
            decimal size = 0;

            
            foreach (var item in Items)
            {
                size += item.GetSize();

            }
                    
            return size;
        }

        public Folder GetDirectoryFromPath(string path)
        {
            //""
            if (path == "")
                return this;
            //"reza"
            int speratorIndex = path.IndexOf("\\");
            string parentDirName;
            if (speratorIndex == -1)
                parentDirName = path;
            else
                parentDirName = path.Substring(0, speratorIndex);
            Folder parentDir = Folders.FirstOrDefault(x => x.Name == parentDirName);
            if (parentDir is null)
                throw new Exception(string.Format("There is no {0} Directory in {1}", parentDirName, this.Name));

            string subPath;
            if (speratorIndex == -1)
                subPath = "";
            else
                subPath = path.Substring(speratorIndex + 1 , path.Length - speratorIndex - 1);
            return parentDir.GetDirectoryFromPath(subPath);

        }
    }
}
