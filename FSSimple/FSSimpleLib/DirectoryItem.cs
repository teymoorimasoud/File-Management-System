using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSSimpleLib
{
    public abstract class DirectoryItem
    {

        enum DocumentImageIndex
        {
            Folder,
            File
        }

        private string _Name;
        private int _Size { get; set; }
        private string _Format { get; set; }
        public DateTime _CreateDate { get; set; }
        private DirectoryItem _ParentDirectoryItem;
        public string Path { get; set; }

        public DirectoryItem(string name)
        {
            this.Name = name;
            SubDirectoryItems = new List<DirectoryItem>();
        }

        public string Name
        {
            get => _Name;
            set
            {
                if ((value.Trim() == "") ||
                    (value.Contains("//")) ||
                    (value.Contains("\\")) ||
                    (value.Contains(":")) ||
                    (value.Contains("*")) ||
                    (value.Contains("?")) ||
                    (value.Contains(">")) ||
                    (value.Contains("<")) ||
                    (value.Contains("|")) ||
                    (value.Contains("/")))
                    throw new Exception("Directory Name is Invalid!");
                _Name = value;
            }
        }

        public DirectoryItem ParentDirectoryItem
        {
            get => _ParentDirectoryItem;
            set
            {
                _ParentDirectoryItem = value;
                _ParentDirectoryItem.SubDirectoryItems.Add(this);
            }
        }
        public List<DirectoryItem> SubDirectoryItems { get; }


        public virtual DirectoryItem AddF(string folderName, Folder parentFolder)
        {
            return ParentDirectoryItem;
        }
        public virtual void Remove()
        {

        }
        public virtual void Rename()
        {

        }
        public virtual void CalculateSize()
        {

        }

    }
}
