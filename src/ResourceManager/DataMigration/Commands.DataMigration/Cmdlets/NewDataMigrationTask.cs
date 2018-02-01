// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewDataMigrationTask.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.Azure.Commands.DataMigration.Common;
using Microsoft.Azure.Commands.DataMigration.Models;
using Microsoft.Azure.Management.DataMigration;
using Microsoft.Azure.Management.DataMigration.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    /// <summary>
    /// Class for the cmdlet to create task.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmDataMigrationTask", DefaultParameterSetName = ComponentNameParameterSet , SupportsShouldProcess = true), OutputType(typeof(PSProjectTask))]
    [Alias("New-AzureRmDmsTask")]
    public class NewDataMigrationTask : DataMigrationCmdlet, IDynamicParameters
    {
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
            HelpMessage = "Data Migration Service Name.")]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = ComponentNameParameterSet,
            HelpMessage = "The name of the project.")]
        [ValidateNotNullOrEmpty]
        public string ProjectName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the task.")]
        [ValidateNotNullOrEmpty]
        [Alias("TaskName")]
        public string Name { get; set; }

        private TaskCmdlet taskCmdlet = null;

        public object GetDynamicParameters()
        {
            RuntimeDefinedParameterDictionary dynamicParams = null;

            if (taskTypeSet)
            {

                switch (taskType)
                {
                    case TaskTypeEnum.ConnectToSourceSqlServer:
                        taskCmdlet = new ConnectToSourceSqlServerTaskCmdlet(this.MyInvocation);
                        break;
                    case TaskTypeEnum.MigrateSqlServerSqlDb:
                        taskCmdlet = new MigrateSqlServerSqlDbTaskCmdlet(this.MyInvocation);
                        break;
                    case TaskTypeEnum.ConnectToTargetSqlDb:
                        taskCmdlet = new ConnectToTargetSqlDbTaskCmdlet(this.MyInvocation);
                        break;
                    case TaskTypeEnum.GetUserTablesSql:
                        taskCmdlet = new GetUserTableSqlCmdlet(this.MyInvocation);
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
                        ProjectTask taskInput = new ProjectTask()
                        {
                            Properties = taskCmdlet.ProcessTaskCmdlet()
                        };

                        response = DataMigrationClient.Tasks.CreateOrUpdate(taskInput, ResourceGroupName, ServiceName, ProjectName, Name);
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
