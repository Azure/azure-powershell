using Microsoft.Azure.Commands.DataMigration.Common;
using Microsoft.Azure.Commands.DataMigration.Models;
using Microsoft.Azure.Management.DataMigration;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    /// <summary>
    /// Class for the cmdlet to get project task details.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmDataMigrationTask", DefaultParameterSetName = DefaultParams), OutputType(typeof(IList<PSProjectTask>))]
    [Alias("Get-AzureRmDmsTask")]
    public class GetDataMigrationTask : DataMigrationCmdlet
    {
        private const string DefaultParams = ListByComponent;
        private const string ListByComponent = "ListByComponent";
        private const string GetByComponent = "GetByComponent";
        private const string GetByComponentResultType = "GetByComponentResultType";
        private const string ListByInputObject = "ListByInputObject";
        private const string GetByInputObject = "GetByInputObject";
        private const string GetByInputObjectResultType = "GetByInputObjectResultType";
        private const string ListByResourceId = "ListByResourceId";
        private const string GetByResourceId = "GetByResourceId";
        private const string GetByResourceIdResultType = "GetByResourceIdResultType";


        [Parameter(
          Position = 0,
          Mandatory = true,
          ParameterSetName = ListByInputObject,
          ValueFromPipeline = true,
          HelpMessage = "PSProject Object.")]
        [Parameter(ParameterSetName = GetByInputObject, Mandatory = true)]
        [Parameter(ParameterSetName = GetByInputObjectResultType, Mandatory = true)]
        [ValidateNotNull]
        [Alias("Project")]
        public PSProject InputObject { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ListByResourceId,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Project Resource Id.")]
        [ValidateNotNullOrEmpty]
        [Parameter(ParameterSetName = GetByResourceId, Mandatory = true)]
        [Parameter(ParameterSetName = GetByResourceIdResultType, Mandatory = true)]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = ListByComponent,
            HelpMessage = "The name of the resource group."
                )]
        [ValidateNotNullOrEmpty]
        [Parameter(ParameterSetName = GetByComponent, Mandatory = true)]
        [Parameter(ParameterSetName = GetByComponentResultType, Mandatory = true)]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = ListByComponent,
            HelpMessage = "Data Migration Service Name.")]
        [ValidateNotNullOrEmpty]
        [Parameter(ParameterSetName = GetByComponent, Mandatory = true)]
        [Parameter(ParameterSetName = GetByComponentResultType, Mandatory = true)]
        public string ServiceName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = ListByComponent,
            HelpMessage = "The name of the project.")]
        [Parameter(ParameterSetName = GetByComponent, Mandatory = true)]
        [Parameter(ParameterSetName = GetByComponentResultType, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string ProjectName { get; set; }

        [Parameter(
            ParameterSetName = GetByComponent,
            Mandatory = false,
            HelpMessage = "The name of the task.")]
        [Parameter(ParameterSetName = GetByComponentResultType, Mandatory = true)]
        [Parameter(ParameterSetName = GetByInputObject, Mandatory = true)]
        [Parameter(ParameterSetName = GetByInputObjectResultType, Mandatory = true)]
        [Parameter(ParameterSetName = GetByResourceId, Mandatory = true)]
        [Parameter(ParameterSetName = GetByResourceIdResultType, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        [Alias("TaskName")]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = GetByComponent,
            Mandatory = false,
            HelpMessage = "Expand output")]
        [Parameter(ParameterSetName = GetByComponentResultType, Mandatory = true)]
        [Parameter(ParameterSetName = GetByInputObject, Mandatory = false)]
        [Parameter(ParameterSetName = GetByInputObjectResultType, Mandatory = true)]
        [Parameter(ParameterSetName = GetByResourceId, Mandatory = false)]
        [Parameter(ParameterSetName = GetByResourceIdResultType, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Expand { get; set; }

        [Parameter(
            ParameterSetName = GetByComponentResultType,
            Mandatory = true,
            HelpMessage = "Expand output of given result type.")]
        [Parameter(ParameterSetName = GetByInputObjectResultType, Mandatory = true)]
        [Parameter(ParameterSetName = GetByResourceIdResultType, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ResultTypeEnum ResultType { get; set; }

        [Parameter(
            ParameterSetName = ListByComponent,
            Mandatory = false,
            HelpMessage = "Filter by TaskType.")]
        [Parameter(ParameterSetName = ListByInputObject, Mandatory = false)]
        [Parameter(ParameterSetName = ListByResourceId, Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public TaskTypeEnum? TaskType { get; set; }

        public override void ExecuteCmdlet()
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

            IList<PSProjectTask> results = new List<PSProjectTask>();

            if ((MyInvocation.BoundParameters.ContainsKey("ServiceName") || !string.IsNullOrEmpty(this.ServiceName))
                && (MyInvocation.BoundParameters.ContainsKey("ResourceGroupName") || !string.IsNullOrEmpty(this.ResourceGroupName))
                && (MyInvocation.BoundParameters.ContainsKey("ProjectName") || !string.IsNullOrEmpty(this.ProjectName))
                && (MyInvocation.BoundParameters.ContainsKey("Name") || !string.IsNullOrEmpty(this.Name)))
            {
                results.Add(new PSProjectTask(DataMigrationClient.Tasks.Get(this.ResourceGroupName, this.ServiceName, this.ProjectName, this.Name, this.ExpandFilter())));
            }
            else if ((MyInvocation.BoundParameters.ContainsKey("ServiceName") || !string.IsNullOrEmpty(this.ServiceName))
                && (MyInvocation.BoundParameters.ContainsKey("ResourceGroupName") || !string.IsNullOrEmpty(this.ResourceGroupName))
                && (MyInvocation.BoundParameters.ContainsKey("ProjectName") || !string.IsNullOrEmpty(this.ProjectName)))
            {
                string taskType = TaskType?.ToString();
                DataMigrationClient.Tasks.EnumerateTaskByProjects(ResourceGroupName, ServiceName, ProjectName, taskType)
                    .ForEach(item =>
                    {
                        results.Add(new PSProjectTask(item));
                    });
            }
            else
            {
                throw new PSArgumentException("Invalid Argument List");
            }

            WriteObject(results, true);
        }

        private string ExpandFilter()
        {
            string expandFilter = null;

            if (Expand.IsPresent)
            {
                if (Expand && MyInvocation.BoundParameters.ContainsKey("ResultType"))
                {
                    expandFilter = string.Format("output($filter= ResultType eq '{0}')", ResultType.ToString());
                }
                else
                {
                    expandFilter = "output";
                }
            }

            return expandFilter;
        }
    }
}
