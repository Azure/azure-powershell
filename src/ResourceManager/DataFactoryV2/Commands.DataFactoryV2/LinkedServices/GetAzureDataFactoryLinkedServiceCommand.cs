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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.DataFactoryV2.Models;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    [Cmdlet(VerbsCommon.Get, Constants.LinkedService, DefaultParameterSetName = ParameterSetNames.ByFactoryName), OutputType(typeof(List<PSLinkedService>), typeof(PSLinkedService))]
    public class GetAzureDataFactoryLinkedServiceCommand : DataFactoryContextBaseGetCmdlet
    {
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpLinkedServiceName)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryObject, Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpLinkedServiceName)]
        [Alias(Constants.LinkedServiceName)]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            ByResourceId();
            ByFactoryObject();

            AdfEntityFilterOptions filterOptions = new AdfEntityFilterOptions()
            {
                Name = Name,
                ResourceGroupName = ResourceGroupName,
                DataFactoryName = DataFactoryName
            };

            if (Name != null)
            {
                List<PSLinkedService> linkedServices = DataFactoryClient.FilterPSLinkedServices(filterOptions);

                if (linkedServices != null && linkedServices.Any())
                {
                    WriteObject(linkedServices[0]);
                }
                return;
            }

            // List all linked services until all pages are fetched.
            do
            {
                WriteObject(DataFactoryClient.FilterPSLinkedServices(filterOptions), true);
            } while (filterOptions.NextLink.IsNextPageLink());
        }
    }
}
