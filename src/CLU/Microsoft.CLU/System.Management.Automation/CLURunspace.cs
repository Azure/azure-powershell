using Microsoft.CLU.Common.Properties;
using System.Diagnostics;

namespace System.Management.Automation.Runspaces
{
    /// <summary>
    /// Represents the runspace that is the operating environment for CLU command pipelines.
    /// </summary>
    internal class CLURunspace : Runspace
    {
        /// <summary>
        /// Backing field for the property InitialSessionState.
        /// </summary>
        InitialSessionState _intialSessionState;
        /// <summary>
        /// Represents a session state configuration that is used when a runspace is opened.
        /// </summary>
        public override InitialSessionState InitialSessionState
        {
            get
            {
                return _intialSessionState;
            }
        }

        /// <summary>
        /// Backing field for the property RunspaceStateInfo.
        /// </summary>
        RunspaceStateInfo _runspaceStateInfo;
        /// <summary>
        /// Gets the current state of the runspace.
        /// </summary>
        public override RunspaceStateInfo RunspaceStateInfo
        {
            get
            {
                return _runspaceStateInfo;
            }
        }

        /// <summary>
        /// Gets the version of the runspace class.
        /// </summary>
        public override Version Version
        {
            get
            {
                return new Version(1, 1, 0);
            }
        }

        /// <summary>
        /// Creates an instance of CLURunspace.
        /// </summary>
        /// <param name="initialSessionState">the initial session-state to use</param>
        public CLURunspace(InitialSessionState initialSessionState)
        {
            Debug.Assert(initialSessionState != null);

            _intialSessionState = initialSessionState;
            _runspaceStateInfo = new RunspaceStateInfo
            {
                State = RunspaceState.BeforeOpen
            };
        }

        /// <summary>
        /// Opens the runspace synchronously.
        /// </summary>
        public override void Open()
        {
            _runspaceStateInfo.State = RunspaceState.Opened;
        }

        /// <summary>
        /// Closes the runspace and makes it unavailable for use.
        /// </summary>
        public override void Close()
        {
            _runspaceStateInfo.State = RunspaceState.Closed;
        }

        /// <summary>
        /// Creates a pipeline for the runspace.
        /// </summary>
        /// <returns></returns>
        public override Pipeline CreatePipeline()
        {
            if (_runspaceStateInfo.State != RunspaceState.Opened)
            {
                throw new InvalidOperationException(Strings.CLURunspace_CreatePipeline_RunspaceNotOpended);
            }

            return new CLUSyncPipeline(this);
        }
    }
}
