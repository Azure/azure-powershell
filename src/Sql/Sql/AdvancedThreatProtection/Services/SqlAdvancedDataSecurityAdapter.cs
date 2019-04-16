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
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.AdvancedThreatProtection.Model;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.ThreatDetection.Model;
using Microsoft.Azure.Commands.Sql.ThreatDetection.Services;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.Sql.AdvancedThreatProtection.Services
{
    /// <summary>
    /// The SqlAdvancedDataSecurityAdapter class is responsible for transforming the data that was received form the endpoints to the cmdlets model of AdvancedDataSecurity policy and vice versa
    /// </summary>
    public class SqlAdvancedDataSecurityAdapter
    {
        /// <summary>
        /// Gets or sets the Azure subscription
        /// </summary>
        private IAzureSubscription Subscription { get; set; }

        /// <summary>
        /// The Threat Detection endpoints communicator used by this adapter
        /// </summary>
        private SqlThreatDetectionAdapter SqlThreatDetectionAdapter { get; set; }

        /// <summary>
        /// The Azure endpoints communicator used by this adapter
        /// </summary>
        private AzureEndpointsCommunicator AzureCommunicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        public SqlAdvancedDataSecurityAdapter(IAzureContext context)
        {
            Context = context;
            Subscription = context?.Subscription;
            SqlThreatDetectionAdapter = new SqlThreatDetectionAdapter(Context);
            AzureCommunicator = new AzureEndpointsCommunicator(Context);
        }

        /// <summary>
        /// Provides a server Advanced Data Security policy model for the given server
        /// </summary>
        public ServerAdvancedDataSecurityPolicyModel GetServerAdvancedDataSecurityPolicy(string resourceGroup, string serverName)
        {
            // Currently Advanced Threat Protection policy is a TD policy until the backend will support Advanced Threat Protection APIs
            var threatDetectionPolicy = SqlThreatDetectionAdapter.GetServerThreatDetectionPolicy(resourceGroup, serverName);
            var serverAdvancedDataSecurityPolicyModel = new ServerAdvancedDataSecurityPolicyModel()
            {
                ResourceGroupName = resourceGroup,
                ServerName = serverName,
                IsEnabled = (threatDetectionPolicy.ThreatDetectionState == ThreatDetectionStateType.Enabled)
            };

            return serverAdvancedDataSecurityPolicyModel;
        }

        /// <summary>
        /// Provides a managed instance Advanced Data Security policy model for the given managed instance
        /// </summary>
        public ManagedInstanceAdvancedDataSecurityPolicyModel GetManagedInstanceAdvancedDataSecurityPolicy(string resourceGroup, string managedInstanceName)
        {
            // Currently Advanced Threat Protection policy is a TD policy until the backend will support Advanced Threat Protection APIs
            var threatDetectionPolicy = SqlThreatDetectionAdapter.GetManagedInstanceThreatDetectionPolicy(resourceGroup, managedInstanceName);
            var managedInstanceAdvancedDataSecurityPolicy = new ManagedInstanceAdvancedDataSecurityPolicyModel()
            {
                ResourceGroupName = resourceGroup,
                ManagedInstanceName = managedInstanceName,
                IsEnabled = (threatDetectionPolicy.ThreatDetectionState == ThreatDetectionStateType.Enabled)
            };

            return managedInstanceAdvancedDataSecurityPolicy;
        }

        /// <summary>
        /// Sets a server Advanced Data Security policy model for the given server
        /// </summary>
        public ServerAdvancedDataSecurityPolicyModel SetServerAdvancedDataSecurity(ServerAdvancedDataSecurityPolicyModel model)
        {
            // Currently Advanced Data Security policy is a TD policy until the backend will support Advanced Data Security APIs
            var threatDetectionPolicy = SqlThreatDetectionAdapter.GetServerThreatDetectionPolicy(model.ResourceGroupName, model.ServerName);

            threatDetectionPolicy.ThreatDetectionState = model.IsEnabled ? ThreatDetectionStateType.Enabled : ThreatDetectionStateType.Disabled;

            SqlThreatDetectionAdapter.SetServerThreatDetectionPolicy(threatDetectionPolicy, AzureEnvironment.Endpoint.StorageEndpointSuffix);

            return model;
        }

        /// <summary>
        /// Sets a managed instance Advanced Data Security policy model for the given managed instance
        /// </summary>
        public ManagedInstanceAdvancedDataSecurityPolicyModel SetManagedInstanceAdvancedDataSecurity(ManagedInstanceAdvancedDataSecurityPolicyModel model)
        {
            // Currently Advanced Data Security policy is a TD policy until the backend will support Advanced Data Security APIs
            var threatDetectionPolicy = SqlThreatDetectionAdapter.GetManagedInstanceThreatDetectionPolicy(model.ResourceGroupName, model.ManagedInstanceName);

            threatDetectionPolicy.ThreatDetectionState = model.IsEnabled ? ThreatDetectionStateType.Enabled : ThreatDetectionStateType.Disabled;

            SqlThreatDetectionAdapter.SetManagedInstanceThreatDetectionPolicy(threatDetectionPolicy, AzureEnvironment.Endpoint.StorageEndpointSuffix);

            return model;
        }

        /// <summary>
        /// Deploys an ARM template that enables ADS with VA on server
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="serverName">The server name</param>
        /// <param name="serverLocation">The server location</param>
        /// <param name="deploymentName">The name of the deployment (can be null - in this case a random name will be generated)</param>
        public void EnableServerAdsWithVa(string resourceGroupName, string serverName, string serverLocation, string deploymentName)
        {
            EnableAdsWithVa(resourceGroupName, serverName, serverLocation, @"DeployServerAdsWithVaTemplate.json", deploymentName);
        }

        /// <summary>
        /// Deploys an ARM template that enables ADS with VA on managed instance
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="instanceName">The managed instance name</param>
        /// <param name="instanceLocation">The managed instance location</param>
        /// <param name="deploymentName">The name of the deployment (can be null - in this case a random name will be generated)</param>
        public void EnableInstanceAdsWithVa(string resourceGroupName, string instanceName, string instanceLocation, string deploymentName)
        {
            EnableAdsWithVa(resourceGroupName, instanceName, instanceLocation, @"DeployInstanceAdsWithVaTemplate.json", deploymentName);
        }

        private void EnableAdsWithVa(string resourceGroupName, string serverName, string serverLocation, string templateName, string deploymentName)
        {
            // Generate deployment name if it was not provided
            if (string.IsNullOrEmpty(deploymentName))
            {
                deploymentName = "EnableADS_" + serverName + "_" + Guid.NewGuid().ToString("N");
            }

            // Trim deployment name as it has a maximum of 64 chars
            if (deploymentName.Length > 64)
            {
                deploymentName = deploymentName.Substring(0, 64);
            }

            Dictionary<string, object> parametersDictionary = new Dictionary<string, object>
            {
                {"serverName", new Dictionary<string, object> { {"value", serverName } }},
                {"location", new Dictionary<string, object> { {"value", serverLocation } }},
            };
            string parameters = JsonConvert.SerializeObject(parametersDictionary, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.None,
                Formatting = Formatting.Indented
            });

            var properties = new DeploymentProperties
            {
                Mode = DeploymentMode.Incremental,
                Parameters = JObject.Parse(parameters),
                Template = JObject.Parse(GetArmTemplateContent(templateName)),
            };

            Deployment deployment = new Deployment(properties);

            AzureCommunicator.DeployArmTemplate(resourceGroupName, deploymentName, deployment);
        }

        /// <summary>
        /// Returns the string content of the given template name
        /// </summary>
        /// <param name="templateName">The json file template name (with *.json ending)</param>
        /// <returns>The string content of the given template name</returns>
        private string GetArmTemplateContent(string templateName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames().FirstOrDefault(str => str.EndsWith(templateName));
            string template;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    template = reader.ReadToEnd();
                }
            }

            return template;
        }
    }
}
