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

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.Security;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.RecoveryServices.Models;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;
using Microsoft.Azure.Management.RecoveryServices;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Newtonsoft.Json;
using Microsoft.Rest.Azure;
using rpError = Microsoft.Azure.Commands.RecoveryServices.RestApiInfra;
using Formatting = System.Xml.Formatting;
using Microsoft.Azure.Commands.Common.Compute.Version2016_04_preview;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Recovery services convenience client.
    /// </summary>
    public partial class PSComputeManagementClient
    {
        private static AzureContext AzureContext;

        /// <summary>
        ///     Compute management client.
        /// </summary>
        private readonly ComputeManagementClient computeManagementClient;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PSRecoveryServicesClient" /> class with
        ///     required current subscription.
        /// </summary>
        /// <param name="azureSubscription">Azure Subscription</param>
        public PSComputeManagementClient(
            IAzureContextContainer azureProfile)
        {
            AzureContext = (AzureContext)azureProfile.DefaultContext;

            var resourceType = ARMResourceTypeConstants.VirtualMachine;

            this.computeManagementClient = AzureSession.Instance.ClientFactory
                .CreateArmClient<ComputeManagementClient>(
                    AzureContext,
                    AzureEnvironment.Endpoint.ResourceManager);
        }

        /// <summary>
        ///     Gets the value of compute management client.
        /// </summary>
        public ComputeManagementClient GetComputeManagementClient => this
            .computeManagementClient;
    }
}
