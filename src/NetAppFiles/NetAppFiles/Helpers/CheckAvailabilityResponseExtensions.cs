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
using Microsoft.Azure.Commands.NetAppFiles.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.NetApp.Models;
using Microsoft.Azure.PowerShell.Cmdlets.NetAppFiles.Models;

namespace Microsoft.Azure.Commands.NetAppFiles.Helpers
{
    public static class CheckAvailabilityResponseExtensions
    {
        public static PSCheckAvailabilityResponse ConvertToPs(this Management.NetApp.Models.CheckAvailabilityResponse checkAvailabilityResponse)
        {
            var psCheckAvailabilityResponse = new PSCheckAvailabilityResponse()
            {
                IsAvailable = checkAvailabilityResponse.IsAvailable,
                Message = checkAvailabilityResponse.Message,
                Reason = checkAvailabilityResponse.Reason
            };
            return psCheckAvailabilityResponse;
        }
    }
}
