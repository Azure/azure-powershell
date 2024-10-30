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
    /// <summary>
    /// Class for the cmdlet to create task.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataMigrationTask", DefaultParameterSetName = ComponentNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSProjectTask))]
    [Alias("New-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DmsTask")]
    public class NewDataMigrationTask : DataMigrationCmdlet, IDynamicParameters
    {
        // under -wait flag, we wait 5 seconds in between the polls for
        // new status of task progress
        private const int TaskWaitSleepIntervalInSeconds = 5;

        [Parameter(
          Position = 0,
          Mandatory = true,
          ParameterSetName = ComponentObjectParameterSet,
          ValueFromPipeline = true,
          HelpMessage = "PSProject Object.")]
        [ValidateNotNull]
        [Alias("Project")]
        public PSProject InputObject { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Project Resource Id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

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

        private TaskTypeEnum taskType;

        private bool taskTypeSet;

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
            HelpMessage = "Azure Database Migration Service (classic) Name.")]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = ComponentNameParameterSet,
            HelpMessage = "The name of the project.")]
        [ValidateNotNullOrEmpty]
        public string ProjectName { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = ComponentNameParameterSet,
            HelpMessage = "Whether to wait for the task to finish execution.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Wait { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the task.")]
        [ValidateNotNullOrEmpty]
        [Alias("TaskName")]
        public string Name { get; set; }

        private ITaskCmdlet taskCmdlet = null;

        // add a flag for expanding the fields of desired within the output. Especially if user provides
        // -Wait switch, the user expects the results contains the needed output fields, as it 
        // could save user from writing Get-AzureRmDataMigrationTask commandlet to pull these back.
        private string expandParameterOfTask = "output"; // default: $expand=output

        public new object GetDynamicParameters()
        {
            RuntimeDefinedParameterDictionary dynamicParams = null;

            if (taskTypeSet)
            {
                switch (taskType)
                {
                    case TaskTypeEnum.ConnectToSourceSqlServer:
                        taskCmdlet = new ConnectToSourceSqlServerTaskCmdlet(this.MyInvocation);
                        expandParameterOfTask = "output";
                        break;
                    case TaskTypeEnum.MigrateSqlServerSqlDb:
                        taskCmdlet = new MigrateSqlServerSqlDbTaskCmdlet(this.MyInvocation);
                        expandParameterOfTask = ""; // default not to get output upon wait.
                        break;
                    case TaskTypeEnum.ConnectToTargetSqlDb:
                        taskCmdlet = new ConnectToTargetSqlDbTaskCmdlet(this.MyInvocation);
                        expandParameterOfTask = "output";
                        break;
                    case TaskTypeEnum.GetUserTablesSql:
                        taskCmdlet = new GetUserTableSqlCmdlet(this.MyInvocation);
                        expandParameterOfTask = "output";
                        break;
                    case TaskTypeEnum.ConnectToTargetSqlDbMi:
                        taskCmdlet = new ConnectToTargetSqlDbMiTaskCmdlet(this.MyInvocation);
                        expandParameterOfTask = "output";
                        break;
                    case TaskTypeEnum.MigrateSqlServerSqlDbMi:
                        taskCmdlet = new MigrateSqlServerSqlDbMiTaskCmdlet(this.MyInvocation);
                        expandParameterOfTask = ""; // default not to get output upon wait.
                        break;
                    case TaskTypeEnum.ValidateSqlServerSqlDbMi:
                        taskCmdlet = new ValidateSqlServerSqlDbMiTaskCmdlet(this.MyInvocation);
                        expandParameterOfTask = "output";
                        break;
                    case TaskTypeEnum.ConnectToSourceSqlServerSync:
                        taskCmdlet = new ConnectToSourceSqlServerSyncTaskCmdlet(this.MyInvocation);
                        expandParameterOfTask = "output";
                        break;
                    case TaskTypeEnum.MigrateSqlServerSqlDbSync:
                        taskCmdlet = new MigrateSqlServerSqlDbSyncTaskCmdlet(this.MyInvocation);
                        expandParameterOfTask = ""; // default not to get output upon wait.
                        break;
                    case TaskTypeEnum.ConnectToTargetSqlSync:
                        taskCmdlet = new ConnectToTargetSqlSqlDbSyncTaskCmdlet(this.MyInvocation);
                        expandParameterOfTask = "output";
                        break;
                    case TaskTypeEnum.GetUserTablesSqlSync:
                        taskCmdlet = new GetUserTableSqlSyncCmdlet(this.MyInvocation);
                        expandParameterOfTask = "output";
                        break;
                    case TaskTypeEnum.ValidateSqlServerSqlDbSync:
                        taskCmdlet = new ValidateSqlServerSqlDbSyncTaskCmdlet(this.MyInvocation);
                        expandParameterOfTask = "output";
                        break;
                    case TaskTypeEnum.ConnectToSourceMongoDb:
                        taskCmdlet = new ConnectToSourceMongoDbTaskCmdlet(this.MyInvocation);
                        expandParameterOfTask = "output";
                        break;
                    case TaskTypeEnum.ConnectToTargetMongoDb:
                        taskCmdlet = new ConnectToTargetMongoDbTaskCmdlet(this.MyInvocation);
                        expandParameterOfTask = "output";
                        break;
                    case TaskTypeEnum.MigrateMongoDb:
                        taskCmdlet = new MigrateMongoDbTaskCmdlet(this.MyInvocation);
                        expandParameterOfTask = "output($filter=ResultType eq 'Migration' or ResultType eq 'Database')";
                        break;
                    case TaskTypeEnum.ValidateMongoDbMigration:
                        taskCmdlet = new ValidateMongoDbMigrationTaskCmdlet(this.MyInvocation);
                        expandParameterOfTask = "output($filter=ResultType eq 'Migration' or ResultType eq 'Database')";
                        break;
                    case TaskTypeEnum.ConnectToTargetSqlDbMiSync:
                        taskCmdlet = new ConnectToTargetSqlDbMiSyncTaskCmdlet(this.MyInvocation);
                        expandParameterOfTask = "output";
                        break;
                    case TaskTypeEnum.ValidateSqlServerSqlDbMiSync:
                        taskCmdlet = new ValidateSqlServerSqlDbMiSyncTaskCmdlet(this.MyInvocation);
                        expandParameterOfTask = "output";
                        break;
                    case TaskTypeEnum.MigrateSqlServerSqlDbMiSync:
                        taskCmdlet = new MigrateSqlServerSqlDbMiSyncTaskCmdlet(this.MyInvocation);
                        expandParameterOfTask = "";
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
                        this.ServiceName = InputObject.ServiceName;
                        this.ProjectName = InputObject.Name;
                    }

                    if (this.ParameterSetName.Equals(ResourceIdParameterSet))
                    {
                        DmsResourceIdentifier ids = new DmsResourceIdentifier(this.ResourceId);
                        this.ResourceGroupName = ids.ResourceGroupName;
                        this.ServiceName = ids.ServiceName;
                        this.ProjectName = ids.ProjectName;
                    }

                    ProjectTask response = null;
                    try
                    {
                        ProjectTaskProperties properties = taskCmdlet.ProcessTaskCmdlet();

                        var utcStartedOn = System.DateTime.UtcNow;
                        // need swagger of -pr line 64 of tasks.json add.
                        // uncomment the following line once we get new sdk.
                        // give all tasks a start time, so that portal can calculate how long it is running.
                        // properties.ClientData.Add("startedOn", utcStartedOn.ToString("o")); 

                        ProjectTask taskInput = new ProjectTask()
                        {
                            Properties = properties
                        };

                        response = DataMigrationClient.Tasks.CreateOrUpdate(ResourceGroupName, ServiceName, ProjectName, Name, taskInput);

                        // wait for the task to finish: not queued or running state:
                        while (this.Wait.IsPresent && response !=null && response.Properties != null &&
                            ( response.Properties.State == "Queued" || response.Properties.State == "Running" ) )
                        {
                            System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(TaskWaitSleepIntervalInSeconds));
                            WriteVerbose($"{response.Id} {response.Name} {response.Properties.State} Elapsed: {System.DateTime.UtcNow - utcStartedOn}");
                            response = DataMigrationClient.Tasks.Get(ResourceGroupName, ServiceName, ProjectName, Name, this.expandParameterOfTask);
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
    }
}
