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
using Microsoft.Azure.Management.Monitor.Models;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Insights.ScheduledQueryRules
{
    /// <summary>
    /// Create a ScheduledQueryRule Source object
    /// </summary>
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ScheduledQueryRuleSource"), OutputType(typeof(PSScheduledQueryRuleSource))]
    public class NewScheduledQueryRuleSourceCommand : ManagementCmdletBase
    {

        #region Cmdlet parameters

        [Parameter(Mandatory = true, HelpMessage = "The alert query")]
        [ValidateNotNullOrEmpty]
        public string Query { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The list of authorized resources for this alert")]
        public string[] AuthorizedResource { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The data source on which this alert is created")]
        [ValidateNotNullOrEmpty]
        public string DataSourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Type of Query - currently supported values : ResultCount")]
        [PSArgumentCompleter("ResultCount")]
        public string QueryType { get; set; }

        #endregion
        protected override void ProcessRecordInternal()
        {
            Source source = new Source(query: Query, dataSourceId: DataSourceId, authorizedResources: AuthorizedResource, queryType: QueryType);
            source.Validate();
            WriteObject(new PSScheduledQueryRuleSource(source));
        }
    }
}
