using System.Threading;

namespace System.Management.Automation.Runspaces
{
    /// <summary>
    /// Writer to write to pipe.
    /// </summary>
    public abstract class PipelineWriter
    {
        /// <summary>
        /// The number of items in the pipe.
        /// </summary>
        public abstract int Count { get; }

        /// <summary>
        /// Indicates whether the pipe is open.
        /// </summary>
        public abstract bool IsOpen { get; }

        /// <summary>
        /// The max capacity of the pipe.
        /// </summary>
        public abstract int MaxCapacity { get; }

        /// <summary>
        /// Create an instance of PipelineWriter.
        /// </summary>
        protected PipelineWriter()
        { }

        /// <summary>
        /// Write the given object as json string to pipe.
        /// </summary>
        /// <param name="obj">The object to write as json string</param>
        public abstract int Write(object obj);

        /// <summary>
        /// Write the given enumerable object as json strings to pipe.
        /// </summary>
        /// <param name="obj">The object to enumerate and write</param>
        /// <param name="enumerateCollection">Indicates whether to enumerate or not</param>
        /// <returns>The number of objects written</returns>
        public abstract int Write(object obj, bool enumerateCollection);

        /// <summary>
        /// Flushes the pipe.
        /// </summary>
        public abstract void Flush();

        /// <summary>
        /// Closes the write end.
        /// </summary>
        public abstract void Close();
    }
}
