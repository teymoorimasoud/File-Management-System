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

        public string Add(string name, string creator)
        {
            var folderHasExist = children.Any(x => x.GetType() == typeof(Folder) && x.Name == name);
            if (folderHasExist)
                return "Folder Has Exist";

                children.Add(new Folder(name, creator));

            return string.Empty;
        }

        public string Add(string name, string creator, string format,decimal size)
        {
            var folderHasExist = children.Any(x => x.GetType() == typeof(File) && x.Name == name );//&& x.format == format
            if (folderHasExist)
                return "File Has Exist";

            children.Add(new File(name,creator,format,size));

            return string.Empty;
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
