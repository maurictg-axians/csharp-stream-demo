using System;
using System.Collections.Generic;
using System.IO;

namespace CSStreamDemo
{
    public class Block : IBlock
    {
        private List<Stream> Streams { get; set; }

        public Stream Stream { get; private set; }

        public Block()
        {
            Stream = new MemoryStream();
            Streams = new List<Stream>();
        }

        private void WriteToAll(byte[] data)
        {
            foreach (var s in Streams)
                s.Write(data);
        }

        public void Subscribe(Stream outStream)
        {
            Streams.Add(outStream);
        }

        public void Unsubscribe(Stream outStream)
        {
            Streams.Remove(outStream);
        }

        public void Clear()
        {
            var s = (MemoryStream)Stream;
            var buff = s.GetBuffer();
            Array.Clear(buff, 0, buff.Length);
            s.Position = 0;
            s.SetLength(0);
        }

        public byte[] Read()
        {
            return ((MemoryStream) Stream).ToArray();
        }

        public void Write(byte[] data)
        {
            Stream.Write(data);

            WriteToAll(data);
        }
    }
}