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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Factories;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.Examples.Test
{
    public class ExampleTestHelper
    {
        Random _generator;
        string _resourceGroupName;
        IClientFactory _clientFactory = new ClientFactory();
        ITestContext _context = new EnvironmentTestContext();
        List<IScriptEnvironmentHelper> _environmentHelpers = new List<IScriptEnvironmentHelper> { new AuthenticationEnvironmentHelper()};
        ResourceManagementClient _client;
        const string DefaultLocation = "West US";
        const string ResourceGroupNameKey = "resourceGroupName";
        const string locationKey = "resourceGroupLocation";
        const string SessionKey = "CmdletSessionId";

        public ExampleTestHelper() : this(new Random())
        {
        }

        public ExampleTestHelper(int seed) : this(new Random(seed))
        {
        }


        public ExampleTestHelper(Random generator)
        {
            _generator = generator;
            _environmentHelpers.Add(new RandomNameEnvironmentHelper(_generator, SessionKey));
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

        public List<IScriptEnvironmentHelper> EnvironmentHelpers { get { return _environmentHelpers; } }
        public void RunTest(string testName)
        {
            var testDirectory = Path.GetFullPath(_context.TestDirectory);
            string testFile = $"{testName}{_context.TestScriptSuffix}";
            string testPath = Path.Combine(testDirectory, testFile);
            if (!File.Exists(testPath))
            {
                throw new InvalidOperationException($"Path to test script '{testPath}' does not exist.");
            }

            string deploymentTemplatePath = Path.Combine(testDirectory, $"{testName}.json");
            try
            {
                _resourceGroupName = CreateRandomName();
                if (File.Exists(deploymentTemplatePath))
                {
                    DeployTemplate(deploymentTemplatePath, _resourceGroupName);
                }

                using (var process = new ProcessHelper(testDirectory, _context.TestExecutableName, testPath))
                {
                    process.EnvironmentVariables[ResourceGroupNameKey] = _resourceGroupName;
                    process.EnvironmentVariables[locationKey] = DefaultLocation;
                    foreach (var helper in _environmentHelpers)
                    {
                        helper.TrySetupScriptEnvironment(_context, _clientFactory, process.EnvironmentVariables);
                    }
                    int statusCode = process.StartAndWaitForExit();
                    if (statusCode != 0)
                    {
                        throw new Exception($"Process exited with unexpected status code {statusCode}");
                    }
                }
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
