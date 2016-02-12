using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class RunnerTests
    {
        [Fact]
        public void ExecuteRunnerTests()
        {
            var mode = Environment.GetEnvironmentVariable("AZURE_TEST_MODE");
            var csmAuth = Environment.GetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION");

            if (mode == null || csmAuth == null || mode.ToLower() != "record")
            {
                return;
            }

            Assert.False(string.IsNullOrEmpty(csmAuth));
            Assert.True(csmAuth.Contains("AADTenant"));

            var envDictionary = TestUtilities.ParseConnectionString(csmAuth);
            var testEnv = new TestEnvironment(envDictionary);
            Assert.NotNull(testEnv.Tenant);
            Assert.NotNull(testEnv.SubscriptionId);
            Assert.NotNull(testEnv.ClientId);
            Assert.True(envDictionary.ContainsKey("ApplicationSecret"));

            var authenticationContext = new AuthenticationContext("https://login.windows.net/" + testEnv.Tenant);
            var credential = new ClientCredential(testEnv.ClientId, envDictionary["ApplicationSecret"]);

            var result = authenticationContext.AcquireToken("https://management.core.windows.net/", clientCredential: credential);

            Assert.NotNull(result.AccessToken);
            envDictionary["RawToken"] = result.AccessToken;

            FixCSMAuthEnvVariable(envDictionary);

            Console.WriteLine(Environment.GetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION"));

            var testFile = File.ReadAllLines("ScenarioTests\\RunnerTests.csv");
            foreach (var line in testFile)
            {
                var tokens = line.Split(';');
                var className = tokens[0];
                var type = Type.GetType(className);
                var constructorInfo = type.GetConstructor(Type.EmptyTypes);
                for (int i = 1; i < tokens.Length; i++)
                {
                    var method = tokens[i];
                    var testClassInstance = constructorInfo.Invoke(new object[] {});
                    var testMethod = type.GetMethod(method);

                    Console.WriteLine("Invoking method : " + testMethod);

                    testMethod.Invoke(testClassInstance, new object[] {});

                    Console.WriteLine("Method " + testMethod + " has finished");
                }
            }
        }

        private void FixCSMAuthEnvVariable(IDictionary<string, string> envDictionary)
        {
            var str = string.Empty;
            foreach (var entry in envDictionary)
            {
                if (entry.Key != "AADClientId" && entry.Key != "ApplicationSecret")
                {
                    str += string.Format("{0}={1};", entry.Key, entry.Value);
                }
            }

            Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", str);
        }
    }
}
