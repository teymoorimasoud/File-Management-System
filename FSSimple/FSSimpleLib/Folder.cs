using System;
using System.Collections.Generic;
using System.Linq;

namespace FSSimpleLib
{
    public class Folder:FileSystemElement
    {

        public List<FileSystemElement> children { get; }

        public void AddFolder(string name, string creator)
        {
            children.Add(new Folder
            {
                CreateDate = DateTime.Now,
                Creator = creator
            });
        }

        public void AddFile(string name, string creator,decimal size, string format)
        {
            children.Add(new File
            {
                CreateDate = DateTime.Now,
                Creator = creator,
                Size = size,
                Frotmat = format
            });
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
