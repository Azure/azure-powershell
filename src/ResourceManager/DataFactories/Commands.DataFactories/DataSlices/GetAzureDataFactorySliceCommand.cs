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
    [Cmdlet(VerbsCommon.Get, Constants.DataSlice, DefaultParameterSetName = ByFactoryName), OutputType(typeof(List<PSDataSlice>))]
    public class GetAzureDataFactorySliceCommand : DataSliceContextBaseCmdlet
    {
        [Parameter(Position = 4, Mandatory = false, HelpMessage = "The data slice range end time.")]
        public DateTime EndDateTime
        {
            get
            {
                if (_endDateTime == default(DateTime))
                {
                    WriteWarning(Resources.EndDateTimeNotSpecifiedForGetSlice);
                    return StartDateTime + Constants.DefaultSliceActivePeriodDuration;
                }

                return _endDateTime;
            }
            set
            {
                _endDateTime = value;
            }
        }

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

            DataSliceFilterOptions filterOptions = new DataSliceFilterOptions()
            {
                ResourceGroupName = ResourceGroupName,
                DataFactoryName = DataFactoryName,
                DatasetName = this.DatasetName,
                DataSliceRangeStartTime = StartDateTime,
                DataSliceRangeEndTime = EndDateTime
            };

            int totalDataSlices = 0;
            do
            {
                var dataSlices = DataFactoryClient.ListDataSlices(filterOptions);
                totalDataSlices += dataSlices.Count;
                WriteObject(dataSlices, true);
            } while (filterOptions.NextLink.IsNextPageLink());

            if (totalDataSlices == 0)
            {
                WriteWarning(string.Format(CultureInfo.InvariantCulture, Resources.NoDataSliceFound));
            }
        }
    }
}