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
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    internal static class AddressFamilyHelper
    {
        private const string IPv4 = "IPv4";
        private const string IPv6 = "IPv6";

        /// <summary>
        /// Validates the provided address family values and canonicalizes their casing to IPv4/IPv6.
        /// Rejects more than two values, duplicates (case-insensitive), empty values, and any value
        /// other than IPv4 or IPv6.
        /// </summary>
        public static string[] ValidateAndCanonicalize(string[] addressFamily)
        {
            if (addressFamily == null)
            {
                return null;
            }

            if (addressFamily.Length > 2)
            {
                throw new PSArgumentException("AddressFamily accepts at most two values (IPv4 and IPv6).");
            }

            var canonicalized = new List<string>();
            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var value in addressFamily)
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new PSArgumentException("AddressFamily values cannot be null or empty. Allowed values are IPv4 and IPv6.");
                }

                string canonical;
                if (string.Equals(value, IPv4, StringComparison.OrdinalIgnoreCase))
                {
                    canonical = IPv4;
                }
                else if (string.Equals(value, IPv6, StringComparison.OrdinalIgnoreCase))
                {
                    canonical = IPv6;
                }
                else
                {
                    throw new PSArgumentException($"Invalid AddressFamily value '{value}'. Allowed values are IPv4 and IPv6.");
                }

                if (!seen.Add(canonical))
                {
                    throw new PSArgumentException($"Duplicate AddressFamily value '{canonical}' is not allowed.");
                }

                canonicalized.Add(canonical);
            }

            return canonicalized.ToArray();
        }
    }
}
