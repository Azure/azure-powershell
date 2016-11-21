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

using Microsoft.Azure.Commands.OperationalInsights.Models;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.OperationalInsights
{
    [Cmdlet(VerbsCommon.Set, Constants.DataSource, DefaultParameterSetName = ByWorkspaceName), OutputType(typeof(PSDataSource))]
    public class SetAzureOperationalInsightsDataSourceCommand : OperationalInsightsBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true,
            HelpMessage = "The existing data source to update.")]
        [ValidateNotNull]
        public PSDataSource DataSource { get; set; }

        public override void ExecuteCmdlet()
        {
            UpdatePSDataSourceParameters parameters = new UpdatePSDataSourceParameters
            {
                ResourceGroupName = DataSource.ResourceGroupName,
                WorkspaceName = DataSource.WorkspaceName,
                Name = DataSource.Name,
                Properties= DataSource.Properties
            };

            WriteObject(OperationalInsightsClient.UpdatePSDataSource(parameters));
        }
    }
}