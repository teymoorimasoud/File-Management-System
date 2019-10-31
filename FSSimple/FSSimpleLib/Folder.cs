using System;
using System.Collections.Generic;
//using System.Windows.Forms;

namespace FSSimpleLib
{
    public class Folder
    {
        //private string _Name;
        private Folder _ParentFolder;
        enum DocumentImageIndex
        {
            Folder,
            File
        }
        public Folder(string name)

        {
            // this.Name = name;
            SubFolders = new List<Folder>();
            Files = new List<File>();

        }
       
        public string Path { get; set; }
        public string Name { get; set; }
        

        public Folder ParentFolder
        {
            get => _ParentFolder;
            set
            {
                _ParentFolder = value;
                _ParentFolder.SubFolders.Add(this);
            }
        }

        public List<Folder> SubFolders { get; }
        public List<File> Files { get; }
        //private Folder Add(string folderName, Folder parentFolder, TreeNodeCollection parentNode)
        //{
        //    Folder F = new Folder(folderName);
        //    F.ParentFolder = parentFolder;

        //    var node = parentNode.Add(folderName);
        //    node.ImageIndex = (int)DocumentImageIndex.Folder;
        //    node.SelectedImageIndex = node.ImageIndex;
        //    node.Tag = F;

        //    return F;
        //}

        public Folder Add(string folderName, Folder parentFolder)
        {
            Folder F = new Folder(folderName);
            F.ParentFolder = parentFolder;

            return parentFolder;
        }

    }
}
