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
    using Microsoft.Azure.Management.StorageCache;
    using Microsoft.Azure.Management.StorageCache.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.HPCCache.Models;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Remove HPC Cache.
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HpcCache", SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class RemoveAzHpcCache : HpcCacheBaseCmdlet
    {
        /// <summary>
        /// Gets or sets ResourceGroupName.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of resource group under which you want to remove cache.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets CacheName.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of cache.")]
        [Alias(CacheNameAlias)]
        [ResourceNameCompleter("Microsoft.StorageCache/caches", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Delete Force - always set to false.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Indicates that the cmdlet does not prompt you for confirmation. By default, this cmdlet prompts you to confirm that you want to remove the cache.")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Gets or sets Switch parameter if you do not want to wait till success.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Returns an object representing the item with which you are working.By default, this cmdlet does not generate any output.")]
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
            this.ConfirmAction(
                this.Force.IsPresent,
                string.Format(Resources.ConfirmDeleteHpcCache, this.Name),
                string.Format(Resources.DeleteHpcCache, this.Name),
                this.Name,
                () =>
                {
                    try
                    {
                        this.HpcCacheClient.Caches.Delete(this.ResourceGroupName, this.Name);
                        if (this.PassThru)
                        {
                            this.WriteObject(true);
                        }
                    }
                    catch (CloudErrorException ex)
                    {
                        throw new CloudException(string.Format("Exception: {0}", ex.Body.Error.Message));
                    }
                });
        }
    }
}