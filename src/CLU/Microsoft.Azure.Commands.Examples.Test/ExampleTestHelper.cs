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
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Factories;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Microsoft.Azure.Commands.Examples.Test
{
    public class ExampleTestHelper
    {
        Random _generator;
        string _resourceGroupName;
        IClientFactory _clientFactory = new ClientFactory();
        ITestContext _context = new EnvironmentTestContext();
        ResourceManagementClient _client;
        const string DefaultLocation = "West US";

        public ExampleTestHelper() : this(new Random())
        {
        }

        public ExampleTestHelper(int seed) : this(new Random(seed))
        {
        }


        public ExampleTestHelper(Random generator)
        {
            _generator = generator;
        }

        public IClientFactory ClientFactory
        {
            get { return _clientFactory; }
            set { _clientFactory = value; }
        }

        public ITestContext TestContext
        {
            get { return _context; }
            set { _context = value; }
        }

        public void RunTest(string testPath, string deploymentTemplatePath)
        {
            if (!File.Exists(testPath))
            {
                throw new InvalidOperationException($"Path to test script '{testPath}' does not exist.");
            }

            if (!string.IsNullOrEmpty(deploymentTemplatePath))
            {
                if (!File.Exists(deploymentTemplatePath))
                {
                    throw new InvalidOperationException($"Path to deployment template '{deploymentTemplatePath}' does not exist.");
                }
            }
            try
            {
                DeployTemplate(deploymentTemplatePath, CreateRandomName());
            }
            finally
            {
                Cleanup();
            }
        }

        public void DeployTemplate(string deploymentTemplatePath, string resourceGroupName)
        {
            EnsureClient();
            var location = GetLocation();
            CreateResourceGroup(resourceGroupName, location);
            var template = JObject.Parse(File.ReadAllText(deploymentTemplatePath));
            var deployment = _client.Deployments.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, "testDeployment",
                new Deployment(new DeploymentProperties(template: template, mode: DeploymentMode.Complete))).GetAwaiter().GetResult();
            if (!deployment.Response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException($"Deployment failed with response: {deployment.Response.AsFormattedString()}");
            }
        }

        public string CreateRandomName()
        {
            return "clutst" + _generator.Next(10000, 99999);
        }

        private void EnsureClient()
        {
            if (this._client == null)
            {
                var context = _context.Context;
                var _client = _clientFactory.CreateArmClient<ResourceManagementClient>(context,
                    AzureEnvironment.Endpoint.ResourceManager);
            }
        }


        private string GetLocation()
        {
            return DefaultLocation;
        }

        private void CreateResourceGroup(string resourceGroupName, string location)
        {
            var response =
                _client.ResourceGroups.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName,
                    new ResourceGroup(location: location)).GetAwaiter().GetResult();
            _resourceGroupName = resourceGroupName;
        }

        public void Cleanup()
        {
            if (_client != null && !string.IsNullOrWhiteSpace(_resourceGroupName))
                _client.ResourceGroups.DeleteWithHttpMessagesAsync(_resourceGroupName).GetAwaiter().GetResult();
            _client = null;
            _resourceGroupName = null;
        }
    }
}
