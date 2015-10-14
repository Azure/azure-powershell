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
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Threading.Tasks;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Authorization;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Resources;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Newtonsoft.Json.Linq;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation;
    using Commands.Intune.Helpers;
    using Commands.Intune.RestClient;

    /// <summary>
    /// Cmdlet to get existing resources.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmIntunePolicy", DefaultParameterSetName = GetIntunePolicyCmdlet.ListPoliciesParameterSet), OutputType(typeof(PSObject))]
    public sealed class GetIntunePolicyCmdlet : ResourceManagerCmdletBase
    {
        /// <summary>
        /// Contains the errors that encountered while satifying the request.
        /// </summary>
        private readonly ConcurrentBag<ErrorRecord> errors = new ConcurrentBag<ErrorRecord>();

        /// <summary>
        /// The list resources parameter set.
        /// </summary>
        internal const string ListPoliciesParameterSet = "Lists the policies.";

        /// <summary>
        /// Gets or sets the top parameter.
        /// </summary>
        [ValidateNotNullOrEmpty]
        public int? Top { get; set; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The policy kind.")]
        [ValidateNotNullOrEmpty]
        public PolicyTypeEnum Kind { get; set; }

        /// <summary>
        /// PolicyType.
        /// </summary>
        public enum PolicyTypeEnum
        {
            iOS,
            Android
        }

        /// <summary>
        /// Collects subscription ids from the pipeline.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();
        }

        /// <summary>
        /// Finishes the pipeline execution and runs the cmdlet.
        /// </summary>
        protected override void OnEndProcessing()
        {
            base.OnEndProcessing();

            this.RunCmdlet();
        }

        /// <summary>
        /// Contains the cmdlet's execution logic.
        /// </summary>
        private void RunCmdlet()
        {
            var client = IntuneRPClientHelper.GetIntuneManagementClient(this.DefaultContext, "2015-01-05-alpha");

            var resources = client.GetiOSPolicies(LocationHelper.GetLocation(client, this.DefaultContext.Tenant.Id));

            var genericResources = resources.Value.Where(res => res != null).SelectArray(res => res.ToJToken().ToResource());

            foreach (var batch in genericResources.Batch())
            {
                var items = batch;

                var powerShellObjects = items.SelectArray(genericResource => genericResource.ToPsObject());

                this.WriteObject(sendToPipeline: powerShellObjects, enumerateCollection: true);
            }

            if (this.errors.Count != 0)
            {
                foreach (var error in this.errors)
                {
                    this.WriteError(error);
                }
            }
        }
    }
}