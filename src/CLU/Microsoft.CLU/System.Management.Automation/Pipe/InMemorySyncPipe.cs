using System.Collections.ObjectModel;
using System.IO;

namespace System.Management.Automation.Runspaces
{
    using Strings = Microsoft.CLU.Common.Properties.Strings;

    /// <summary>
    /// Represents a pipe that stores items in memory stream.
    /// </summary>
    internal class InMemorySyncPipe : PipeBase
    {
        /// <summary>
        /// Backing field for the property Reader.
        /// </summary>
        PipelineReader<string> _reader;
        /// <summary>
        /// The pipe reader.
        /// </summary>
        public override PipelineReader<string> Reader
        {
            get
            {
                if (_reader == null)
                {
                    _reader = new PipelineStringReader(this);
                }

                return _reader;
            }
        }

        /// <summary>
        /// Backing field for the property Writer.
        /// </summary>
        PipelineWriter _writer;
        /// <summary>
        /// The pipe writer.
        /// </summary>
        public override PipelineWriter Writer
        {
            get
            {
                if (_writer == null)
                {
                    _writer = new PipelineStringWriter(this);
                }

                return _writer;
            }
        }

        /// <summary>
        /// The maximum capacity of the pipe.
        /// </summary>
        public override int MaxCapacity
        {
            get
            {
                return int.MaxValue;
            }
        }

        /// <summary>
        /// Indicates whether the pipe is open or not.
        /// </summary>
        public override bool IsOpen
        {
            get
            {
                return !_closed;
            }
        }

        /// <summary>
        /// The number of items in the pipe.
        /// </summary>
        public override int Count
        {
            get
            {
                throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Creates an instance of InMemorySyncPipe.
        /// </summary>
        /// <param name="stream">The stream to use</param>
        private InMemorySyncPipe(MemoryStream stream) : base(new StreamReader(stream), new StreamWriter(stream), true)
        {
            _stream = stream;
            SetWritable();
        }

        /// <summary>
        /// Crerates an instance of InMemorySyncPipe.
        /// </summary>
        public InMemorySyncPipe() : this(new MemoryStream())
        {
        }

        /// <summary>
        /// Read next string from the pipe.
        /// </summary>
        /// <returns>The next string item in the pipe</returns>
        public override string Read()
        {
            CheckReable();
            string line = base.Read();
            if (EndOfPipeline)
            {
                SetWritable();
            }

            return line;
        }

        /// <summary>
        /// Read a sequence of string items from the pipe.
        /// </summary>
        /// <param name="count">The number of items to read</param>
        /// <returns>The collection of string items</returns>
        public override Collection<string> Read(int count)
        {
            CheckReable();
            var lines = base.Read(count);
            if (EndOfPipeline)
            {
                SetWritable();
            }

            return lines;
        }

        /// <summary>
        /// Read all string items from the pipe.
        /// </summary>
        /// <returns>The collection of string items</returns>
        public override Collection<string> ReadToEnd()
        {
            CheckReable();
            var lines = base.ReadToEnd();
            if (EndOfPipeline)
            {
                SetWritable();
            }

            return lines;
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

        /// <summary>
        /// Mark the pipe as readable.
        /// </summary>
        public override void SetReadable()
        {
            if (!_closed)
            {
                Flush();
                _canRead = true;
                _canWrite = false;
                _stream.Seek(0, SeekOrigin.Begin);
            }
        }

        /// <summary>
        /// Write the given object as json string to pipe.
        /// </summary>
        /// <param name="obj">The object to write as json string</param>
        public override void Write(object obj)
        {
            CheckWritable();
            base.Write(obj);
        }

        /// <summary>
        /// Write the given enumerable object as json strings to pipe.
        /// </summary>
        /// <param name="obj">The object to enumerate and write</param>
        /// <param name="enumerateCollection">Indicates whether to enumerate or not</param>
        /// <returns>The number of objects written</returns>
        public override int Write(object obj, bool enumerateCollection)
        {
            CheckWritable();
            return base.Write(obj, enumerateCollection);
        }

        /// <summary>
        /// Flushes the pipe.
        /// </summary>
        public override void Flush()
        {
            if (!_closed)
            {
                if (_canWrite)
                {
                    base.Flush();
                }
            }
        }

        /// <summary>
        /// Mark the pipe as writable.
        /// </summary>
        public override void SetWritable()
        {
            _canRead = false;
            _canWrite = true;
            _stream.Seek(0, SeekOrigin.Begin);
        }

        /// <summary>
        /// Close the pipe.
        /// </summary>
        public override void Close()
        {
            if (_stream != null)
            {
                _stream.Dispose();
                _stream = null;
            }

            _closed = true;
        }

        /// <summary>
        /// Closes the read end.
        /// </summary>
        public override void ReadClose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Closes the write end.
        /// </summary>
        public override void WriteClose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks whether the pipe is readable.
        /// </summary>
        private void CheckReable()
        {
            if (_closed)
            {
                throw new InvalidOperationException(Strings.InMemorySyncPipe_CheckReable_PipeClosed);
            }

            if (!_canRead)
            {
                throw new InvalidOperationException(Strings.InMemorySyncPipe_CheckReable_PipeNotReadable);
            }
        }

        /// <summary>
        /// Checks whether the pipe is writable.
        /// </summary>
        private void CheckWritable()
        {
            if (_closed)
            {
                throw new InvalidOperationException(Strings.InMemorySyncPipe_CheckWritable_PipeClosed);
            }

            if (!_canWrite)
            {
                throw new InvalidOperationException(Strings.InMemorySyncPipe_CheckWritable_PipeNotWritable);
            }
        }

        /// <summary>
        /// The stream used by the pipe to store items.
        /// </summary>
        private MemoryStream _stream;

        /// <summary>
        /// Indicates whether read operation can be performed on the pipe.
        /// </summary>
        private bool _canRead;

        /// <summary>
        /// Indicates whether write operation can be performed on the pipe.
        /// </summary>
        private bool _canWrite;

        /// <summary>
        /// Indicates whether the pipe is closed or not.
        /// </summary>
        private bool _closed;
    }
}
