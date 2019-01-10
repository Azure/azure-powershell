﻿// ----------------------------------------------------------------------------------
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
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.OperationalInsights
{
    public abstract class AzureOperationalInsightsDataSourceBaseCmdlet : OperationalInsightsBaseCmdlet
    {
        public virtual PSWorkspace Workspace { get; set; }

        public virtual string ResourceGroupName { get; set; }

        public virtual string WorkspaceName { get; set; }

        public virtual SwitchParameter Force { get; set; }


        protected override void BeginProcessing()
        {
            if (ParameterSetName == ByWorkspaceObject)
            {
                ResourceGroupName = Workspace.ResourceGroupName;
                WorkspaceName = Workspace.Name;
            }
            base.BeginProcessing();
        }

        protected void CreatePSDataSourceWithProperties(PSDataSourcePropertiesBase createParameters, string dataSourceName)
        {
            CreatePSDataSourceParameters parameters = new CreatePSDataSourceParameters()
            {
                Name = dataSourceName,
                Properties = createParameters,
                ResourceGroupName = this.ResourceGroupName,
                WorkspaceName = this.WorkspaceName,
                Force = Force.IsPresent,
                ConfirmAction = ConfirmAction
            };
            WriteObject(OperationalInsightsClient.CreatePSDataSource(parameters));
        }

    }
}