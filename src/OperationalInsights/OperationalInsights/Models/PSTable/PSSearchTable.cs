// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.OperationalInsights.Properties;
using Microsoft.Azure.Management.OperationalInsights.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSSearchTable : PSTable
    {
        public string Query { get; set; }

        public DateTime? StartSearchTime { get; set; }

        public DateTime? EndSearchTime { get; set; }

        public int? Limit { get; set; }

        public PSSearchTable(
            string resourceGroupName,
            string workspaceName,
            string tableName,
            string query,
            string startSearchTime,
            string endSearchTime,
            int? limit)
        {
            base.ResourceGroupName = resourceGroupName;
            base.WorkspaceName = workspaceName;
            base.Name = tableName;
            this.Query = query;

            DateTime start;
            DateTime end;
            try
            {
                var parsedStart = DateTime.TryParse(startSearchTime, out start);
            }
            catch (Exception)
            {
                throw new PSArgumentException(string.Format(Resources.BadDateTimeFormat, startSearchTime, nameof(startSearchTime)));
            }

            try
            {
                var parsedEnd = DateTime.TryParse(endSearchTime, out end);
            }
            catch (Exception)
            {
                throw new PSArgumentException(string.Format(Resources.BadDateTimeFormat, endSearchTime, nameof(endSearchTime)));
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
                name: Name,
                searchResults: new SearchResults(query: this.Query, startSearchTime: this.StartSearchTime, endSearchTime: this.EndSearchTime, limit: this.Limit));
        }
    }
}
