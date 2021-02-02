using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Assignment4
{
    public class SetWriter : IDisposable
    {
        private bool _DisposedValue = false;
        private StreamWriter streamWriter;

        public SetWriter(string filePath)
        {
            streamWriter = new(filePath);
        }

        public void WriteSetToFile(NumSet numSet)
        {
            if (numSet is null) throw new ArgumentNullException(numSet + " is null in WriteSetToFile");

            this.streamWriter.WriteLine(numSet.ToString());
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_DisposedValue)
            {
                if (disposing)
                {
                    streamWriter.Dispose();
                }

                _DisposedValue = true;
            }
        }
    }
}
