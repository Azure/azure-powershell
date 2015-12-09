using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace System.Management.Automation.Runspaces
{
    using Strings = Microsoft.CLU.Common.Properties.Strings;

    /// <summary>
    /// Represents the functionality of a pipeline that can be used to invoke CLU commands.
    /// </summary>
    internal class CLUSyncPipeline : Pipeline
    {
        /// <summary>
        /// Backing field for the property HadErrors.
        /// </summary>
        private bool _hadErrors;
        /// <summary>
        /// Gets a value that indicates whether there were errors in the execution of the pipeline.
        /// </summary>
        public override bool HadErrors
        {
            get
            {
                return _hadErrors;
            }
        }

        /// <summary>
        /// Backing field for the property Streams.
        /// </summary>
        private IList<PSDataStreams> _streams;
        /// <summary>
        /// The collection of streams where each stream belongs to a command in the pipeline.
        /// </summary>
        internal override IEnumerable<PSDataStreams> Streams
        {
            get
            {
                if (_streams == null)
                {
                    throw new InvalidOperationException(Strings.CLUSyncPipeline_Streams_StreamsNotAvailable);
                }

                return _streams;
            }
        }

        /// <summary>
        /// Backing field for the property Input.
        /// </summary>
        private InMemorySyncPipe _pipeIn;
        /// <summary>
        /// Gets the input writer for the pipeline.
        /// </summary>
        public override PipelineWriter Input
        {
            get
            {
                if (_pipeIn == null)
                {
                    _pipeIn = new InMemorySyncPipe();
                }

                return _pipeIn.Writer;
            }
        }

        /// <summary>
        /// Gets a Boolean value that indicates whether the pipeline is a nested pipeline.
        /// </summary>
        public override bool IsNested
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Backing field for the property Output.
        /// </summary>
        private PipelinePSObjectReader _pipeOutReader;
        /// <summary>
        ///  Gets the output reader for the pipeline.
        /// </summary>
        public override PipelineReader<PSObject> Output
        {
            get
            {
                if (_pipeOutReader == null)
                {
                    throw new InvalidOperationException(Strings.CLUSyncPipeline_Output_OutputNotAvailable);
                }

                return _pipeOutReader;
            }
        }

        /// <summary>
        /// Backing field for the property PipelineStateInfo.
        /// </summary>
        private PipelineStateInfo _pipelineState = new PipelineStateInfo();
        /// <summary>
        /// Gets information about the current state of the pipeline.
        /// </summary>
        public override PipelineStateInfo PipelineStateInfo
        {
            get
            {
                return _pipelineState;
            }
        }

        /// <summary>
        /// Backing field for the property Runspace.
        /// </summary>
        private Runspace _runSpace;
        /// <summary>
        /// Gets the runspace of the pipeline.
        /// </summary>
        public override Runspace Runspace
        {
            get
            {
                return _runSpace;
            }
        }

        /// <summary>
        /// Creates an instance of CLUSyncPipeline.
        /// </summary>
        /// <param name="runSpace">The runspace to use</param>
        public CLUSyncPipeline(Runspace runSpace) : this (runSpace, new CommandCollection())
        {}

        /// <summary>
        /// Creates an instance of CLUSyncPipeline.
        /// </summary>
        /// <param name="runSpace">The runspace to use</param>
        /// <param name="commands">The commands to run in the runspace</param>
        public CLUSyncPipeline(Runspace runSpace, CommandCollection commands): base(commands)
        {
            Debug.Assert(runSpace != null);
            Debug.Assert(commands != null);
            _runSpace = runSpace;
            _sessionState = runSpace.InitialSessionState;
        }

        /// <summary>
        /// Invokes the pipeline synchronously.
        /// </summary>
        /// <param name="input">An array of input objects to pass to the pipeline. The array can be empty, but cannot be null.</param>
        /// <returns>An array of objects that contain the output of the pipeline.
        /// If the pipeline has no output, an empty collection is returned</returns>
        public override Collection<PSObject> Invoke(IEnumerable input)
        {
            Debug.Assert(input != null);
            _pipelineState.Set(PipelineState.NotStarted);
            int count = base.Commands.Count;
            if (count == 0)
            {
                return new Collection<PSObject>();
            }

            foreach (var obj in input)
            {
                Input.Write(obj);
            }

            _cmdletRunners = new CmdletRunner[count];
            if (_pipeIn != null)
            {
                // Consumer accessed 'Input' property there is possibly some data.
                _pipeIn.SetReadable();
            }

            int idx = 0;
            var command = base.Commands[0];
            if (_pipeIn == null)
            {
                _cmdletRunners[idx] = new CmdletRunner(command, _sessionState);
            }
            else
            {
                _cmdletRunners[idx] = new CmdletRunner(command, _sessionState, _pipeIn);
            }

            _pipelineState.Set(PipelineState.Running);
            try
            {
                foreach (Command currentCommand in base.Commands.Skip(1))
                {
                    _cmdletRunners[idx].Invoke();
                    idx++;
                    _cmdletRunners[idx] = new CmdletRunner(currentCommand, _sessionState, _cmdletRunners[idx - 1]);
                }

                _cmdletRunners[idx].Invoke();
            }
            catch (Exception exception)
            {
                return InvokeCompleted(idx, exception);
            }

            return InvokeCompleted(idx, null);
        }

        /// <summary>
        /// Handler for invoke completion.
        /// </summary>
        /// <param name="last">The index of last command executed in the pipeline</param>
        /// <param name="exception">Any exception during the execution of last command</param>
        /// <returns></returns>
        private Collection<PSObject> InvokeCompleted(int last, Exception exception)
        {
            Collection<PSObject> psObjects = new Collection<PSObject>();
            Collection<PSObject> psObjects2 = new Collection<PSObject>();
            if (exception != null)
            {
                _hadErrors = true;
                _cmdletRunners[last].PSDataStream.WriteExceptionLine(exception);
                _pipelineState.Set(exception, PipelineState.Failed);
            }
            else
            {
                var cmdletInfo = _cmdletRunners[last].CmdletInfo;
                Debug.Assert(cmdletInfo != null);
                var outputType = cmdletInfo.OutputType.FirstOrDefault();
                if (outputType != null)
                {
                    string line;
                    while ((line = _cmdletRunners[last].PipeOut.Read()) != null)
                    {
                        psObjects.Add(PSObject.AsPSObject(line, outputType.Type));
                        psObjects2.Add(PSObject.AsPSObject(line, outputType.Type));
                    }
                }
                else
                {
                    // If Outtype is not set then store output in PSObject instance as string.
                    string line;
                    while ((line = _cmdletRunners[last].PipeOut.Read()) != null)
                    {
                        psObjects.Add(PSObject.AsPSObject(line));
                        psObjects2.Add(PSObject.AsPSObject(line));
                    }
                }

                _pipelineState.Set(PipelineState.Completed);
            }

            _streams = new List<PSDataStreams>();
            for (int i = 0; i <= last; i++)
            {
                // merge the streams
                _streams.Add(_cmdletRunners[i].PSDataStream.Streams);
            }

            _pipeOutReader = new PipelinePSObjectReader(psObjects2);
            return psObjects;
        }

        #region Private fileds

        /// <summary>
        /// The intial session state.
        /// </summary>
        private InitialSessionState _sessionState;

        /// <summary>
        /// The collection of cmdlet runners for running each command in the pipeline.
        /// </summary>
        private CmdletRunner[] _cmdletRunners;

        #endregion
    }
}
