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
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class CertificateTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        public CertificateTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddCertificate()
        {
            BatchController.NewInstance.RunPsTest("Test-AddCertificate");
        }

        [Fact]
        public void TestGetCertificateByThumbprint()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string thumbprint = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-GetCertificateByThumbprint '{0}' '{1}'", BatchTestHelpers.TestCertificateAlgorithm, thumbprint) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    thumbprint = ScenarioTestHelpers.AddTestCertificate(controller, context, BatchTestHelpers.TestCertificateFileName1);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteTestCertificate(controller, context, BatchTestHelpers.TestCertificateAlgorithm, thumbprint);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestListCertificatesByFilter()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string state = "active";
            string thumbprint1 = null;
            string toDeleteThumbprint = null;
            int matchCount = 1;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListCertificatesByFilter '{0}' '{1}' '{2}'", state, toDeleteThumbprint, matchCount) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    thumbprint1 = ScenarioTestHelpers.AddTestCertificate(controller, context, BatchTestHelpers.TestCertificateFileName1);
                    toDeleteThumbprint = ScenarioTestHelpers.AddTestCertificate(controller, context, BatchTestHelpers.TestCertificateFileName2);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteTestCertificate(controller, context, BatchTestHelpers.TestCertificateAlgorithm, thumbprint1);
                    // Other cert is deleted as the first part of the PowerShell test script, but we ensure it's gone.
                    try
                    {
                        ScenarioTestHelpers.DeleteTestCertificate(controller, context, BatchTestHelpers.TestCertificateAlgorithm, toDeleteThumbprint);
                    }
                    catch { }
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAndListCertificatesWithSelect()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string thumbprint = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-GetAndListCertificatesWithSelect '{0}' '{1}'", BatchTestHelpers.TestCertificateAlgorithm, thumbprint) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    thumbprint = ScenarioTestHelpers.AddTestCertificate(controller, context, BatchTestHelpers.TestCertificateFileName1);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteTestCertificate(controller, context, BatchTestHelpers.TestCertificateAlgorithm, thumbprint);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestListCertificatesWithMaxCount()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            int maxCount = 1;
            string thumbprint1 = null;
            string thumbprint2 = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListCertificatesWithMaxCount '{0}'", maxCount) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    thumbprint1 = ScenarioTestHelpers.AddTestCertificate(controller, context, BatchTestHelpers.TestCertificateFileName1);
                    thumbprint2 = ScenarioTestHelpers.AddTestCertificate(controller, context, BatchTestHelpers.TestCertificateFileName2);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteTestCertificate(controller, context, BatchTestHelpers.TestCertificateAlgorithm, thumbprint1);
                    ScenarioTestHelpers.DeleteTestCertificate(controller, context, BatchTestHelpers.TestCertificateAlgorithm, thumbprint2);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestListAllCertificates()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            int count = 2;
            string thumbprint1 = null;
            string thumbprint2 = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListAllCertificates '{0}'", count) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    thumbprint1 = ScenarioTestHelpers.AddTestCertificate(controller, context, BatchTestHelpers.TestCertificateFileName1);
                    thumbprint2 = ScenarioTestHelpers.AddTestCertificate(controller, context, BatchTestHelpers.TestCertificateFileName2);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteTestCertificate(controller, context, BatchTestHelpers.TestCertificateAlgorithm, thumbprint1);
                    ScenarioTestHelpers.DeleteTestCertificate(controller, context, BatchTestHelpers.TestCertificateAlgorithm, thumbprint2);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeleteCertificate()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string thumbprint = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-DeleteCertificate '{0}' '{1}'", BatchTestHelpers.TestCertificateAlgorithm, thumbprint) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    thumbprint = ScenarioTestHelpers.AddTestCertificate(controller, context, BatchTestHelpers.TestCertificateFileName1);
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestCancelCertificateDelete()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string thumbprint = null;
            string poolId = "certPool";
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-TestCancelCertificateDelete '{0}' '{1}'", BatchTestHelpers.TestCertificateAlgorithm, thumbprint) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    thumbprint = ScenarioTestHelpers.AddTestCertificate(controller, context, BatchTestHelpers.TestCertificateFileName1);
                    CertificateReference certRef = new CertificateReference();
                    certRef.StoreLocation = CertStoreLocation.CurrentUser;
                    certRef.StoreName = "My";
                    certRef.ThumbprintAlgorithm = BatchTestHelpers.TestCertificateAlgorithm;
                    certRef.Thumbprint = thumbprint;
                    certRef.Visibility = CertificateVisibility.Task;
                    ScenarioTestHelpers.CreateTestPool(controller, context, poolId, 0, certRef);
                    ScenarioTestHelpers.DeleteTestCertificate(controller, context, BatchTestHelpers.TestCertificateAlgorithm, thumbprint);
                    ScenarioTestHelpers.WaitForCertificateToFailDeletion(controller, context, BatchTestHelpers.TestCertificateAlgorithm, thumbprint);
                },
                () =>
                {
                    ScenarioTestHelpers.DeletePool(controller, context, poolId);
                    ScenarioTestHelpers.DeleteTestCertificate(controller, context, BatchTestHelpers.TestCertificateAlgorithm, thumbprint);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }
    }
}
