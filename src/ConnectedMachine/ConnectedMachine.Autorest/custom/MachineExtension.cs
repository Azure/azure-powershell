namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Extensions;

    public partial class MachineExtension
    {
        public string MachineName
        {
            get => (new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/Microsoft.HybridCompute/machines/(?<machineName>[^/]+)",
                        global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Success ?
                        new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/Microsoft.HybridCompute/machines/(?<machineName>[^/]+)",
                        global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Groups["machineName"].Value : null);
        }
    }

}