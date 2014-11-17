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
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataFactories
{
    public abstract class DataSliceContextBaseCmdlet : DataFactoryBaseCmdlet
    {
        private DateTime _endDateTime;

        [Parameter(ParameterSetName = ByFactoryObject, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
 HelpMessage = "The data factory object.")]
        public PSDataFactory DataFactory { get; set; }

        [Parameter(ParameterSetName = ByFactoryName, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The data factory name.")]
        [ValidateNotNullOrEmpty]
        public string DataFactoryName { get; set; }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The table name.")]
        [ValidateNotNullOrEmpty]
        public string TableName { get; set; }

        [Parameter(Position = 3, Mandatory = true, HelpMessage = "The data slice range start time.")]
        public DateTime StartDateTime { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = "The data slice range end time.")]
        public DateTime EndDateTime
        {
            get
            {
                return _endDateTime == default(DateTime)
                           ? StartDateTime + Constants.DefaultSliceActivePeriodDuration
                           : _endDateTime;
            }
            set
            {
                _endDateTime = value;
            }
        }
    }
}