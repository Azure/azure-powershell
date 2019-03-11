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

namespace Microsoft.Azure.Commands.Security.Models.JitNetworkAccessPolicies
{
    public static class PSSecurityJitNetworkAccessPolicyConverters
    {
        public static PSSecurityJitNetworkAccessPolicy ConvertToPSType(this JitNetworkAccessPolicy value)
        {
            return new PSSecurityJitNetworkAccessPolicy()
            {
                Id = value.Id,
                Kind = value.Kind,
                Name = value.Name,
                ProvisioningState = value.ProvisioningState,
                Requests = value.Requests.ConvertToPSType(),
                VirtualMachines = value.VirtualMachines.ConvertToPSType()
            };
        }

        public static List<PSSecurityJitNetworkAccessPolicy> ConvertToPSType(this IEnumerable<JitNetworkAccessPolicy> value)
        {
            return value.Select(dss => dss.ConvertToPSType()).ToList();
        }

        public static PSSecurityJitNetworkAccessPolicyRequest ConvertToPSType(this JitNetworkAccessRequest value)
        {
            return new PSSecurityJitNetworkAccessPolicyRequest()
            {
                Requestor = value.Requestor,
                StartTimeUtc = value.StartTimeUtc,
                VirtualMachines = value.VirtualMachines.ConvertToPSType()
            };
        }

        public static List<PSSecurityJitNetworkAccessPolicyRequest> ConvertToPSType(this IEnumerable<JitNetworkAccessRequest> value)
        {
            return value.Select(dss => dss.ConvertToPSType()).ToList();
        }

        public static PSSecurityJitNetworkAccessRequestVirtualMachine ConvertToPSType(this JitNetworkAccessRequestVirtualMachine value)
        {
            return new PSSecurityJitNetworkAccessRequestVirtualMachine()
            {
                Id = value.Id,
                Ports = value.Ports.ConvertToPSType()
            };
        }

        public static List<PSSecurityJitNetworkAccessRequestVirtualMachine> ConvertToPSType(this IEnumerable<JitNetworkAccessRequestVirtualMachine> value)
        {
            return value.Select(dss => dss.ConvertToPSType()).ToList();
        }

        public static PSSecurityJitNetworkAccessPolicyVirtualMachinePort ConvertToPSType(this JitNetworkAccessRequestPort value)
        {
            return new PSSecurityJitNetworkAccessPolicyVirtualMachinePort()
            {
                AllowedSourceAddressPrefix = value.AllowedSourceAddressPrefix,
                AllowedSourceAddressPrefixes = value.AllowedSourceAddressPrefixes,
                EndTimeUtc = value.EndTimeUtc,
                Number = value.Number,
                Status = value.Status,
                StatusReason = value.StatusReason
            };
        }

        public static List<PSSecurityJitNetworkAccessPolicyVirtualMachinePort> ConvertToPSType(this IEnumerable<JitNetworkAccessRequestPort> value)
        {
            return value.Select(dss => dss.ConvertToPSType()).ToList();
        }

        public static PSSecurityJitNetworkAccessPolicyVirtualMachine ConvertToPSType(this JitNetworkAccessPolicyVirtualMachine value)
        {
            return new PSSecurityJitNetworkAccessPolicyVirtualMachine()
            {
                Id = value.Id,
                Ports = value.Ports.ConvertToPSType()
            };
        }

        public static List<PSSecurityJitNetworkAccessPolicyVirtualMachine> ConvertToPSType(this IEnumerable<JitNetworkAccessPolicyVirtualMachine> value)
        {
            return value.Select(dss => dss.ConvertToPSType()).ToList();
        }

        public static PSSecurityJitNetworkAccessPortRule ConvertToPSType(this JitNetworkAccessPortRule value)
        {
            return new PSSecurityJitNetworkAccessPortRule()
            {
                AllowedSourceAddressPrefix = value.AllowedSourceAddressPrefix,
                AllowedSourceAddressPrefixes = value.AllowedSourceAddressPrefixes,
                MaxRequestAccessDuration = value.MaxRequestAccessDuration,
                Number = value.Number,
                Protocol = value.Protocol
            };
        }

        public static PSSecurityJitNetworkAccessPortRule[] ConvertToPSType(this IEnumerable<JitNetworkAccessPortRule> value)
        {
            return value.Select(dss => dss.ConvertToPSType()).ToArray();
        }

        public static JitNetworkAccessPolicyInitiatePort ConvertToCSType(this PSSecurityJitNetworkAccessPolicyInitiatePort value)
        {
            return new JitNetworkAccessPolicyInitiatePort()
            {
                AllowedSourceAddressPrefix = value.AllowedSourceAddressPrefix,
                EndTimeUtc = value.EndTimeUtc,
                Number = value.Number
            };
        }

        public static List<JitNetworkAccessPolicyInitiatePort> ConvertToCSType(this IEnumerable<PSSecurityJitNetworkAccessPolicyInitiatePort> value)
        {
            return value.Select(dss => dss.ConvertToCSType()).ToList();
        }

        public static JitNetworkAccessPolicyInitiateVirtualMachine ConvertToCSType(this PSSecurityJitNetworkAccessPolicyInitiateVirtualMachine value)
        {
            return new JitNetworkAccessPolicyInitiateVirtualMachine()
            {
                Id = value.Id,
                Ports = value.Ports.ConvertToCSType()
            };
        }

        public static List<JitNetworkAccessPolicyInitiateVirtualMachine> ConvertToCSType(this IEnumerable<PSSecurityJitNetworkAccessPolicyInitiateVirtualMachine> value)
        {
            return value.Select(dss => dss.ConvertToCSType()).ToList();
        }

        public static JitNetworkAccessPolicyVirtualMachine ConvertToCSType(this PSSecurityJitNetworkAccessPolicyVirtualMachine value)
        {
            return new JitNetworkAccessPolicyVirtualMachine()
            {
                Id = value.Id,
                Ports = value.Ports.ConvertToCSType()
            };
        }

        public static List<JitNetworkAccessPolicyVirtualMachine> ConvertToCSType(this IEnumerable<PSSecurityJitNetworkAccessPolicyVirtualMachine> value)
        {
            return value.Select(dss => dss.ConvertToCSType()).ToList();
        }

        public static JitNetworkAccessPortRule ConvertToCSType(this PSSecurityJitNetworkAccessPortRule value)
        {
            return new JitNetworkAccessPortRule()
            {
                AllowedSourceAddressPrefix = value.AllowedSourceAddressPrefix,
                AllowedSourceAddressPrefixes = value.AllowedSourceAddressPrefixes,
                Number = value.Number,
                MaxRequestAccessDuration = value.MaxRequestAccessDuration,
                Protocol = value.Protocol
            };
        }

        public static List<JitNetworkAccessPortRule> ConvertToCSType(this IEnumerable<PSSecurityJitNetworkAccessPortRule> value)
        {
            return value.Select(dss => dss.ConvertToCSType()).ToList();
        }
    }
}
