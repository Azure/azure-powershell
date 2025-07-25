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
    [Cmdlet(VerbsCommon.Move, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceDatabase",
        SupportsShouldProcess = true,
        DefaultParameterSetName = MoveCopyManagedDatabaseByNameParameterSet),
        OutputType(typeof(MoveCopyManagedDatabaseModel))]
    public class MoveAzureSqlManagedDatabase : MoveCopyAzureSqlManagedDatabaseBase
    {
        protected override string ShouldProcessConfirmationMessage => "Moving managed database from one managed instance to another";

        protected override MoveCopyManagedDatabaseModel PersistChanges(MoveCopyManagedDatabaseModel model)
        {
            model.OperationMode = OperationMode.Move;
            ModelAdapter.MoveManagedDatabase(model);

            return model;
        }

        protected override object TransformModelToOutputObject(MoveCopyManagedDatabaseModel model)
        {
            return model;
        }
    }
}
