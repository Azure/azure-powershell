using Microsoft.Azure.Management.OperationalInsights.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSWorkspacePurgeBody
    {
        public PSWorkspacePurgeBody(WorkspacePurgeBody body)
        {
            Filters = body.Filters;
            Table = body.Table;
        }

        public PSWorkspacePurgeBody(IList<WorkspacePurgeBodyFilters> filters, string table)
        {
            Filters = filters;
            Table = table;
        }

        public WorkspacePurgeBody GetWorkspacePurgeBody()
        {
            return new WorkspacePurgeBody(Table, Filters);
        }

        public IList<WorkspacePurgeBodyFilters> Filters { get; set; }
        public string Table { get; set; }
    }
}
