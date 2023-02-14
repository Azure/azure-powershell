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
    public class RecordsTests : DnsTestRunner
    { 
        public RecordsTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAliasRecordSet()
        {
            TestRunner.RunTestScript("Test-AliasRecordSet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetCrud()
        {
            TestRunner.RunTestScript("Test-RecordSetCrud");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetCrudTrimsDotFromZoneName()
        {
            TestRunner.RunTestScript("Test-RecordSetCrudTrimsDotFromZoneName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetCrudWithPiping()
        {
            TestRunner.RunTestScript("Test-RecordSetCrudWithPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetCrudWithPipingTrimsDotFromZoneName()
        {
            TestRunner.RunTestScript("Test-RecordSetCrudWithPipingTrimsDotFromZoneName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetA()
        {
            TestRunner.RunTestScript("Test-RecordSetA");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetANonEmpty()
        {
            TestRunner.RunTestScript("Test-RecordSetANonEmpty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetAAAA()
        {
            TestRunner.RunTestScript("Test-RecordSetAAAA");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetAAAANonEmpty()
        {
            TestRunner.RunTestScript("Test-RecordSetAAAANonEmpty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetCNAME()
        {
            TestRunner.RunTestScript("Test-RecordSetCNAME");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetCNAMENonEmpty()
        {
            TestRunner.RunTestScript("Test-RecordSetCNAMENonEmpty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetMX()
        {
            TestRunner.RunTestScript("Test-RecordSetMX");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetMXNonEmpty()
        {
            TestRunner.RunTestScript("Test-RecordSetMXNonEmpty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetCAA()
        {
            TestRunner.RunTestScript("Test-RecordSetCAA");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetCAANonEmpty()
        {
            TestRunner.RunTestScript("Test-RecordSetCAANonEmpty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetNS()
        {
            TestRunner.RunTestScript("Test-RecordSetNS");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetNSNonEmpty()
        {
            TestRunner.RunTestScript("Test-RecordSetNSNonEmpty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetTXT()
        {
            TestRunner.RunTestScript("Test-RecordSetTXT");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetTXTNonEmpty()
        {
            TestRunner.RunTestScript("Test-RecordSetTXTNonEmpty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetTXTLengthValidation()
        {
            TestRunner.RunTestScript("Test-RecordSetTXTLengthValidation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetTXTLegacyLengthValidation()
        {
            TestRunner.RunTestScript("Test-RecordSetTXTLegacyLengthValidation");
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetSRV()
        {
            TestRunner.RunTestScript("Test-RecordSetSRV");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetSRVNonEmpty()
        {
            TestRunner.RunTestScript("Test-RecordSetSRVNonEmpty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetSOA()
        {
            TestRunner.RunTestScript("Test-RecordSetSOA");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetPTR()
        {
            TestRunner.RunTestScript("Test-RecordSetPTR");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetPTRNonEmpty()
        {
            TestRunner.RunTestScript("Test-RecordSetPTRNonEmpty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetnewAlreadyExists()
        {
            TestRunner.RunTestScript("Test-RecordSetnewAlreadyExists");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetAddRecordTypeMismatch()
        {
            TestRunner.RunTestScript("Test-RecordSetAddRecordTypeMismatch");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetAddTwoCnames()
        {
            TestRunner.RunTestScript("Test-RecordSetAddTwoCnames");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetRemoveRecordTypeMismatch()
        {
            TestRunner.RunTestScript("Test-RecordSetRemoveRecordTypeMismatch");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetEtagMismatch()
        {
            TestRunner.RunTestScript("Test-RecordSetEtagMismatch");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetGet()
        {
            TestRunner.RunTestScript("Test-RecordSetGet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetEndsWithZoneName()
        {
            TestRunner.RunTestScript("Test-RecordSetEndsWithZoneName");
        }
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetNewRecordNoName()
        {
            TestRunner.RunTestScript("Test-RecordSetNewRecordNoName");
        }
    }
}
