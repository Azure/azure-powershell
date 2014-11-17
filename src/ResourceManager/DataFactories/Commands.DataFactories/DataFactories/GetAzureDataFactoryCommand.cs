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

using System.Collections.Generic;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.DataFactories.Models;

namespace Microsoft.Azure.Commands.DataFactories
{
    [Cmdlet(VerbsCommon.Get, Constants.DataFactory), OutputType(typeof(List<PSDataFactory>), typeof(PSDataFactory))]
    public class GetAzureDataFactoryCommand : DataFactoryBaseCmdlet
    {
        [Parameter(Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The data factory name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }
        
        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            // ValidationNotNullOrEmpty doesn't handle whitespaces well
            if (Name != null && string.IsNullOrWhiteSpace(Name))
            {
                throw new PSArgumentNullException("Name");
            }

            DataFactoryFilterOptions filterOptions = new DataFactoryFilterOptions()
            {
                Name = Name,
                ResourceGroupName = ResourceGroupName
            };
            
            List<PSDataFactory> dataFactories = DataFactoryClient.FilterPSDataFactories(filterOptions);

            if (dataFactories != null)
            {
                if (dataFactories.Count == 1 && Name != null)
                {
                    WriteObject(dataFactories[0]);
                }
                else
                {
                    WriteObject(dataFactories, true);
                }
            }
        }
    }
}