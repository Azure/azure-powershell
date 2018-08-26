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
using System.Globalization;
using System.Management.Automation;
using System.Net;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.DataFactories
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataFactory", DefaultParameterSetName = ByFactoryName, SupportsShouldProcess = true), OutputType(typeof(void))]
    public class RemoveAzureDataFactoryCommand : DataFactoryBaseCmdlet
    {
        [Parameter(ParameterSetName = ByFactoryName, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The data factory name.")]
        [Alias("DataFactoryName")]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ByFactoryObject, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The data factory object.")]
        public PSDataFactory DataFactory { get; set; }

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

                Name = DataFactory.DataFactoryName;
                ResourceGroupName = DataFactory.ResourceGroupName;
            }

            ConfirmAction(
                Force.IsPresent,
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.DataFactoryConfirmationMessage,
                    Name,
                    ResourceGroupName),
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.DataFactoryRemoving,
                    Name,
                    ResourceGroupName),
                Name,
                ExecuteDelete);
        }

        public void ExecuteDelete()
        {
            HttpStatusCode response = DataFactoryClient.DeleteDataFactory(ResourceGroupName, Name);

            if (response == HttpStatusCode.NoContent)
            {
                WriteWarning(string.Format(CultureInfo.InvariantCulture, Resources.DataFactoryNotFound, Name,
                    ResourceGroupName));
            }
        }
    }
}
