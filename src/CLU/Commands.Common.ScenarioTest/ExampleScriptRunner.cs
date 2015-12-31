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
using System.Diagnostics;
using System.IO;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Factories;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common.ScenarioTest;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Microsoft.Azure.Commands.Common.ScenarioTest
{
    public class ExampleScriptRunner
    {
        string _sessionId;
        Random _generator;
        string _resourceGroupName;
        string _storageAccountName;
        IClientFactory _clientFactory = new ClientFactory();
        TestContext _context;
        ResourceManagementClient _client;
        const string DefaultLocation = "westus";
        const string ResourceGroupNameKey = "groupName";
        const string LocationKey = "location";
        const string BaseDir = "BASEDIR";
        const string SessionKey = "CmdletSessionID";
        const string StorageAccountTypeKey = "storageAccountType";
        const string StorageAccountNameKey = "storageAccountName";
        const string DefaultStorageAccountType = "Standard_GRS";

        public ExampleScriptRunner(string sessionId) : this(new Random(), sessionId)
        {
        }

        public ExampleScriptRunner(int seed, string sessionId) : this(new Random(seed), sessionId)
        {
        }


        public ExampleScriptRunner(Random generator, string sessionId)
        {
            _generator = generator;
            _sessionId = sessionId;
            EnvironmentVariables = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        }

        public IClientFactory ClientFactory
        {
            get { return _clientFactory; }
            set { _clientFactory = value; }
        }

        public TestContext TestContext
        {
            get { return _context; }
            set { _context = value; }
        }

        public IDictionary<string, string> EnvironmentVariables { get; private set; } 

        public string ScriptOutput { get; protected set; }

        public string RunScript(string testName)
        {
            var testDirectory = Path.GetFullPath(_context.TestScriptDirectory);
            var executionDirectory = Path.GetFullPath(_context.ExecutionDirectory);
            string testFile = $"{testName}{_context.TestScriptSuffix}";
            string logFile = $"{testName}.log";
            string logFilePath = Path.Combine(executionDirectory, logFile);
            string testPath = Path.Combine(testDirectory, testFile);
            if (!File.Exists(testPath))
            {
                throw new InvalidOperationException($"Path to test script '{testPath}' does not exist.");
            }

            string deploymentTemplatePath = Path.Combine(testDirectory, $"{testName}.json");
            TraceListener listener = null;
            try
            {
                using (var stream = new FileStream(logFilePath, FileMode.Create))
                using (listener = new TextWriterTraceListener(stream))
                using (var process = new ProcessHelper(executionDirectory, _context.TestExecutableName, testPath))
                {
                    Trace.Listeners.Add(listener);
                    _resourceGroupName = CreateRandomName();
                    _storageAccountName = CreateRandomName() + "sto";
                    if (File.Exists(deploymentTemplatePath))
                    {
                        DeployTemplate(deploymentTemplatePath, _resourceGroupName);
                    }

                    process.EnvironmentVariables[BaseDir] = testDirectory;
                    process.EnvironmentVariables[SessionKey] = _sessionId;
                    process.EnvironmentVariables[ResourceGroupNameKey] = _resourceGroupName;
                    process.EnvironmentVariables[LocationKey] = DefaultLocation;
                    process.EnvironmentVariables[StorageAccountTypeKey] = DefaultStorageAccountType;
                    process.EnvironmentVariables[StorageAccountNameKey] = _storageAccountName;
                    foreach (var helper in _context.EnvironmentHelpers)
                    {
                        helper.TrySetupScriptEnvironment(_context, _clientFactory, process.EnvironmentVariables);
                    }

                    foreach (var environmentVar in EnvironmentVariables.Keys)
                    {
                        process.EnvironmentVariables.Add(environmentVar, EnvironmentVariables[environmentVar]);
                    }

                    int statusCode = process.StartAndWaitForExit();
                    Assert.Equal(0, statusCode);
                    return process.Output;
                }
            }
            finally
            {
                if (listener != null)
                {
                    Trace.Listeners.Remove(listener);
                }
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
            return GenerateName("clutst");
        }

        public string GenerateName(string prefix)
        {
            return $"{prefix}{_generator.Next(10000, 99999)}";
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
            {
                try
                {
                    _client.ResourceGroups.DeleteWithHttpMessagesAsync(_resourceGroupName).GetAwaiter().GetResult();
                }
                catch (Exception exception)
                {
                    Logger.Instance.WriteError($"Could not remove resource group: {exception}");
                }
            }
            _client = null;
            _resourceGroupName = null;
        }
    }
}
