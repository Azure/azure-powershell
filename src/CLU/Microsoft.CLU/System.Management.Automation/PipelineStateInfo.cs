namespace System.Management.Automation.Runspaces
{
    public sealed class PipelineStateInfo
    {
        public Exception Reason { get; private set; }
        public PipelineState State { get; private set; }

        public PipelineStateInfo()
        {
            State = PipelineState.NotStarted;
        }

        internal void Set(Exception reason, PipelineState state)
        {
            Reason = reason;
            State = state;
        }

        internal void Set(PipelineState state)
        {
            State = state;
        }
    }

    public sealed class PipelineStateEventArgs : EventArgs
    {
        public PipelineStateInfo PipelineStateInfo { get; }
    }

    public enum PipelineState
    {
        NotStarted = 0,
        Running = 1,
        Stopping = 2,
        Stopped = 3,
        Completed = 4,
        Failed = 5,
        Disconnected = 6
    }
}