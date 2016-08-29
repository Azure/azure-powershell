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

using Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions;
using Microsoft.WindowsAzure.ServiceManagemenet.Common.Models;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest
{
    public partial class ServiceManagementTests
    {
        [Fact]
        [Trait(Category.Service, Category.ServiceManagement)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestExtensionRoleNames()
        {
            var roleNames = new string[]
            {
                "test Role Name",
                "!!!!! _____ test    Role   Name ~~~",
                "testRoleName",
                "   testRoleName",
                "testRoleName   ",
                "   testRoleName"
            };
            var expectedPrefixName = "testRoleName";
            var expectedExtensionId = "testRoleName-test-test-Ext-0";
            foreach (var roleName in roleNames)
            {
                ExtensionRole er = new ExtensionRole(roleName);
                Assert.Equal(er.RoleName, roleName.Trim());
                Assert.Equal(er.PrefixName, expectedPrefixName);
                Assert.Equal(er.GetExtensionId("test", "test", 0), expectedExtensionId);
            }

            var longRoleNames = new string[]
            {
                "A123456789B123456789C123456789D123456789E123456789F123456789G123456789H123456789",
                "   A123456789B123456789C123456789D123456789E123456789F123456789G123456789H123456789 ~~~"
            };

            // PrefixName = A123456789B123456789C123456789D123456789E123456789F123456789G123456789H123456789
            // Extension Name = test
            // Slot = test
            // Index = 0
            // Extension ID Format = {prefix_name_part}-{extension_name_part}-{slot}-Ext-{index}
            // Extenion ID's Max Length: 60 = 43 + 1 + 4 + 1 + 4 + 1 + 5
            // i.e. 'A123...E123' + '-' + 'test' + '-' + 'test' + '-' + 'Ext-0'
            //           L=43       L=1    L=4     L=1    L=4     L=1     L=5
            expectedPrefixName = longRoleNames[0];
            expectedExtensionId = "A123456789B123456789C123456789D123456789E123-test-test-Ext-0";
            foreach (var roleName in longRoleNames)
            {
                ExtensionRole er = new ExtensionRole(roleName);
                Assert.Equal(er.RoleName, roleName.Trim());
                Assert.Equal(er.PrefixName, expectedPrefixName);
                Assert.Equal(er.GetExtensionId("test", "test", 0), expectedExtensionId);
            }


            var longExtensionNames = longRoleNames;
            // PrefixName = Default
            // Extension Name = A123456789B123456789C123456789D123456789E123456789F123456789G123456789H123456789
            // Slot = test
            // Index = 1
            // Extension ID Format = {prefix_name_part}-{extension_name_part}-{slot}-Ext-{index}
            // Extenion ID's Max Length: 60 = 1 + 1 + 47 + 1 + 4 + 1 + 5
            // i.e. 'D' + '-' + 'A123...456' + '-' + 'test' + '-' + 'Ext-0'
            //      L=1   L=1       L=47       L=1    L=4     L=1     L=5
            expectedExtensionId = "D-A123456789B123456789C123456789D123456789E123456-test-Ext-1";
            foreach (var extensionName in longExtensionNames)
            {
                ExtensionRole er = new ExtensionRole();
                Assert.Equal(er.RoleName, string.Empty);
                Assert.Equal(er.PrefixName, "Default");
                Assert.Equal(er.GetExtensionId(extensionName, "test", 1), expectedExtensionId);
            }
        }
    }
}
