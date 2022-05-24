using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzurePrefix + "BatchSupportedVirtualMachineSku"), OutputType(typeof(PSSupportedSku))]
    [Alias("Get-AzBatchSupportedVMSku")]
    public class GetSupportedVirtualMachineSkuCommand : BatchCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The region to get the supported SKUs from.")]
        [LocationCompleter("Microsoft.Batch/locations/quotas")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The maximum number of items to return in the response.")]
        [ValidateNotNullOrEmpty]
        public int? MaxResultCount { get; set; }

        [Parameter(Position = 2, ValueFromPipelineByPropertyName = true,
            HelpMessage = "OData filter expression. Valid properties for filtering are \"familyName\".")]
        [ValidateNotNullOrEmpty]
        public string Filter { get; set; }

        protected override void ExecuteCmdletImpl()
        {
            IList<PSSupportedSku> skus = BatchClient.GetSupportedVirtualMachineSku(Location, MaxResultCount, Filter);
            WriteObject(skus, true);
        }
    }
}
