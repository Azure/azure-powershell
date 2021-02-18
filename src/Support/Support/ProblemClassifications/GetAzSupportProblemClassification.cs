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
using Microsoft.Azure.Graph.RBAC.Version1_6;
using Microsoft.Azure.Management.Support;
using Microsoft.Azure.Management.Support.Models;
using Microsoft.Azure.PowerShell.Cmdlets.Support.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Linq;
using System.Management.Automation;
using static Microsoft.Azure.Commands.Support.Helpers.ResourceIdentifierHelper;

namespace Microsoft.Azure.Commands.Support.ProblemClassifications
{
    [Cmdlet(VerbsCommon.Get, AzureRMConstants.AzureRMPrefix + "SupportProblemClassification", DefaultParameterSetName = GetByNameParameterSet), OutputType(typeof(PSSupportProblemClassification))]
    public class GetAzSupportProblemClassification : AzSupportCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet, HelpMessage = "Service id for which all problem classifications are retrieved.")]
        [Alias("ServiceName")]
        [ServiceIdCompleter()]
        [ValidateNotNullOrEmpty]
        public string ServiceId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = GetByNameParameterSet, HelpMessage = "Problem classification id.")]
        [Parameter(Mandatory = false, ParameterSetName = GetByParentObjectParameterSet, HelpMessage = "Problem classification id.")]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = GetByParentObjectParameterSet, HelpMessage = "Service object for which problem classifications are retrieved.")]
        [ValidateNotNull]
        public PSSupportService ServiceObject { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                if (this.IsParameterBound(c => c.ServiceObject))
                {
                    this.ServiceId = this.ServiceObject.Name;
                }

                if (!string.IsNullOrEmpty(this.Id))
                {
                    var result = this.SupportClient.ProblemClassifications.Get(this.GetId(this.ServiceId, ResourceType.Services), this.GetId(this.Id, ResourceType.ProblemClassifications));
                    this.WriteObject(result.ToPSSupportProblemClassification());
                }
                else
                {
                    var serviceId = this.GetId(this.ServiceId, ResourceType.Services);

                    var result = this.SupportClient.ProblemClassifications.List(serviceId).Select(f => f.ToPSSupportProblemClassification()).ToList();
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
