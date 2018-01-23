using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class RunnerTests
    {
        public RunnerTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
        }

        [Fact]
        public void ExecuteRunnerTests()
        {
            var mode = Environment.GetEnvironmentVariable("AZURE_TEST_MODE");
            var csmAuth = Environment.GetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION");

            if (mode == null || csmAuth == null || mode.ToLower() != "record")
            {
                return;
            }

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
                    var testClassInstance = constructorInfo.Invoke(new object[] { });
                    var testMethod = type.GetMethod(method);

                    Console.WriteLine("Invoking method : " + testMethod);

                    testMethod.Invoke(testClassInstance, new object[] { });

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
