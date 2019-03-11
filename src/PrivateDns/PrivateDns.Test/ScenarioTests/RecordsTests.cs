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

namespace Microsoft.Azure.Commands.PrivateDns.Test.ScenarioTests
{
    using ServiceManagement.Common.Models;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;

    public class RecordsTests : PrivateDnsTestsBase
    {
        public XunitTracingInterceptor _logger;

        public RecordsTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetCrud()
        {
            PrivateDnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetCrud");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetCrudTrimsDotFromZoneName()
        {
            PrivateDnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetCrudTrimsDotFromZoneName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetCrudWithZoneResourceId()
        {
            PrivateDnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetCrudWithZoneResourceId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetCrudWithPiping()
        {
            PrivateDnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetCrudWithPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetCrudWithPipingTrimsDotFromZoneName()
        {
            PrivateDnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetCrudWithPipingTrimsDotFromZoneName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetA()
        {
            PrivateDnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetA");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetANonEmpty()
        {
            PrivateDnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetANonEmpty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetAAAA()
        {
            PrivateDnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetAAAA");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetAAAANonEmpty()
        {
            PrivateDnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetAAAANonEmpty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetCNAME()
        {
            PrivateDnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetCNAME");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetCNAMENonEmpty()
        {
            PrivateDnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetCNAMENonEmpty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetMX()
        {
            PrivateDnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetMX");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetMXNonEmpty()
        {
            PrivateDnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetMXNonEmpty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetTXT()
        {
            PrivateDnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetTXT");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetTXTNonEmpty()
        {
            PrivateDnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetTXTNonEmpty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetTXTLengthValidation()
        {
            PrivateDnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetTXTLengthValidation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetTXTLegacyLengthValidation()
        {
            PrivateDnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetTXTLegacyLengthValidation");
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetSRV()
        {
            PrivateDnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetSRV");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetSRVNonEmpty()
        {
            PrivateDnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetSRVNonEmpty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetSOA()
        {
            PrivateDnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetSOA");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetPTR()
        {
            PrivateDnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetPTR");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetPTRNonEmpty()
        {
            PrivateDnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetPTRNonEmpty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetNewAlreadyExists()
        {
            PrivateDnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetNewAlreadyExists");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetAddRecordTypeMismatch()
        {
            PrivateDnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetAddRecordTypeMismatch");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetAddTwoCnames()
        {
            PrivateDnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetAddTwoCnames");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetRemoveRecordTypeMismatch()
        {
            PrivateDnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetRemoveRecordTypeMismatch");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetRemoveUsingResourceId()
        {
            PrivateDnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetRemoveUsingResourceId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetEtagMismatch()
        {
            PrivateDnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetEtagMismatch");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetGet()
        {
            PrivateDnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetGet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetEndsWithZoneName()
        {
            PrivateDnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetEndsWithZoneName");
        }
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecordSetNewRecordNoName()
        {
            PrivateDnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-RecordSetNewRecordNoName");
        }
    }
}
