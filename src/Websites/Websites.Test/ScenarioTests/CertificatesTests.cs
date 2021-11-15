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

using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Websites.Test.ScenarioTests
{
    public class CertificatesTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;
        public CertificatesTests(ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzWebAppCertificate()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-NewAzWebAppCertificate");
        }
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzWebAppCertificateWithSSLBinding()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-NewAzWebAppCertificateWithSSLBinding");
        }
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzWebAppCertificateForSlot()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-NewAzWebAppCertificateForSlot");
        }
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAzWebAppCertificate()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-RemoveAzWebAppCertificate");
        }
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestImportAzWebAppKeyVaultCertificate()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-ImportAzWebAppKeyVaultCertificate");
        }
    }
}
