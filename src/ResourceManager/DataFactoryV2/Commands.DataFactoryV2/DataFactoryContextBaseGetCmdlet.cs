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
using Microsoft.Azure.Commands.DataFactoryV2.Models;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    public abstract class DataFactoryContextBaseGetCmdlet: DataFactoryContextBaseCmdlet
    {
        [Parameter(ParameterSetName = ParameterSetNames.ByResourceId, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        // The Name property is abstract to force child classes to redefine it with proper set of attributes.
        [ValidateNotNullOrEmpty]
        public abstract string Name { get; set; }

        protected void ByResourceId()
        {
            if (ParameterSetName.Equals(ParameterSetNames.ByResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(ResourceId);
                ResourceGroupName = parsedResourceId.ResourceGroupName;
                Name = parsedResourceId.ResourceName;
                var parentResource = parsedResourceId.ParentResource.Split(new[] { '/' });
                DataFactoryName = parentResource[parentResource.Length - 1];
            }
        }
    }
}
