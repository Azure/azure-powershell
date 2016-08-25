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
    [Cmdlet(VerbsCommon.Get, Constants.ActivityWindows, DefaultParameterSetName = ByFactoryName), OutputType(typeof(List<PSActivityWindow>))]
    public class GetAzureDataFactoryActivityWindowsCommand : DataFactoryBaseCmdlet
    {
        [Parameter(ParameterSetName = ByFactoryObject, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The data factory object.")]
        public PSDataFactory DataFactory { get; set; }

        [Parameter(ParameterSetName = ByFactoryName, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The data factory name.")]
        [ValidateNotNullOrEmpty]
        public string DataFactoryName { get; set; }

        [Parameter(Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The dataset name.")]
        [ValidateNotNullOrEmpty]
        public string DatasetName { get; set; }

        [Parameter(Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The pipeline name.")]
        [ValidateNotNullOrEmpty]
        public string PipelineName { get; set; }

        [Parameter(Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The pipeline activity name.")]
        [ValidateNotNullOrEmpty]
        public string ActivityName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The state of the activity window. The possible states includes: None, Waiting, InProgress, Ready, Failed, and Skipped")]
        [ValidateNotNullOrEmpty]
        public string WindowState { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The substate of the activity window. The possible substates includes: Canceled, timedOut, Validating," +
            " ScheduledTime, DatasetDependencies, ComputeResources, ConcurrencyLimit, ActivityResume, Retry, Validation, ValidationRetry.")]
        [ValidateNotNullOrEmpty]
        public string WindowSubstate { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The activity window filter based on Azure Search filter " +
                          "grammar. For more information see https://msdn.microsoft.com/en-us/library/azure/dn798921.aspx")]
        [ValidateNotNullOrEmpty]
        public string Filter { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Order the response by one of the activity window list parameters.")]
        [ValidateNotNullOrEmpty]
        public string OrderBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The activity window start time.")]
        [ValidateNotNullOrEmpty]
        public DateTime? WindowStart { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The activity window end time.")]
        [ValidateNotNullOrEmpty]
        public DateTime? WindowEnd { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The activity window run start time.")]
        [ValidateNotNullOrEmpty]
        public DateTime? RunStart { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The activity window run end time.")]
        [ValidateNotNullOrEmpty]
        public DateTime? RunEnd { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The number of activity windows to be listed.")]
        [ValidateNotNullOrEmpty]
        public int? Top { get; set; }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            if (this.ParameterSetName == ByFactoryObject)
            {
                if (this.DataFactory == null)
                {
                    throw new PSArgumentNullException(string.Format(CultureInfo.InvariantCulture, Resources.DataFactoryArgumentInvalid));
                }

                this.DataFactoryName = DataFactory.DataFactoryName;
                this.ResourceGroupName = DataFactory.ResourceGroupName;
            }

            ActivityWindowFilterOptions filterOptions = new ActivityWindowFilterOptions()
            {
                ResourceGroupName = this.ResourceGroupName,
                DataFactoryName = this.DataFactoryName,
                ActivityName = this.ActivityName,
                DatasetName = this.DatasetName,
                PipelineName = this.PipelineName,
                Filter = Filter,
                OrderBy = this.OrderBy,
                RunEnd = this.RunEnd,
                RunStart = this.RunStart,
                Top = this.Top,
                WindowEnd = this.WindowEnd,
                WindowStart = this.WindowStart,
                WindowState = this.WindowState,
                WindowSubstate = this.WindowSubstate
            };

            try
            {
                do
                {
                    List<PSActivityWindow> activityWindows = DataFactoryClient.ProcessListFilterActivityWindows(filterOptions);
                    WriteObject(activityWindows, true);
                } while (filterOptions.NextLink.IsNextPageLink());
            }
            catch (PSArgumentException e)
            {
                WriteWarning(e.Message);
            }
        }
    }
}