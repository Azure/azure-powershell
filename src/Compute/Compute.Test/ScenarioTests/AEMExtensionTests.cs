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

using Microsoft.Azure.Commands.Compute.Extension.AEM;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class AEMExtensionTests : ComputeTestRunner
    {
        public AEMExtensionTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionBasicWindowsWAD()
        {
            TestRunner.RunTestScript("Test-AEMExtensionBasicWindowsWAD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionBasicWindows()
        {
            TestRunner.RunTestScript("Test-AEMExtensionBasicWindows");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionBasicLinuxWAD()
        {
            TestRunner.RunTestScript("Test-AEMExtensionBasicLinuxWAD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionBasicLinux()
        {
            TestRunner.RunTestScript("Test-AEMExtensionBasicLinux");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionAdvancedWindowsWAD()
        {
            TestRunner.RunTestScript("Test-AEMExtensionAdvancedWindowsWAD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionAdvancedWindows()
        {
            TestRunner.RunTestScript("Test-AEMExtensionAdvancedWindows");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionAdvancedLinuxWAD()
        {
            TestRunner.RunTestScript("Test-AEMExtensionAdvancedLinuxWAD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionAdvancedLinux()
        {
            TestRunner.RunTestScript("Test-AEMExtensionAdvancedLinux");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionAdvancedWindowsMD()
        {
            TestRunner.RunTestScript("Test-AEMExtensionAdvancedWindowsMD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionAdvancedLinuxMD()
        {
            TestRunner.RunTestScript("Test-AEMExtensionAdvancedLinuxMD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionAdvancedLinuxMD_ESeries()
        {
            TestRunner.RunTestScript("Test-AEMExtensionAdvancedLinuxMD_E");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionAdvancedLinuxMD_DSeries()
        {
            TestRunner.RunTestScript("Test-AEMExtensionAdvancedLinuxMD_D");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestWithUserAssignedIdentity()
        {
            TestRunner.RunTestScript("Test-WithUserAssignedIdentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestWithoutIdentity()
        {
            TestRunner.RunTestScript("Test-WithoutIdentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestWithSystemAssignedIdentity()
        {
            TestRunner.RunTestScript("Test-WithSystemAssignedIdentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestExtensionReinstall()
        {
            TestRunner.RunTestScript("Test-ExtensionReinstall");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestOldExtensionReinstall()
        {
            TestRunner.RunTestScript("Test-OldExtensionReinstall");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestExtensionDowngrade()
        {
            TestRunner.RunTestScript("Test-ExtensionDowngrade");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestExtensionUpgrade()
        {
            TestRunner.RunTestScript("Test-ExtensionUpgrade");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewExtensionDiskAdd()
        {
            TestRunner.RunTestScript("Test-NewExtensionDiskAdd");
        }        

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestScopePermissionCheck()
        {
            string groupScope = "group";
            string resourceScope = "resource";

            // | Permissions for RG | Permission for Resource (after check) | Result                                             |
            // |         Y          |           Y                           |   Y                                                |
            {
                bool expectedCheckResult = true;
                bool expectedGroupCall = false;
                bool expectedResCall = false;
                int okCount = 0;
                int nokCount = 0;

                HashSet<string> ok = new HashSet<string>();
                HashSet<string> nok = new HashSet<string>();
                bool groupCalled = false;
                bool resCalled = false;
                bool checkOk = AEMHelper.CheckScopePermissions(true, true, groupScope, resourceScope, "role", null, ok, nok,
                    (scope, roleDefinitionId, vm) =>
                    {
                        groupCalled |= scope == groupScope;
                        resCalled |= scope == resourceScope;
                        return true;
                    }
                );
                Assert.True(checkOk == expectedCheckResult);
                Assert.True(groupCalled == expectedGroupCall);
                Assert.True(resCalled == expectedResCall);
                Assert.True(ok.Count == okCount);
                Assert.True(nok.Count == nokCount);
            }


            // | Permissions for RG | Permission for Resource (after check) | Result                                             |
            // |         Y          |           N                           |   Y                                                |
            {
                bool expectedCheckResult = true;
                bool expectedGroupCall = false;
                bool expectedResCall = false;
                int okCount = 0;
                int nokCount = 0;

                HashSet<string> ok = new HashSet<string>();
                HashSet<string> nok = new HashSet<string>();
                bool groupCalled = false;
                bool resCalled = false;
                bool checkOk = AEMHelper.CheckScopePermissions(true, false, groupScope, resourceScope, "role", null, ok, nok,
                    (scope, roleDefinitionId, vm) =>
                    {
                        groupCalled |= scope == groupScope;
                        resCalled |= scope == resourceScope;
                        return true;
                    }
                );
                Assert.True(checkOk == expectedCheckResult);
                Assert.True(groupCalled == expectedGroupCall);
                Assert.True(resCalled == expectedResCall);
                Assert.True(ok.Count == okCount);
                Assert.True(nok.Count == nokCount);
            }

            // | Permissions for RG | Permission for Resource (after check) | Result                                             |
            // |         Y          |           ?                           |   Y                                                |
            {
                bool expectedCheckResult = true;
                bool expectedGroupCall = false;
                bool expectedResCall = false;
                int okCount = 0;
                int nokCount = 0;

                HashSet<string> ok = new HashSet<string>();
                HashSet<string> nok = new HashSet<string>();
                bool groupCalled = false;
                bool resCalled = false;
                bool checkOk = AEMHelper.CheckScopePermissions(true, null, groupScope, resourceScope, "role", null, ok, nok,
                    (scope, roleDefinitionId, vm) =>
                    {
                        groupCalled |= scope == groupScope;
                        resCalled |= scope == resourceScope;
                        return true;
                    }
                );
                Assert.True(checkOk == expectedCheckResult);
                Assert.True(groupCalled == expectedGroupCall);
                Assert.True(resCalled == expectedResCall);
                Assert.True(ok.Count == okCount);
                Assert.True(nok.Count == nokCount);
            }
            // | Permissions for RG | Permission for Resource (after check) | Result                                             |
            // |         N          |           Y                           |   Y                                                |
            {
                bool expectedCheckResult = true;
                bool expectedGroupCall = false;
                bool expectedResCall = false;
                int okCount = 0;
                int nokCount = 0;

                HashSet<string> ok = new HashSet<string>();
                HashSet<string> nok = new HashSet<string>();
                bool groupCalled = false;
                bool resCalled = false;
                bool checkOk = AEMHelper.CheckScopePermissions(false, true, groupScope, resourceScope, "role", null, ok, nok,
                    (scope, roleDefinitionId, vm) =>
                    {
                        groupCalled |= scope == groupScope;
                        resCalled |= scope == resourceScope;
                        return true;
                    }
                );
                Assert.True(checkOk == expectedCheckResult);
                Assert.True(groupCalled == expectedGroupCall);
                Assert.True(resCalled == expectedResCall);
                Assert.True(ok.Count == okCount);
                Assert.True(nok.Count == nokCount);
            }
            // | Permissions for RG | Permission for Resource (after check) | Result                                             |
            // |         N          |           N                           |   N                                                |
            {
                bool expectedCheckResult = false;
                bool expectedGroupCall = false;
                bool expectedResCall = false;
                int okCount = 0;
                int nokCount = 0;

                HashSet<string> ok = new HashSet<string>();
                HashSet<string> nok = new HashSet<string>();
                bool groupCalled = false;
                bool resCalled = false;
                bool checkOk = AEMHelper.CheckScopePermissions(false, false, groupScope, resourceScope, "role", null, ok, nok,
                    (scope, roleDefinitionId, vm) =>
                    {
                        groupCalled |= scope == groupScope;
                        resCalled |= scope == resourceScope;
                        return true;
                    }
                );
                Assert.True(checkOk == expectedCheckResult);
                Assert.True(groupCalled == expectedGroupCall);
                Assert.True(resCalled == expectedResCall);
                Assert.True(ok.Count == okCount);
                Assert.True(nok.Count == nokCount);
            }
            // | Permissions for RG | Permission for Resource (after check) | Result                                             |
            // |         N          |           ? (Y)                       | check resource (Y)                                 |
            {
                bool expectedCheckResult = true;
                bool expectedGroupCall = false;
                bool expectedResCall = true;
                int okCount = 1;
                int nokCount = 0;

                HashSet<string> ok = new HashSet<string>();
                HashSet<string> nok = new HashSet<string>();
                bool groupCalled = false;
                bool resCalled = false;
                bool checkOk = AEMHelper.CheckScopePermissions(false, null, groupScope, resourceScope, "role", null, ok, nok,
                    (scope, roleDefinitionId, vm) =>
                    {
                        groupCalled |= scope == groupScope;
                        resCalled |= scope == resourceScope;
                        return true;
                    }
                );
                Assert.True(checkOk == expectedCheckResult);
                Assert.True(groupCalled == expectedGroupCall);
                Assert.True(resCalled == expectedResCall);
                Assert.True(ok.Count == okCount);
                Assert.True(nok.Count == nokCount);
            }
            // | Permissions for RG | Permission for Resource (after check) | Result                                             |
            // |         N          |           ? (N)                       | check resource (N)                                 |
            {
                bool expectedCheckResult = false;
                bool expectedGroupCall = false;
                bool expectedResCall = true;
                int okCount = 0;
                int nokCount = 1;

                HashSet<string> ok = new HashSet<string>();
                HashSet<string> nok = new HashSet<string>();
                bool groupCalled = false;
                bool resCalled = false;
                bool checkOk = AEMHelper.CheckScopePermissions(false, null, groupScope, resourceScope, "role", null, ok, nok,
                    (scope, roleDefinitionId, vm) =>
                    {
                        groupCalled |= scope == groupScope;
                        resCalled |= scope == resourceScope;
                        return false;
                    }
                );
                Assert.True(checkOk == expectedCheckResult);
                Assert.True(groupCalled == expectedGroupCall);
                Assert.True(resCalled == expectedResCall);
                Assert.True(ok.Count == okCount);
                Assert.True(nok.Count == nokCount);
            }

            // | Permissions for RG | Permission for Resource (after check) | Result                                             |
            // |         ?          |           Y                           |   Y                                                |
            {
                bool expectedCheckResult = true;
                bool expectedGroupCall = false;
                bool expectedResCall = false;
                int okCount = 0;
                int nokCount = 0;

                HashSet<string> ok = new HashSet<string>();
                HashSet<string> nok = new HashSet<string>();
                bool groupCalled = false;
                bool resCalled = false;
                bool checkOk = AEMHelper.CheckScopePermissions(null, true, groupScope, resourceScope, "role", null, ok, nok,
                    (scope, roleDefinitionId, vm) =>
                    {
                        groupCalled |= scope == groupScope;
                        resCalled |= scope == resourceScope;
                        return true;
                    }
                );
                Assert.True(checkOk == expectedCheckResult);
                Assert.True(groupCalled == expectedGroupCall);
                Assert.True(resCalled == expectedResCall);
                Assert.True(ok.Count == okCount);
                Assert.True(nok.Count == nokCount);
            }

            // | Permissions for RG | Permission for Resource (after check) | Result                                             |
            // |         ? (Y)      |           N                           | check resource group (Y)                           |
            {
                bool expectedCheckResult = true;
                bool expectedGroupCall = true;
                bool expectedResCall = false;
                int okCount = 1;
                int nokCount = 0;

                HashSet<string> ok = new HashSet<string>();
                HashSet<string> nok = new HashSet<string>();
                bool groupCalled = false;
                bool resCalled = false;
                bool checkOk = AEMHelper.CheckScopePermissions(null, false, groupScope, resourceScope, "role", null, ok, nok,
                    (scope, roleDefinitionId, vm) =>
                    {
                        groupCalled |= scope == groupScope;
                        resCalled |= scope == resourceScope;
                        return true;
                    }
                );
                Assert.True(checkOk == expectedCheckResult);
                Assert.True(groupCalled == expectedGroupCall);
                Assert.True(resCalled == expectedResCall);
                Assert.True(ok.Count == okCount);
                Assert.True(nok.Count == nokCount);
            }

            // | Permissions for RG | Permission for Resource (after check) | Result                                             |
            // |         ? (N)      |           N                           | check resource group (N)                           |
            {
                bool expectedCheckResult = false;
                bool expectedGroupCall = true;
                bool expectedResCall = false;
                int okCount = 0;
                int nokCount = 1;

                HashSet<string> ok = new HashSet<string>();
                HashSet<string> nok = new HashSet<string>();
                bool groupCalled = false;
                bool resCalled = false;
                bool checkOk = AEMHelper.CheckScopePermissions(null, false, groupScope, resourceScope, "role", null, ok, nok,
                    (scope, roleDefinitionId, vm) =>
                    {
                        groupCalled |= scope == groupScope;
                        resCalled |= scope == resourceScope;
                        return false;
                    }
                );
                Assert.True(checkOk == expectedCheckResult);
                Assert.True(groupCalled == expectedGroupCall);
                Assert.True(resCalled == expectedResCall);
                Assert.True(ok.Count == okCount);
                Assert.True(nok.Count == nokCount);
            }

            // | Permissions for RG | Permission for Resource (after check) | Result                                             |
            // |         ? (Y)      |           ?                           | check resource group, if no, check resource (Y)    |
            {
                bool expectedCheckResult = true;
                bool expectedGroupCall = true;
                bool expectedResCall = false;
                int okCount = 1;
                int nokCount = 0;

                HashSet<string> ok = new HashSet<string>();
                HashSet<string> nok = new HashSet<string>();
                bool groupCalled = false;
                bool resCalled = false;
                bool checkOk = AEMHelper.CheckScopePermissions(null, null, groupScope, resourceScope, "role", null, ok, nok,
                    (scope, roleDefinitionId, vm) =>
                    {
                        groupCalled |= scope == groupScope;
                        resCalled |= scope == resourceScope;
                        return true;
                    }
                );
                Assert.True(checkOk == expectedCheckResult);
                Assert.True(groupCalled == expectedGroupCall);
                Assert.True(resCalled == expectedResCall);
                Assert.True(ok.Count == okCount);
                Assert.True(nok.Count == nokCount);
            }

            // | Permissions for RG | Permission for Resource (after check) | Result                                             |
            // |         ? (N)      |           ? (Y)                       | check resource group, if no, check resource (N)(Y) |
            {
                bool expectedCheckResult = true;
                bool expectedGroupCall = true;
                bool expectedResCall = true;
                int okCount = 1;
                int nokCount = 1;

                HashSet<string> ok = new HashSet<string>();
                HashSet<string> nok = new HashSet<string>();
                bool groupCalled = false;
                bool resCalled = false;
                bool checkOk = AEMHelper.CheckScopePermissions(null, null, groupScope, resourceScope, "role", null, ok, nok,
                    (scope, roleDefinitionId, vm) =>
                    {
                        groupCalled |= scope == groupScope;
                        resCalled |= scope == resourceScope;
                        return scope == resourceScope; // return true for resource scope
                    }
                );
                Assert.True(checkOk == expectedCheckResult);
                Assert.True(groupCalled == expectedGroupCall);
                Assert.True(resCalled == expectedResCall);
                Assert.True(ok.Count == okCount);
                Assert.True(nok.Count == nokCount);
            }
            // | Permissions for RG | Permission for Resource (after check) | Result                                             |
            // |         ? (N)      |           ? (N)                       | check resource group, if no, check resource (N)(N) |
            {
                bool expectedCheckResult = false;
                bool expectedGroupCall = true;
                bool expectedResCall = true;
                int okCount = 0;
                int nokCount = 2;

                HashSet<string> ok = new HashSet<string>();
                HashSet<string> nok = new HashSet<string>();
                bool groupCalled = false;
                bool resCalled = false;
                bool checkOk = AEMHelper.CheckScopePermissions(null, null, groupScope, resourceScope, "role", null, ok, nok,
                    (scope, roleDefinitionId, vm) =>
                    {
                        groupCalled |= scope == groupScope;
                        resCalled |= scope == resourceScope;
                        return false;
                    }
                );
                Assert.True(checkOk == expectedCheckResult);
                Assert.True(groupCalled == expectedGroupCall);
                Assert.True(resCalled == expectedResCall);
                Assert.True(ok.Count == okCount);
                Assert.True(nok.Count == nokCount);
            }
        }
    }
}