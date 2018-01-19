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

using Microsoft.Azure.Commands.EventHub.Models;
using Microsoft.Azure.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.EventHub.Commands.Namespace
{
    /// <summary>
    /// 'Get-AzureRmEventHubOperation' Cmdlet retrive the Operations List
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmEventHubOperation"), OutputType(typeof(List<PSOperationAttributes>))]
    public class GetAzureEventHubOperations : AzureEventHubsCmdletBase
    {
        public override void ExecuteCmdlet()
        {   
            IEnumerable<PSOperationAttributes> GetOperationsResult = Client.GetOperations();
            WriteObject(GetOperationsResult, true);
        }
    }
}   