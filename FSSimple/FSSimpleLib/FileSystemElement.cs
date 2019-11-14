using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSSimpleLib
{
    public abstract class FileSystemElement
    {
       

        public FileSystemElement(string name,string creator)
        {
            Name = name;
            Creator = creator;
            CreateDate = DateTime.Now;
        }

        private string _Name;
        private string Creator {get; set; }
        private decimal Size
        {
            get
            {
                return GetSize();
            }
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
                    throw new Exception("Folder or File Name is Invalid!");
                _Name = value;
            }
        }

        private DateTime CreateDate { get; set; }
        
        public void Rename(string name)
        {
            Name = name;
        }
        

        public abstract void Delete();       

        public abstract decimal GetSize();
    }
}
  
