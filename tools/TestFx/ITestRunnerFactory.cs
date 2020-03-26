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
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;

namespace Microsoft.Azure.Commands.TestFx
{
    public interface ITestRunnerFactory
    {
        ITestRunner Build();
        ITestRunnerFactory WithProjectSubfolderForTests(string folderName);
        ITestRunnerFactory WithCommonPsScripts(string[] psScriptList);
        ITestRunnerFactory WithNewPsScriptFilename(string psScriptName);
        ITestRunnerFactory WithMockContextAction(Action mockContextAction);
        ITestRunnerFactory WithExtraRmModules(Func<EnvironmentSetupHelper, string[]> buildModuleList);
        ITestRunnerFactory WithNewRmModules(Func<EnvironmentSetupHelper, string[]> buildModuleList);
        ITestRunnerFactory WithExtraUserAgentsToIgnore(Dictionary<string, string> userAgentsToIgnore);
        ITestRunnerFactory WithRecordMatcher(RecordMatcherDelegate recordMatcher);
        ITestRunnerFactory WithNewRecordMatcherArguments(Dictionary<string, string> userAgentsToIgnore, Dictionary<string, string> resourceProviders);
        ITestRunnerFactory WithManagementClients(params Func<MockContext, object> []initializedManagementClients);
    }
}
