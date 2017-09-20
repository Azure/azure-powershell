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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    public abstract class IntegrationRuntimeCmdlet : IntegrationRuntimeBaseCmdlet
    {
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpIntegrationRuntimeName)]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.IntegrationRuntimeName)]
        public string Name { get; set; }

        protected override void ByResourceId()
        {
            if (ParameterSetName.Equals(ParameterSetNames.ByResourceId, StringComparison.OrdinalIgnoreCase))
            {
                base.ByResourceId();

                var parsedResourceId = new ResourceIdentifier(ResourceId);
                Name = parsedResourceId.ResourceName;
            }
        }

        protected override void ByIntegrationRuntimeObject()
        {
            if (ParameterSetName.Equals(ParameterSetNames.ByIntegrationRuntimeObject, StringComparison.OrdinalIgnoreCase))
            {
                base.ByIntegrationRuntimeObject();
                Name = InputObject.Name;
            }
        }
    }
}