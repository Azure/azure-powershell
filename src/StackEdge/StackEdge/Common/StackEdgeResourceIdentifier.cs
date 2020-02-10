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

using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Resource = Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Resources.Resource;
using System;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common
{
    public class StackEdgeResourceIdentifier : ResourceIdentifier
    {
        public bool IsSubResource { get; }
        public string DeviceName { get; }
        public string Name { get; }

        public StackEdgeResourceIdentifier(string resourceId) : base(resourceId)
        {
            if (!this.ResourceType.StartsWithInsensitively(Constants.DataBoxEdgeDeviceProvider))
            {
                throw new Exception(Resource.InvalidResourceId);
            }

            if (!string.IsNullOrEmpty(this.ParentResource))
            {
                this.IsSubResource = true;
                this.DeviceName = this.ParentResource.Remove(0, Constants.DevicesPath.Length);
            }
            else
            {
                this.IsSubResource = false;
                this.DeviceName = this.ResourceName;
            }

            this.Name = this.ResourceName;
        }
    }
}