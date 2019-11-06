﻿using System;
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

        public string Name { get; private set; }
        private string Creator {get; set; }
        private decimal Size
        {
            get
            {
                return GetSize();
            }
        }

        private DateTime CreateDate { get; set; }
        
        public void Rename(FileSystemElement fileSystemElement, string name)
        {
            fileSystemElement.Name = name;
        }

        public abstract void Delete();       

        public abstract decimal GetSize();
    }
}
  