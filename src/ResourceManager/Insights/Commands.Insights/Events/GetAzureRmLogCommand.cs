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

using Microsoft.Azure.Commands.Insights.OutputClasses;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Insights.Events
{
    /// <summary>
    /// Get the list of events for at a subscription level.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmLog"), OutputType(typeof(List<IPSEventData>))]
    public class GetAzureRmLogCommand : EventCmdletBase
    {
        /// <summary>
        /// Gets or sets the starttime parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = CorrelationIdName, ValueFromPipelineByPropertyName = true, HelpMessage = "The correlationId of the query")]
        [Parameter(ParameterSetName = ResourceIdName, ValueFromPipelineByPropertyName = true, HelpMessage = "The resourceId of the query")]
        [Parameter(ParameterSetName = ResourceGroupName, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name of the query")]
        [Parameter(ParameterSetName = ResourceProviderName, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource provider name of the query")]
        [Parameter(ParameterSetName = SubscriptionLevelName, ValueFromPipelineByPropertyName = true, HelpMessage = "The subscriptionId of the query")]
        public override DateTime? StartTime { get; set; }

        /// <summary>
        /// Gets or sets the endtime parameter of the cmdlet
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "The endTime of the query")]
        public override DateTime? EndTime { get; set; }

        /// <summary>
        /// Gets or sets the status parameter of the cmdlet
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "The status of the events to fetch")]
        [ValidateNotNullOrEmpty]
        public override string Status { get; set; }

        /// <summary>
        /// Gets or sets the caller parameter of the cmdlet
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "The caller of the events to fetch")]
        [ValidateNotNullOrEmpty]
        public override string Caller { get; set; }

        /// <summary>
        /// Gets or sets the detailedoutput parameter of the cmdlet
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "Return object with all the details of the events (the default is to return only some attributes, i.e. no detail)")]
        public override SwitchParameter DetailedOutput { get; set; }

        /// <summary>
        /// Gets or sets the correlationId of the cmdlet
        /// </summary>
        [Parameter(Position = 0, ParameterSetName = CorrelationIdName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The CorrelationId")]
        [ValidateNotNullOrEmpty]
        public string CorrelationId { get; set; }

        /// <summary>
        /// Gets or sets the resourcegroup parameters of this cmdlet
        /// </summary>
        [Parameter(Position = 0, ParameterSetName = ResourceGroupName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroup { get; set; }

        /// <summary>
        /// Gets or sets the resourceId parameter of the cmdlet
        /// </summary>
        [Parameter(Position = 0, ParameterSetName = ResourceIdName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The ResourceId")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the resourceprovider parameter of the cmdlet
        /// </summary>
        [Parameter(Position = 0, ParameterSetName = ResourceProviderName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The ResourceProvider name")]
        [ValidateNotNullOrEmpty]
        public string ResourceProvider { get; set; }

        /// <summary>
        /// Gets or sets the max number of events to fetch parameter of the cmdlet
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "The maximum number of events to fetch")]
        [ValidateNotNullOrEmpty]
        public virtual int MaxEvents { get; set; }

        /// <summary>
        /// Process the parameters defined by this class  (a.k.a. particular parameters)
        /// </summary>
        /// <param name="currentQueryFilter">The current query filter</param>
        /// <returns>The query filter with the conditions for particular parameters added</returns>
        protected override string ProcessParticularParameters(string currentQueryFilter)
        {
            this.SetMaxEventsIfPresent(currentQueryFilter, "MaxEvents", this.MaxEvents);

            string extendedQuery = this.AddConditionIfPResent(currentQueryFilter, "correlationId", this.CorrelationId);
            extendedQuery = this.AddConditionIfPResent(extendedQuery, "resourceGroupName", this.ResourceGroup);

            // Notice the different name in the condition (resourceUri) and the parameter (resourceId)
            // The difference is intentional as the new directive is to use ResourceId everywhere, but the SDK still uses resourceUri
            extendedQuery = this.AddConditionIfPResent(extendedQuery, "resourceUri", this.ResourceId);
            return this.AddConditionIfPResent(extendedQuery, "resourceProvider", this.ResourceProvider);
        }
    }
}
