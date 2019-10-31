
namespace FSSimpleLib
{
    public class File : FileSystemElement
    {
        public string Frotmat { get; set; }
        public decimal Size { get; set; }

        public override decimal GetSize()
        {
            return size;
        }
    }
}
