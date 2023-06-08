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

using Microsoft.Azure.Commands.Sql.ManagedDatabase.Model;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabase.Cmdlet
{
    [Cmdlet(VerbsLifecycle.Complete, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceDatabaseMove",
        SupportsShouldProcess = true,
        DefaultParameterSetName = MoveCopyManagedDatabaseByNameParameterSet),
        OutputType(typeof(bool))]
    public class CompleteAzureSqlManagedDatabaseMove : MoveCopyAzureSqlManagedDatabaseBase
    {
        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation")]
        public SwitchParameter Force { get; set; }


        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "CompleteManagedDatabaseMoveByMoveModelObject", HelpMessage = "Object that is returned from start move operation.")]
        [ValidateNotNullOrEmpty]
        public MoveCopyManagedDatabaseModel MoveModelObject { get; set; }

        protected override string ShouldProcessConfirmationMessage => "Complete ongoing manage database move operation";

        protected override MoveCopyManagedDatabaseModel PersistChanges(MoveCopyManagedDatabaseModel model)
        {
            if (Force || ShouldContinue(
                $"By completing move, database on the source managed instance '{InstanceName}' will be deleted",
                "Are you sure?"))
            {
                if (MoveModelObject != null)
                {
                    ModelAdapter.CompleteMove(MoveModelObject);
                    return MoveModelObject;
                }
                ModelAdapter.CompleteMove(model);
            }
            
            return model;
        }
    }
}
