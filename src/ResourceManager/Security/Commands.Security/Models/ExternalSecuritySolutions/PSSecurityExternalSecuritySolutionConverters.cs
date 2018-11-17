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

using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.Security.Models;

namespace Microsoft.Azure.Commands.Security.Models.ExternalSecuritySolutions
{
    public static class PSSecurityExternalSecuritySolutionConverters
    {
        public static PSSecurityExternalSecuritySolution ConvertToPSType(this ExternalSecuritySolution value)
        {
            var convertedAadValue = value as AadExternalSecuritySolution;

            if (convertedAadValue != null)
            {
                return convertedAadValue.ConvertToPSType();
            }

            var convertedAtaValue = value as AtaExternalSecuritySolution;

            if (convertedAtaValue != null)
            {
                return convertedAtaValue.ConvertToPSType();
            }

            var convertedCefValue = value as CefExternalSecuritySolution;

            if (convertedCefValue != null)
            {
                return convertedCefValue.ConvertToPSType();
            }

            return new PSSecurityExternalSecuritySolution()
            {
                Kind = "Error",
                Name = value.Name
            };
        }

        public static List<PSSecurityExternalSecuritySolution> ConvertToPSType(this IEnumerable<ExternalSecuritySolution> value)
        {
            return value.Select(ess => ess.ConvertToPSType()).ToList();
        }

        public static PSSecurityAadExternalSecuritySolution ConvertToPSType(this AadExternalSecuritySolution value)
        {
            return new PSSecurityAadExternalSecuritySolution()
            {
                Id = value.Id,
                Name = value.Name,
                ConnectivityState = value.Properties.ConnectivityState,
                DeviceType = value.Properties.DeviceType,
                DeviceVendor = value.Properties.DeviceVendor,
                Kind = "AAD",
                Workspace = value.Properties.Workspace.Id
            };
        }

        public static PSSecurityAtaExternalSecuritySolution ConvertToPSType(this AtaExternalSecuritySolution value)
        {
            return new PSSecurityAtaExternalSecuritySolution()
            {
                Id = value.Id,
                Name = value.Name,
                Workspace = value.Properties.Workspace.Id,
                Kind = "ATA",
                DeviceVendor = value.Properties.DeviceVendor,
                DeviceType = value.Properties.DeviceType,
                LastEventReceived = value.Properties.LastEventReceived
            };
        }

        public static PSSecurityCefExternalSecuritySolution ConvertToPSType(this CefExternalSecuritySolution value)
        {
            return new PSSecurityCefExternalSecuritySolution()
            {
                Id = value.Id,
                Name = value.Name,
                LastEventReceived = value.Properties.LastEventReceived,
                DeviceType = value.Properties.DeviceType,
                DeviceVendor = value.Properties.DeviceVendor,
                Kind = "CEF",
                Workspace = value.Properties.Workspace.Id,
                Agent = value.Properties.Agent,
                Hostname = value.Properties.Hostname
            };
        }
    }
}
