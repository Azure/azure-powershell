using System.Diagnostics;
using System.Threading;

namespace System.Management.Automation.Runspaces
{
    /// <summary>
    /// Writer to write to pipe with string items.
    /// </summary>
    internal class PipelineStringWriter : PipelineWriter
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
        /// Creates an instance of PipelineStringWriter
        /// </summary>
        /// <param name="pipe">The pipe</param>
        public PipelineStringWriter(IPipe<string> pipe)
        {
            Debug.Assert(pipe != null);
            _pipe = pipe;
        }

        /// <summary>
        /// Write the given object as json string to pipe.
        /// </summary>
        /// <param name="obj">The object to write as json string</param>
        public override int Write(object obj)
        {
            _pipe.Write(obj);
            return 1;
        }

        /// <summary>
        /// Write the given enumerable object as json strings to pipe.
        /// </summary>
        /// <param name="obj">The object to enumerate and write</param>
        /// <param name="enumerateCollection">Indicates whether to enumerate or not</param>
        /// <returns>The number of objects written</returns>
        public override int Write(object obj, bool enumerateCollection)
        {
            return _pipe.Write(obj, enumerateCollection);
        }

        /// <summary>
        /// Flushes the pipe.
        /// </summary>
        public override void Flush()
        {
            _pipe.Flush();
        }

        /// <summary>
        /// Closes the write end.
        /// </summary>
        public override void Close()
        {
            _pipe.WriteClose();
        }

        /// <summary>
        /// The pipe.
        /// </summary>
        private IPipe<string> _pipe;
    }
}
