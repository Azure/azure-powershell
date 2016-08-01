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
using System.Globalization;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.DataFactories
{
    [Cmdlet(VerbsCommon.Set, Constants.PipelineActivePeriod, DefaultParameterSetName = ByFactoryName,
        SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class SetAzureDataFactoryPipelineActivePeriodCommand : DataFactoryBaseCmdlet
    {
        private DateTime _endDateTime;

        [Alias("Name")]
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The pipeline name.")]
        [ValidateNotNullOrEmpty]
        public string PipelineName { get; set; }

        [Parameter(ParameterSetName = ByFactoryObject, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The data factory object.")]
        public PSDataFactory DataFactory { get; set; }

        [Parameter(ParameterSetName = ByFactoryName, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The data factory name.")]
        [ValidateNotNullOrEmpty]
        public string DataFactoryName { get; set; }

        [Parameter(Position = 3, Mandatory = true, HelpMessage = "The pipeline active period start time.")]
        public DateTime StartDateTime { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = "The pipeline active period end time.")]
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

        [Parameter(Mandatory = false, HelpMessage = "Auto resolve active periods of conflicting pipelines.")]
        public SwitchParameter AutoResolve { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Mark all data slices in the period as PendingExecution to force re-calculation.")]
        public SwitchParameter ForceRecalculate { get; set; }

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

            DateTime startTime = StartDateTime;
            DateTime endTime = EndDateTime;

            ConfirmAction(
                string.Format(
                    CultureInfo.InvariantCulture,
                    "Set pipeline '{0}' active period from '{1}' to '{2}'",
                    PipelineName,
                    startTime,
                    endTime),
                PipelineName,
                () =>
                DataFactoryClient.SetPipelineActivePeriod(
                    ResourceGroupName, DataFactoryName, PipelineName, startTime, endTime, AutoResolve.ToBool(), ForceRecalculate.ToBool()));

            WriteObject(true);
        }
    }
}