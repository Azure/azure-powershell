// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.Properties;
using System.Management.Automation;
using System.Security.Permissions;
namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Removes a hybridworkergroup for automation.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AutomationHybridWorkerGroup",
        SupportsShouldProcess = true, DefaultParameterSetName = AutomationCmdletParameterSets.ByName)]
    [OutputType(typeof(void))]
    public class RemoveAzureAutomationHybridWorkerGroup : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the hybridworkergroup name.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The hybrid worker group name.")]
        [ValidateNotNullOrEmpty]
        [Alias("Group")]
        public string Name { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            ConfirmAction(
                       string.Format(Resources.RemoveAzureAutomationResourceDescription, "HybridWorkerGroup"),
                       Name,
                       () =>
                       {
                           this.AutomationClient.DeleteHybridRunbookWorkerGroup(this.ResourceGroupName, this.AutomationAccountName, Name);
                       });
        }
    }
}