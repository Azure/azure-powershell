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

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Management.Automation;
using System.Net;

namespace Microsoft.Azure.Commands.Network
{
    public abstract class VirtualNetworkApplianceCapabilityBaseCmdlet : NetworkBaseCmdlet
    {
        public IVirtualNetworkApplianceCapabilitiesOperations VirtualNetworkApplianceCapabilitiesClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.VirtualNetworkApplianceCapabilities;
            }
        }

        public bool IsVirtualNetworkApplianceCapabilityPresent(string resourceGroupName, string virtualNetworkApplianceName, string name)
        {
            try
            {
                GetVirtualNetworkApplianceCapability(resourceGroupName, virtualNetworkApplianceName, name);
            }
            catch (Microsoft.Rest.Azure.CloudException exception)
            {
                if (exception.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Resource is not present
                    return false;
                }
                throw;
            }
            return true;
        }

        public PSVirtualNetworkApplianceCapability GetVirtualNetworkApplianceCapability(string resourceGroupName, string virtualNetworkApplianceName, string name)
        {
            var capability = this.VirtualNetworkApplianceCapabilitiesClient.Get(resourceGroupName, virtualNetworkApplianceName, name);
            return ToPsVirtualNetworkApplianceCapability(capability, resourceGroupName, virtualNetworkApplianceName);
        }

        public PSVirtualNetworkApplianceCapability ToPsVirtualNetworkApplianceCapability(VirtualNetworkApplianceCapability capability, string resourceGroupName, string virtualNetworkApplianceName)
        {
            return new PSVirtualNetworkApplianceCapability
            {
                Name = capability.Name,
                Id = capability.Id,
                Type = capability.Type,
                Kind = GetCapabilityKind(capability),
                IpVersion = capability.Properties?.IPVersion,
                LinkedResourceId = capability.Properties?.LinkedResourceId,
                ProvisioningState = capability.Properties?.ProvisioningState,
                ResourceGroupName = resourceGroupName,
                VirtualNetworkApplianceName = virtualNetworkApplianceName
            };
        }

        // The capability is a discriminated resource: the concrete SDK subtype maps one-to-one to the
        // wire-level "kind". The generated base type does not surface "kind" as a settable property, so it is
        // derived from the runtime subtype here. Exposed for unit testing (no service dependency).
        public static string GetCapabilityKind(VirtualNetworkApplianceCapability capability)
        {
            switch (capability)
            {
                case PLGatewayFastpathCapability _:
                    return VirtualNetworkApplianceCapabilityKind.PLGatewayFastpath;
                case PLGatewayCapability _:
                    return VirtualNetworkApplianceCapabilityKind.PLGateway;
                case PlipForwardersCapability _:
                    return VirtualNetworkApplianceCapabilityKind.PlipForwarders;
                case Nat64Capability _:
                    return VirtualNetworkApplianceCapabilityKind.Nat64;
                default:
                    return null;
            }
        }

        // Builds the kind-specific create-or-update payload. "kind" selects the concrete subtype (which the
        // serializer emits as the top-level discriminator). The Private-Link kinds carry an "ipVersion" (the
        // service validates it against the kind: PLGatewayFastpath -> DualStack; PLGateway / PLIPForwarders ->
        // IPv6). NAT64 is property-less and must not carry an ipVersion. Exposed for unit testing (no service dependency).
        public static VirtualNetworkApplianceCapabilityCreateOrUpdate BuildCapabilityParameters(string kind, string ipVersion)
        {
            bool isNat64 = string.Equals(kind, VirtualNetworkApplianceCapabilityKind.Nat64, StringComparison.OrdinalIgnoreCase);
            bool ipVersionProvided = !string.IsNullOrEmpty(ipVersion);

            if (isNat64 && ipVersionProvided)
            {
                throw new ArgumentException("The -IpVersion parameter is not supported for the 'NAT64' capability kind, which is property-less.", nameof(ipVersion));
            }

            if (!isNat64 && !ipVersionProvided)
            {
                throw new ArgumentException($"The -IpVersion parameter is required for the '{kind}' capability kind.", nameof(ipVersion));
            }

            if (isNat64)
            {
                // NAT64 is property-less; the wire contract still carries an empty "properties" object
                // (no ipVersion). An empty properties bag serializes to "properties": {} to match the service contract.
                return new Nat64CapabilityCreateOrUpdate { Properties = new VirtualNetworkApplianceCapabilityProperties() };
            }

            var properties = new VirtualNetworkApplianceCapabilityProperties
            {
                IPVersion = NormalizeIpVersion(ipVersion)
            };

            // Enforce the per-kind ipVersion contract client-side (the service also validates it), so a
            // documented-invalid combination fails fast without a network round-trip. NAT64 already returned
            // above, so it is never evaluated here. The value compared is the normalized (canonical-cased) one.
            bool invalidIpVersion =
                (string.Equals(kind, VirtualNetworkApplianceCapabilityKind.PLGatewayFastpath, StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(properties.IPVersion, VirtualNetworkApplianceCapabilityIpVersion.DualStack, StringComparison.Ordinal))
                || ((string.Equals(kind, VirtualNetworkApplianceCapabilityKind.PLGateway, StringComparison.OrdinalIgnoreCase)
                        || string.Equals(kind, VirtualNetworkApplianceCapabilityKind.PlipForwarders, StringComparison.OrdinalIgnoreCase))
                    && !string.Equals(properties.IPVersion, VirtualNetworkApplianceCapabilityIpVersion.IPv6, StringComparison.Ordinal));

            if (invalidIpVersion)
            {
                throw new ArgumentException($"The -IpVersion value '{ipVersion}' is not valid for the '{kind}' capability kind. PLGatewayFastpath requires DualStack; PLGateway and PLIPForwarders require IPv6.", nameof(ipVersion));
            }

            if (string.Equals(kind, VirtualNetworkApplianceCapabilityKind.PLGatewayFastpath, StringComparison.OrdinalIgnoreCase))
            {
                return new PLGatewayFastpathCapabilityCreateOrUpdate { Properties = properties };
            }

            if (string.Equals(kind, VirtualNetworkApplianceCapabilityKind.PLGateway, StringComparison.OrdinalIgnoreCase))
            {
                return new PLGatewayCapabilityCreateOrUpdate { Properties = properties };
            }

            if (string.Equals(kind, VirtualNetworkApplianceCapabilityKind.PlipForwarders, StringComparison.OrdinalIgnoreCase))
            {
                return new PlipForwardersCapabilityCreateOrUpdate { Properties = properties };
            }

            throw new ArgumentException($"Unsupported virtual network appliance capability kind '{kind}'.", nameof(kind));
        }

        // Canonicalizes the IP version to the exact wire value the service expects, since the cmdlet's
        // ValidateSet accepts case-insensitive input.
        private static string NormalizeIpVersion(string ipVersion)
        {
            if (string.Equals(ipVersion, VirtualNetworkApplianceCapabilityIpVersion.IPv6, StringComparison.OrdinalIgnoreCase))
            {
                return VirtualNetworkApplianceCapabilityIpVersion.IPv6;
            }

            if (string.Equals(ipVersion, VirtualNetworkApplianceCapabilityIpVersion.DualStack, StringComparison.OrdinalIgnoreCase))
            {
                return VirtualNetworkApplianceCapabilityIpVersion.DualStack;
            }

            return ipVersion;
        }

        // Parses a capability ARM resource id of the fixed 10-segment form
        // /subscriptions/{sub}/resourceGroups/{rg}/providers/Microsoft.Network/virtualNetworkAppliances/{appliance}/capabilities/{capability}
        // Every structural token is validated positionally and the resource group, appliance, and capability
        // names are read from fixed positions, so a resource NAME that happens to equal a type keyword
        // (e.g. an appliance literally named "resourceGroups" or "capabilities") cannot be mis-parsed.
        // Exposed for unit testing (no service dependency).
        public static void ParseCapabilityResourceId(string resourceId, out string resourceGroupName, out string virtualNetworkApplianceName, out string capabilityName)
        {
            var segments = (resourceId ?? string.Empty).Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            bool valid = segments.Length == 10
                && string.Equals(segments[0], "subscriptions", StringComparison.OrdinalIgnoreCase)
                && string.Equals(segments[2], "resourceGroups", StringComparison.OrdinalIgnoreCase)
                && string.Equals(segments[4], "providers", StringComparison.OrdinalIgnoreCase)
                && string.Equals(segments[5], "Microsoft.Network", StringComparison.OrdinalIgnoreCase)
                && string.Equals(segments[6], "virtualNetworkAppliances", StringComparison.OrdinalIgnoreCase)
                && string.Equals(segments[8], "capabilities", StringComparison.OrdinalIgnoreCase);

            if (!valid)
            {
                throw new PSArgumentException($"'{resourceId}' is not a valid virtual network appliance capability resource id. Expected the form '/subscriptions/{{subscriptionId}}/resourceGroups/{{resourceGroupName}}/providers/Microsoft.Network/virtualNetworkAppliances/{{applianceName}}/capabilities/{{capabilityName}}'.", nameof(resourceId));
            }

            resourceGroupName = segments[3];
            virtualNetworkApplianceName = segments[7];
            capabilityName = segments[9];
        }
    }
}
