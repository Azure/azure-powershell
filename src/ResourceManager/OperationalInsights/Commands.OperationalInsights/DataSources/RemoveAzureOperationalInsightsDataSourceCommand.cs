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
using Microsoft.Azure.Commands.OperationalInsights.Properties;
using System.Globalization;
using System.Management.Automation;
using System.Net;

namespace Microsoft.Azure.Commands.OperationalInsights
{
    [Cmdlet(VerbsCommon.Remove, Constants.DataSource, SupportsShouldProcess = true,
        DefaultParameterSetName = ByWorkspaceName)]
    public class RemoveAzureOperationalInsightsDataSourceCommand : NewAzureOperationalInsightsDataSourceBaseCmdlet
    {
        public override void ExecuteCmdlet()
        {

            ConfirmAction(
                Force.IsPresent,
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.DataSourceDeleteConfirmationMessage,
                    Name,
                    WorkspaceName),
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.DataSourceRemoving,
                    Name,
                    WorkspaceName),
                Name,
                ExecuteDelete);
        }

        public void ExecuteDelete()
        {
            HttpStatusCode response = OperationalInsightsClient.DeleteDataSource(ResourceGroupName, WorkspaceName, Name);

            if (response == HttpStatusCode.NoContent)
            {
                WriteWarning(string.Format(CultureInfo.InvariantCulture, Resources.DataSourceNotFound, Name, WorkspaceName));
            }
        }
    }
}