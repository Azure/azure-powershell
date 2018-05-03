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
    [Cmdlet(VerbsLifecycle.Stop, "AzureRmDataMigrationTask", DefaultParameterSetName = ComponentNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    [Alias("Stop-AzureRmDmsTask")]
    public class StopDataMigrationTask : DataMigrationCmdlet
    {
        [Parameter(
         Position = 0,
         Mandatory = true,
         ParameterSetName = ComponentObjectParameterSet,
         ValueFromPipeline = true,
         HelpMessage = "PSProjectTask Object.")]
        [ValidateNotNull]
        [Alias("ProjectTask")]
        public PSProjectTask InputObject { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "ProjectTask Resource Id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = ComponentNameParameterSet,
            HelpMessage = "The name of the resource group ."
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
            Mandatory = true,
            ParameterSetName = ComponentNameParameterSet,
            HelpMessage = "The name of the project.")]
        [ValidateNotNullOrEmpty]
        public string ProjectName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = ComponentNameParameterSet,
            HelpMessage = "The name of the task.")]
        [ValidateNotNullOrEmpty]
        [Alias("TaskName")]
        public string Name { get; set; }

        [Parameter(HelpMessage = "Returns an true/false. By default, this cmdlet does not generate any output.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(this.Name, Resources.stopTask))
            {
                if (this.ParameterSetName.Equals(ComponentObjectParameterSet))
                {
                    this.ResourceGroupName = InputObject.ResourceGroupName;
                    this.ServiceName = InputObject.ServiceName;
                    this.ProjectName = InputObject.ProjectName;
                    this.Name = InputObject.Name;
                }

                if (this.ParameterSetName.Equals(ResourceIdParameterSet))
                {
                    DmsResourceIdentifier ids = new DmsResourceIdentifier(this.ResourceId);
                    this.ResourceGroupName = ids.ResourceGroupName;
                    this.ServiceName = ids.ServiceName;
                    this.ProjectName = ids.ProjectName;
                    this.Name = ids.TaskName;
                }

                bool result = false;
                try
                {
                    DataMigrationClient.Tasks.Cancel(ResourceGroupName, ServiceName, ProjectName, Name);
                    result = true;
                }
                catch (ApiErrorException ex)
                {
                    ThrowAppropriateException(ex);
                }

                if (PassThru.IsPresent)
                {
                    WriteObject(result);
                }
            }
        }
    }
}
