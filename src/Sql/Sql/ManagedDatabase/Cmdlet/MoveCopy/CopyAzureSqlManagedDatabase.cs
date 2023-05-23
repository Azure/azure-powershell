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
    [Cmdlet(VerbsCommon.Copy, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceDatabase",
        SupportsShouldProcess = true,
        DefaultParameterSetName = MoveCopyManagedDatabaseByNameParameterSet),
        OutputType(typeof(void))]
    public class CopyAzureSqlManagedDatabase : MoveCopyAzureSqlManagedDatabaseBase
    {
        protected override MoveCopyManagedDatabaseModel PersistChanges(MoveCopyManagedDatabaseModel model)
        {
            if (ShouldProcess(DatabaseName, $"Copying database to managed instance {model.TargetManagedInstanceName} in resource group {model.TargetResourceGroupName}"))
            {
                model.OperationMode = OperationMode.COPY;
                ModelAdapter.MoveManagedDatabase(model);
            }
            
            return null;
        }
    }
}
