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

using Microsoft.Azure.Management.OperationalInsights.Models;

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

        public WorkspacePurgeBodyFilters GetFilter()
        {
            return new WorkspacePurgeBodyFilters(Column, OperatorProperty, Value, Key);
        }
    }
}
