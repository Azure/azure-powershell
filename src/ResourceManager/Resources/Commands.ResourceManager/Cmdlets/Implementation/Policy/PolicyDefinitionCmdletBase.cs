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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Newtonsoft.Json.Linq;
    using System.Linq;
    using System.Management.Automation;
    using System.Threading.Tasks;

    /// <summary>
    /// Base class for policy definition cmdlets.
    /// </summary>
    public abstract class PolicyDefinitionCmdletBase : ResourceManagerCmdletBase
    {
        /// <summary>
        /// Gets the next set of resources using the <paramref name="nextLink"/>
        /// </summary>
        /// <param name="nextLink">The next link.</param>
        protected Task<ResponseWithContinuation<TType[]>> GetNextLink<TType>(string nextLink)
        {
            return this
                .GetResourcesClient()
                .ListNextBatch<TType>(nextLink: nextLink, cancellationToken: this.CancellationToken.Value);
        }

        /// <summary>
        /// Converts the resource object to policy definition object.
        /// </summary>
        /// <param name="resources">The policy definition resource object.</param>
        protected PSObject[] GetOutputObjects(params JToken[] resources)
        {
            return resources
                .CoalesceEnumerable()
                .Where(resource => resource != null)
                .SelectArray(resource =>
                {
                    var psobject = resource.ToResource().ToPsObject();
                    psobject.Properties.Add(new PSNoteProperty("PolicyDefinitionId", psobject.Properties["ResourceId"].Value));
                    return psobject;
                });
        }
    }
}