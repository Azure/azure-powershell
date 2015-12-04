using System.Collections.ObjectModel;

namespace System.Management.Automation.Runspaces
{
    /// <summary>
    /// Represents a contract that pipe needs to implement.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IPipe<T>
    {
        /// <summary>
        /// The pipeline reader.
        /// </summary>
        PipelineReader<string> Reader { get; }

        /// <summary>
        /// The pipeline writer.
        /// </summary>
        PipelineWriter Writer { get; }

        /// <summary>
        /// Indicates whether the end of pipeline has reached.
        /// </summary>
        bool EndOfPipeline { get; }

        /// <summary>
        /// The maximum capacity of the pipe.
        /// </summary>
        int MaxCapacity { get; }

        /// <summary>
        /// Indicates whether the pipe is open.
        /// </summary>
        bool IsOpen { get; }

        /// <summary>
        /// Number of elements in the pipe.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Reads a item from the pipeline.
        /// </summary>
        /// <returns>The next item from the pipeline, or null if all items have been read.</returns>
        T Read();

        /// <summary>
        ///  reads a sequence of items from the pipeline.
        /// </summary>
        /// <param name="count">The number of items to read</param>
        /// <returns></returns>
        Collection<T> Read(int count);

        /// <summary>
        /// Reads all items from the current position to the end of the
        /// pipeline and returns them as collection.
        /// </summary>
        /// <returns>A collection that contains all items from the current position to the end of the pieline</returns>
        Collection<T> ReadToEnd();

        /// <summary>
        /// Read next item without blocking.
        /// </summary>
        /// <returns>The next item from the pipeline, or null if all items have been read</returns>
        Collection<T> NonBlockingRead();

        /// <summary>
        /// reads a sequence of items from the pipeline without blocking.
        /// </summary>
        /// <param name="maxRequested">The max number of items to read</param>
        /// <returns></returns>
        Collection<T> NonBlockingRead(int maxRequested);

        /// <summary>
        /// Writes a single object to the output pipeline.
        /// </summary>
        /// <param name="obj">The object to be sent to the pipeline</param>
        void Write(object obj);

        /// <summary>
        /// Writes an object to the pipeline that can be enumerated by CLU.
        /// </summary>
        /// <param name="obj">The object to be sent to the pipeline</param>
        /// <param name="enumerateCollection">True indicates that enumerate the object one level. The default is False</param>
        /// <returns>The number of items written</returns>
        int Write(object obj, bool enumerateCollection);

        /// <summary>
        /// Flush the pipe.
        /// </summary>
        void Flush();

        /// <summary>
        /// Mark the pipe as readabe.
        /// </summary>
        void SetReadable();

        /// <summary>
        /// Mark the pipe as writable.
        /// </summary>
        void SetWritable();

        /// <summary>
        /// Returns the next available item from the pipeline but does not consume it.
        /// </summary>
        /// <returns>The next available item</returns>
        T Peek();

        /// <summary>
        /// Close the pipe.
        /// </summary>
        void Close();

        /// <summary>
        /// Close the read end.
        /// </summary>
        void ReadClose();

        /// <summary>
        /// Close the write end.
        /// </summary>
        void WriteClose();
    }
}
