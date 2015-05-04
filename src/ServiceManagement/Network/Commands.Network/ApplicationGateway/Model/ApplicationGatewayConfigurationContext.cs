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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.ApplicationGateway.Model
{
    using System.Collections.Generic;

    public class ApplicationGatewayConfigurationContext
    {
        public Dictionary<string, FrontendIPConfiguration> FrontendIPConfigurations;
        public Dictionary<string, FrontendPort> FrontendPorts;
        public Dictionary<string, BackendAddressPool> BackendAddressPools;
        public Dictionary<string, BackendHttpSettings> BackendHttpSettingsList;
        public Dictionary<string, HttpListener> HttpListeners;
        public Dictionary<string, HttpLoadBalancingRule> HttpLoadBalancingRules;

        ApplicationGatewayConfiguration Configuration { get; set; }

        public ApplicationGatewayConfigurationContext()
        {
            this.FrontendIPConfigurations = new Dictionary<string, FrontendIPConfiguration>();
            this.FrontendPorts = new Dictionary<string, FrontendPort>();
            this.BackendAddressPools = new Dictionary<string, BackendAddressPool>();
            this.BackendHttpSettingsList = new Dictionary<string, BackendHttpSettings>();
            this.HttpListeners = new Dictionary<string, HttpListener>();
            this.HttpLoadBalancingRules = new Dictionary<string, HttpLoadBalancingRule>();
        }

        internal ApplicationGatewayConfigurationContext(ApplicationGatewayConfiguration configuration)
            :this()
        {
            this.Configuration = configuration;
        }
        
        internal void ProcessConfigurationElements()
        {
            FlattenConfigurationElementsAndValidateElementUniquesness();

            ValidateConfigElements();
        }

        private void FlattenConfigurationElementsAndValidateElementUniquesness()
        {
            if (this.Configuration.FrontendIPConfigurations != null)
            {
                foreach (var ipConfiguration in this.Configuration.FrontendIPConfigurations)
                {
                    if (FrontendIPConfigurations.ContainsKey(ipConfiguration.Name.ToLower()))
                    {
                        throw new ApplicationGatewayConfigurationValidationException(
                            string.Format("FrontendIPConfiguration with name: {0} already exists", ipConfiguration.Name));
                    }

                    ipConfiguration.ConfigurationContext = this;
                    FrontendIPConfigurations.Add(ipConfiguration.Name.ToLower(), ipConfiguration);
                }               
            }

            foreach (var frontendPort in this.Configuration.FrontendPorts)
            {
                if (FrontendPorts.ContainsKey(frontendPort.Name.ToLower()))
                {
                    throw new ApplicationGatewayConfigurationValidationException(
                        string.Format("FrontendPort with name: {0} already exists", frontendPort.Name));
                }

                frontendPort.ConfigurationContext = this;
                FrontendPorts.Add(frontendPort.Name.ToLower(), frontendPort);
            }

            foreach (var backendAddressPool in this.Configuration.BackendAddressPools)
            {
                if (BackendAddressPools.ContainsKey(backendAddressPool.Name.ToLower()))
                {
                    throw new ApplicationGatewayConfigurationValidationException(
                        string.Format("BackendAddressPool with name: {0} already exists", backendAddressPool.Name));
                }

                backendAddressPool.ConfigurationContext = this;
                BackendAddressPools.Add(backendAddressPool.Name.ToLower(), backendAddressPool);
            }

            foreach (var backendHttpSettings in this.Configuration.BackendHttpSettingsList)
            {
                if (BackendHttpSettingsList.ContainsKey(backendHttpSettings.Name.ToLower()))
                {
                    throw new ApplicationGatewayConfigurationValidationException(
                        string.Format("BackendHttpSettings with name: {0} already exists", backendHttpSettings.Name));
                }

                backendHttpSettings.ConfigurationContext = this;
                BackendHttpSettingsList.Add(backendHttpSettings.Name.ToLower(), backendHttpSettings);
            }

            foreach (var httpListener in this.Configuration.HttpListeners)
            {
                if (HttpListeners.ContainsKey(httpListener.Name.ToLower()))
                {
                    throw new ApplicationGatewayConfigurationValidationException(
                        string.Format("httpListener with name: {0} already exists", httpListener.Name));
                }

                httpListener.ConfigurationContext = this;
                HttpListeners.Add(httpListener.Name.ToLower(), httpListener);
            }

            foreach (var httpLoadBalancingRule in this.Configuration.HttpLoadBalancingRules)
            {
                if (HttpLoadBalancingRules.ContainsKey(httpLoadBalancingRule.Name.ToLower()))
                {
                    throw new ApplicationGatewayConfigurationValidationException(
                        string.Format("httpLoadBalancingRule with name: {0} already exists", httpLoadBalancingRule.Name));
                }

                httpLoadBalancingRule.ConfigurationContext = this;
                HttpLoadBalancingRules.Add(httpLoadBalancingRule.Name.ToLower(), httpLoadBalancingRule);
            }
        }

        private void ValidateConfigElements()
        {
            this.Configuration.Validate();

            if (this.FrontendIPConfigurations.Count > 0)
            {
                foreach (var ipConfig in this.Configuration.FrontendIPConfigurations)
                {
                    ipConfig.Validate();
                }
            }

            foreach (var frontendPort in this.Configuration.FrontendPorts)
            {
                frontendPort.Validate();
            }

            foreach (var backendAddressPool in this.Configuration.BackendAddressPools)
            {
                backendAddressPool.Validate();
            }

            foreach (var backendHttpSettings in this.Configuration.BackendHttpSettingsList)
            {
                backendHttpSettings.Validate();
            }

            foreach (var httpListener in this.Configuration.HttpListeners)
            {
                httpListener.Validate();
            }

            foreach (var httpLoadBalancingRule in this.Configuration.HttpLoadBalancingRules)
            {
                httpLoadBalancingRule.Validate();
            }
        }
    }
}
