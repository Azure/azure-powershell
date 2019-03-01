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

using Microsoft.Azure.Commands.Network.Models;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApplicationGatewayRedirectConfiguration", DefaultParameterSetName = "SetByResource"), OutputType(typeof(PSApplicationGateway))]
    public class UpdateAzureApplicationGatewayRedirectConfigurationCommand : AzureApplicationGatewayRedirectConfigurationBase
    {
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The applicationGateway")]
        public PSApplicationGateway ApplicationGateway { get; set; }

        [Parameter(
                Mandatory = false,
                HelpMessage = "The type of redirect")]
        [ValidateSet("Permanent", "Found", "SeeOther", "Temporary", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public override string RedirectType { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var redirectConfiguration = this.ApplicationGateway.RedirectConfigurations.SingleOrDefault
                (resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (redirectConfiguration == null)
            {
                throw new ArgumentException("RedirectConfiguration with the specified name does not exist");
            }

            if (string.Equals(ParameterSetName, Microsoft.Azure.Commands.Network.Properties.Resources.SetByResource))
            {
                if (TargetListener != null)
                {
                    this.TargetListenerID = this.TargetListener.Id;
                }
            }

            if (!string.IsNullOrEmpty(this.RedirectType))
            {
                redirectConfiguration.RedirectType = this.RedirectType;
            }

            if (!string.IsNullOrEmpty(this.RedirectType))
            {
                redirectConfiguration.TargetUrl = this.TargetUrl;
            }

            if (this.IncludePath != null)
            {
                redirectConfiguration.IncludePath = this.IncludePath;
            }

            if (this.IncludeQueryString != null)
            {
                redirectConfiguration.IncludeQueryString = this.IncludeQueryString;
            }

            if (!string.IsNullOrEmpty(this.TargetListenerID))
            {
                redirectConfiguration.TargetListener = new PSResourceId();
                redirectConfiguration.TargetListener.Id = this.TargetListener.Id;
            }

            WriteObject(this.ApplicationGateway);
        }
    }
}
