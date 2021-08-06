using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RestorePointCollection", DefaultParameterSetName = "DefaultParameter", SupportsShouldProcess = true)]
    [OutputType(typeof(PSOperationStatusResponse))]
    public class RemoveAzureRestorePointCollection : ComputeAutomationBaseCmdlet
    {

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [Alias("RestorePointCollectionName")]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                if (ShouldProcess(this.Name, VerbsCommon.Remove))
                {
                    string resourceGroup = this.ResourceGroupName;
                    string restorePointCollectionName = this.Name;
                    RestorePointCollectionUpdate update = new RestorePointCollectionUpdate();

                    var result = RestorePointCollectionsClient.DeleteWithHttpMessagesAsync(resourceGroup, restorePointCollectionName).GetAwaiter().GetResult();

                    PSOperationStatusResponse output = new PSOperationStatusResponse
                    {
                        StartTime = this.StartTime,
                        EndTime = DateTime.Now
                    };

                    if (result != null && result.Request != null && result.Request.RequestUri != null)
                    {
                        output.Name = GetOperationIdFromUrlString(result.Request.RequestUri.ToString());
                    }

                    WriteObject(output);
                }
            });
        }
    }
}
