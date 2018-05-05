using System.Collections.ObjectModel;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.StorageSync.Evaluation
{
    public interface IPowershellCommandRunner
    {
        Collection<PSObject> Invoke();

        void AddScript(string v);

        PSDataCollection<ErrorRecord> Errors();
    }
}