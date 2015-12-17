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

using System.Collections.Generic;
using System.IO;

namespace Microsoft.Azure.Commands.Common.ScenarioTest
{
    public class EnvironmentContextFactory
    {
        ICredentialsProvider _credentials;


        public EnvironmentContextFactory(ICredentialsProvider credentials)
        {
            _credentials = credentials;
        }

        public TestContext GetTestContext(string scriptDirectoryName)
        {
            var context = new TestContext();
            context.ExecutionDirectory = GetBaseDirectory();
            context.TestScriptDirectory =GetExamplesDirectory(context.ExecutionDirectory, scriptDirectoryName);
            context.TestExecutableName = "bash.exe";
            context.TestScriptSuffix = ".sh";
            var helpers = new List<IScriptEnvironmentHelper>();
            helpers.Add(_credentials.EnvironmentProvider);
            context.EnvironmentHelpers = helpers;
            return context;
        }

        private string GetExamplesDirectory(string executionDirectory, string scriptDirectoryName)
        {
            string examplesDirectory;
            if (!Utilities.TryGetEnvironmentVariable(EnvironmentConstants.ExampleDirectory, out examplesDirectory))
            {
                examplesDirectory = Path.GetFullPath(Path.Combine(executionDirectory, "..",
                    "..", "..", "examples"));
            }

            return Path.Combine(examplesDirectory, scriptDirectoryName);
        }
        private string GetBaseDirectory()
        {
            string baseDirectory;
            if (!Utilities.TryGetEnvironmentVariable(EnvironmentConstants.TestRunDirectory, out baseDirectory))
            {
                baseDirectory = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "TestResults"));
            }

            Utilities.EnsureDirectoryExists(baseDirectory);
            return baseDirectory;
        }

    }
}
