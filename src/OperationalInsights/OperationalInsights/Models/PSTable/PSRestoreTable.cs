using Microsoft.Azure.Management.OperationalInsights.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSRestoreTable : PSTable
    {
        public DateTime? StartRestoreTime { get; set; }

        public DateTime? EndRestoreTime { get; set; }

        public string RestoreSourceTable { get; set; }

        public PSRestoreTable(
            string resourceGroupName,
            string workspaceName,
            string tableName,
            string startRestoreTime,
            string endRestoreTime,
            string restoreSourceTable)
        {
            base.ResourceGroupName = resourceGroupName;
            base.WorkspaceName = workspaceName;
            base.TableName = tableName;

            DateTime start;
            DateTime end;
            try
            {
                var parsedStart = DateTime.TryParse(startRestoreTime, out start);
            }
            catch (Exception)
            {
                throw new PSArgumentException(string.Format(Errors.BadDateTimeFormat, startRestoreTime, nameof(startRestoreTime)));
            }

            try
            {
                var parsedEnd = DateTime.TryParse(endRestoreTime, out end);
            }
            catch (Exception)
            {
                throw new PSArgumentException(string.Format(Errors.BadDateTimeFormat, endRestoreTime, nameof(endRestoreTime)));
            }

            this.StartRestoreTime = start;
            this.EndRestoreTime = end;
            this.RestoreSourceTable = restoreSourceTable;
        }

        /// <summary>
        /// Creates a Table object for create or update flow
        /// </summary>
        /// <returns>The payload for Create or Update table</returns>
        public override Table ToTableProperties()
        {
            return new Table(
                name: TableName,
                plan: Plan,
                restoredLogs: new RestoredLogs(this.StartRestoreTime, this.EndRestoreTime, this.RestoreSourceTable));
                
        }
    }
}
