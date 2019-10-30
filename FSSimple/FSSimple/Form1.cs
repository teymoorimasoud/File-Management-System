using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FSSimpleLib;

namespace FSSimple
{
    public partial class Form1 : Form
    {
        enum DocumentImageIndex
        {
            Folder,
            File
        }
         Folder newFolder = new Folder("a");

        private Folder rootFolder = new Folder("root");

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            var parentNode = tvDocs.SelectedNode == null ? tvDocs.Nodes : tvDocs.SelectedNode.Nodes;
            var parentFolder = (Folder) tvDocs.SelectedNode?.Tag ?? rootFolder;
            newFolder.Add(txtDocName.Text, parentFolder);
        } 

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            var parentNode = tvDocs.SelectedNode == null ? tvDocs.Nodes : tvDocs.SelectedNode.Nodes;
            var parentFolder = (Folder) tvDocs.SelectedNode?.Tag ?? rootFolder;
            AddFile(txtDocName.Text, parentFolder, parentNode);
        }

        private Folder Add(string folderName, Folder parentFolder, TreeNodeCollection parentNode)
        {
            Folder F = new Folder(folderName);
            F.ParentFolder = parentFolder;

            var node = parentNode.Add(folderName);
            node.ImageIndex = (int) DocumentImageIndex.Folder;
            node.SelectedImageIndex = node.ImageIndex;
            node.Tag = F;

            return F;
        }

        private File AddFile(string fileName, Folder parentFolder, TreeNodeCollection parentNode)
        {
            File F = new File(fileName);
            F.ParentFolder = parentFolder;

            var node = parentNode.Add(fileName);
            node.ImageIndex = (int) DocumentImageIndex.File;
            node.SelectedImageIndex = node.ImageIndex;
            node.Tag = F;

            return F;
        }

        private void tvDocs_AfterSelect(object sender, TreeViewEventArgs e)
        {
            btnAddFolder.Enabled = btnAddFile.Enabled = (tvDocs.SelectedNode.Tag is Folder);
            if (tvDocs.SelectedNode.Tag is Folder)
            {
                txtTitle.Text = ((Folder) tvDocs.SelectedNode.Tag).Name;
                txtParent.Text = ((Folder) tvDocs.SelectedNode.Tag).ParentFolder?.Name;
            }
            else
            {
                txtTitle.Text = ((File) tvDocs.SelectedNode.Tag).Name;
                txtParent.Text = ((File) tvDocs.SelectedNode.Tag).ParentFolder?.Name;

            }
        }

        private void btnTraverse_Click(object sender, EventArgs e)
        {
            TraverseFolder(rootFolder, tvResult.Nodes);
            TraverseFolderText(rootFolder, 0);

        }



        private void TraverseFolder(Folder folder, TreeNodeCollection parentNode)
        {
            MessageBox.Show("Folder: " + folder.Name);
            var node = AddNode(folder.Name, parentNode, DocumentImageIndex.Folder);

            foreach (var f in folder.Files)
            {
                MessageBox.Show("File: " + f.Name);
                AddNode(f.Name, node.Nodes, DocumentImageIndex.File);
            }
            foreach (var f in folder.SubFolders)
            {
                TraverseFolder(f, node.Nodes);
            }
        }
        private TreeNode AddNode(string text, TreeNodeCollection parentNode, DocumentImageIndex imageIndex)
        {
            var node = parentNode.Add(text);
            node.ImageIndex = (int)imageIndex;
            node.SelectedImageIndex = node.ImageIndex;
            return node;
        }


        private void TraverseFolderText(Folder folder, int level)
        {
            AddNodeText(folder.Name, level, DocumentImageIndex.Folder);

            foreach (var f in folder.Files)
            {
                AddNodeText(f.Name, level + 1, DocumentImageIndex.File);
            }
            foreach (var f in folder.SubFolders)
            {
                TraverseFolderText(f, level+1);
            }
        }

        private void AddNodeText(string text, int level, DocumentImageIndex ImageIndex)
        {
            //txtResult.AppendText("|" + new String('-', level * 3) + text + Environment.NewLine);
            string spaces = "";
            string lines = "";
            if (level > 0)
            {
                spaces = new String(' ', (level - 1) * 4);
                lines = "|___";
            }
            txtResult.AppendText(spaces + lines + text + Environment.NewLine);
        }
     }
}
