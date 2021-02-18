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
    using Microsoft.Rest.Azure;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;

    /// <summary>
    /// NewAzHpcStorageTarget.
    /// </summary>
    [Cmdlet("New",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HpcCacheStorageTarget",
        DefaultParameterSetName = ClfsStorageTargetParameterSet,
        SupportsShouldProcess = true)]
    [OutputType(typeof(PSHpcStorageTarget))]
    public class NewAzHpcStorageTarget : HpcCacheBaseCmdlet
    {
        private const string NfsStorageTargetParameterSet = "NfsParameterSet";
        private const string ClfsStorageTargetParameterSet = "ClfsParameterSet";
        private StorageTarget storageTarget;

        /// <summary>
        /// Gets or sets resource Group Name.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of resource group under which you want to create storage target for given cache.")]
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
        [Parameter(Mandatory = false, ParameterSetName = ClfsStorageTargetParameterSet, HelpMessage = "Create CLFS storage target.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter CLFS { get; set; }

        /// <summary>
        /// Gets or sets NFS storage target.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = NfsStorageTargetParameterSet, HelpMessage = "Create NFS storage target.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter NFS { get; set; }

        /// <summary>
        /// Gets or sets CLFS storage target StorageContainerID.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = ClfsStorageTargetParameterSet, HelpMessage = "StorageContainerID.")]
        [ValidateNotNullOrEmpty]
        public string StorageContainerID { get; set; }

        /// <summary>
        /// Gets or sets NFS storage target hostname.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = NfsStorageTargetParameterSet, HelpMessage = "NFS host name.")]
        [ValidateNotNullOrEmpty]
        public string HostName { get; set; }

        /// <summary>
        /// Gets or sets NFS storage target usage model.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = NfsStorageTargetParameterSet, HelpMessage = "NFS usage model.")]
        [ValidateNotNullOrEmpty]
        public string UsageModel { get; set; }

        /// <summary>
        /// Gets or sets junction.
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
            this.ConfirmAction(
                this.Force.IsPresent,
                string.Format(Resources.ConfirmCreateStorageTarget, this.Name),
                string.Format(Resources.CreateStorageTarget, this.Name),
                this.Name,
                () =>
                {
                    if (this.CLFS.IsPresent)
                    {
                        this.storageTarget = this.CreateClfsStorageTargetParameters();
                    }
                    else if (this.NFS.IsPresent)
                    {
                        this.storageTarget = this.CreateNfsStorageTargetParameters();
                    }
                    else
                    {
                        throw new Exception(string.Format(Resources.CLFSorNFS));
                    }
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

                    this.DoesStorageTargetExists();
                    var results = new List<PSHpcStorageTarget>() { this.CreateStorageTargetModel() };
                    this.WriteObject(results, enumerateCollection: true);
                });
        }

        private PSHpcStorageTarget CreateStorageTargetModel()
        {
            return new PSHpcStorageTarget(
                this.HpcCacheClient.StorageTargets.CreateOrUpdate(
                    this.ResourceGroupName,
                    this.CacheName,
                    this.Name,
                    this.storageTarget));
        }

        private bool DoesStorageTargetExists()
        {
            try
            {
                var resource = this.HpcCacheClient.StorageTargets.Get(
                    this.ResourceGroupName,
                    this.CacheName,
                    this.Name);

                throw new Exception(string.Format(Resources.StorageTargetAlreadyExist, this.Name, this.CacheName));
            }
            catch (CloudErrorException e)
            {
                if (e.Body.Error.Code == "NotFound")
                {
                    return false;
                }

                throw;
            }
        }

        /// <summary>
        /// Create CLFS storage target parameters.
        /// </summary>
        /// <returns>CLFS storage target parameters.</returns>
        private StorageTarget CreateClfsStorageTargetParameters()
        {
            ClfsTarget clfsTarget = new ClfsTarget()
            {
                Target = this.StorageContainerID,
            };

            StorageTarget storageTargetParameters = new StorageTarget
            {
                TargetType = "clfs",
                Clfs = clfsTarget,
            };

            return storageTargetParameters;
        }

        /// <summary>
        /// Create NFS storage target parameters.
        /// </summary>
        /// <returns>NFS storage target parameters.</returns>
        private StorageTarget CreateNfsStorageTargetParameters()
        {
            Nfs3Target nfs3Target = new Nfs3Target()
            {
                Target = this.HostName,
                UsageModel = this.UsageModel,
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
