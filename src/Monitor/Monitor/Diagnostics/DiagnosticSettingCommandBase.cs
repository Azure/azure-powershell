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

using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Insights.Diagnostics
{
    public abstract class DiagnosticSettingCommandBase : ManagementCmdletBase
    {
        protected const string ResourceIdParameterSet = "ResourceIdParameterSet";
        protected const string SubscriptionIdParameterSet = "SubscriptionIdParameterSet";

        [Parameter(ParameterSetName = ResourceIdParameterSet, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource id")]
        [ValidateNotNullOrEmpty]
        [Alias("TargetResourceId")]
        public string ResourceId { get; set; }

        [Parameter(ParameterSetName = SubscriptionIdParameterSet, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The subscription id")]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        protected virtual void Validate()
        {
            if (this.IsParameterBound(c => c.SubscriptionId) && !Utilities.IsGuid(this.SubscriptionId))
            {
                throw new AzPSArgumentException("Please specify a valid subscription Id", "SubscriptionId");
            }

            if (this.IsParameterBound(c => c.ResourceId) && Utilities.IsGuid(this.ResourceId))
            {
                throw new AzPSArgumentException("Please use parameter 'SubscriptionId' instead of 'ResourceId'", "ResourceId");
            }
        }

        private string GetSubscription()
        {
            return string.Format("/subscriptions/{0}", this.SubscriptionId);
        }

        protected string GetTargetUri()
        {
            return this.IsParameterBound(c => c.SubscriptionId) ? GetSubscription() : this.ResourceId;
        }
    }
}
