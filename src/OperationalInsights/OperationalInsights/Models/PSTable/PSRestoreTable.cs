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
    public class PSRestoreTable : PSTable
    {
        public DateTime? StartRestoreTime { get; set; }

        public DateTime? EndRestoreTime { get; set; }

        public string SourceTable { get; set; }

        public PSRestoreTable(
            string resourceGroupName,
            string workspaceName,
            string tableName,
            string startRestoreTime,
            string endRestoreTime,
            string SourceTable)
        {
            base.ResourceGroupName = resourceGroupName;
            base.WorkspaceName = workspaceName;
            base.Name = tableName;

            DateTime start;
            DateTime end;
            try
            {
                var parsedStart = DateTime.TryParse(startRestoreTime, out start);
            }
            catch (Exception)
            {
                throw new PSArgumentException(string.Format(Resources.BadDateTimeFormat, startRestoreTime, nameof(startRestoreTime)));
            }

            try
            {
                var parsedEnd = DateTime.TryParse(endRestoreTime, out end);
            }
            catch (Exception)
            {
                throw new PSArgumentException(string.Format(Resources.BadDateTimeFormat, endRestoreTime, nameof(endRestoreTime)));
            }

            this.StartRestoreTime = start;
            this.EndRestoreTime = end;
            this.SourceTable = SourceTable;
        }

        /// <summary>
        /// Creates a Table object for create or update flow
        /// </summary>
        /// <returns>The payload for Create or Update table</returns>
        public override Table ToTableProperties()
        {
            return new Table(
                name: Name,
                plan: Plan,
                restoredLogs: new RestoredLogs(this.StartRestoreTime, this.EndRestoreTime, this.SourceTable));

        }
    }
}
