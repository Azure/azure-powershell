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

using Hyak.Common;
using Microsoft.Azure.Commands.OperationalInsights.Client;
using System;

namespace Microsoft.Azure.Commands.OperationalInsights
{
    public abstract class OperationalInsightsBaseCmdlet : ResourceManager.Common.AzureRMCmdlet
    {
        protected const string ByWorkspaceName = "ByWorkspaceName";
        protected const string ByWorkspaceObject = "ByWorkspaceObject";
        protected const string ByName = "ByName";
        protected const string ByObject = "ByObject";

        private OperationalInsightsClient operationalInsightsClient;

        internal OperationalInsightsClient OperationalInsightsClient
        {
            get
            {
                if (this.operationalInsightsClient == null)
                {
                    this.operationalInsightsClient = new OperationalInsightsClient(DefaultProfile.Context);
                }

                return this.operationalInsightsClient;
            }
            set
            {
                this.operationalInsightsClient = value;
            }
        }

        protected override void WriteExceptionError(Exception exception)
        {
            // Override the default error message into a formatted message which contains Request Id
            CloudException cloudException = exception as CloudException;
            if (cloudException != null)
            {
                exception = cloudException.CreateFormattedException();
            }

            base.WriteExceptionError(exception);
        }
    }
}
