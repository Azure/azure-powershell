using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace System.Management.Automation.Runspaces
{
    /// <summary>
    /// An implementation of PipelineReader to abstract read from a file.
    /// </summary>
    internal class PipelineFileReader : PipelineReader<string>, IDisposable
    {
        public PipelineFileReader(string filePath)
        {
            Debug.Assert(!string.IsNullOrEmpty(filePath));
            _streamReader = System.IO.File.OpenText(filePath);
        }

        /// <summary>
        /// The numer of items that can be read.
        /// </summary>
        public override int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Backing field for the property EndOfPipeline.
        /// </summary>
        private bool _endOfPipeline;
        /// <summary>
        /// Indicates whether the end of pipeline has reached.
        /// </summary>
        public override bool EndOfPipeline
        {
            get
            {
                return _endOfPipeline;
            }
        }

        /// <summary>
        /// Indicates whether read can be performed from the file.
        /// </summary>
        public override bool IsOpen
        {
            get
            {
                return _streamReader != null;
            }
        }

        /// <summary>
        /// The max capacity.
        /// </summary>
        public override int MaxCapacity
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Read next string from the file.
        /// </summary>
        /// <returns>The next string item in the file</returns>
        public override string Read()
        {
            string line = _streamReader.ReadLine();
            _endOfPipeline = line == null;
            return line;
        }

        /// <summary>
        /// Read a sequence of string items from the file.
        /// </summary>
        /// <param name="count">The number of items to read</param>
        /// <returns>The collection of string items</returns>
        public override Collection<string> Read(int count)
        {
            if (count == 0)
            {
                return new Collection<string>();
            }

            Collection<string> lines = new Collection<string>();
            string line = null;
            while (count-- >= 0 && (line = _streamReader.ReadLine()) != null)
            {
                lines.Add(line);
            }

            _endOfPipeline = line == null;
            return lines;
        }

        /// <summary>
        /// Read all string items from the file.
        /// </summary>
        /// <returns>The collection of string items</returns>
        public override Collection<string> ReadToEnd()
        {
            return Read(int.MaxValue);
        }

        /// <summary>
        /// Do non-blocking read.
        /// </summary>
        /// <returns></returns>
        public override Collection<string> NonBlockingRead()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Do non-blocking read.
        /// </summary>
        /// <param name="maxRequested">The maximum string items to be read</param>
        /// <returns></returns>
        public override Collection<string> NonBlockingRead(int maxRequested)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Read next string item without consuming it.
        /// </summary>
        /// <returns>The next string item</returns>
        public override string Peek()
        {
            throw new NotSupportedException();
        }

        public override void Close()
        {
            Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    if (_streamReader != null)
                    {
                        _streamReader.Dispose();
                        _streamReader = null;
                    }
                }

                this._disposed = true;
            }
        }

        ~PipelineFileReader()
        {
            Dispose(false);
        }

        #region Private fields

        private bool _disposed = false;
        private StreamReader _streamReader;

        #endregion
    }
}
