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
using Microsoft.Azure.Commands.Insights.Properties;
using Microsoft.Azure.Insights.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Threading;

namespace Microsoft.Azure.Commands.Insights
{
    /// <summary>
    /// Base class for the Azure Insights SDK EventService Cmdlets
    /// </summary>
    public abstract class EventCmdletBase : InsightsClientCmdletBase
    {
        private static readonly TimeSpan MaximumDateDifferenceAllowedInDays = TimeSpan.FromDays(15);
        private static readonly TimeSpan DefaultQueryTimeRange = TimeSpan.FromHours(1);
        private const int MaxNumberOfReturnedRecords = 1000;
        private int MaxEvents = 0;

        internal const string SubscriptionLevelName = "Query at subscription level";
        internal const string ResourceProviderName = "Query on ResourceProvider";
        internal const string ResourceGroupName = "Query on ResourceGroupProvider";
        internal const string ResourceIdName = "Query on ResourceIdName";
        internal const string CorrelationIdName = "Query on CorrelationId";

        #region Parameters declarations

        /// <summary>
        /// Gets or sets the starttime parameter of the cmdlet
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "The startTime of the query")]
        public virtual DateTime? StartTime { get; set; }

        /// <summary>
        /// Gets or sets the endtime parameter of the cmdlet
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "The endTime of the query")]
        public virtual DateTime? EndTime { get; set; }

        /// <summary>
        /// Gets or sets the status parameter of the cmdlet
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "The status of the records to fetch")]
        [ValidateNotNullOrEmpty]
        public virtual string Status { get; set; }

        /// <summary>
        /// Gets or sets the caller parameter of the cmdlet
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "The caller of the records to fetch")]
        [ValidateNotNullOrEmpty]
        public virtual string Caller { get; set; }

        /// <summary>
        /// Gets or sets the detailedoutput parameter of the cmdlet
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "Return object with all the details of the records (the default is to return only some attributes, i.e. no detail)")]
        public virtual SwitchParameter DetailedOutput { get; set; }

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
        /// Gets the default query time range
        /// </summary>
        /// <returns>The default query time range for this class</returns>
        protected virtual TimeSpan GetDefaultQueryTimeRange()
        {
            return DefaultQueryTimeRange;
        }

        /// <summary>
        /// Sets the max number of records to fetch
        /// </summary>
        protected virtual void SetMaxEventsIfPresent(string currentQueryFilter, string name, int value)
        {
            if (value > 0 && value <= 100000)
            {
                this.MaxEvents = value;
            }
        }

        /// <summary>
        /// Validates that the range of dates (start / end) makes sense, it is not to great (less 15 days), and adds the defaul values if needed
        /// </summary>
        /// <returns>A query filter string with the time conditions</returns>
        private string ValidateDateTimeRangeAndAdddefaults()
        {
            // EndTime is optional
            DateTime endTime = this.EndTime.HasValue ? this.EndTime.Value : DateTime.Now;

            // StartTime is optional
            DateTime startTime = this.StartTime.HasValue ? this.StartTime.Value : endTime.Subtract(this.GetDefaultQueryTimeRange());

            // Check the value of StartTime
            if (startTime > DateTime.Now)
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, ResourcesForEventCmdlets.StartDateLaterThanNow, startTime, DateTime.Now));
            }

            // Check that the dateTime range makes sense
            if (endTime < startTime)
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, ResourcesForEventCmdlets.EndDateEarlierThanStartDate, endTime, startTime));
            }

            // Validate start and end dates difference is reasonable (<= MaximumDateDifferenceAllowedInDays)
            var dateDifference = endTime.Subtract(startTime);
            if (dateDifference > MaximumDateDifferenceAllowedInDays)
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, ResourcesForEventCmdlets.StartAndEndDatesTooFarAppart, MaximumDateDifferenceAllowedInDays.TotalDays, dateDifference.TotalDays));
            }

            return string.Format("eventTimestamp ge '{0:o}' and eventTimestamp le '{1:o}'", startTime.ToUniversalTime(), endTime.ToUniversalTime());
        }

        /// <summary>
        /// Process the parameters defined by this class
        /// </summary>
        /// <returns>The query filter with the conditions for general parameters (i.e. defined by this class) added</returns>
        private string ProcessGeneralParameters()
        {
            string queryFilter = this.ValidateDateTimeRangeAndAdddefaults();

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
        /// A predicate to filter in/out the records from original list of records obtained from the SDK.
        /// <para>This method is intended to allow descendants of this class to further filter the results.</para>
        /// <para>An example of this is when the filtering is needed based on Category and ResourceUri at the same time. 
        /// The SDK does not allow these two fields to be in the query filter togheter. So the call should filter by one and then use this function to filter by the second one.</para>
        /// </summary>
        /// <param name="record">A record from the original list of records obtained from the sdk</param>
        /// <returns>true if the record should kept in the result, false if it should be filtered out</returns>
        protected virtual bool KeepTheRecord(EventData record)
        {
            // Do not filter in this funtion, use a filter in the descendants only
            return true;
        }

        /// <summary>
        /// Execute the cmdlet
        /// </summary>
        protected override void ProcessRecordInternal()
        {
            string queryFilter = this.ProcessParameters();

            // Retrieve the records
            var fullDetails = this.DetailedOutput.IsPresent;

            //Number of records to retrieve
            int maxNumberOfRecords = this.MaxEvents > 0 ? this.MaxEvents : MaxNumberOfReturnedRecords;

            // Call the proper API methods to return a list of raw records. In the future this pattern can be extended to include DigestRecords
            // If fullDetails is present do not select fields, if not present fetch only the SelectedFieldsForQuery
            EventDataListResponse response = this.InsightsClient.EventOperations.ListEventsAsync(filterString: queryFilter, selectedProperties: fullDetails ? null : PSEventDataNoDetails.SelectedFieldsForQuery, cancellationToken: CancellationToken.None).Result;
            var records = new List<IPSEventData>(response.EventDataCollection.Value.Where(this.KeepTheRecord).Select(e => fullDetails ? (IPSEventData)new PSEventData(e) : (IPSEventData)new PSEventDataNoDetails(e)));
            string nextLink = response.EventDataCollection.NextLink;

            // Adding a safety check to stop returning records if too many have been read already.
            while (!string.IsNullOrWhiteSpace(nextLink) && records.Count < maxNumberOfRecords)
            {
                response = this.InsightsClient.EventOperations.ListEventsNextAsync(nextLink: nextLink, cancellationToken: CancellationToken.None).Result;
                records.AddRange(response.EventDataCollection.Value.Select(e => fullDetails ? (IPSEventData)new PSEventData(e) : (IPSEventData)new PSEventDataNoDetails(e)));
                nextLink = response.EventDataCollection.NextLink;
            }

            var recordsReturned = new List<IPSEventData>();
            if (records.Count > maxNumberOfRecords)
            {
                recordsReturned.AddRange(records.Take(maxNumberOfRecords));
            }
            else
            {
                recordsReturned = records;
            }

            // Returns an object that contains a link to the set of subsequent records or null if not more records are available, called Next, and an array of records, called Value
            WriteObject(sendToPipeline: recordsReturned, enumerateCollection: true);
        }
    }
}
