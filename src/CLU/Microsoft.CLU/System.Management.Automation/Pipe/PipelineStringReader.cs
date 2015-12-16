using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;

namespace System.Management.Automation.Runspaces
{
    /// <summary>
    /// Reader to read from a pipe with string items.
    /// </summary>
    internal class PipelineStringReader : PipelineReader<string>
    {
        /// <summary>
        /// The number of items in the pipe.
        /// </summary>
        public override int Count
        {
            get
            {
                return _pipe.Count;
            }
        }

        /// <summary>
        /// Indicates whether the end of pipe has been reached.
        /// </summary>
        public override bool EndOfPipeline
        {
            get
            {
                return _pipe.EndOfPipeline;
            }
        }

        /// <summary>
        /// Indicates whether the pipe is open.
        /// </summary>
        public override bool IsOpen
        {
            get
            {
                return _pipe.IsOpen;
            }
        }

        /// <summary>
        /// The max capacity of the pipe.
        /// </summary>
        public override int MaxCapacity
        {
            get
            {
                return _pipe.MaxCapacity;
            }
        }

        /// <summary>
        /// Creates an instance of PipelineStringReader
        /// </summary>
        /// <param name="pipe">The pipe</param>
        public PipelineStringReader(IPipe<string> pipe)
        {
            Debug.Assert(pipe != null);
            _pipe = pipe;
        }

        /// <summary>
        /// Read next string from the pipe.
        /// </summary>
        /// <returns>The next string item in the pipe</returns>
        public override string Read()
        {
            return _pipe.Read();
        }

        /// <summary>
        /// Read a sequence of string items from the pipe.
        /// </summary>
        /// <param name="count">The number of items to read</param>
        /// <returns>The collection of string items</returns>
        public override Collection<string> Read(int count)
        {
            return _pipe.Read(count);
        }

        /// <summary>
        /// Read all string items from the pipe.
        /// </summary>
        /// <returns>The collection of string items</returns>
        public override Collection<string> ReadToEnd()
        {
            return _pipe.ReadToEnd();
        }

        /// <summary>
        /// Do non-blocking read.
        /// </summary>
        /// <returns></returns>
        public override Collection<string> NonBlockingRead()
        {
            return _pipe.NonBlockingRead();
        }

        /// <summary>
        /// Do non-blocking read.
        /// </summary>
        /// <param name="maxRequested">The maximum string items to be read</param>
        /// <returns></returns>
        public override Collection<string> NonBlockingRead(int maxRequested)
        {
            return _pipe.NonBlockingRead(maxRequested);
        }

        /// <summary>
        /// Read next string item without consuming it.
        /// </summary>
        /// <returns>The next string item</returns>
        public override string Peek()
        {
            return _pipe.Peek();
        }

        /// <summary>
        /// Closes the read end.
        /// </summary>
        public override void Close()
        {
            _pipe.ReadClose();
        }

        /// <summary>
        /// The pipe.
        /// </summary>
        private IPipe<string> _pipe;
    }
}
