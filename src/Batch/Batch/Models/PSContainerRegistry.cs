// -----------------------------------------------------------------------------
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
// -----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class PSContainerRegistry
    {
        internal ContainerRegistry toMgmtContainerRegistry()
        {
            if (this.omObject == null)
            {
                return null;
            }
            ContainerRegistry containerRegistry = new ContainerRegistry();
            containerRegistry.UserName = this.UserName;
            containerRegistry.Password = this.Password;
            containerRegistry.RegistryServer = this.RegistryServer;
            containerRegistry.IdentityReference = (this.IdentityReference != null) ? this.IdentityReference.toMgmtIdentityReference() : null;
            return containerRegistry;
        }

        internal static PSContainerRegistry fromMgmtContainerRegistry(ContainerRegistry containerRegistry)
        {
            if (containerRegistry == null)
            {
                return null;
            }

            PSComputeNodeIdentityReference identityReference = containerRegistry.IdentityReference != null 
                ? new PSComputeNodeIdentityReference(PSComputeNodeIdentityReference.fromMgmtIdentityReference(containerRegistry.IdentityReference))
                : null;

            PSContainerRegistry psContainerRegistry = new PSContainerRegistry(
                userName: containerRegistry.UserName,
                password: containerRegistry.Password,
                registryServer: containerRegistry.RegistryServer,
                identityReference: identityReference);

            return psContainerRegistry;
        }
    }
}
