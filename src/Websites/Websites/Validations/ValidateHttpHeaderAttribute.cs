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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Net.Sockets;

namespace Microsoft.Azure.Commands.WebApps.Validations
{
    public class ValidateHttpHeaderAttribute : ValidateArgumentsAttribute
    {
        private List<string> SupportedHttpHeaders = new List<string>() {
            "x-forwarded-for",
            "x-forwarded-host",
            "x-azure-fdid",
            "x-fd-healthprobe"
        };
        protected override void Validate(object arguments, EngineIntrinsics engineIntrinsics)
        {
            var hashtable = arguments as Hashtable;
            if (hashtable == null)
            {
                throw new ValidationMetadataException("Argument must be of type 'System.Collections.Hashtable'");
            }

            foreach (var key in hashtable.Keys)
            {
                if (key.GetType() != typeof(string))
                {
                    throw new ValidationMetadataException(string.Format("Key '{0}' should be of type string instead of {1}", key, key.GetType()));
                }

                var headerName = key as string;
                if (!SupportedHttpHeaders.Contains(headerName, StringComparer.OrdinalIgnoreCase))
                {
                    throw new ValidationMetadataException(string.Format("'{0}' is not a supported http header name. only {1} are supported", headerName, SupportedHttpHeaders.ToString()));
                }

                var value = hashtable[headerName];
                if (value.GetType() == typeof(object[]))
                {
                    var headerValues = value as object[];
                    if (headerValues.Length > 8)
                        throw new ValidationMetadataException(string.Format("Header '{0}' contains more than 8 values", headerName));

                    if (headerName.Equals("x-forwarded-for", StringComparison.OrdinalIgnoreCase) && !headerValues.All(a => IsValidCIDR((string)a)))
                    {
                        throw new ValidationMetadataException(string.Format("'{0}' must be in valid CIDR format. E.g. 192.168.0.0/24 (IPv4) or 2002::1234:abcd:ffff:c0a8:101/64 (IPv6)", headerName));
                    }
                }
                else if (value.GetType() == typeof(string))
                {
                    var headerValue = value as string;
                    if (headerName.Equals("x-forwarded-for", StringComparison.OrdinalIgnoreCase) && !IsValidCIDR(headerValue))
                    {
                        throw new ValidationMetadataException(string.Format("'{0}' must be in valid CIDR format. E.g. 192.168.0.0/24 (IPv4) or 2002::1234:abcd:ffff:c0a8:101/64 (IPv6)", headerName));
                    }
                }
                else
                {
                    throw new ValidationMetadataException(string.Format("Value(s) '{0}' should be of type string instead of {1}", key, key.GetType()));
                }
            }
        }

        private bool IsValidCIDR(string cidr)
        {
            if (string.IsNullOrEmpty(cidr))
            {
                return false;
            }

            var parts = cidr.Split('/');
            if (parts.Length != 2)
            {
                return false;
            }

            IPAddress ipAddress;
            if (!IPAddress.TryParse(parts[0], out ipAddress))
            {
                return false;
            }

            int prefixLength;
            if (!int.TryParse(parts[1], out prefixLength))
            {
                return false;
            }

            if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
            {
                return prefixLength >= 0 && prefixLength <= 32;
            }
            else if (ipAddress.AddressFamily == AddressFamily.InterNetworkV6)
            {
                return prefixLength >= 0 && prefixLength <= 128;
            }
            else
            {
                return false;
            }
        }
    }
}
