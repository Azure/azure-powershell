﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.PowerShell.Cmdlets.Compute.Helpers.Network.Models;

namespace Microsoft.Azure.Commands.Compute.Strategies.ComputeRp
{
    static class NetworkInterfaceReferenceStrategy
    {
        public static NetworkInterfaceReference GetReference(
            this IEngine engine, ResourceConfig<NetworkInterface> networkInterface, string deleteOption = null)
            => new NetworkInterfaceReference { Id = engine.GetId(networkInterface), DeleteOption = deleteOption };
    }
}
