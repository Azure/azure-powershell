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
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Threading;
using Microsoft.Rest.Azure;
using Microsoft.Rest.Azure.OData;

namespace Microsoft.Azure.Commands.Insights
{
    /// <summary>
    /// Base class for the Azure Insights SDK EventService Cmdlets
    /// </summary>
    public abstract class LogsCmdletBase : MonitorClientCmdletBase
    {
        private static readonly TimeSpan DefaultQueryTimeRange = TimeSpan.FromDays(7);
        private const int MaxNumberOfReturnedRecords = 1000;
        private int MaxRecords = 0;

        internal const string SubscriptionLevelParameterSetName = "GetBySubscription";
        internal const string ResourceProviderParameterSetName = "GetByResourceProvider";
        internal const string ResourceGroupParameterSetName = "GetByResourceGroup";
        internal const string ResourceIdParameterSetName = "GetByResourceId";
        internal const string CorrelationIdParameterSetName = "GetByCorrelationId";

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
        protected virtual void SetMaxEventsIfPresent(string currentQueryFilter, int value)
        {
            // If value is not acceptable this forces the use of the default value
            this.MaxRecords = (value > 0 && value <= 100000) ? value : 0;
        }

        /// <summary>
        /// Validates that the range of dates (start / end) makes sense, it is not to great (less 15 days), and adds the defaul values if needed
        /// </summary>
        /// <returns>A query filter string with the time conditions</returns>
        private string ValidateDateTimeRangeAndAddDefaults()
        {
            // Removing time in the default current date, but including the whole day: date will be Now + 1 day, the time 00:00:00 AM
            var currentDateTime = DateTime.Now;

            // EndTime is optional.
            DateTime endTime = this.EndTime ?? currentDateTime.AddDays(1).Date;

            // StartTime is optional
            DateTime startTime = this.StartTime ?? endTime.Subtract(this.GetDefaultQueryTimeRange());

            // Check the value of StartTime
            if (startTime > currentDateTime)
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, ResourcesForEventCmdlets.StartDateLaterThanNow, startTime, currentDateTime));
            }

            // Check that the dateTime range makes sense
            if (endTime < startTime)
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, ResourcesForEventCmdlets.EndDateEarlierThanStartDate, endTime, startTime));
            }

            return string.Format("eventTimestamp ge '{0:o}' and eventTimestamp le '{1:o}'", startTime.ToUniversalTime(), endTime.ToUniversalTime());
        }

        /// <summary>
        /// Process the parameters defined by this class
        /// </summary>
        /// <returns>The query filter with the conditions for general parameters (i.e. defined by this class) added</returns>
        private string ProcessGeneralParameters()
        {
            string queryFilter = this.ValidateDateTimeRangeAndAddDefaults();

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
            var result = this.ProcessParticularParameters(queryFilter);
            this.WriteIdentifiedWarning(
                cmdletName: this.GetCmdletName(),
                topic: "Output change", 
                message: "The field EventChannels from the EventData object is being deprecated in the release 5.0.0 - November 2017 - since it now returns a constant value (Admin,Operation)");
            return result;
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
            this.WriteIdentifiedWarning(
                cmdletName: this.GetCmdletName(),
                topic: "Parameter deprecation", 
                message: "The DetailedOutput parameter will be deprecated in a future breaking change release.");
            WriteDebug("Processing parameters");
            string queryFilter = this.ProcessParameters();

            // Retrieve the records
            var fullDetails = this.DetailedOutput.IsPresent;

            //Number of records to retrieve
            int maxNumberOfRecords = this.MaxRecords > 0 ? this.MaxRecords : MaxNumberOfReturnedRecords;

            // Call the proper API methods to return a list of raw records. In the future this pattern can be extended to include DigestRecords
            // If fullDetails is present do not select fields, if not present fetch only the SelectedFieldsForQuery
            WriteDebug("First call");
            var query = new ODataQuery<EventData>(queryFilter);
            IPage<EventData> response = this.MonitorClient.ActivityLogs.ListAsync(odataQuery: query, cancellationToken: CancellationToken.None).Result;
            var records = new List<PSEventData>();
            var enumerator = response.GetEnumerator();
            enumerator.ExtractCollectionFromResult(fullDetails: fullDetails, records: records, keepTheRecord: this.KeepTheRecord);
            string nextLink = response.NextPageLink;

            // Adding a safety check to stop returning records if too many have been read already.
            while (!string.IsNullOrWhiteSpace(nextLink) && records.Count < maxNumberOfRecords)
            {
                WriteDebug("Following continuation token");
                response = this.MonitorClient.ActivityLogs.ListNextAsync(nextPageLink: nextLink, cancellationToken: CancellationToken.None).Result;
                enumerator = response.GetEnumerator();
                WriteDebug(string.Format("Merging records with {0} records", records.Count));
                enumerator.ExtractCollectionFromResult(fullDetails: fullDetails, records: records, keepTheRecord: this.KeepTheRecord);
                WriteDebug(string.Format("Merged records. Now with {0} records", records.Count));
                nextLink = response.NextPageLink;
            }

            WriteDebug("Done following continuation token");
            var recordsReturned = new List<PSEventData>();
            if (records.Count > maxNumberOfRecords)
            {
                WriteDebug("Complying with maxNumberOfRecords");
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
