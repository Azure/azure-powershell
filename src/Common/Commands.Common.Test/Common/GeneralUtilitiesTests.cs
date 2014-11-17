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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.Common.Test
{
    public class PowerShellUtilitiesTests
    {
        [Fact]
        public void AddsModulePathToUserPSModulePath()
        {
            string originalPSModulePath = Environment.GetEnvironmentVariable(PowerShellUtilities.PSModulePathName);

            try
            {
                string modulePath = "C:\\ExampleTest\\MyModule.psd1";
                string expected = originalPSModulePath + ";" + modulePath;
                PowerShellUtilities.AddModuleToPSModulePath(modulePath);
                string actual = Environment.GetEnvironmentVariable(PowerShellUtilities.PSModulePathName);
                Assert.Equal(expected, actual);
            }
            finally
            {
                Environment.SetEnvironmentVariable(PowerShellUtilities.PSModulePathName, originalPSModulePath);
            }
        }

        [Fact]
        public void RemovesModulePathFromUserPSModulePath()
        {
            string originalPSModulePath = Environment.GetEnvironmentVariable(PowerShellUtilities.PSModulePathName);

            string[] modulePaths = originalPSModulePath.Split(';');
            string modulePath = modulePaths[modulePaths.Length - 1];
            string expected = null;
            string actual;

            try
            {
                if (modulePaths.Length > 1)
                {
                    expected = string.Join(";", modulePaths, 0, modulePaths.Length - 1);
                }

                PowerShellUtilities.RemoveModuleFromPSModulePath(modulePath);
                actual = Environment.GetEnvironmentVariable(PowerShellUtilities.PSModulePathName);
                Assert.Equal(expected, actual);
            }
            finally
            {
                Environment.SetEnvironmentVariable(PowerShellUtilities.PSModulePathName, originalPSModulePath);
            }

            Assert.Equal(expected, actual);
        }
    }
}
