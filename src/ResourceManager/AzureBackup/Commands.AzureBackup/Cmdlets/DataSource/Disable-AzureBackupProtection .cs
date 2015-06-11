using Microsoft.Azure.Management.BackupServices;
using Microsoft.Azure.Management.BackupServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets.DataSource
{
    // ToDo:
    // Correct the Commandlet
    // Correct the OperationResponse
    // Get Tracking API from Piyush and Get JobResponse
    // Get JobResponse Object from Aditya

    /// <summary>
    /// Enable Azure Backup protection
    /// </summary>
    [Cmdlet(VerbsLifecycle.Disable, "AzureBackupProtection"), OutputType(typeof(OperationResponse))]
    public class DisableAzureBackupProtection : AzureBackupDSCmdletBase
    {
        [Parameter(Position = 1, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.RemoveProtectionOption)]
        [ValidateSet("Invalid", "RetainBackupData", "DeleteBackupData")] 
        public string RemoveProtectionOption { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.Reason)]
        public string Reason { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.Comments)]
        public string Comments { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecutionBlock(() =>
            {
                WriteVerbose("Making client call");
                RemoveProtectionRequestInput input = new RemoveProtectionRequestInput()
                {
                    RemoveProtectionOption = this.RemoveProtectionOption == null ? "RetainBackupData" : this.RemoveProtectionOption,
                    Reason = this.Reason,
                    Comments = this.Comments,
                };

                WriteVerbose("RemoveProtectionOption = " + input.RemoveProtectionOption);
                var disbaleAzureBackupProtection = AzureBackupClient.DataSource.DisableProtectionAsync(GetCustomRequestHeaders(), item.ContainerUniqueName, item.Type, item.DataSourceId, input, CmdletCancellationToken).Result;

                WriteVerbose("Received policy response");
                WriteVerbose("Converting response");
                WriteAzureBackupProtectionPolicy(disbaleAzureBackupProtection);
            });
        }

        public void WriteAzureBackupProtectionPolicy(OperationResponse sourceOperationResponse)
        {
            // this needs to be uncommented once we have proper constructor
            //this.WriteObject(new AzureBackupRecoveryPoint(ResourceGroupName, ResourceName, sourceOperationResponse));
        }

        public void WriteAzureBackupProtectionPolicy(IEnumerable<OperationResponse> sourceOperationResponseList)
        {
            List<OperationResponse> targetList = new List<OperationResponse>();

            foreach (var sourceOperationResponse in sourceOperationResponseList)
            {
                // this needs to be uncommented once we have proper constructor
                targetList.Add(sourceOperationResponse);
            }

            this.WriteObject(targetList, true);
        }
        public enum removeProtectionOption
        {
            [EnumMember]
            Invalid = 0,

            [EnumMember]
            RetainBackupData,

            [EnumMember]
            DeleteBackupData,
        }
    }
}
