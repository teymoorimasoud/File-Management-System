
namespace FSSimpleLib
{
    public class File : FileSystemElement
    {
        public File(string name, string creator,string format,decimal size) : base(name, creator)
        {
            Format = format;
            Size = size;
        }
        private string Format { get; set; }
        private decimal Size { get; set; }

        public override decimal GetSize()
        {
            return Size;
        }
    }
}
