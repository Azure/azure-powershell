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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    public class AzureApplicationGatewayRedirectConfigurationBase : NetworkBaseCmdlet
    {
        [Parameter(
                Mandatory = true,
                HelpMessage = "The name of the Redirect Configuration")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
                Mandatory = true,
                HelpMessage = "The type of redirect")]
        [ValidateSet("Permanent", "Found", "SeeOther", "Temporary", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string RedirectType { get; set; }

        [Parameter(
                ParameterSetName = "SetByResourceId",
                HelpMessage = "ID of  listener to redirect the request to")]
        [ValidateNotNullOrEmpty]
        public string TargetListenerID { get; set; }

        [Parameter(
                ParameterSetName = "SetByResource",
                HelpMessage = "HTTPListener to redirect the request to")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayHttpListener TargetListener { get; set; }

        [Parameter(
                ParameterSetName = "SetByURL",
                HelpMessage = "Target URL fo redirection")]
        [ValidateNotNullOrEmpty]
        public string TargetUrl { get; set; }

        [Parameter(
                HelpMessage = "Include path in the redirected url. Default is true.")]
        public bool? IncludePath { get; set; }

        [Parameter(
                HelpMessage = "Include query string in the redirected url. Default is true.")]
        public bool? IncludeQueryString { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (string.Equals(ParameterSetName, Microsoft.Azure.Commands.Network.Properties.Resources.SetByResource))
            {
                if (TargetListener != null)
                {
                    this.TargetListenerID = this.TargetListener.Id;
                }
            }
        }

        public PSApplicationGatewayRedirectConfiguration NewObject()
        {
            var redirectConfiguration = new PSApplicationGatewayRedirectConfiguration();
            redirectConfiguration.Name = this.Name;
            redirectConfiguration.RedirectType = this.RedirectType;

            if (this.TargetUrl != null
                && this.TargetListenerID != null
                && this.TargetListener != null)
            {
                throw new ArgumentException("Please either specify a target url or a target listener.");
            }

            if (this.TargetUrl != null
                && (this.TargetListenerID != null
                || this.TargetListener != null))
            {
                throw new ArgumentException("Both target url or target listener can not be specified.");
            }

            redirectConfiguration.TargetUrl = this.TargetUrl;
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

            redirectConfiguration.Id = ApplicationGatewayChildResourceHelper.GetResourceNotSetId(
                                this.NetworkClient.NetworkManagementClient.SubscriptionId,
                                Microsoft.Azure.Commands.Network.Properties.Resources.ApplicationGatewayRedirectConfigurationName,
                                this.Name);

            return redirectConfiguration;
        }
    }
}
