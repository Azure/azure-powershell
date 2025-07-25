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

using Microsoft.Azure.Batch;
using Microsoft.Azure.Batch.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class CertificateTests : BatchTestRunner
    {
        public CertificateTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {

        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCertificateCrudOperations()
        {
            TestRunner.RunTestScript("Test-CertificateCrudOperations");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Obsolete]
        public void TestCancelCertificateDelete()
        {
            BatchAccountContext context = null;
            X509Certificate2 cert = new X509Certificate2(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources/BatchTestCert01.cer"));
            string thumbprint = cert.Thumbprint.ToLowerInvariant();
            string poolId = "certPool";
            TestRunner.RunTestScript(
                null,
                mockContext =>
                {
                    context = new ScenarioTestContext();
                    thumbprint = ScenarioTestHelpers.AddTestCertificate(this, context, BatchTestHelpers.TestCertificateFileName).ToLowerInvariant();
                    CertificateReference certRef = new CertificateReference();
                    certRef.StoreLocation = CertStoreLocation.CurrentUser;
                    certRef.StoreName = "My";
                    certRef.ThumbprintAlgorithm = BatchTestHelpers.TestCertificateAlgorithm;
                    certRef.Thumbprint = thumbprint;
                    certRef.Visibility = CertificateVisibility.Task;
                    ScenarioTestHelpers.CreateTestPoolVirtualMachine(this, context, poolId, targetDedicated: 0, targetLowPriority: 0, certReference: certRef);
                    ScenarioTestHelpers.DeleteTestCertificate(this, context, BatchTestHelpers.TestCertificateAlgorithm, thumbprint);
                    ScenarioTestHelpers.WaitForCertificateToFailDeletion(this, context, BatchTestHelpers.TestCertificateAlgorithm, thumbprint);
                },
                () =>
                {
                    ScenarioTestHelpers.DeletePool(this, context, poolId);
                    ScenarioTestHelpers.DeleteTestCertificate(this, context, BatchTestHelpers.TestCertificateAlgorithm, thumbprint);
                },
                $"Test-TestCancelCertificateDelete '{BatchTestHelpers.TestCertificateAlgorithm}' '{thumbprint}'"
            );
        }
    }
}
