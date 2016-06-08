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
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers
{
    public class ConfigurationSetsBuilder
    {
        private ConfigurationSetBuilder<WindowsProvisioningConfigurationSet> windowsBuilder;
        private ConfigurationSetBuilder<LinuxProvisioningConfigurationSet> linuxBuilder;
        private NetworkConfigurationSetBuilder networkConfigurationBuilder;

        public Collection<ConfigurationSet> ConfigurationSets { get; set; }

        public ConfigurationSetBuilder<WindowsProvisioningConfigurationSet> WindowsConfigurationBuilder
        {
            get { return windowsBuilder ?? (windowsBuilder = new ConfigurationSetBuilder<WindowsProvisioningConfigurationSet>(ConfigurationSets)); }
        }

        public ConfigurationSetBuilder<LinuxProvisioningConfigurationSet> LinuxConfigurationBuilder
        {
            get { return linuxBuilder ?? (linuxBuilder = new ConfigurationSetBuilder<LinuxProvisioningConfigurationSet>(ConfigurationSets)); }
        }

        public NetworkConfigurationSetBuilder NetworkConfigurationBuilder
        {
            get { return networkConfigurationBuilder ?? (networkConfigurationBuilder = new NetworkConfigurationSetBuilder(ConfigurationSets)); }
        }

        public ConfigurationSetsBuilder(Collection<ConfigurationSet> configurationSets)
        {
            if (configurationSets == null)
            {
                throw new ArgumentNullException("configurationSets");
            }
            ConfigurationSets = configurationSets;
        }
    }

    public class ConfigurationSetBuilder<T> where T: ProvisioningConfigurationSet, new()
    {
        protected Collection<ConfigurationSet> ConfigurationSets { get; set; }

        public T Provisioning { get; private set; }

        public ConfigurationSetBuilder(Collection<ConfigurationSet> configurationSets)
        {
            if (configurationSets == null)
            {
                throw new ArgumentNullException("configurationSets");
            }
            this.ConfigurationSets = configurationSets;
            Initialize();
        }

        private void Initialize()
        {
            var provisioningConfigurationSet = ConfigurationSets.OfType<T>().SingleOrDefault();
            if (provisioningConfigurationSet == null)
            {
                Provisioning = new T();
                ConfigurationSets.Add(Provisioning);
            }
            else
            {
                Provisioning = provisioningConfigurationSet;
            }
        }

        public static bool ConfigurationExists(Collection<ConfigurationSet> configurationSets)
        {
            return configurationSets.OfType<T>().SingleOrDefault() != null;
        }
    }

    public class NetworkConfigurationSetBuilder
    {
        private const int RDPPortNumber = 3389;
        private const int WinRMPortNumber = 5986;
        private const int SSHPortNumber = 22;
        private const string TcpProtocol = "tcp";
        private const string RdpEndpointName = "RemoteDesktop";
        private const string SSHEndpointName = "SSH";

        protected Collection<ConfigurationSet> ConfigurationSets { get; set; }

        public static bool HasNetworkConfigurationSet(Collection<ConfigurationSet> configurationSets)
        {
            return configurationSets.OfType<NetworkConfigurationSet>().SingleOrDefault() != null;
        }

        public NetworkConfigurationSet NetworkConfigurationSet
        {
            get;
            private set;
        }

        public NetworkConfigurationSetBuilder(Collection<ConfigurationSet> configurationSets)
        {
            this.ConfigurationSets = configurationSets;
            Initialize();
        }

        private void Initialize()
        {
            var networkConfigurationSet = ConfigurationSets.OfType<NetworkConfigurationSet>().SingleOrDefault();
            if (networkConfigurationSet == null)
            {
                NetworkConfigurationSet = new NetworkConfigurationSet();
                ConfigurationSets.Add(NetworkConfigurationSet);
            }
            else
            {
                NetworkConfigurationSet = networkConfigurationSet;
            }

            if (NetworkConfigurationSet.InputEndpoints == null)
            {
                NetworkConfigurationSet.InputEndpoints = new Collection<InputEndpoint>();
            }
        }

        public void AddWinRmEndpoint()
        {
            var winRmEndpoint = GetWinRmEndpoint(NetworkConfigurationSet);
            if (winRmEndpoint != null)
            {
                winRmEndpoint.Port = null; // null out to avoid conflicts
            }
            else
            {
                NetworkConfigurationSet.InputEndpoints.Add(
                    new InputEndpoint
                    {
                        LocalPort = WinRMPortNumber,
                        Protocol = TcpProtocol,
                        Name = WinRMConstants.EndpointName
                    });
            }
        }

        private static InputEndpoint GetWinRmEndpoint(NetworkConfigurationSet networkConfigurationSet)
        {
            return networkConfigurationSet.InputEndpoints.FirstOrDefault(
                ep => string.Equals(WinRMConstants.EndpointName, ep.Name, StringComparison.OrdinalIgnoreCase)
                   || ep.LocalPort == WinRMPortNumber);
        }

        public void AddRdpEndpoint()
        {
            var endPoint = GetRdpEndpoint(NetworkConfigurationSet);
            if (endPoint != null)
            {
                endPoint.Port = null; // null out to avoid conflicts
            }
            else
            {
                var rdpEndpoint = new InputEndpoint { LocalPort = RDPPortNumber, Protocol = TcpProtocol, Name = RdpEndpointName };
                NetworkConfigurationSet.InputEndpoints.Add(rdpEndpoint);
            }
        }

        private static InputEndpoint GetRdpEndpoint(NetworkConfigurationSet networkConfigurationSet)
        {
            return networkConfigurationSet.InputEndpoints.FirstOrDefault(ep => RdpEndpointName.Equals(ep.Name, StringComparison.OrdinalIgnoreCase) || ep.LocalPort == RDPPortNumber);
        }

        public void AddSshEndpoint()
        {
            var endpoint = GetSSHEndpoint(NetworkConfigurationSet);
            if (endpoint != null)
            {
                endpoint.Port = null;  // null out to avoid conflicts
            }
            else
            {
                var sshEndpoint = new InputEndpoint { LocalPort = SSHPortNumber, Protocol = TcpProtocol, Name = SSHEndpointName };
                NetworkConfigurationSet.InputEndpoints.Add(sshEndpoint);
            }
        }

        private static InputEndpoint GetSSHEndpoint(NetworkConfigurationSet networkConfigurationSet)
        {
            return networkConfigurationSet.InputEndpoints.FirstOrDefault(ep => SSHEndpointName.Equals(ep.Name, StringComparison.OrdinalIgnoreCase) || ep.LocalPort == SSHPortNumber);
        }
    }
}