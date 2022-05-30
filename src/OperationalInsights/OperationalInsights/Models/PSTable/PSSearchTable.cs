using Microsoft.Azure.Management.OperationalInsights.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSSearchTable : PSTable
    {
        public DateTime? StartSearchTime { get; set; }

        public DateTime? EndSearchTime { get; set; }

        public int? Limit { get; set; }

        public PSSearchTable(
            string resourceGroupName,
            string workspaceName,
            string tableName,
            string startSearchTime,
            string endSearchTime,
            int? limit)
        {
            base.ResourceGroupName = resourceGroupName;
            base.WorkspaceName = workspaceName;
            base.TableName = tableName;

            DateTime start;
            DateTime end;
            try
            {
                var parsedStart = DateTime.TryParse(startSearchTime, out start);
            }
            catch (Exception)
            {
                throw new PSArgumentException(string.Format(Errors.BadDateTimeFormat, startSearchTime, nameof(startSearchTime)));
            }

            try
            {
                var parsedEnd = DateTime.TryParse(endSearchTime, out end);
            }
            catch (Exception)
            {
                throw new PSArgumentException(string.Format(Errors.BadDateTimeFormat, endSearchTime, nameof(endSearchTime)));
            }

            this.StartSearchTime = start;
            this.EndSearchTime = end;
            this.Limit = limit;
        }

        /// <summary>
        /// Creates a Table object for create or update flow
        /// </summary>
        /// <returns>The payload for Create or Update table</returns>
        public override Table ToTableProperties()
        {
            return new Table(
                name: TableName,
                searchResults: new SearchResults(startSearchTime: this.StartSearchTime, endSearchTime: this.EndSearchTime, limit: this.Limit));
        }
    }
}
