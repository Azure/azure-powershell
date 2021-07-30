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
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RestorePoint", DefaultParameterSetName = "DefaultParameter", SupportsShouldProcess = true)]
    [OutputType(typeof(PSRestorePoint))]
    public class NewAzureRestorePoint : ComputeAutomationBaseCmdlet
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
        public string RestorePointCollectionName{ get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [Alias("RestorePointName")]
        public string Name { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = false,
            ValueFromPipeline = true)]
        public string[] DisksToExclude { get; set; }


        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                if (ShouldProcess(this.Name, VerbsCommon.New))
                {
                    string resourceGroup = this.ResourceGroupName;
                    string restorePointName = this.Name;
                    string restorePointCollectionName = this.RestorePointCollectionName;
                    List<ApiEntityReference> disksExclude = new List<ApiEntityReference>();


                    if (this.IsParameterBound(c => c.DisksToExclude))
                    {
                        foreach (string s in DisksToExclude)
                        {
                            disksExclude.Add(new ApiEntityReference(s));
                        }
                        var result = RestorePointClient.Create(resourceGroup, restorePointCollectionName, restorePointName, disksExclude);
                        var psObject = new PSRestorePoint();
                        ComputeAutomationAutoMapperProfile.Mapper.Map<RestorePoint, PSRestorePoint>(result, psObject);
                        WriteObject(psObject);

                    }
                    else
                    {
                        var result = RestorePointClient.Create(resourceGroup, restorePointCollectionName, restorePointName);
                        var psObject = new PSRestorePoint();
                        ComputeAutomationAutoMapperProfile.Mapper.Map<RestorePoint, PSRestorePoint>(result, psObject);
                        WriteObject(psObject);
                    }
                }
            });
        }
    }
}
