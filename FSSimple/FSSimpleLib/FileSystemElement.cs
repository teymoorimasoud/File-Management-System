using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSSimpleLib
{
    public abstract class FileSystemElement
    {
        public string Name { get; set; }
        public string Creator { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }

        public void Rename(FileSystemElement fileSystemElement, string name)
        {
            fileSystemElement.Name = name;
        }

        public void delete()
        {
            IsDeleted = true;
        }

        public abstract decimal GetSize();
        

    }
}
