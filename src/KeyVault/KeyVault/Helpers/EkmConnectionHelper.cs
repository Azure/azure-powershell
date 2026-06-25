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

using Microsoft.Azure.Commands.Common.Exceptions;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.KeyVault.Helpers
{
    /// <summary>
    /// Validation and certificate-loading helpers for External Key Manager (EKM)
    /// connection cmdlets. Mirrors the rules implemented by the Azure CLI
    /// (<c>az keyvault ekm-connection</c>).
    /// </summary>
    internal static class EkmConnectionHelper
    {
        private const int MaxPathPrefixLength = 64;
        private const string PemBegin = "-----BEGIN CERTIFICATE-----";
        private const string PemEnd = "-----END CERTIFICATE-----";

        private static readonly Regex PathPrefixRegex = new Regex("^[A-Za-z0-9/-]+$", RegexOptions.Compiled);

        /// <summary>
        /// Validates and normalizes an EKM proxy host. Rejects scheme/path,
        /// defaults the port to 443 when omitted, and validates the port range.
        /// </summary>
        public static string NormalizeHost(string host)
        {
            host = (host ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(host))
            {
                throw new AzPSArgumentException("Host cannot be empty.", nameof(host));
            }
            if (host.Contains("://"))
            {
                throw new AzPSArgumentException("Host must not include a URL scheme (use FQDN or FQDN:port).", nameof(host));
            }
            if (host.Contains("/"))
            {
                throw new AzPSArgumentException("Host must not include a path (use FQDN or FQDN:port).", nameof(host));
            }

            int colonCount = 0;
            foreach (char c in host)
            {
                if (c == ':') colonCount++;
            }

            if (colonCount == 0)
            {
                return host + ":443";
            }

            // A single colon is required; more than one indicates an IPv6 literal which is not supported.
            if (colonCount != 1)
            {
                throw new AzPSArgumentException("Host must be in the form FQDN or FQDN:port.", nameof(host));
            }

            var parts = host.Split(':');
            string hostname = parts[0];
            string portStr = parts[1];
            if (string.IsNullOrEmpty(hostname))
            {
                throw new AzPSArgumentException("Host must be in the form FQDN or FQDN:port.", nameof(host));
            }
            if (!int.TryParse(portStr, out int port))
            {
                throw new AzPSArgumentException("Host port must be an integer.", nameof(host));
            }
            if (port < 1 || port > 65535)
            {
                throw new AzPSArgumentException("Host port must be between 1 and 65535.", nameof(host));
            }
            return hostname + ":" + port;
        }

        /// <summary>
        /// Validates an optional EKM path prefix. Must start with "/", must not end
        /// with "/", be at most 64 characters, and contain only letters, digits,
        /// "/" and "-".
        /// </summary>
        public static void ValidatePathPrefix(string pathPrefix)
        {
            if (pathPrefix == null)
            {
                return;
            }
            if (!pathPrefix.StartsWith("/", StringComparison.Ordinal))
            {
                throw new AzPSArgumentException("PathPrefix must start with \"/\".", nameof(pathPrefix));
            }
            if (pathPrefix.EndsWith("/", StringComparison.Ordinal))
            {
                throw new AzPSArgumentException("PathPrefix must not end with \"/\".", nameof(pathPrefix));
            }
            if (pathPrefix.Length > MaxPathPrefixLength)
            {
                throw new AzPSArgumentException($"PathPrefix must be at most {MaxPathPrefixLength} characters.", nameof(pathPrefix));
            }
            if (!PathPrefixRegex.IsMatch(pathPrefix))
            {
                throw new AzPSArgumentException("PathPrefix may contain only letters, digits, \"/\" and \"-\".", nameof(pathPrefix));
            }
        }

        /// <summary>
        /// Loads the supplied certificate file paths into a list of DER-encoded byte
        /// arrays. Each file may be a single DER certificate or a PEM file containing
        /// one or more certificate blocks.
        /// </summary>
        public static List<byte[]> LoadCertificatesAsDer(IEnumerable<string> certPaths)
        {
            var derCerts = new List<byte[]>();
            if (certPaths == null)
            {
                return derCerts;
            }

            foreach (var certPath in certPaths)
            {
                if (string.IsNullOrEmpty(certPath))
                {
                    continue;
                }

                string expanded = Environment.ExpandEnvironmentVariables(certPath);
                byte[] raw;
                try
                {
                    raw = File.ReadAllBytes(expanded);
                }
                catch (Exception ex)
                {
                    throw new AzPSArgumentException($"Failed to read certificate file '{certPath}': {ex.Message}", nameof(certPaths));
                }

                string asText = Encoding.UTF8.GetString(raw);
                if (asText.Contains(PemBegin))
                {
                    bool foundAny = false;
                    int start = 0;
                    while (true)
                    {
                        int beginIdx = asText.IndexOf(PemBegin, start, StringComparison.Ordinal);
                        if (beginIdx == -1)
                        {
                            break;
                        }
                        int endIdx = asText.IndexOf(PemEnd, beginIdx, StringComparison.Ordinal);
                        if (endIdx == -1)
                        {
                            throw new AzPSArgumentException($"Invalid PEM certificate in '{certPath}'.", nameof(certPaths));
                        }

                        string base64 = asText
                            .Substring(beginIdx + PemBegin.Length, endIdx - (beginIdx + PemBegin.Length))
                            .Replace("\r", string.Empty)
                            .Replace("\n", string.Empty)
                            .Trim();
                        try
                        {
                            derCerts.Add(Convert.FromBase64String(base64));
                        }
                        catch (FormatException)
                        {
                            throw new AzPSArgumentException($"Invalid PEM certificate in '{certPath}'.", nameof(certPaths));
                        }
                        foundAny = true;
                        start = endIdx + PemEnd.Length;
                    }
                    if (!foundAny)
                    {
                        throw new AzPSArgumentException($"Invalid PEM certificate in '{certPath}'.", nameof(certPaths));
                    }
                }
                else
                {
                    // Assume DER.
                    derCerts.Add(raw);
                }
            }

            return derCerts;
        }
    }
}
