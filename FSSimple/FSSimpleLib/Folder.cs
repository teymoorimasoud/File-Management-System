using System;
using System.Collections.Generic;
using System.Linq;

namespace FSSimpleLib
{
    public class Folder:FileSystemElement
    {

        public List<Folder> SubFolders { get; }
        public List<File> Files { get; }

        public void AddFolder(string name, string creator)
        {
            SubFolders.Add(new Folder
            {
                CreateDate = DateTime.Now,
                Creator = creator
            });
        }

        public void AddFile(string name, string creator,decimal size, string format)
        {
            Files.Add(new File
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
            foreach (var subFolder in SubFolders.Where(x=>!x.IsDeleted))
            {
                size += subFolder.GetSize();
            }
            foreach (var file in Files.Where(x=>!x.IsDeleted))
            {
                size += file.GetSize();
            }
            return size;
        }
    }
}
