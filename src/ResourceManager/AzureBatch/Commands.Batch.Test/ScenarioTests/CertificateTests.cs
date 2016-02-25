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

using System;
using Microsoft.Azure.Batch;
using Microsoft.Azure.Batch.Common;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System.Collections.Generic;
using System.Management.Automation;
using Xunit;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class CertificateTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private const string accountName = ScenarioTestHelpers.SharedAccount;

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddCertificate()
        {
            BatchController controller = BatchController.NewInstance;
            controller.RunPsTest(string.Format("Test-AddCertificate '{0}'", accountName));
        }

        [Fact]
        public void TestGetCertificateByThumbprint()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string thumbprint = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-GetCertificateByThumbprint '{0}' '{1}' '{2}'", accountName, BatchTestHelpers.TestCertificateAlgorithm, thumbprint) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
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
                () => { return new string[] { string.Format("Test-ListCertificatesByFilter '{0}' '{1}' '{2}' '{3}'", accountName, state, toDeleteThumbprint, matchCount) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
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
                () => { return new string[] { string.Format("Test-GetAndListCertificatesWithSelect '{0}' '{1}' '{2}'", accountName, BatchTestHelpers.TestCertificateAlgorithm, thumbprint) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
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
                () => { return new string[] { string.Format("Test-ListCertificatesWithMaxCount '{0}' '{1}'", accountName, maxCount) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
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
                () => { return new string[] { string.Format("Test-ListAllCertificates '{0}' '{1}'", accountName, count) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
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
                () => { return new string[] { string.Format("Test-DeleteCertificate '{0}' '{1}' '{2}'", accountName, BatchTestHelpers.TestCertificateAlgorithm, thumbprint) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
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
                () => { return new string[] { string.Format("Test-TestCancelCertificateDelete '{0}' '{1}' '{2}'", accountName, BatchTestHelpers.TestCertificateAlgorithm, thumbprint) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
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
