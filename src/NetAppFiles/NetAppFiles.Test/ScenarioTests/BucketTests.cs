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

using Microsoft.Azure.Commands.TestFx.Recorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.NetAppFiles.Test.ScenarioTests.ScenarioTest
{
    public class BucketTests : NetAppFilesTestRunner
    {
        public BucketTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
            RecorderUtilities.JsonPathSanitizers.Add("$..accessKey");
            RecorderUtilities.JsonPathSanitizers.Add("$..secretKey");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBucketCrud()
        {
            TestRunner.RunTestScript("Test-BucketCrud");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBucketPipeline()
        {
            TestRunner.RunTestScript("Test-BucketPipeline");
        }

        // AKV-backed scenarios require a pre-existing Azure Key Vault with:
        //   - a PEM certificate (cert + private key) stored under 'CertificateName', and
        //   - a managed-identity/access policy that allows the ANF RP to read that certificate and
        //     (for the credentials scenarios) write the generated access/secret key pair as a secret.
        // We do not have those prerequisites wired up in the test environment yet, so these tests are
        // skipped. Enable them once an AKV + ANF identity/access-policy fixture is provisioned.

        [Fact(Skip = "Requires pre-provisioned Azure Key Vault + ANF identity/access policy. Enable once AKV fixture is available.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBucketCreateWithAkv()
        {
            TestRunner.RunTestScript("Test-BucketCreateWithAkv");
        }

        [Fact(Skip = "Requires pre-provisioned Azure Key Vault + ANF identity/access policy. Enable once AKV fixture is available.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBucketUpdateWithAkv()
        {
            TestRunner.RunTestScript("Test-BucketUpdateWithAkv");
        }

        [Fact(Skip = "Requires pre-provisioned Azure Key Vault + ANF identity/access policy. Enable once AKV fixture is available.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBucketAkvCredential()
        {
            TestRunner.RunTestScript("Test-BucketAkvCredential");
        }

        [Fact(Skip = "Requires pre-provisioned Azure Key Vault + ANF identity/access policy. Enable once AKV fixture is available.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBucketRefreshCertificate()
        {
            TestRunner.RunTestScript("Test-BucketRefreshCertificate");
        }
    }
}
