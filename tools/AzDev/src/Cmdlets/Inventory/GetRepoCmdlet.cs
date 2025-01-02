using System;
using System.Management.Automation;

namespace AzDev.Cmdlets.Inventory
{
    [Cmdlet("Get", "DevCodebase")]
    [Obsolete("Useless cmdlet")]
    public class GetRepoCmdlet : DevCmdletBase
    {
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            WriteObject(Codebase);
        }
    }
}
