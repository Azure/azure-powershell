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
    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RestorePointCollection", DefaultParameterSetName = "DefaultParameter", SupportsShouldProcess = true)]
    [OutputType(typeof(PSRestorePointCollection))]
    public class UpdateAzureRestorePointCollection : ComputeAutomationBaseCmdlet
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

        [Parameter(
             Mandatory = false,
             HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                if (ShouldProcess(this.Name, VerbsData.Update))
                {
                    string resourceGroup = this.ResourceGroupName;
                    string restorePointCollectionName = this.Name;
                    RestorePointCollectionUpdate update = new RestorePointCollectionUpdate();

                    if (this.IsParameterBound(c => c.Tag))
                    {
                        update.Tags = this.Tag.Cast<DictionaryEntry>().ToDictionary(ht => (string)ht.Key, ht => (string)ht.Value);
                    }

                    RestorePointCollectionsClient.Update(resourceGroup, restorePointCollectionName, update);
                    var result = RestorePointCollectionsClient.Get(resourceGroup, restorePointCollectionName);
                    var psObject = new PSRestorePointCollection();
                    ComputeAutomationAutoMapperProfile.Mapper.Map<RestorePointCollection, PSRestorePointCollection>(result, psObject);
                    WriteObject(psObject);
                }
            });
        }
    }
}
