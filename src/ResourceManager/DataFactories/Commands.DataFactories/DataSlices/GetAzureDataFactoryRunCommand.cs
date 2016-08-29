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
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.DataFactories
{
    [Cmdlet(VerbsCommon.Get, Constants.Run, DefaultParameterSetName = ByFactoryName), OutputType(typeof(List<PSDataSliceRun>))]
    public class GetAzureDataFactoryRunCommand : DataFactoryBaseCmdlet
    {
        [Parameter(ParameterSetName = ByFactoryObject, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The data factory object.")]
        public PSDataFactory DataFactory { get; set; }

        [Parameter(ParameterSetName = ByFactoryName, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The data factory name.")]
        [ValidateNotNullOrEmpty]
        public string DataFactoryName { get; set; }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The dataset name.")]
        [ValidateNotNullOrEmpty]
        public string DatasetName { get; set; }

        [Parameter(Position = 3, Mandatory = true, HelpMessage = "The start time of the data slice queried.")]
        public DateTime StartDateTime { get; set; }

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

            DataSliceRunFilterOptions filterOptions = new DataSliceRunFilterOptions()
            {
                ResourceGroupName = ResourceGroupName,
                DataFactoryName = DataFactoryName,
                DatasetName = this.DatasetName,
                StartDateTime = StartDateTime
            };

            int totalDataSliceRuns = 0;

            do
            {
                var dataSliceRuns = DataFactoryClient.ListDataSliceRuns(filterOptions);
                totalDataSliceRuns += dataSliceRuns.Count;
                WriteObject(dataSliceRuns, true);
            } while (filterOptions.NextLink.IsNextPageLink());

            if (totalDataSliceRuns == 0)
            {
                WriteWarning(string.Format(CultureInfo.InvariantCulture, Resources.NoDataSliceFound));
            }
        }
    }
}