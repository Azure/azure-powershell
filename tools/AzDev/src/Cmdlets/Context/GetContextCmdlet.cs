using System.Management.Automation;
using AzDev.Models.PSModels;

namespace AzDev.Cmdlets.Context
{
    [Cmdlet("Get", "DevContext")]
    [OutputType(typeof(PSDevContext))]
    public class GetContextCmdlet : DevCmdletBase
    {
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            WriteObject(new PSDevContext(Context, ContextProvider.ContextPath));
        }
    }
}
