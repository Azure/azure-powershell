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


using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Test;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Management.Automation;
using Xunit;


namespace Microsoft.WindowsAzure.Commands.ScenarioTest.RemoteAppTests
{
    
    public class CreateCloudCollection
    {
        protected Collection<T> RunPowerShellTest<T>(params string[] scripts)
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start(TestUtilities.GetCallingClass(1), TestUtilities.GetCurrentMethodName(2));
                List<string> modules = null;
                Collection<PSObject> pipeLineObjects = null;
                Collection<T> result = new Collection<T>();
                EnvironmentSetupHelper helper = new EnvironmentSetupHelper();

                modules = Directory.GetFiles(@"..\..\Scripts".AsAbsoluteLocation(), "*.ps1").ToList();
                helper.SetupSomeOfManagementClients();
                helper.SetupEnvironment(AzureModule.AzureServiceManagement);
                helper.SetupModules(AzureModule.AzureServiceManagement, modules.ToArray());

                pipeLineObjects = helper.RunPowerShellTest(scripts);
                foreach (PSObject obj in pipeLineObjects)
                {
                    T item = LanguagePrimitives.ConvertTo<T>(obj);
                    result.Add(item);
                }
                return result;
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoteAppEndToEnd()
        {
            System.Environment.SetEnvironmentVariable("rdfeNameSpace", "rdsr8");
            RunPowerShellTest<string>("TestRemoteAppEndToEnd");
        }
    }
}
