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
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Net;
    using Microsoft.Azure.Commands.Common.Strategies;
    using Microsoft.Azure.Commands.HPCCache.Properties;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.StorageCache;
    using Microsoft.Azure.Management.StorageCache.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.HPCCache.Models;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Newtonsoft.Json;

    /// <summary>
    /// SetAzHpcStorageTarget.
    /// </summary>
    [Cmdlet("Set",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HpcCacheStorageTarget",
        DefaultParameterSetName = ClfsStorageTargetParameterSet,
        SupportsShouldProcess = true)]
    [OutputType(typeof(PSHpcStorageTarget))]
    public class SetAzHpcStorageTarget : HpcCacheBaseCmdlet
    {
        private const string NfsStorageTargetParameterSet = "NfsParameterSet";
        private const string ClfsStorageTargetParameterSet = "ClfsParameterSet";
        private StorageTarget storageTarget;

        /// <summary>
        /// Gets or sets resource Group Name.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of resource group under which you want to update storage target.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets resource CacheName.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of cache.")]
        [ResourceNameCompleter("Microsoft.StorageCache/caches", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string CacheName { get; set; }

        /// <summary>
        /// Gets or sets resource storage target name.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of storage target.")]
        [Alias(StoragTargetNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets CLFS storage target.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = ClfsStorageTargetParameterSet, HelpMessage = "Update CLFS storage target.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter CLFS { get; set; }

        /// <summary>
        /// Gets or sets NFS storage target.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = NfsStorageTargetParameterSet, HelpMessage = "Update NFS storage target.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter NFS { get; set; }

        /// <summary>
        /// Gets or sets junctions.  Note: only junctions can be updated as of now.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = ClfsStorageTargetParameterSet, HelpMessage = "Junction.")]
        [Parameter(Mandatory = false, ParameterSetName = NfsStorageTargetParameterSet, HelpMessage = "Junction.")]
        [ValidateNotNullOrEmpty]
        public Hashtable[] Junction { get; set; }

        /// <summary>
        /// Gets or sets AsJob.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "AsJob.")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Gets or sets switch parameter force.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Indicates that the cmdlet does not prompt you for confirmation. By default, this cmdlet prompts you to confirm that you want to flush the cache.")]
        public SwitchParameter Force { get; set; }

        /// <inheritdoc/>
        public override void ExecuteCmdlet()
        {
            if (string.IsNullOrWhiteSpace(this.ResourceGroupName))
            {
                throw new PSArgumentNullException("ResourceGroupName");
            }

            if (string.IsNullOrWhiteSpace(this.CacheName))
            {
                throw new PSArgumentNullException("CacheName");
            }

            if (string.IsNullOrWhiteSpace(this.Name))
            {
                throw new PSArgumentNullException("StorageTargetName");
            }

            this.ConfirmAction(
                this.Force.IsPresent,
                string.Format(Resources.ConfirmUpdateStorageTarget, this.Name),
                string.Format(Resources.UpdateStorageTarget, this.Name),
                this.Name,
                () =>
                {
                    var storageT = this.DoesStorageTargetExists();

                        if (storageT == null)
                        {
                            throw new CloudException(string.Format("Storage target {0} does not exists.", this.Name));
                        }

                        this.storageTarget = this.CLFS.IsPresent ? this.CreateClfsStorageTargetParameters(storageT) : this.CreateNfsStorageTargetParameters(storageT);
                        if (this.IsParameterBound(c => c.Junction))
                        {
                            this.storageTarget.Junctions = new List<NamespaceJunction>();
                            foreach (var junction in this.Junction)
                            {
                                var nameSpaceJunction = HashtableToDictionary<string, string>(junction);
                                this.storageTarget.Junctions.Add(
                                    new NamespaceJunction(
                                        nameSpaceJunction.GetOrNull("namespacePath"),
                                        nameSpaceJunction.GetOrNull("targetPath"),
                                        nameSpaceJunction.GetOrNull("nfsExport")));
                            }
                        }

                        var results = new List<PSHpcStorageTarget>() { this.CreateStorageTargetModel() };
                        this.WriteObject(results, enumerateCollection: true);
                });
        }


        private PSHpcStorageTarget CreateStorageTargetModel()
        {
            try
            {
                StorageTarget storageTarget = this.HpcCacheClient.StorageTargets.CreateOrUpdate(
                    this.ResourceGroupName,
                    this.CacheName,
                    this.Name,
                    this.storageTarget);
            }
            catch (CloudErrorException ex)
            {
                // Fix for update storage target, until Swagger is updated with correct response code.
                if (ex.Response.StatusCode == HttpStatusCode.Accepted)
                {
                    try
                    {
                        this.storageTarget = Rest.Serialization.SafeJsonConvert.DeserializeObject<StorageTarget>(ex.Response.Content, this.HpcCacheClient.DeserializationSettings);
                    }
                    catch (JsonException jsonEx)
                    {
                        throw new SerializationException("Unable to deserialize the response.", ex.Response.Content, jsonEx);
                    }
                }
                else
                {
                    throw;
                }
            }

            return new PSHpcStorageTarget(this.storageTarget);
        }

        private StorageTarget DoesStorageTargetExists()
        {
            return this.HpcCacheClient.StorageTargets.Get(
                    this.ResourceGroupName,
                    this.CacheName,
                    this.Name);
        }

        /// <summary>
        /// Update CLFS storage target parameters.
        /// </summary>
        /// <returns>CLFS storage target parameters.</returns>
        private StorageTarget CreateClfsStorageTargetParameters(StorageTarget storageT)
        {
            ClfsTarget clfsTarget = new ClfsTarget()
            {
                Target = storageT.Clfs.Target,
            };

            StorageTarget storageTargetParameters = new StorageTarget
            {
                TargetType = "clfs",
                Clfs = clfsTarget,
            };

            return storageTargetParameters;
        }

        /// <summary>
        /// Update CLFS storage target parameters.
        /// </summary>
        /// <returns>CLFS storage target parameters.</returns>
        private StorageTarget CreateNfsStorageTargetParameters(StorageTarget storageT)
        {
            Nfs3Target nfs3Target = new Nfs3Target()
            {
                Target = storageT.Nfs3.Target,
                UsageModel = storageT.Nfs3.UsageModel,
            };

            StorageTarget storageTargetParameters = new StorageTarget
            {
                TargetType = "nfs3",
                Nfs3 = nfs3Target,
            };

            return storageTargetParameters;
        }
    }
}
