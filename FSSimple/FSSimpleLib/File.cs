 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSSimpleLib
{
    public class File : DirectoryItem
    {
       
        private Folder _ParentFolder;
      
        public new string Path { get; set; }
        public Folder ParentFolder
            {
                get => _ParentFolder;
                set
                {
                    _ParentFolder = value;
                    _ParentFolder.Files.Add(this);
                }
            }

        public File(string name): base(name) 
        {
            this.Name = name;

        }
    }
}
