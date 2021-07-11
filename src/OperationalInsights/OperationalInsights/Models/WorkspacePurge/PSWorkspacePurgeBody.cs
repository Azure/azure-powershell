using Microsoft.Azure.Management.OperationalInsights.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.OperationalInsights.Models.WorkspacePurge;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSWorkspacePurgeBody
    {
        public PSWorkspacePurgeBody(WorkspacePurgeBody body)
        {
            Filters = body.Filters.Select(filter => new PSWorkspacePurgeBodyFilters(filter)).ToList(); ;
            Table = body.Table;
        }

        public PSWorkspacePurgeBody(IList<WorkspacePurgeBodyFilters> filters, string table)
        {
            Filters = filters.Select(filter => new PSWorkspacePurgeBodyFilters(filter)).ToList();
            Table = table;
        }

        public WorkspacePurgeBody GetWorkspacePurgeBody()
        {
            var filters = Filters.Select(filter => filter.GetFilter()).ToList();
            return new WorkspacePurgeBody(Table, filters);
        }

        public IList<PSWorkspacePurgeBodyFilters> Filters { get; set; }
        public string Table { get; set; }
    }
}
