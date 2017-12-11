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
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.DataFactoryV2.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    [Cmdlet(VerbsCommon.Get, Constants.DataFactory, DefaultParameterSetName = ParameterSetNames.BySubscriptionId),
        OutputType(typeof(List<PSDataFactory>), typeof(PSDataFactory))]
    public class GetAzureDataFactoryCommand : DataFactoryBaseCmdlet
    {
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpResourceGroup)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryName)]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.DataFactoryName)]
        public string Name { get; set; }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            var filterOptions = new DataFactoryFilterOptions();
            if (ParameterSetName.Equals(ParameterSetNames.ByFactoryName, StringComparison.OrdinalIgnoreCase))
            {
                filterOptions.DataFactoryName = Name;
                filterOptions.ResourceGroupName = ResourceGroupName;
            };

            //List data factories until all pages are fetched
            do
            {
                WriteObject(DataFactoryClient.FilterPSDataFactories(filterOptions), true);
            } while (filterOptions.NextLink.IsNextPageLink());
        }
    }
}