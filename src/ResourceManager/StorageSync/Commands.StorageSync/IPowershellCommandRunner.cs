using System.Collections.ObjectModel;
using System.Management.Automation;

namespace AFSEvaluationTool
{
    public interface IPowershellCommandRunner
    {
        Collection<PSObject> Invoke();

        void AddScript(string v);

        PSDataCollection<ErrorRecord> Errors();
    }
}