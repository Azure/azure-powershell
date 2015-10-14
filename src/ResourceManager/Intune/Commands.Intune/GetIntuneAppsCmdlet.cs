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
    using Commands.Intune.Helpers;
    using Commands.Intune.RestClient;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Management.Automation;

    /// <summary>
    /// Cmdlet to get existing resources.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmIntuneApps", DefaultParameterSetName = GetIntuneAppsCmdlet.ListAppsParameterSet), OutputType(typeof(PSObject))]
    public sealed class GetIntuneAppsCmdlet : ResourceManagerCmdletBase
    {
        /// <summary>
        /// Contains the errors that encountered while satisfying the request.
        /// </summary>
        private readonly ConcurrentBag<ErrorRecord> errors = new ConcurrentBag<ErrorRecord>();
        private IntuneResourceManagementClient client;

        /// <summary>
        /// The list resources parameter set.
        /// </summary>
        internal const string ListAppsParameterSet = "Lists the applications.";

        /// <summary>
        /// Gets or sets the OData query parameter.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "An OData style filter which will be appended to the request in addition to any other filters.")]
        [ValidateNotNullOrEmpty]
        public platform? Platform { get; set; }

        public enum platform
        {
            ios,
            android,
            windows,
            none

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

            var resources = client.GetApplications(LocationHelper.GetLocation(client, this.DefaultContext.Tenant.Id));

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