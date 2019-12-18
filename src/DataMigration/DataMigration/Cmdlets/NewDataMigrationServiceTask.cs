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

using System.Management.Automation;
using Microsoft.Azure.Commands.DataMigration.Common;
using Microsoft.Azure.Commands.DataMigration.Models;
using Microsoft.Azure.Management.DataMigration;
using Microsoft.Azure.Management.DataMigration.Models;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataMigrationServiceTask", DefaultParameterSetName = ComponentNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSProjectTask))]
    [Alias("New-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DmsServiceTask")]
    public class NewDataMigrationServiceTask : DataMigrationCmdlet, IDynamicParameters
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the task.")]
        [ValidateNotNullOrEmpty]
        [Alias("TaskName")]
        public string Name { get; set; }

        [Parameter(
        Mandatory = true,
        HelpMessage = "Task Type.")]
        [ValidateNotNullOrEmpty]
        public TaskTypeEnum TaskType
        {
            get
            {
                return taskType;
            }
            set
            {
                taskType = value;
                taskTypeSet = true;
            }
        }

        [Parameter(
          Position = 0,
          Mandatory = true,
          ParameterSetName = ComponentObjectParameterSet,
          ValueFromPipeline = true,
          HelpMessage = "PSDataMigrationService Object.")]
        [ValidateNotNull]
        [Alias("Service")]
        public PSDataMigrationService InputObject { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Service Resource Id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = ComponentNameParameterSet,
            HelpMessage = "The name of the resource group."
                )]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = ComponentNameParameterSet,
            HelpMessage = "Database Migration Service Name.")]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = ComponentNameParameterSet,
            HelpMessage = "Whether to wait for the task to finish execution.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Wait { get; set; }

        public object GetDynamicParameters()
        {
            RuntimeDefinedParameterDictionary dynamicParams = null;

            if (taskTypeSet)
            {
                switch (taskType)
                {
                    case TaskTypeEnum.CheckOciDriver:
                        taskCmdlet = new GetOciDriverTaskCmdlet(this.MyInvocation);
                        break;
                    case TaskTypeEnum.UploadOciDriver:
                        taskCmdlet = new UploadOciDriverTaskCmdlet(this.MyInvocation);
                        break;
                    case TaskTypeEnum.InstallOciDriver:
                        taskCmdlet = new InstallOciDriverTaskCmdlet(this.MyInvocation);
                        break;
                    default:
                        throw new PSArgumentException();
                }

                dynamicParams = taskCmdlet.RuntimeDefinedParams;
            }

            return dynamicParams;
        }

        public override void ExecuteCmdlet()
        {
            if (taskCmdlet != null)
            {
                if (ShouldProcess(this.Name, Resources.createTask))
                {
                    if (this.ParameterSetName.Equals(ComponentObjectParameterSet))
                    {
                        this.ResourceGroupName = InputObject.ResourceGroupName;
                        this.ServiceName = InputObject.Name;
                    }

                    if (this.ParameterSetName.Equals(ResourceIdParameterSet))
                    {
                        DmsResourceIdentifier ids = new DmsResourceIdentifier(this.ResourceId);
                        this.ResourceGroupName = ids.ResourceGroupName;
                        this.ServiceName = ids.ServiceName;
                    }

                    ProjectTask response = null;
                    try
                    {
                        ProjectTaskProperties properties = taskCmdlet.ProcessTaskCmdlet();
                        var utcStartedOn = System.DateTime.UtcNow;
                        ProjectTask taskInput = new ProjectTask { Properties = properties };

                        response = DataMigrationClient.ServiceTasks.CreateOrUpdate(taskInput, ResourceGroupName, ServiceName, Name);

                        // wait for the task to finish: not queued or running state:
                        while (this.Wait.IsPresent && response != null && response.Properties != null &&
                            (response.Properties.State == "Queued" || response.Properties.State == "Running"))
                        {
                            System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(TaskWaitSleepIntervalInSeconds));
                            WriteVerbose($"{response.Id} {response.Name} {response.Properties.State} Elapsed: {System.DateTime.UtcNow - utcStartedOn}");
                            response = DataMigrationClient.ServiceTasks.Get(ResourceGroupName, ServiceName, Name, this.expandParameterOfTask);
                        }
                    }
                    catch (ApiErrorException ex)
                    {
                        ThrowAppropriateException(ex);
                    }

                    WriteObject(new PSProjectTask(response));
                }
            }
            else
            {
                throw new PSArgumentException("Invalid Argument List");
            }
        }

        // under -wait flag, we wait 5 seconds in between the polls for new status of task progress
        private const int TaskWaitSleepIntervalInSeconds = 5;

        // add a flag for expanding the fields of desired within the output. Especially if user provides
        // -Wait switch, the user expects the results contains the needed output fields, as it 
        // could save user from writing Get-AzureRmDataMigrationTask commandlet to pull these back.
        private string expandParameterOfTask = "output"; // default: $expand=output
        private ITaskCmdlet taskCmdlet = null;
        private TaskTypeEnum taskType;
        private bool taskTypeSet;
    }
}
