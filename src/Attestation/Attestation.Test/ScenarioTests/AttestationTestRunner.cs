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

using Microsoft.Azure.Attestation;
using Microsoft.Azure.Commands.TestFx;
using Microsoft.Azure.Management.Attestation;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Attestation.Test.ScenarioTests
{
    public class AttestationTestRunner
    {
        protected readonly ITestRunner TestRunner;

        protected AttestationTestRunner(ITestOutputHelper output)
        {
            TestRunner = TestManager.CreateInstance(output)
                .WithNewPsScriptFilename($"{GetType().Name}.ps1")
                .WithProjectSubfolderForTests("ScenarioTests")
                .WithCommonPsScripts(new[]
                {
                    @"Common.ps1",
                    @"../AzureRM.Resources.ps1"
                })
                .WithNewRmModules(helper => new[]
                {
                    helper.RMProfileModule,
                    helper.GetRMModulePath("Az.Attestation.psd1")
                })
                .WithNewRecordMatcherArguments(
                    userAgentsToIgnore: new Dictionary<string, string>
                    {
                        {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"},
                        {"Microsoft.Azure.Management.ResourceManager.ResourceManagementClient", "2017-05-10"}
                    },
                    resourceProviders: new Dictionary<string, string>
                    {
                        {"Microsoft.Resources", null},
                        {"Microsoft.Features", null},
                        {"Microsoft.Authorization", null}
                    }
                ).WithManagementClients(
                    GetResourceManagementClient,
                    GetAttestationManagementClient,
                    GetAttestationClient
                )
                .Build();
        }

        private static ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>();
        }

        private static AttestationManagementClient GetAttestationManagementClient(MockContext context)
        {
            return context.GetServiceClient<AttestationManagementClient>();
        }

        private static AttestationClient GetAttestationClient(MockContext context)
        {
            string accessToken = "fakefakefake";

            // When recording, we should have a connection string passed into the code from the environment
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                accessToken = TestEnvironmentFactory.GetTestEnvironment().GetAccessToken(new[] { "https://attest.azure.net/.default" });
            }

            return new AttestationClient(new AttestationCredentials(accessToken), HttpMockServer.CreateInstance());
        }
    }
}
