using Microsoft.Azure.Management.OperationalInsights.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.OperationalInsights.Models.WorkspacePurge
{
    public class PSWorkspacePurgeBodyFilters
    {
        public PSWorkspacePurgeBodyFilters(WorkspacePurgeBodyFilters filters)
        {
            Column = filters.Column;
            OperatorProperty = filters.OperatorProperty;
            Value = filters.Value;
            Key = filters.Key;
        }

        public PSWorkspacePurgeBodyFilters(string column, string operatorProperty, string key, object value)
        {
            Column = column;
            OperatorProperty = operatorProperty;
            Key = key;
            Value = value;
        }

        public string Column { get; set; }

        public string OperatorProperty { get; set; }

        public object Value { get; set; }

        public string Key { get; set; }
    }
}
