﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.ScenarioTest.SqlTests;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class ManagedInstanceLedgerDigestUploadTests : SqlTestRunner
    {
        public ManagedInstanceLedgerDigestUploadTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetDefaultLedgerDigestUpload()
        {
            TestRunner.RunTestScript("Test-GetDefaultManagedLedgerDigestUpload");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetLedgerDigestUploadByName()
        {
            TestRunner.RunTestScript("Test-SetManagedLedgerDigestUploadByName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetLedgerDigestUploadByDatabaseObject()
        {
            TestRunner.RunTestScript("Test-SetManagedLedgerDigestUploadByDatabaseObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetLedgerDigestUploadByResourceId()
        {
            TestRunner.RunTestScript("Test-SetManagedLedgerDigestUploadByResourceId");
        }
    }
}
