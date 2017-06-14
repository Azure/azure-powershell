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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.OperationalInsights
{
    [Cmdlet(VerbsLifecycle.Disable, "AzureRmOperationalInsightsLinuxSyslogCollection", SupportsShouldProcess = true,
        DefaultParameterSetName = ByWorkspaceName), OutputType(typeof(PSDataSource))]
    public class DisableAzureOperationalInsightsLinuxSyslogCollectionCommand : AzureOperationalInsightsDataSourceBaseCmdlet
    {
        [Parameter(Position = 0, ParameterSetName = ByWorkspaceObject, Mandatory = true, ValueFromPipeline = true,
            HelpMessage = "The workspace that will contain the data source.")]
        [ValidateNotNull]
        public override PSWorkspace Workspace { get; set; }

        [Parameter(Position = 1, ParameterSetName = ByWorkspaceName, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        [Parameter(Position = 2, ParameterSetName = ByWorkspaceName, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the workspace that will contain the data source.")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        public override void ExecuteCmdlet()
        {
            PSDataSource dataSource = OperationalInsightsClient.GetSingletonDataSource(
                this.ResourceGroupName, 
                this.WorkspaceName, 
                PSDataSourceKinds.LinuxSyslogCollection);
            if (null == dataSource)
            {
                var dsProperties = new PSLinuxSyslogCollectionDataSourceProperties
                {
                    State = CollectionState.Disabled
                };

                CreatePSDataSourceWithProperties(dsProperties, Resources.SingletonDataSourceLinuxSyslogCollectionDefaultName);
            }
            else
            {
                PSLinuxSyslogCollectionDataSourceProperties dsProperties = dataSource.Properties as PSLinuxSyslogCollectionDataSourceProperties;
                dsProperties.State = CollectionState.Disabled;
                UpdatePSDataSourceParameters parameters = new UpdatePSDataSourceParameters
                {
                    ResourceGroupName = dataSource.ResourceGroupName,
                    WorkspaceName = dataSource.WorkspaceName,
                    Name = dataSource.Name,
                    Properties = dsProperties
                };
                WriteObject(OperationalInsightsClient.UpdatePSDataSource(parameters));
            }
        }
    }
}