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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Network
{
    public class AzureApplicationGatewayFirewallPolicySetting : NetworkBaseCmdlet
    {
        [Parameter(
            HelpMessage = "Web Application Firewall Mode.")]
        [ValidateSet("Prevention", "Detection", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string Mode { get; set; }

        [Parameter(
            HelpMessage = "Web Application Firewall State.")]
        [ValidateSet("Disabled", "Enabled", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string State { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Disable request body enforcement limits for WAF.")]
        [ValidateNotNullOrEmpty]
        public bool? DisableRequestBodyEnforcement { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Max inspection limit in KB for request body inspection.")]
        [ValidateNotNullOrEmpty]
        public int? RequestBodyInspectLimitInKB { get; set; }

        [Parameter(
            HelpMessage = "Disable Request Body check.")]
        public SwitchParameter DisableRequestBodyCheck { get; set; }

        [Parameter(
           HelpMessage = "Maximum request body size in KB.")]
        [ValidateNotNullOrEmpty]
        public int MaxRequestBodySizeInKb { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Disable file upload enforcement limits for WAF.")]
        [ValidateNotNullOrEmpty]
        public bool? DisableFileUploadEnforcement { get; set; }

        [Parameter(
           HelpMessage = "Maximum fileUpload size in MB.")]
        [ValidateNotNullOrEmpty]
        public int MaxFileUploadInMb { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Custom Response Status Code")]
        [ValidateNotNullOrEmpty]
        public int? CustomBlockResponseStatusCode { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Custom Response Body")]
        [ValidateNotNullOrEmpty]
        public string CustomBlockResponseBody { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "To scrub sensitive log fields")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayFirewallPolicyLogScrubbingConfiguration LogScrubbing { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Web Application Firewall JavaScript Challenge Cookie Expiration time in minutes.")]
        [ValidateNotNullOrEmpty]
        [ValidateRange(5,1440)]
        public int? JSChallengeCookieExpirationInMins { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (!this.MyInvocation.BoundParameters.ContainsKey("Mode"))
            {
                this.Mode = "Detection";
            }

            if (!this.MyInvocation.BoundParameters.ContainsKey("State"))
            {
                this.State = "Enabled";
            }

            if (!this.MyInvocation.BoundParameters.ContainsKey("MaxRequestBodySizeInKb"))
            {
                this.MaxRequestBodySizeInKb = 128;
            }

            if (!this.MyInvocation.BoundParameters.ContainsKey("MaxFileUploadInMb"))
            {
                this.MaxFileUploadInMb = 100;
            }

            if (!this.MyInvocation.BoundParameters.ContainsKey("CustomBlockResponseStatusCode"))
            {
                this.CustomBlockResponseStatusCode = (int?)null;
            }

            if (!this.MyInvocation.BoundParameters.ContainsKey("RequestBodyInspectLimitInKB"))
            {
                this.RequestBodyInspectLimitInKB = (int?)null;
            }

            if (!this.MyInvocation.BoundParameters.ContainsKey("DisableFileUploadEnforcement"))
            {
                this.DisableFileUploadEnforcement = (bool?)null;
            }

            if (!this.MyInvocation.BoundParameters.ContainsKey("DisableRequestBodyEnforcement"))
            {
                this.DisableRequestBodyEnforcement = (bool?)null;
            }

            if (this.MyInvocation.BoundParameters.ContainsKey("CustomBlockResponseBody"))
            {
                this.CustomBlockResponseBody = System.Convert.ToBase64String(Encoding.UTF8.GetBytes(CustomBlockResponseBody));
            } else
            {
                this.CustomBlockResponseBody = null;
            }

            if (!this.MyInvocation.BoundParameters.ContainsKey("JSChallengeCookieExpirationInMins"))
            {
                this.JSChallengeCookieExpirationInMins = (int?)null;
            }
        }

        protected PSApplicationGatewayFirewallPolicySettings NewObject()
        {
            bool? RequestBodyEnforcementVal = null;
            if (this.DisableRequestBodyEnforcement != null)
            {
                RequestBodyEnforcementVal = true;
                if (this.DisableRequestBodyEnforcement == true)
                {
                    RequestBodyEnforcementVal = false;
                }
            }
            bool? FileUploadEnforcementVal = null;
            if (this.DisableFileUploadEnforcement != null)
            {
                FileUploadEnforcementVal = true;
                if (this.DisableFileUploadEnforcement == true)
                {
                    FileUploadEnforcementVal = false;
                }
            }

            return new PSApplicationGatewayFirewallPolicySettings()
            {
                Mode = this.Mode,
                State = this.State,
                RequestBodyEnforcement = RequestBodyEnforcementVal,
                RequestBodyInspectLimitInKB = this.RequestBodyInspectLimitInKB,
                RequestBodyCheck = this.DisableRequestBodyCheck.IsPresent ? false : true,
                MaxRequestBodySizeInKb = this.MaxRequestBodySizeInKb,
                FileUploadEnforcement = FileUploadEnforcementVal,
                FileUploadLimitInMb = this.MaxFileUploadInMb,
                CustomBlockResponseBody = this.CustomBlockResponseBody,
                CustomBlockResponseStatusCode = this.CustomBlockResponseStatusCode,
                LogScrubbing = this.LogScrubbing,
                JSChallengeCookieExpirationInMins = this.JSChallengeCookieExpirationInMins
            };
        }
    }
}
