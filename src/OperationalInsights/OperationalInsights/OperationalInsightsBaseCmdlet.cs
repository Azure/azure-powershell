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
        protected const string GetByNameParameterSet = "GetByNameParameterSet";
        protected const string GetByParentObjectParameterSet = "GetByParentObjectParameterSet";
        protected const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";
        protected const string ListParameterSet = "ListParameterSet";
        protected const string UpdateByNameParameterSet = "UpdateByNameParameterSet";
        protected const string UpdateByResourceIdParameterSet = "UpdateByResourceIdParameterSet";
        protected const string UpdateByInputObjectParameterSet = "UpdateByInputObjectParameterSet";
        protected const string DeleteByNameParameterSet = "DeleteByNameParameterSet";
        protected const string DeleteByInputObjectParameterSet = "DeleteByInputObjectParameterSet";
        protected const string DeleteByResourceIdParameterSet = "DeleteByResourceIdParameterSet";
        protected const string CreateByNameParameterSet = "CreateByNameParameterSet";
        protected const string CreateByObjectParameterSet = "CreateByObjectParameterSet";
        protected const string AllParameterSet = "AllParameterSet";

        private OperationalInsightsClient operationalInsightsClient;

        internal OperationalInsightsClient OperationalInsightsClient
        {
            get
            {
                if (this.operationalInsightsClient == null)
                {
                    this.operationalInsightsClient = new OperationalInsightsClient(DefaultProfile.DefaultContext);
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
            Rest.Azure.CloudException cloudException = exception as Rest.Azure.CloudException;
            if (cloudException != null)
            {
                exception = cloudException.CreateFormattedException();
            }

            // Override the default error message so it will include information passed from Backend
            Management.OperationalInsights.Models.ErrorResponseException errorException = exception as Management.OperationalInsights.Models.ErrorResponseException;
            if (errorException != null)
            {                
                exception = new Exception(string.Format("{0}\n{1}\n{2}", errorException.Message, errorException.Response?.ReasonPhrase, errorException.Response?.Content), errorException);
            }
            base.WriteExceptionError(exception);
        }
    }
}
