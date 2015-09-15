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
using System.Management.Automation;
using System.Reflection;
using Microsoft.Azure.Commands.Resources.Models;
using System.IO;
using Microsoft.Azure.Common.Authentication;

namespace Microsoft.Azure.Commands.Resources
{
    /// <summary>
    /// Get the available locations for certain resource types.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureLocation"), OutputType(typeof(List<PSResourceProviderLocationInfo>))]
    public class GetAzureLocationCommand : ResourcesBaseCmdlet, IModuleAssemblyInitializer
    {
        public override void ExecuteCmdlet()
        {
            WriteObject(ResourcesClient.GetLocations(), true);
        }

        /// <summary>
        /// Load global aliases for ARM
        /// </summary>
        public void OnImport()
        {
            try
            {
                System.Management.Automation.PowerShell invoker = null;
                invoker = System.Management.Automation.PowerShell.Create(RunspaceMode.CurrentRunspace);
                invoker.AddScript(File.ReadAllText(FileUtilities.GetContentFilePath(
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "ResourceManagerStartup.ps1")));
                invoker.Invoke();
            }
            catch
            {
                // This will throw exception for tests, ignore.
            }
        }
    }
}