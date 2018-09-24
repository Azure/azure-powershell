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

using Microsoft.Azure.Commands.DataFactories.Models;
using Microsoft.Azure.Commands.DataFactories.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Globalization;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.DataFactories
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataFactoryDataset", DefaultParameterSetName = ByFactoryName,SupportsShouldProcess = true), OutputType(typeof(PSDataset))]
    public class NewAzureDataFactoryDatasetCommand : DataFactoryBaseCmdlet
    {
        [Parameter(ParameterSetName = ByFactoryObject, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
HelpMessage = "The data factory object.")]
        public PSDataFactory DataFactory { get; set; }

        [Parameter(ParameterSetName = ByFactoryName, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The data factory name.")]
        [ValidateNotNullOrEmpty]
        public string DataFactoryName { get; set; }

        [Parameter(Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The dataset name.")]
        public string Name { get; set; }

        [Parameter(Position = 3, Mandatory = true, HelpMessage = "The dataset JSON file path.")]
        [ValidateNotNullOrEmpty]
        public string File { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Don't ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ByFactoryObject)
            {
                if (DataFactory == null)
                {
                    throw new PSArgumentNullException(string.Format(CultureInfo.InvariantCulture, Resources.DataFactoryArgumentInvalid));
                }

                DataFactoryName = DataFactory.DataFactoryName;
                ResourceGroupName = DataFactory.ResourceGroupName;
            }

            // Resolve the file path and read the raw content
            string rawJsonContent = DataFactoryClient.ReadJsonFileContent(this.TryResolvePath(File));

            // Resolve any mismatch between -Name and the name written in JSON
            Name = ResolveResourceName(rawJsonContent, Name, "Dataset");

            CreatePSDatasetParameters parameters = new CreatePSDatasetParameters()
            {
                ResourceGroupName = ResourceGroupName,
                DataFactoryName = DataFactoryName,
                Name = Name,
                RawJsonContent = rawJsonContent,
                Force = Force.IsPresent,
                ConfirmAction = ConfirmAction
            };

            WriteObject(DataFactoryClient.CreatePSDataset(parameters));
        }
    }
}
