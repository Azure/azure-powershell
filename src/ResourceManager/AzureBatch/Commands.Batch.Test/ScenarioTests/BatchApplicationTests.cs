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
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Xunit;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.Azure.ServiceManagemenet.Common.Models;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class BatchApplicationTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public BatchApplicationTests(Xunit.Abstractions.ITestOutputHelper output)
        {
#if NET472
            string libDirectory = null;
            System.IO.DirectoryInfo currentDirectory = new System.IO.DirectoryInfo(System.AppDomain.CurrentDomain.BaseDirectory);
            while (!string.Equals("src", currentDirectory.Name, System.StringComparison.OrdinalIgnoreCase) && currentDirectory.Exists)
            {
                currentDirectory = System.IO.Directory.GetParent(currentDirectory.FullName);
            }

            if (string.Equals("src", currentDirectory.Name, System.StringComparison.OrdinalIgnoreCase))
            {
                libDirectory = System.IO.Path.Combine(currentDirectory.FullName, "lib");
            }

            System.AppDomain.CurrentDomain.Load(System.IO.File.ReadAllBytes(System.IO.Path.Combine(libDirectory, "Newtonsoft.Json.9.dll")));
            System.AppDomain.CurrentDomain.Load(System.IO.File.ReadAllBytes(System.IO.Path.Combine(libDirectory, "Newtonsoft.Json.10.dll")));
#endif
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddApplication()
        {
            BatchController.NewInstance.RunPsTest(_logger, string.Format("Test-AddApplication"));
        }
    }
}