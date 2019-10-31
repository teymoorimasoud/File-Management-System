using System;
using System.Collections.Generic;
using System.Linq;

namespace FSSimpleLib
{
    public class Folder:FileSystemElement
    {
        public Folder(string name,string creator):base(name,creator)
        {
        }

        private List<FileSystemElement> children { get; set; }

        public void Add(string name, string creator)
        {
            children.Add(new Folder(name, creator));
        }

        public void Add(string name, string creator, string format,decimal size)
        {
            children.Add(new File(name,creator,format,size));
        }

        public override decimal GetSize()
        {
            decimal size = 0;

            foreach (var subFolder in children.Where(x=>!x.IsDeleted))
                size += subFolder.GetSize();
          
            return size;
        }
    }
}
