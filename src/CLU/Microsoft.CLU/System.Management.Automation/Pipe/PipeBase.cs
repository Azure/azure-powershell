using Microsoft.CLU;
using Microsoft.CLU.Common.Properties;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;

namespace System.Management.Automation.Runspaces
{
    /// <summary>
    /// The base type representing a pipe that can hold string items.
    /// </summary>
    internal abstract class PipeBase : IPipe<string>
    {
        /// <summary>
        /// The pipe reader.
        /// </summary>
        public abstract PipelineReader<string> Reader { get; }

        /// <summary>
        /// The pipe writer.
        /// </summary>
        public abstract PipelineWriter Writer { get; }

        /// <summary>
        /// The maximum capacity of the pipe.
        /// </summary>
        public abstract int MaxCapacity { get; }

        /// <summary>
        /// Indicates whether the pipe is open or not.
        /// </summary>
        public abstract bool IsOpen { get; }

        /// <summary>
        /// The number of items in the pipe.
        /// </summary>
        public abstract int Count { get; }

        /// <summary>
        /// Backing field for the property EndOfPipeline.
        /// </summary>
        private bool _endOfPipeline;
        /// <summary>
        /// Indicates whether the end of pipe has been reached.
        /// </summary>
        public bool EndOfPipeline
        {
            get
            {
                return _endOfPipeline;
            }
        }

        /// <summary>
        /// Creates an instance of PipeBase. 
        /// </summary>
        /// <param name="reader">The reader for the pipe.</param>
        /// <param name="writer">The writer for the pipe</param>
        /// <param name="outputRedirected">Indicates whether the output has been redirected</param>
        public PipeBase(TextReader reader, TextWriter writer, bool outputRedirected)
        {
            Debug.Assert(reader != null);
            Debug.Assert(writer != null);
            _reader = reader;
            _writer = writer;
            _outputRedirected = outputRedirected;
        }

        /// <summary>
        /// Read next string from the pipe.
        /// </summary>
        /// <returns>The next string item in the pipe</returns>
        public virtual string Read()
        {
            string line = _reader.ReadLine();
            _endOfPipeline = line == null;
            return line;
        }

        /// <summary>
        /// Read a sequence of string items from the pipe.
        /// </summary>
        /// <param name="count">The number of items to read</param>
        /// <returns>The collection of string items</returns>
        public virtual Collection<string> Read(int count)
        {
            if (count < 0)
            {
                throw new ArgumentException(Strings.PipeBase_Read_ArgumentMustBePositive, "count");
            }

            if (count == 0)
            {
                return new Collection<string>();
            }

            Collection<string> lines = new Collection<string>();
            string line = null;
            while (count-- >= 0 && (line = _reader.ReadLine()) != null)
            {
                lines.Add(line);
            }

            _endOfPipeline = line == null;
            return lines;
        }

        /// <summary>
        /// Read all string items from the pipe.
        /// </summary>
        /// <returns>The collection of string items</returns>
        public virtual Collection<string> ReadToEnd()
        {
            return Read(int.MaxValue);
        }

        /// <summary>
        /// Do non-blocking read.
        /// </summary>
        /// <returns></returns>
        public abstract Collection<string> NonBlockingRead();

        /// <summary>
        /// Do non-blocking read.
        /// </summary>
        /// <param name="maxRequested">The maximum string items to be read</param>
        /// <returns></returns>
        public abstract Collection<string> NonBlockingRead(int maxRequested);

        /// <summary>
        /// Read next string item without consuming it.
        /// </summary>
        /// <returns>The next string item</returns>
        public abstract string Peek();

        /// <summary>
        /// Mark the pipe as readable.
        /// </summary>
        public abstract void SetReadable();

        /// <summary>
        /// Write the given object as json string to pipe.
        /// </summary>
        /// <param name="obj">The object to write as json string</param>
        public virtual void Write(object obj)
        {
            PrimitiveTypeCode code = PrimitiveTypeCode.None;

            if (obj.GetType().IsPrimitive(out code) && code != PrimitiveTypeCode.JSON)
            {
                _writer.WriteLine(obj.ToString());
            }
            else
            {
                var line = JsonConvert.SerializeObject(
                    obj,
                    _outputRedirected ? Formatting.None : Formatting.Indented,
                    new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                _writer.WriteLine(line);
            }
        }

        /// <summary>
        /// Write the given enumerable object as json strings to pipe.
        /// </summary>
        /// <param name="obj">The object to enumerate and write</param>
        /// <param name="enumerateCollection">Indicates whether to enumerate or not</param>
        /// <returns>The number of objects written</returns>
        public virtual int Write(object obj, bool enumerateCollection)
        {
            int written = 0;
            if (!enumerateCollection || !(obj is IEnumerable))
            {
                Write(obj);
                written = 1;
            }
            else
            {
                foreach (var o in obj as IEnumerable)
                {
                    Write(o);
                    written++;
                }
            }

            return written;
        }

        /// <summary>
        /// Flushes the pipe.
        /// </summary>
        public virtual void Flush()
        {
            _writer.Flush();
        }

        /// <summary>
        /// Mark the pipe as writable.
        /// </summary>
        public abstract void SetWritable();

        /// <summary>
        /// Close the pipe.
        /// </summary>
        public abstract void Close();

        /// <summary>
        /// Closes the read end.
        /// </summary>
        public abstract void ReadClose();

        /// <summary>
        /// Closes the write end.
        /// </summary>
        public abstract void WriteClose();

        /// <summary>
        /// The text reader that this type wraps.
        /// </summary>
        private TextReader _reader;

        /// <summary>
        /// The text writer that this type wraps.
        /// </summary>
        private TextWriter _writer;

        /// <summary>
        /// Indicates whether the output is redirected or not.
        /// </summary>
        private bool _outputRedirected;
    }
}
