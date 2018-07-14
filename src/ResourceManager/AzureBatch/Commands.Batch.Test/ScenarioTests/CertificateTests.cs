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

using System.Reflection;
using Microsoft.Azure.Batch;
using Microsoft.Azure.Batch.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.Azure.ServiceManagemenet.Common.Models;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class CertificateTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public CertificateTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCertificateCrudOperations()
        {
            BatchController.NewInstance.RunPsTest(_logger, "Test-CertificateCrudOperations");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCancelCertificateDelete()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string thumbprint = null;
            string poolId = "certPool";
            controller.RunPsTestWorkflow(
                _logger,
                () => { return new string[] { string.Format("Test-TestCancelCertificateDelete '{0}' '{1}'", BatchTestHelpers.TestCertificateAlgorithm, thumbprint) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    thumbprint = ScenarioTestHelpers.AddTestCertificate(controller, context, BatchTestHelpers.TestCertificateFileName);
                    CertificateReference certRef = new CertificateReference();
                    certRef.StoreLocation = CertStoreLocation.CurrentUser;
                    certRef.StoreName = "My";
                    certRef.ThumbprintAlgorithm = BatchTestHelpers.TestCertificateAlgorithm;
                    certRef.Thumbprint = thumbprint;
                    certRef.Visibility = CertificateVisibility.Task;
                    ScenarioTestHelpers.CreateTestPool(controller, context, poolId, targetDedicated: 0, targetLowPriority: 0, certReference: certRef);
                    ScenarioTestHelpers.DeleteTestCertificate(controller, context, BatchTestHelpers.TestCertificateAlgorithm, thumbprint);
                    ScenarioTestHelpers.WaitForCertificateToFailDeletion(controller, context, BatchTestHelpers.TestCertificateAlgorithm, thumbprint);
                },
                () =>
                {
                    ScenarioTestHelpers.DeletePool(controller, context, poolId);
                    ScenarioTestHelpers.DeleteTestCertificate(controller, context, BatchTestHelpers.TestCertificateAlgorithm, thumbprint);
                },
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }
    }
}
