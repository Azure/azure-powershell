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
using System.Reflection;
using Microsoft.AzureStack.AzureConsistentStorage.Models;

namespace Microsoft.AzureStack.AzureConsistentStorage.Commands
{
    internal class ResponseBase : BasicResponseBase
    {
        public ResponseBase(ResourceBase resource) : this(resource, "Properties")
        {

        }

        public ResponseBase(ResourceBase resource, string propertyNameToExpand)
            : base(resource, propertyNameToExpand)
        {
            // Id is in the following format:
            // /subscriptions/{subid}/resourceGroups/{resourceGroupName}/providers/{providerName}/farms/{farmId}/nodes/{nodeId}
            string[] ids = resource.Id.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            // ResourceGroupName = ids[3];
            FarmName = ids[7];
        }
        // public string ResourceGroupName { get; set; }
        public string FarmName { get; set; }
    }
}
