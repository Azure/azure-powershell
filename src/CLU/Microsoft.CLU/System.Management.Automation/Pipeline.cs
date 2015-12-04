using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace System.Management.Automation.Runspaces
{
    /// <summary>
    /// Represents the base functionality of a pipeline that can be used to invoke commands.
    /// </summary>
    public abstract class Pipeline : IDisposable
    {
        /// <summary>
        /// Gets the collection of commands for the pipeline.
        /// </summary>
        public CommandCollection Commands { get; private set; }

        /// <summary>
        /// Gets a value that indicates whether there were errors in the execution of the pipeline.
        /// </summary>
        public virtual bool HadErrors { get; }

        /// <summary>
        /// Gets the input writer for the pipeline.
        /// </summary>
        public abstract PipelineWriter Input { get; }

        /// <summary>
        /// Gets the identifier for this instance of the pipeline.
        /// </summary>
        public long InstanceId { get; }

        /// <summary>
        /// Gets a Boolean value that indicates whether the pipeline is a nested pipeline.
        /// </summary>
        public abstract bool IsNested { get; }

        /// <summary>
        /// Gets the output reader for the pipeline.
        /// </summary>
        public abstract PipelineReader<PSObject> Output { get; }

        /// <summary>
        /// Gets information about the current state of the pipeline.
        /// </summary>
        public abstract PipelineStateInfo PipelineStateInfo { get; }

        /// <summary>
        /// Gets the runspace of the pipeline.
        /// </summary>
        public abstract Runspace Runspace { get; }

        /// <summary>
        /// The collection of streams where each stream belongs to a command in the pipeline.
        /// </summary>
        internal abstract IEnumerable<PSDataStreams> Streams { get; }

        /// <summary>
        /// Creates a new pipeline with the given set of commands.
        /// </summary>
        /// <param name="commands"></param>
        public Pipeline(CommandCollection commands)
        {
            Commands = commands;
        }

        /// <summary>
        /// Creates a new pipeline.
        /// </summary>
        public Pipeline() : this(new CommandCollection())
        {}

        /// <summary>
        /// Invokes the pipeline synchronously.
        /// </summary>
        /// <returns>An array of objects that contain the output of the pipeline.
        /// If the pipeline has no output, an empty collection is returned</returns>
        public Collection<PSObject> Invoke()
        {
            return this.Invoke(new Collections.Generic.List<object>());
        }

        /// <summary>
        /// Invokes the pipeline synchronously.
        /// </summary>
        /// <param name="input">An array of input objects to pass to the pipeline. The array can be empty, but cannot be null.</param>
        /// <returns>An array of objects that contain the output of the pipeline.
        /// If the pipeline has no output, an empty collection is returned</returns>
        public abstract Collection<PSObject> Invoke(IEnumerable input);

        public void Dispose()
        {}

        protected virtual void Dispose(bool disposing)
        {}
    }
}