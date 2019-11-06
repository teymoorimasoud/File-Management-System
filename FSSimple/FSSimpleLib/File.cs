
namespace FSSimpleLib
{
    public class File : FileSystemElement
    {
        public Folder Parent { get; set; }
        public File(string name, string creator,string format,decimal size) : base(name, creator)
        {
            Format = format;
            Size = size;
        } 
        public string Format { get; set; }
        public decimal Size { get; set; }

        public override void Delete()
        {
            Parent.Remove(this);
        }

        public override decimal GetSize()
        {
            return Size;
        }
    }
}
