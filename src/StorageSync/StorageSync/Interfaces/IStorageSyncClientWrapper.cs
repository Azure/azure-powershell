﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Graph.RBAC.Version1_6_20190326.ActiveDirectory;
using Microsoft.Azure.Management.Authorization.Version2015_07_01;
using Microsoft.Azure.Management.Authorization.Version2015_07_01.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.StorageSync;
using System;

namespace Microsoft.Azure.Commands.StorageSync.Interfaces
{

    /// <summary>
    /// Interface IStorageSyncClientWrapper
    /// </summary>
    public interface IStorageSyncClientWrapper
    {

        /// <summary>
        /// Gets or sets the active directory client.
        /// </summary>
        /// <value>The active directory client.</value>
        ActiveDirectoryClient ActiveDirectoryClient { get; set; }

        /// <summary>
        /// Gets or sets the storage sync management client.
        /// </summary>
        /// <value>The storage sync management client.</value>
        IStorageSyncManagementClient StorageSyncManagementClient { get; set; }

        /// <summary>
        /// Gets or sets the storage sync resource manager.
        /// </summary>
        /// <value>The storage sync resource manager.</value>
        IStorageSyncResourceManager StorageSyncResourceManager { get; set; }

        /// <summary>
        /// Gets or sets the authorization management client.
        /// </summary>
        /// <value>The authorization management client.</value>
        IAuthorizationManagementClient AuthorizationManagementClient { get; set; }

        /// <summary>
        /// Gets or sets the resource management client.
        /// </summary>
        /// <value>The resource management client.</value>
        IResourceManagementClient ResourceManagementClient { get; set; }

        /// <summary>
        /// Gets or sets the verbose logger.
        /// </summary>
        /// <value>The verbose logger.</value>
        Action<string> VerboseLogger { get; set; }

        /// <summary>
        /// Gets or sets the error logger.
        /// </summary>
        /// <value>The error logger.</value>
        Action<string> ErrorLogger { get; set; }

        /// <summary>
        /// Ensures the service principal.
        /// </summary>
        /// <returns>PSADServicePrincipal.</returns>
        PSADServicePrincipal EnsureServicePrincipal();

        /// <summary>
        /// Ensures the role assignment.
        /// </summary>
        /// <param name="serverPrincipal">The server principal.</param>
        /// <param name="storageAccountSubscriptionId">The storage account subscription identifier.</param>
        /// <param name="storageAccountResourceId">The storage account resource identifier.</param>
        /// <returns>RoleAssignment.</returns>
        RoleAssignment EnsureRoleAssignment(PSADServicePrincipal serverPrincipal, string storageAccountSubscriptionId, string storageAccountResourceId);

        /// <summary>
        /// This function will invoke the registration and continue operation with a success function call.
        /// </summary>
        /// <param name="currentSubscriptionId">Current SubscriptionId in Azure Context</param>
        /// <param name="resourceProviderNamespace">Resource provider name</param>
        /// <param name="subscription">subscription</param>
        /// <returns>true if request was successfully made. else false</returns>
        bool TryRegisterProvider(string currentSubscriptionId, string resourceProviderNamespace, string subscription);

        /// <summary>
        /// Gets the afs agent installer path.
        /// </summary>
        /// <value>The afs agent installer path.</value>
        string AfsAgentInstallerPath { get; }

        /// <summary>
        /// Gets the afs agent version.
        /// </summary>
        /// <value>The afs agent version.</value>
        string AfsAgentVersion { get; }
    }
}