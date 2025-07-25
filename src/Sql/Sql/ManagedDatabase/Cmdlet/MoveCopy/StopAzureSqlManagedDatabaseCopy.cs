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
    [Cmdlet(VerbsLifecycle.Stop, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceDatabaseCopy",
        SupportsShouldProcess = true,
        DefaultParameterSetName = MoveCopyManagedDatabaseByNameParameterSet),
        OutputType(typeof(bool))]
    public class StopAzureSqlManagedDatabaseCopy : MoveCopyAzureSqlManagedDatabaseBase
    {
        protected override string ShouldProcessConfirmationMessage => "Stop ongoing managed database copy operation";

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "CancelManagedDatabaseCopyByCopyModelObject", HelpMessage = "Object that is returned from start copy operation.")]
        [ValidateNotNullOrEmpty]
        public MoveCopyManagedDatabaseModel CopyModelObject { get; set; }


        protected override MoveCopyManagedDatabaseModel PersistChanges(MoveCopyManagedDatabaseModel model)
        {
            if (CopyModelObject != null)
            {
                ModelAdapter.CancelMove(CopyModelObject);
                return CopyModelObject;
            }
            ModelAdapter.CancelMove(model);
            return model;
        }
    }
}
