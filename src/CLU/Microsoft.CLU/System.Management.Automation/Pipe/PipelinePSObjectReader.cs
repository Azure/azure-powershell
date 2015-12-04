using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace System.Management.Automation.Runspaces
{
    /// <summary>
    /// An implementation of PipelineReader to abstract read from a PSObject collection.
    /// </summary>
    internal class PipelinePSObjectReader : PipelineReader<PSObject>
    {
        /// <summary>
        /// The numer of items that can be read.
        /// </summary>
        public override int Count
        {
            get
            {
                return _collection.Count;
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
                return true;
            }
        }

        /// <summary>
        /// The max capacity.
        /// </summary>
        public override int MaxCapacity
        {
            get
            {
                return int.MaxValue;
            }
        }

        /// <summary>
        /// Creates an instance of PipelinePSObjectReader.
        /// </summary>
        /// <param name="collection">The collection to use</param>
        public PipelinePSObjectReader(Collection<PSObject> collection)
        {
            Debug.Assert(collection != null);
            _collection = collection;
        }

        /// <summary>
        /// Read next string from the PSObject collection.
        /// </summary>
        /// <returns>The next string item in the PSObject collection</returns>
        public override PSObject Read()
        {
            _endOfPipeline = _collection.Count() == 0;
            if (_endOfPipeline)
            {
                return null;
            }

            var result = _collection[0];
            _collection.RemoveAt(0);
            return result;
        }

        /// <summary>
        /// Read a sequence of string items from the PSObject collection.
        /// </summary>
        /// <param name="count">The number of items to read</param>
        /// <returns>The collection of string items</returns>
        public override Collection<PSObject> Read(int count)
        {
            if (count < 0)
            {
                throw new ArgumentException("count");
            }

            int readCount = Math.Min(count, _collection.Count());
            Collection<PSObject> result = new Collection<PSObject>();
            for (int i = 0; i < readCount; i++)
            {
                result.Add(_collection[i]);
                _collection.RemoveAt(i);
            }

            _endOfPipeline = _collection.Count() == 0;
            return result;
        }

        /// <summary>
        /// Read all string items from the PSObject collection.
        /// </summary>
        /// <returns>The collection of string items</returns>
        public override Collection<PSObject> ReadToEnd()
        {
            return Read(int.MaxValue);
        }

        /// <summary>
        /// Do non-blocking read.
        /// </summary>
        /// <returns></returns>
        public override Collection<PSObject> NonBlockingRead()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Do non-blocking read.
        /// </summary>
        /// <param name="maxRequested">The maximum string items to be read</param>
        /// <returns></returns>
        public override Collection<PSObject> NonBlockingRead(int maxRequested)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Read next string item without consuming it.
        /// </summary>
        /// <returns>The next string item</returns>
        public override PSObject Peek()
        {
            return _collection.FirstOrDefault();
        }

        /// <summary>
        /// Closes the reader.
        /// </summary>
        public override void Close()
        {
            _collection.Clear();
        }

        /// <summary>
        /// The collection to hold PSObject instances.
        /// </summary>
        Collection<PSObject> _collection;
    }
}
