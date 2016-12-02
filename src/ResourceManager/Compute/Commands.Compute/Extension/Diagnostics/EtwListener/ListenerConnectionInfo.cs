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
using System.Diagnostics;

namespace Microsoft.VisualStudio.EtwListener.Common
{
    internal class ListenerConnectionInfo
    {
        public string DnsName { get; set; }

        public string IpAddress { get; set; }

        public int Port { get; set; }

        public string ServerCertificateThumbprint { get; set; }

        public string ClientCertificateThumbprint { get; set; }

        public ListenerConnectionInfo(string dnsName, string ipAddress, int port, string serverCertificateThumbprint, string clientCertificateThumbprint)
        {
            if (string.IsNullOrEmpty(dnsName))
            {
                throw new ArgumentException("dnsName cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(ipAddress))
            {
                throw new ArgumentException("ipAddress cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(serverCertificateThumbprint))
            {
                throw new ArgumentException("serverCertificateThumbprint cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(clientCertificateThumbprint))
            {
                throw new ArgumentException("clientCertificateThumbprint cannot be null or empty.");
            }

            this.DnsName = dnsName;
            this.IpAddress = ipAddress;
            this.Port = port;
            this.ServerCertificateThumbprint = serverCertificateThumbprint;
            this.ClientCertificateThumbprint = clientCertificateThumbprint;
        }
    }
}
