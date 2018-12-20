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
    using ServiceManagement.Common.Models;
    using System.Diagnostics;

    public class RecordsTests : DnsTestsBase
    {
        public XunitTracingInterceptor _logger;

        public RecordsTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAliasRecordSet()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-AliasRecordSet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetCrud()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetCrud");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetCrudTrimsDotFromZoneName()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetCrudTrimsDotFromZoneName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetCrudWithPiping()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetCrudWithPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetCrudWithPipingTrimsDotFromZoneName()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetCrudWithPipingTrimsDotFromZoneName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetA()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetA");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetANonEmpty()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetANonEmpty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetAAAA()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetAAAA");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetAAAANonEmpty()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetAAAANonEmpty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetCNAME()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetCNAME");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetCNAMENonEmpty()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetCNAMENonEmpty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetMX()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetMX");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetMXNonEmpty()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetMXNonEmpty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetCAA()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetCAA");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetCAANonEmpty()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetCAANonEmpty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetNS()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetNS");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetNSNonEmpty()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetNSNonEmpty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetTXT()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetTXT");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetTXTNonEmpty()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetTXTNonEmpty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetTXTLengthValidation()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetTXTLengthValidation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetTXTLegacyLengthValidation()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetTXTLegacyLengthValidation");
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetSRV()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetSRV");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetSRVNonEmpty()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetSRVNonEmpty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetSOA()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetSOA");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetPTR()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetPTR");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetPTRNonEmpty()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetPTRNonEmpty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetnewAlreadyExists()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetnewAlreadyExists");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetAddRecordTypeMismatch()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetAddRecordTypeMismatch");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetAddTwoCnames()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetAddTwoCnames");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetRemoveRecordTypeMismatch()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetRemoveRecordTypeMismatch");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetEtagMismatch()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetEtagMismatch");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetGet()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetGet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetEndsWithZoneName()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetEndsWithZoneName");
        }
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetNewRecordNoName()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetNewRecordNoName");
        }
    }
}
