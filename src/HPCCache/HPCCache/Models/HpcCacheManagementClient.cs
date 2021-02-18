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

namespace Microsoft.Azure.PowerShell.Cmdlets.HPCCache.Models
{
    using System;
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Management.StorageCache;

    /// <summary>
    /// Hpc cache management client wrapper.
    /// </summary>
    public partial class HpcCacheManagementClientWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HpcCacheManagementClientWrapper"/> class.
        /// </summary>
        /// <param name="context">Azure context.</param>
        public HpcCacheManagementClientWrapper(IAzureContext context)
            : this(AzureSession.Instance.ClientFactory.CreateArmClient<StorageCacheManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HpcCacheManagementClientWrapper"/> class.
        /// </summary>
        /// <param name="resourceManagementClient">Resource management client.</param>
        public HpcCacheManagementClientWrapper(IStorageCacheManagementClient resourceManagementClient)
        {
            this.HpcCacheManagementClient = resourceManagementClient;
        }

        /// <summary>
        /// Gets or sets hpc Cache management client.
        /// </summary>
        public IStorageCacheManagementClient HpcCacheManagementClient { get; set; }

        /// <summary>
        /// Gets or sets verbose logging.
        /// </summary>
        public Action<string> VerboseLogger { get; set; }

        /// <summary>
        /// Gets or sets error logging.
        /// </summary>
        public Action<string> ErrorLogger { get; set; }

        /// <summary>
        /// Gets or sets warning Logger.
        /// </summary>
        public Action<string> WarningLogger { get; set; }

        /// <summary>
        /// Writes verbose.
        /// </summary>
        /// <param name="verboseFormat">Verbose format.</param>
        /// <param name="args">Arguments to write verbose.</param>
        private void WriteVerbose(string verboseFormat, params object[] args)
        {
            this.VerboseLogger?.Invoke(string.Format(verboseFormat, args));
        }

        /// <summary>
        /// Write warning.
        /// </summary>
        /// <param name="warningFormat">Warning format.</param>
        /// <param name="args">Arguments to write warning.</param>
        private void WriteWarning(string warningFormat, params object[] args)
        {
            this.WarningLogger?.Invoke(string.Format(warningFormat, args));
        }

        /// <summary>
        /// Write error.
        /// </summary>
        /// <param name="errorFormat">Error format.</param>
        /// <param name="args">Arguments to write error.</param>
        private void WriteError(string errorFormat, params object[] args)
        {
            this.ErrorLogger?.Invoke(string.Format(errorFormat, args));
        }
    }
}