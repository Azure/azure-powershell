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
using System.Linq;
using System.Management.Automation;
using Hyak.Common;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///    Creates an ASR recovery services provider.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrServicesProvider", DefaultParameterSetName = ASRParameterSets.Default, SupportsShouldProcess = true)]
    [Alias("New-ASRServicesProvider")]
    [OutputType(typeof(ASRJob))]
    public class NewAzureRmRecoveryServicesAsrServicesProvider : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets the name of the Azure Site Recovery Provider.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Name of the provider to be created")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the name of the Azure Site Recovery fabric.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Name of the fabric")]
        [ValidateNotNullOrEmpty]
        public string FabricName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the machine where the provider is getting added.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Name of the machine where the provider is getting added")]
        [ValidateNotNullOrEmpty]
        public string MachineName { get; set; }

        /// <summary>
        /// Gets or sets the identity provider input for DRA authentication.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Identity provider input for DRA authentication")]
        [ValidateNotNullOrEmpty]
        public ASRIdentityProviderInput AuthenticationIdentityInput { get; set; }

        /// <summary>
        /// Gets or sets the identity provider input for resource access.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Identity provider input for resource access")]
        [ValidateNotNullOrEmpty]
        public ASRIdentityProviderInput ResourceAccessIdentityInput { get; set; }

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();
            if (this.ShouldProcess(
                this.Name,
                VerbsCommon.New))
            {
                var authenticationIdentityInput = new IdentityProviderInput()
                {
                    TenantId = this.AuthenticationIdentityInput.TenantId,
                    ApplicationId = this.AuthenticationIdentityInput.ApplicationId,
                    ObjectId = this.AuthenticationIdentityInput.ObjectId,
                    Audience = this.AuthenticationIdentityInput.Audience,
                    AadAuthority = this.AuthenticationIdentityInput.AadAuthority
                };

                var resourceAccessIdentityInput = new IdentityProviderInput()
                {
                    TenantId = this.ResourceAccessIdentityInput.TenantId,
                    ApplicationId = this.ResourceAccessIdentityInput.ApplicationId,
                    ObjectId = this.ResourceAccessIdentityInput.ObjectId,
                    Audience = this.ResourceAccessIdentityInput.Audience,
                    AadAuthority = this.ResourceAccessIdentityInput.AadAuthority
                };

                var inputProperties = new AddRecoveryServicesProviderInputProperties()
                {
                    MachineName = this.MachineName,
                    AuthenticationIdentityInput = authenticationIdentityInput,
                    ResourceAccessIdentityInput = resourceAccessIdentityInput
                };

                var input = new AddRecoveryServicesProviderInput
                {
                    Properties = inputProperties
                };

                var response =
                    RecoveryServicesClient.CreateAzureSiteRecoveryProvider(
                        this.FabricName,
                        this.Name,
                        input);

                string jobId = PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location);

                var jobResponse =
                    RecoveryServicesClient
                    .GetAzureSiteRecoveryJobDetails(jobId);

                WriteObject(new ASRJob(jobResponse));
            }
        }
    }
}

