namespace System.Management.Automation
{
    public sealed class PSDataStreams
    {
        public PSDataCollection<DebugRecord> Debug { get; set; }
        public PSDataCollection<ErrorRecord> Error { get; set; }
        public PSDataCollection<ProgressRecord> Progress { get; set; }
        public PSDataCollection<VerboseRecord> Verbose { get; set; }
        public PSDataCollection<WarningRecord> Warning { get; set; }

        public PSDataStreams()
        {
            Debug = new PSDataCollection<DebugRecord>();
            Error = new PSDataCollection<ErrorRecord>();
            Progress = new PSDataCollection<ProgressRecord>();
            Verbose = new PSDataCollection<VerboseRecord>();
            Warning = new PSDataCollection<WarningRecord>();
        }

        public void ClearStreams()
        {
            Debug.Clear();
            Error.Clear();
            Progress.Clear();
            Verbose.Clear();
            Warning.Clear();
        }
    }
}