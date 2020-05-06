// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------
namespace Microsoft.Azure.Commands.HPCCache
{
    using System.Management.Automation;
    using Microsoft.Azure.Commands.HPCCache.Properties;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Management.StorageCache;
    using Microsoft.Azure.Management.StorageCache.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.HPCCache.Models;
    using Microsoft.Rest.Azure;
    /// <summary>
    /// Flush or Upgrade HPC Cache.
    /// </summary>
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HpcCache", DefaultParameterSetName = FlushCacheParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class UpdateAzHpcCache : HpcCacheBaseCmdlet
    {
        private const string UpgradeCacheParameterSet = "UpgradeParameterSet";
        private const string FlushCacheParameterSet = "FlushParameterSet";

        /// <summary>
        /// Gets or sets ResourceGroupName.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of resource group under which you want to flush/upgrade cache.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of cache.")]
        [Alias(CacheNameAlias)]
        [ResourceNameCompleter("Microsoft.StorageCache/caches", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets resource id of the cache.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource id of the Cache", ParameterSetName = ResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets Upgrade Flag.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = UpgradeCacheParameterSet, HelpMessage = "Upgrades HPC Cache.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Upgrade { get; set; }

        /// <summary>
        /// Gets or sets Flush Flag.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = FlushCacheParameterSet, HelpMessage = "Flushes HPC Cache.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Flush { get; set; }

        /// <summary>
        /// Gets or sets cache object.
        /// </summary>
        [Parameter(ParameterSetName = ObjectParameterSet, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The cache object to flush/upgrade.")]
        [ValidateNotNullOrEmpty]
        public PSHPCCache InputObject { get; set; }

        /// <summary>
        /// Gets or sets switch parameter force.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Indicates that the cmdlet does not prompt you for confirmation. By default, this cmdlet prompts you to confirm that you want to flush/upgrade the cache.")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Gets or sets switch parameter passthru.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Returns an object representing the item with which you are working. By default, this cmdlet does not generate any output.")]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Gets or sets Job to run job in background.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Execution Cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (this.ParameterSetName == ResourceIdParameterSet)
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.ResourceName;
            }
            else if (this.ParameterSetName == ObjectParameterSet)
            {
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.Name = this.InputObject.CacheName;
            }

            if (this.Flush.IsPresent)
            {
                this.ConfirmAction(
                    this.Force.IsPresent,
                    string.Format(Resources.ConfirmFlushHpcCache, this.Name),
                    string.Format(Resources.FlushHpcCache, this.Name),
                    this.Name,
                    () =>
                    {
                        this.FlushHpcCache();
                    });
            }
            else if (this.Upgrade.IsPresent){
                this.ConfirmAction(
                    this.Force.IsPresent,
                    string.Format(Resources.ConfirmUpgradeHpcCache, this.Name),
                    string.Format(Resources.UpgradeHpcCache, this.Name),
                    this.Name,
                    () =>
                    {
                        this.UpgradeHpcCache();
                    });
            }
        }
        /// <summary>
        /// Updates HPC Cache by doing upgrade.
        /// </summary>
        public void UpgradeHpcCache()
        {
            if (string.IsNullOrWhiteSpace(this.ResourceGroupName))
            {
                throw new PSArgumentNullException("ResourceGroupName");
            }
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                throw new PSArgumentNullException("CacheName");
            }
            if (this.Upgrade.IsPresent)
            {
                try
                {
                    this.HpcCacheClient.Caches.UpgradeFirmware(this.ResourceGroupName, this.Name);
                    if (this.PassThru)
                    {
                        this.WriteObject(true);
                    }
                }
                catch (CloudErrorException ex)
                {
                    throw new CloudException(string.Format("Exception: {0}", ex.Body.Error.Message));
                }
            }
        }

        /// <summary>
        /// Flush HPC Cache.
        /// </summary>
        public void FlushHpcCache()
        {
            if (string.IsNullOrWhiteSpace(this.ResourceGroupName))
            {
                throw new PSArgumentNullException("ResourceGroupName");
            }

            if (string.IsNullOrWhiteSpace(this.Name))
            {
                throw new PSArgumentNullException("CacheName");
            }

            try
            {
                this.HpcCacheClient.Caches.Flush(this.ResourceGroupName, this.Name);
                if (this.PassThru)
                {
                    this.WriteObject(true);
                }
            }
            catch (CloudErrorException ex)
            {
                throw new CloudException(string.Format("Exception: {0}", ex.Body.Error.Message));
            }
        }
    }
}