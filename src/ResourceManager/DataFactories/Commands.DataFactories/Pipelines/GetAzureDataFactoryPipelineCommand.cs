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

using Microsoft.Azure.Commands.DataFactories.Models;
using Microsoft.Azure.Commands.DataFactories.Properties;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.DataFactories
{
    [Cmdlet(VerbsCommon.Get, Constants.Pipeline, DefaultParameterSetName = ByFactoryName), OutputType(typeof(List<PSPipeline>), typeof(PSPipeline))]
    public class GetAzureDataFactoryPipelineCommand : DataFactoryBaseCmdlet
    {
        [Parameter(Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The pipeline name.")]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ByFactoryObject, Position = 0, Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The data factory object.")]
        public PSDataFactory DataFactory { get; set; }

        [Parameter(ParameterSetName = ByFactoryName, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The data factory name.")]
        [ValidateNotNullOrEmpty]
        public string DataFactoryName { get; set; }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            // ValidationNotNullOrEmpty doesn't handle whitespaces well
            if (Name != null && string.IsNullOrWhiteSpace(Name))
            {
                throw new PSArgumentNullException("Name");
            }

            if (ParameterSetName == ByFactoryObject)
            {
                if (DataFactory == null)
                {
                    throw new PSArgumentNullException(string.Format(CultureInfo.InvariantCulture, Resources.DataFactoryArgumentInvalid));
                }

                DataFactoryName = DataFactory.DataFactoryName;
                ResourceGroupName = DataFactory.ResourceGroupName;
            }

            PipelineFilterOptions filterOptions = new PipelineFilterOptions()
            {
                Name = Name,
                ResourceGroupName = ResourceGroupName,
                DataFactoryName = DataFactoryName
            };

            if (Name != null)
            {
                List<PSPipeline> pipelines = DataFactoryClient.FilterPSPipelines(filterOptions);
                if (pipelines != null && pipelines.Any())
                {
                    WriteObject(pipelines.First());
                }
                return;
            }

            // List pipelines until all pages are fetched.
            do
            {
                WriteObject(DataFactoryClient.FilterPSPipelines(filterOptions), true);
            } while (filterOptions.NextLink.IsNextPageLink());
        }
    }
}
