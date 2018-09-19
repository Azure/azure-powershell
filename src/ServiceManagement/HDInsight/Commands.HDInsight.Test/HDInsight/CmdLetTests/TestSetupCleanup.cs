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

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Utilities
{
    [TestClass]
    public static class TestSetupCleanup
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            IntegrationTestBase.TestRunSetup();
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            IntegrationTestBase.TestRunCleanup();
        }
    }
}
