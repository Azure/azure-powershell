using System.Collections.ObjectModel;
using System.Threading;

namespace System.Management.Automation.Runspaces
{
    /// <summary>
    /// Reader to read items from a pipe.
    /// </summary>
    public abstract class PipelineReader<T>
    {
        /// <summary>
        /// The number of items in the pipe.
        /// </summary>
        public abstract int Count { get; }

        /// <summary>
        /// Indicates whether the end of pipe has been reached.
        /// </summary>
        public abstract bool EndOfPipeline { get; }

        /// <summary>
        /// Indicates whether the pipe is open.
        /// </summary>
        public abstract bool IsOpen { get; }

        /// <summary>
        /// The max capacity of the pipe.
        /// </summary>
        public abstract int MaxCapacity { get; }

        /// <summary>
        /// Create an instance of PipelineReader.
        /// </summary>
        protected PipelineReader()
        { }

        /// <summary>
        /// Read next string from the pipe.
        /// </summary>
        /// <returns>The next string item in the pipe</returns>
        public abstract T Read();

        /// <summary>
        /// Read a sequence of string items from the pipe.
        /// </summary>
        /// <param name="count">The number of items to read</param>
        /// <returns>The collection of string items</returns>
        public abstract Collection<T> Read(int count);

        /// <summary>
        /// Read all string items from the pipe.
        /// </summary>
        /// <returns>The collection of string items</returns>
        public abstract Collection<T> ReadToEnd();

        /// <summary>
        /// Do non-blocking read.
        /// </summary>
        /// <returns></returns>
        public abstract Collection<T> NonBlockingRead();

        /// <summary>
        /// Do non-blocking read.
        /// </summary>
        /// <param name="maxRequested">The maximum string items to be read</param>
        /// <returns></returns>
        public abstract Collection<T> NonBlockingRead(int maxRequested);

        /// <summary>
        /// Read next string item without consuming it.
        /// </summary>
        /// <returns>The next string item</returns>
        public abstract T Peek();

        /// <summary>
        /// Closes the read end.
        /// </summary>
        public abstract void Close();
    }
}