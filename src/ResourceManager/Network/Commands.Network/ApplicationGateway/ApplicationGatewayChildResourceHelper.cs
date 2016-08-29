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
using System;

namespace Microsoft.Azure.Commands.Network
{
    public static class ApplicationGatewayChildResourceHelper
    {
        public static string GetResourceId(
            string subscriptionId,
            string resourceGroupName,
            string applicationGatewayName,
            string resource,
            string resourceName)
        {
            return string.Format(
                Microsoft.Azure.Commands.Network.Properties.Resources.ApplicationGatewayChildResourceId,
                subscriptionId,
                resourceGroupName,
                applicationGatewayName,
                resource,
                resourceName);
        }

        public static string GetResourceNotSetId(string subscriptionId, string resource, string resourceName)
        {
            return string.Format(
                Microsoft.Azure.Commands.Network.Properties.Resources.ApplicationGatewayChildResourceId,
                subscriptionId,
                Microsoft.Azure.Commands.Network.Properties.Resources.ResourceGroupNotSet,
                Microsoft.Azure.Commands.Network.Properties.Resources.ApplicationGatewayNameNotSet,
                resource,
                resourceName);
        }

        private static string NormalizeApplicationGatewayNameChildResourceIds(string id, string resourceGroupName, string applicationGatewayName)
        {
            id = NormalizeId(id, "resourceGroups", resourceGroupName);
            id = NormalizeId(id, "applicationGateways", applicationGatewayName);

            return id;
        }

        private static string NormalizeId(string id, string resourceName, string resourceValue)
        {
            int startIndex = id.IndexOf(resourceName, StringComparison.OrdinalIgnoreCase) + resourceName.Length + 1;
            int endIndex = id.IndexOf("/", startIndex, StringComparison.OrdinalIgnoreCase);

            // Replace the following string '/{value}/'
            startIndex--;
            string orignalString = id.Substring(startIndex, endIndex - startIndex + 1);

            return id.Replace(orignalString, string.Format("/{0}/", resourceValue));
        }

        public static void NormalizeChildResourcesId(PSApplicationGateway applicationGateway)
        {
            // Normalize GatewayIpConfiguration
            if (applicationGateway.GatewayIPConfigurations != null)
            {
                foreach (var gatewayIpConfig in applicationGateway.GatewayIPConfigurations)
                {
                    gatewayIpConfig.Id = string.Empty;
                }
            }

            // Normalize SslCertificates
            if (applicationGateway.SslCertificates != null)
            {
                foreach (var sslCertificate in applicationGateway.SslCertificates)
                {
                    sslCertificate.Id = string.Empty;
                }
            }

            // Normalize AuthenticationCertificates
            if (applicationGateway.AuthenticationCertificates != null)
            {
                foreach (var authCertificate in applicationGateway.AuthenticationCertificates)
                {
                    authCertificate.Id = string.Empty;
                }
            }

            // Normalize FrontendIpConfiguration
            if (applicationGateway.FrontendIPConfigurations != null)
            {
                foreach (var frontendIpConfiguration in applicationGateway.FrontendIPConfigurations)
                {
                    frontendIpConfiguration.Id = string.Empty;
                }
            }

            // Normalize FrontendPort
            if (applicationGateway.FrontendPorts != null)
            {
                foreach (var frontendPort in applicationGateway.FrontendPorts)
                {
                    frontendPort.Id = string.Empty;
                }
            }

            // Normalize BackendAddressPool
            if (applicationGateway.BackendAddressPools != null)
            {
                foreach (var backendAddressPool in applicationGateway.BackendAddressPools)
                {
                    backendAddressPool.Id = string.Empty;
                }
            }

            // Normalize Probe
            if (applicationGateway.Probes != null)
            {
                foreach (var probe in applicationGateway.Probes)
                {
                    probe.Id = string.Empty;
                }
            }

            // Normalize BackendHttpSettings
            if (applicationGateway.BackendHttpSettingsCollection != null)
            {
                foreach (var backendHttpSettings in applicationGateway.BackendHttpSettingsCollection)
                {
                    backendHttpSettings.Id = string.Empty;

                    if (null != backendHttpSettings.Probe)
                    {
                        backendHttpSettings.Probe.Id = NormalizeApplicationGatewayNameChildResourceIds(
                                                    backendHttpSettings.Probe.Id,
                                                    applicationGateway.ResourceGroupName,
                                                    applicationGateway.Name);
                    }
                    if (null != backendHttpSettings.AuthenticationCertificates)
                    {
                        foreach (var authCert in backendHttpSettings.AuthenticationCertificates)
                        {
                            authCert.Id = NormalizeApplicationGatewayNameChildResourceIds(
                                                    authCert.Id,
                                                    applicationGateway.ResourceGroupName,
                                                    applicationGateway.Name);
                        }
                    }
                }
            }

            // Normalize HttpListener
            if (applicationGateway.HttpListeners != null)
            {
                foreach (var httpListener in applicationGateway.HttpListeners)
                {
                    httpListener.Id = string.Empty;

                    httpListener.FrontendPort.Id = NormalizeApplicationGatewayNameChildResourceIds(
                                                httpListener.FrontendPort.Id,
                                                applicationGateway.ResourceGroupName,
                                                applicationGateway.Name);

                    if (null != httpListener.FrontendIpConfiguration)
                    {
                        httpListener.FrontendIpConfiguration.Id = NormalizeApplicationGatewayNameChildResourceIds(
                                                                        httpListener.FrontendIpConfiguration.Id,
                                                                        applicationGateway.ResourceGroupName,
                                                                        applicationGateway.Name);
                    }

                    if (null != httpListener.SslCertificate)
                    {
                        httpListener.SslCertificate.Id = NormalizeApplicationGatewayNameChildResourceIds(
                                                                        httpListener.SslCertificate.Id,
                                                                        applicationGateway.ResourceGroupName,
                                                                        applicationGateway.Name);
                    }
                }
            }

            // Normalize UrlPathMap
            if (applicationGateway.UrlPathMaps != null)
            {
                foreach (var urlPathMap in applicationGateway.UrlPathMaps)
                {
                    urlPathMap.Id = string.Empty;

                    urlPathMap.DefaultBackendAddressPool.Id = NormalizeApplicationGatewayNameChildResourceIds(
                                                    urlPathMap.DefaultBackendAddressPool.Id,
                                                    applicationGateway.ResourceGroupName,
                                                    applicationGateway.Name);

                    urlPathMap.DefaultBackendHttpSettings.Id = NormalizeApplicationGatewayNameChildResourceIds(
                                                    urlPathMap.DefaultBackendHttpSettings.Id,
                                                    applicationGateway.ResourceGroupName,
                                                    applicationGateway.Name);

                    foreach (var pathRule in urlPathMap.PathRules)
                    {
                        pathRule.BackendAddressPool.Id = NormalizeApplicationGatewayNameChildResourceIds(
                                      pathRule.BackendAddressPool.Id,
                                      applicationGateway.ResourceGroupName,
                                      applicationGateway.Name);

                        pathRule.BackendHttpSettings.Id = NormalizeApplicationGatewayNameChildResourceIds(
                                                        pathRule.BackendHttpSettings.Id,
                                                        applicationGateway.ResourceGroupName,
                                                        applicationGateway.Name);
                    }
                }
            }

            // Normalize RequestRoutingRule
            if (applicationGateway.RequestRoutingRules != null)
            {
                foreach (var requestRoutingRule in applicationGateway.RequestRoutingRules)
                {
                    requestRoutingRule.Id = string.Empty;

                    requestRoutingRule.HttpListener.Id = NormalizeApplicationGatewayNameChildResourceIds(
                                                                    requestRoutingRule.HttpListener.Id,
                                                                    applicationGateway.ResourceGroupName,
                                                                    applicationGateway.Name);

                    if (null != requestRoutingRule.BackendAddressPool)
                    {
                        requestRoutingRule.BackendAddressPool.Id = NormalizeApplicationGatewayNameChildResourceIds(
                                                                        requestRoutingRule.BackendAddressPool.Id,
                                                                        applicationGateway.ResourceGroupName,
                                                                        applicationGateway.Name);
                    }

                    if (null != requestRoutingRule.BackendHttpSettings)
                    {
                        requestRoutingRule.BackendHttpSettings.Id = NormalizeApplicationGatewayNameChildResourceIds(
                                                                    requestRoutingRule.BackendHttpSettings.Id,
                                                                    applicationGateway.ResourceGroupName,
                                                                    applicationGateway.Name);
                    }

                    if (null != requestRoutingRule.UrlPathMap)
                    {
                        requestRoutingRule.UrlPathMap.Id = NormalizeApplicationGatewayNameChildResourceIds(
                                                                    requestRoutingRule.UrlPathMap.Id,
                                                                    applicationGateway.ResourceGroupName,
                                                                    applicationGateway.Name);
                    }
                }
            }
        }
    }
}
