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

using System;
using System.Management.Automation;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.DataFactoryV2.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    public abstract class IntegrationRuntimeBaseCmdlet : DataFactoryBaseCmdlet
    {
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpResourceId)]
        [ValidateNotNullOrEmpty]
        [Alias("Id")]
        public string ResourceId { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpResourceGroup)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryName)]
        [ValidateNotNullOrEmpty]
        public string DataFactoryName { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = Constants.HelpIntegrationRuntimeObject)]
        [ValidateNotNull]
        public PSIntegrationRuntime InputObject { get; set; }

        protected virtual void ByResourceId()
        {
            if (ParameterSetName.Equals(ParameterSetNames.ByResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(ResourceId);
                ResourceGroupName = parsedResourceId.ResourceGroupName;
                var parentResource = parsedResourceId.ParentResource.Split(new[] { '/' });
                DataFactoryName = parentResource[parentResource.Length - 1];
            }
        }

        protected virtual void ByIntegrationRuntimeObject()
        {
            if (ParameterSetName.Equals(ParameterSetNames.ByIntegrationRuntimeObject, StringComparison.OrdinalIgnoreCase))
            {
                ResourceGroupName = InputObject.ResourceGroupName;
                DataFactoryName = InputObject.DataFactoryName;
            }
        }

        protected void UpdateProgress(Task task, ProgressRecord progress)
        {
            while (!task.IsCompleted && !task.IsCanceled && !task.IsFaulted)
            {
                if (progress.PercentComplete < 100)
                {
                    progress.PercentComplete++;
                }
                WriteProgress(progress);

                task.Wait(TimeSpan.FromSeconds(15));
            }

            if (progress.PercentComplete < 100)
            {
                progress.PercentComplete = 100;
                WriteProgress(progress);
            }
        }
    }
}
