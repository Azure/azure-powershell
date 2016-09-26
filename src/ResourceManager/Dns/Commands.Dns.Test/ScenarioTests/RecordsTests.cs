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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.ScenarioTest.DnsTests
{
    using System.Diagnostics;

    public class RecordsTests : DnsTestsBase
    {
        public RecordsTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetCrud()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest("Test-RecordSetCrud");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetCrudTrimsDotFromZoneName()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest("Test-RecordSetCrudTrimsDotFromZoneName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetCrudWithPiping()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest("Test-RecordSetCrudWithPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetCrudWithPipingTrimsDotFromZoneName()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest("Test-RecordSetCrudWithPipingTrimsDotFromZoneName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetA()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest("Test-RecordSetA");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetANonEmpty()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest("Test-RecordSetANonEmpty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetAAAA()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest("Test-RecordSetAAAA");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetAAAANonEmpty()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest("Test-RecordSetAAAANonEmpty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetCNAME()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest("Test-RecordSetCNAME");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetCNAMENonEmpty()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest("Test-RecordSetCNAMENonEmpty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetMX()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest("Test-RecordSetMX");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetMXNonEmpty()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest("Test-RecordSetMXNonEmpty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetNS()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest("Test-RecordSetNS");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetNSNonEmpty()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest("Test-RecordSetNSNonEmpty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetTXT()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest("Test-RecordSetTXT");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetTXTNonEmpty()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest("Test-RecordSetTXTNonEmpty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetTXTLengthValidation()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest("Test-RecordSetTXTLengthValidation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetTXTLegacyLengthValidation()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest("Test-RecordSetTXTLegacyLengthValidation");
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetSRV()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest("Test-RecordSetSRV");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetSRVNonEmpty()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest("Test-RecordSetSRVNonEmpty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetSOA()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest("Test-RecordSetSOA");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetPTR()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest("Test-RecordSetPTR");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetPTRNonEmpty()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest("Test-RecordSetPTRNonEmpty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetnewAlreadyExists()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest("Test-RecordSetnewAlreadyExists");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetAddRecordTypeMismatch()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest("Test-RecordSetAddRecordTypeMismatch");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetAddTwoCnames()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest("Test-RecordSetAddTwoCnames");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetRemoveRecordTypeMismatch()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest("Test-RecordSetRemoveRecordTypeMismatch");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetEtagMismatch()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest("Test-RecordSetEtagMismatch");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetGet()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest("Test-RecordSetGet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetEndsWithZoneName()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest("Test-RecordSetEndsWithZoneName");
        }
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetNewRecordNoName()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest("Test-RecordSetNewRecordNoName");
        }
    }
}
