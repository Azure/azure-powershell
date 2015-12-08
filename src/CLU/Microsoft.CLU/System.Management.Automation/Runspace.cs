namespace System.Management.Automation.Runspaces
{
    /// <summary>
    /// Represents the runspace that is the operating environment for command pipelines.
    /// </summary>
    public abstract class Runspace : IDisposable
    {
        /// <summary>
        /// Gets configuration information about the session state used when the runspace is opened.
        /// </summary>
        public abstract InitialSessionState InitialSessionState { get; }

        /// <summary>
        /// The runspace instance id.
        /// </summary>
        public Guid InstanceId { get; }

        /// <summary>
        /// Gets the current state of the runspace.
        /// </summary>
        public abstract RunspaceStateInfo RunspaceStateInfo { get; }

        /// <summary>
        /// Gets the version of the runspace class.
        /// </summary>
        public abstract Version Version { get; }

        /// <summary>
        /// Opens the runspace synchronously.
        /// </summary>
        public abstract void Open();

        /// <summary>
        /// Closes the runspace and makes it unavailable for use.
        /// </summary>
        public abstract void Close();

        /// <summary>
        /// Creates a pipeline for the runspace.
        /// </summary>
        /// <returns></returns>
        public abstract Pipeline CreatePipeline();

        public void Dispose()
        {
        }

       protected virtual void Dispose(bool disposing)
       {}
    }

    /// <summary>
    /// Provides information about the current state of the runspace.
    /// </summary>
    public sealed class RunspaceStateInfo
    {
        public Exception Reason { get; internal set; }
        public RunspaceState State { get; internal set; }
        public override string ToString()
        {
            return State.ToString();
        }
    }

    /// <summary>
    /// Gets the current state of the runspace.
    /// </summary>
    public enum RunspaceState
    {
        BeforeOpen = 0,
        Opening = 1,
        Opened = 2,
        Closed = 3,
        Closing = 4,
        Broken = 5,
        Disconnecting = 6,
        Disconnected = 7,
        Connecting = 8
    }
}
