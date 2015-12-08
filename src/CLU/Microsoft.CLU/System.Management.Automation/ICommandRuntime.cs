using System.Management.Automation.Host;

namespace System.Management.Automation
{
    public interface ICommandRuntime
    {
        PSHost Host { get; }

        bool ShouldContinue(string query, string caption);
        bool ShouldContinue(string query, string caption, ref bool yesToAll, ref bool noToAll);
        bool ShouldProcess(string target);
        bool ShouldProcess(string target, string action);
        bool ShouldProcess(string verboseDescription, string verboseWarning, string caption);
        bool ShouldProcess(string verboseDescription, string verboseWarning, string caption, out ShouldProcessReason shouldProcessReason);
        void ThrowTerminatingError(ErrorRecord errorRecord);
        void WriteCommandDetail(string text);
        void WriteDebug(string text);
        void WriteError(ErrorRecord errorRecord);
        void WriteObject(object sendToPipeline);
        void WriteObject(object sendToPipeline, bool enumerateCollection);
        void WriteProgress(ProgressRecord progressRecord);
        void WriteProgress(long sourceId, ProgressRecord progressRecord);
        void WriteVerbose(string text);
        void WriteWarning(string text);
    }
}
