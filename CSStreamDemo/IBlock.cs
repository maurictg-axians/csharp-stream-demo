using System.IO;

namespace CSStreamDemo
{
    public interface IBlock
    {
        public Stream Stream { get; }
        
        public void Subscribe(Stream outStream);
        public void Unsubscribe(Stream outStream);
        public void Clear();
        public byte[] Read();
        public void Write(byte[] data);
    }
}