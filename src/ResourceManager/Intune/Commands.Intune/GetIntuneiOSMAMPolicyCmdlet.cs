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

namespace Commands.Intune
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Resources;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Newtonsoft.Json.Linq;
    using RestClient;

    /// <summary>
    /// Cmdlet to get existing resources.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmIntuneiOSMAMPolicy"), OutputType(typeof(PSObject))]
    public sealed class GetIntuneiOSMAMPolicyCmdlet : IntuneBaseCmdlet
    {        
        /// <summary>
        /// Contains the cmdlet's execution logic.
        /// </summary>
        protected override void ProcessRecord()
        {
            Action action = () =>
            {
                var iOSPolicies = this.IntuneClient.GetiOSPolicies(this.AsuHostName);
                if (iOSPolicies != null && iOSPolicies.Value.Count > 0)
                {
                    IList<Resource<JToken>> genericResources = iOSPolicies.Value.Where(res => res != null).SelectArray(res => res.ToJToken().ToResource());

                    foreach (var batch in genericResources.Batch())
                    {
                        var powerShellObjects = batch.SelectArray(genericResource => genericResource.ToPsObject());
                        this.WriteObject(sendToPipeline: powerShellObjects, enumerateCollection: true);
                    }
                }
                else
                {
                    this.WriteObject("0 Policies returned");
                }
            };

            base.SafeExecutor(action);
        }
    }
}
