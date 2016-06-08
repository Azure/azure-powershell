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

using Microsoft.Azure.Commands.StreamAnalytics.Properties;
using Microsoft.Azure.Management.StreamAnalytics.Models;
using System;
using System.Globalization;
using System.Management.Automation;
using System.Net;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.StreamAnalytics
{
    [Cmdlet(VerbsDiagnostic.Test, Constants.StreamAnalyticsOutput)]
    public class TestAzureStreamAnalyticsOutputCommand : StreamAnalyticsResourceProviderBaseCmdlet
    {
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The azure stream analytics job name.")]
        [ValidateNotNullOrEmpty]
        public string JobName { get; set; }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The stream analytics output name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            if (ResourceGroupName != null && string.IsNullOrWhiteSpace(ResourceGroupName))
            {
                throw new PSArgumentNullException("ResourceGroupName");
            }

            if (JobName != null && string.IsNullOrWhiteSpace(JobName))
            {
                throw new PSArgumentNullException("JobName");
            }

            if (Name != null && string.IsNullOrWhiteSpace(Name))
            {
                throw new PSArgumentNullException("Name");
            }

            try
            {
                ResourceTestConnectionResponse response = StreamAnalyticsClient.TestPSOutput(ResourceGroupName, JobName, Name);
                if (response.StatusCode == HttpStatusCode.OK && response.ResourceTestStatus == ResourceTestStatus.TestSucceeded)
                {
                    WriteObject(true);
                }
                else if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    WriteWarning(string.Format(CultureInfo.InvariantCulture, Resources.OutputNotFound, Name, JobName, ResourceGroupName));
                }
                else
                {
                    string errorId = null;
                    string errorMessage = null;
                    string innerErrorMessage = null;
                    if (response.Error != null)
                    {
                        errorId = response.Error.Code;
                        errorMessage = response.Error.Message;
                        if (response.Error.Details != null)
                        {
                            innerErrorMessage = response.Error.Details.Message;
                        }
                    }

                    Exception ex = new Exception(errorMessage, new Exception(innerErrorMessage));
                    WriteError(new ErrorRecord(ex, errorId, ErrorCategory.ConnectionError, null));
                }
            }
            catch
            {
                WriteObject(false);
            }
        }
    }
}