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
using Microsoft.Azure.Commands.DataMigration.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataMigration;
using Microsoft.Azure.Management.DataMigration.Models;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    /// <summary>
    /// Class for the cmdlet to create task.
    /// </summary>
    [Cmdlet("Invoke", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataMigrationCommand", DefaultParameterSetName = ComponentNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(CommandProperties))]
    [Alias("Invoke-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DmsCommand")]
    public class InvokeDataMigrationCommand : DataMigrationCmdlet, IDynamicParameters
    {
        [Parameter(
          Mandatory = true,
          HelpMessage = "Command Type.")]
        [ValidateNotNullOrEmpty]
        public CommandTypeEnum CommandType
        {
            get
            {
                return commandType;
            }
            set
            {
                commandType = value;
                commandTypeSet = true;
            }
        }

        private CommandTypeEnum commandType;

        private bool commandTypeSet;

        [Parameter(
            Mandatory = true,
            ParameterSetName = ComponentNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the resource group.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = ComponentNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Database Migration Service Name.")]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = ComponentNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the project.")]
        [ValidateNotNullOrEmpty]
        public string ProjectName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the task the command is run on.")]
        [ValidateNotNullOrEmpty]
        public string TaskName { get; set; }

        private CommandCmdlet commandCmdlet = null;

        public object GetDynamicParameters()
        {
            RuntimeDefinedParameterDictionary dynamicParams = null;

            if (commandTypeSet)
            {
                CommandTypeEnum type = CommandType;
                switch (type)
                {
                    case CommandTypeEnum.CompleteSqlDBSync:
                        commandCmdlet = new CompleteCommandCmdlet(this.MyInvocation);
                        break;
                    case CommandTypeEnum.CancelMongoDB:
                        commandCmdlet = new MongoDbObjectCommandCmdlet(this.MyInvocation, CommandTypeEnum.CancelMongoDB);
                        break;
                    case CommandTypeEnum.RestartMongoDB:
                        commandCmdlet = new MongoDbObjectCommandCmdlet(this.MyInvocation, CommandTypeEnum.RestartMongoDB);
                        break;
                    case CommandTypeEnum.FinishMongoDB:
                        commandCmdlet = new MongoDbObjectCommandCmdlet(this.MyInvocation, CommandTypeEnum.FinishMongoDB);
                        break;
                    case CommandTypeEnum.CompleteSqlMiSync:
                        commandCmdlet = new CompleteMiSyncCommandCmdlet(this.MyInvocation);
                        break;
                    default:
                        throw new PSArgumentException();
                }

                dynamicParams = commandCmdlet.RuntimeDefinedParams;
            }

            return dynamicParams;
        }

        public override void ExecuteCmdlet()
        {
            if (commandCmdlet != null)
            {
                if (ShouldProcess(this.TaskName, Resources.createCommand))
                {
                    CommandProperties response = null;
                    try
                    {
                        CommandProperties commandInput = commandCmdlet.ProcessCommandCmdlet();

                        response = DataMigrationClient.Tasks.Command(ResourceGroupName, ServiceName, ProjectName, TaskName, commandInput);
                    }
                    catch (ApiErrorException ex)
                    {
                        ThrowAppropriateException(ex);
                    }

                    WriteObject(response);
                }
            }
            else
            {
                throw new PSArgumentException("Invalid Argument List");
            }
        }
    }
}