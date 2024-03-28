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

using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.Support.Common;
using Microsoft.Azure.Commands.Support.Helpers;
using Microsoft.Azure.Commands.Support.Models;
using Microsoft.Azure.Management.Support;
using Microsoft.Azure.Management.Support.Models;
using Microsoft.Azure.PowerShell.Cmdlets.Support.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Linq;
using System.Management.Automation;
using static Microsoft.Azure.Commands.Support.Helpers.ResourceIdentifierHelper;

namespace Microsoft.Azure.Commands.Support.Services
{
    [CmdletOutputBreakingChangeWithVersion(typeof(PSSupportService), "12.0.0", "2.0.0", ChangeDescription = "Output property name 'ResourceTypes' will be changed to 'ResourceType'.")]
    [Cmdlet(VerbsCommon.Get, AzureRMConstants.AzureRMPrefix + "SupportService", DefaultParameterSetName = ListParameterSet), OutputType(typeof(PSSupportService))]
    public class GetAzSupportService : AzSupportCmdletBase
    {
        [CmdletParameterBreakingChangeWithVersion("Id", "12.0.0", "2.0.0", ChangeDescription = "Parameter name 'Id' will be changed to 'Name'.")]
        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet, HelpMessage = "Service id.")]
        [Alias("Name")]
        [ServiceIdCompleter()]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                if (this.Id != null)
                {
                    var result = this.SupportClient.Services.Get(this.GetId(this.Id, ResourceType.Services));
                    this.WriteObject(result.ToPSSupportService());
                }
                else
                {
                    var result = this.SupportClient.Services.List().Select(f => f.ToPSSupportService()).ToList();
                    this.WriteObject(result, true);
                }
            }
            catch (ExceptionResponseException ex)
            {
                throw new PSArgumentException(string.Format("Error response received. Error Message: '{0}'",
                                     ex.Response.Content));
            }
        }
    }
}
