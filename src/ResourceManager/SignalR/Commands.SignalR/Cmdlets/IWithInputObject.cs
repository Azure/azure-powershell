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

using Microsoft.Azure.Commands.SignalR.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.SignalR.Cmdlets
{
    public interface IWithInputObject : IWithResourceGroupAndName
    {
        PSSignalRResource InputObject { get; }
    }

    public static class IWithInputObjectExtensions
    {
        public static void LoadFromInputObject(this IWithInputObject cmdlet)
        {
            var resourceId = new ResourceIdentifier(cmdlet.InputObject.Id);
            cmdlet.ResourceGroupName = resourceId.ResourceGroupName;
            cmdlet.Name = resourceId.ResourceName;
        }
    }
}
