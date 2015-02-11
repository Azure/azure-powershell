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
using System.Threading;
using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Insights.Models;

namespace Microsoft.Azure.Commands.Insights
{
    /// <summary>
    /// Base class for the Azure SDK EventService Cmdlets
    /// </summary>
    public abstract class EventCmdletBase : InsightsCmdletBase
    {
        internal static readonly TimeSpan DefaultQueryTimeRange = TimeSpan.FromHours(-1);

        internal static int MaxNumberOfReturnedRecords = 100000;

        internal const string SubscriptionLevelName = "Query at subscription level";
        internal const string ResourceProviderName = "Query on ResourceProvider";
        internal const string ResourceGroupName = "Query on ResourceGroupProvider";
        internal const string ResourceUriName = "Query on ResourceUriName";
        internal const string CorrelationIdName = "Query on CorrelationId";

        #region Optional parameters declarations

        /// <summary>
        /// Gets or sets the starttime parameter of the cmdlet
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "The startTime of the query")]
        [ValidateNotNullOrEmpty]
        public string StartTime { get; set; }

        /// <summary>
        /// Gets or sets the endtime parameter of the cmdlet
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "The endTime of the query")]
        [ValidateNotNullOrEmpty]
        public string EndTime { get; set; }

        /// <summary>
        /// Gets or sets the status parameter of the cmdlet
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "The status of the records to fetch")]
        [ValidateNotNullOrEmpty]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the caller parameter of the cmdlet
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "The caller of the records to fetch")]
        [ValidateNotNullOrEmpty]
        public string Caller { get; set; }

        /// <summary>
        /// Gets or sets the detailedoutput parameter of the cmdlet
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "Return object with all the details of the records (the default is to return only some attributes, i.e. no detail)")]
        public SwitchParameter DetailedOutput { get; set; }

        #endregion

        #region Parameters processing

        /// <summary>
        /// Adds a condition to the query filter based on the give name and the value
        /// </summary>
        /// <param name="currentQueryFilter">The current query filter</param>
        /// <param name="name">The name to be used in the new condition</param>
        /// <param name="value">The value to be used in the new condition.<para>If this value is null, the currentQueryFilter is returned unmodified.</para></param>
        /// <returns></returns>
        protected string AddConditionIfPResent(string currentQueryFilter, string name, string value)
        {
            return !string.IsNullOrWhiteSpace(value) ? string.Format("{0} and {1} eq '{2}'", currentQueryFilter, name, value) : currentQueryFilter;
        }

        /// <summary>
        /// Process the parameters defined by this class
        /// </summary>
        /// <returns>The query filter with the conditions for general parameters (i.e. defined by this class) added</returns>
        private string ProcessGeneralParameters()
        {
            DateTime startTime;
            if (string.IsNullOrWhiteSpace(this.StartTime))
            {
                // Default to one hour from Now
                startTime = DateTime.Now.Subtract(DefaultQueryTimeRange);
            }
            else if (!DateTime.TryParse(this.StartTime, out startTime))
            {
                throw new ArgumentException("Unable to parse startTime argument");
            }

            string queryFilter;

            // EndTime is optional
            if (string.IsNullOrWhiteSpace(this.EndTime))
            {
                queryFilter = string.Format("eventTimestamp ge '{0:o}'", startTime.ToUniversalTime());
            }
            else
            {
                DateTime endTime;
                if (!DateTime.TryParse(this.EndTime, out endTime))
                {
                    throw new ArgumentException("Unable to parse endTime argument");
                }

                queryFilter = string.Format("eventTimestamp ge '{0:o}' and eventTimestamp le '{1:o}'", startTime.ToUniversalTime(), endTime.ToUniversalTime());
            }

            // Include the status if present
            queryFilter = this.AddConditionIfPResent(queryFilter, "status", this.Status);

            // Include the caller if present
            queryFilter = this.AddConditionIfPResent(queryFilter, "caller", this.Caller);

            return queryFilter;
        }

        /// <summary>
        /// Process the general parameters (i.e. defined in this class) and the particular parameters (i.e. the parameters added by the descendants of this class).
        /// </summary>
        /// <returns>The final query filter to be used by the cmdlet</returns>
        protected string ProcessParameters()
        {
            string queryFilter = this.ProcessGeneralParameters();
            return this.ProcessParticularParameters(queryFilter);
        }

        /// <summary>
        /// Process the parameters defined by the descendants of this class
        /// </summary>
        /// <param name="currentQueryFilter">The current query filter</param>
        /// <returns>The query filter with the conditions for particular parameters added</returns>
        protected abstract string ProcessParticularParameters(string currentQueryFilter);

        #endregion

        /// <summary>
        /// Execute the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            string queryFilter = this.ProcessParameters();

            // Retrieve the records
            var fullDetails = this.DetailedOutput.IsPresent;

            // Call the proper API methods to return a list of raw records. In the future this pattern can be extended to include DigestRecords
            // If fullDetails is present do not select fields, if not present fetch only the SelectedFieldsForQuery
            EventDataListResponse response = this.InsightsClient.EventOperations.ListEventsAsync(filterString: queryFilter, selectedProperties: fullDetails ? null : PSEventDataNoDetails.SelectedFieldsForQuery, cancellationToken: CancellationToken.None).Result;
            var records = new List<IPSEventData>(response.EventDataCollection.Value.Select(e => fullDetails ? (IPSEventData)new PSEventData(e) : (IPSEventData)new PSEventDataNoDetails(e)));
            string nextLink = response.EventDataCollection.NextLink;

            // Adding a safety check to stop returning records if too many have been read already.
            while (!string.IsNullOrWhiteSpace(nextLink) && records.Count < MaxNumberOfReturnedRecords)
            {
                response = this.InsightsClient.EventOperations.ListEventsNextAsync(nextLink: nextLink, cancellationToken: CancellationToken.None).Result;
                records.AddRange(response.EventDataCollection.Value.Select(e => fullDetails ? (IPSEventData)new PSEventData(e) : (IPSEventData)new PSEventDataNoDetails(e)));
                nextLink = response.EventDataCollection.NextLink;
            }

            // Returns an object that contains a link to the set of subsequent records or null if not more records are available, called Next, and an array of records, called Value
            WriteObject(sendToPipeline: records, enumerateCollection: true);
        }
    }
}
