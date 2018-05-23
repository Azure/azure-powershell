namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces
{
    using System.Collections.ObjectModel;
    using System.Management.Automation;

    public interface IPowershellCommandRunner
    {
        Collection<PSObject> Invoke();

        void AddScript(string value);

        PSDataCollection<ErrorRecord> Errors();
    }
}