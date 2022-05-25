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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Commands.DeviceProvisioningServices.Test
{
    public class IotDpsCertificateTests : DeviceProvisioningServicesTestRunner
    {
        public IotDpsCertificateTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact(Skip = "Access denied error on CertEnroll CX509 Enrollment CreateRequest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void IotDpsCertificateLifeCycle()
        {
            var rootCertificatePath = System.AppDomain.CurrentDomain.BaseDirectory + "\\rootCertificate.cer";
            var verifyCertificatePath = System.AppDomain.CurrentDomain.BaseDirectory + "\\verifyCertificate.cer";

            TestExecutionHelpers.SetUpSessionAndProfile();

            var oldDataStore = AzureSession.Instance.DataStore;
            var memoryStore = oldDataStore as MemoryDataStore;
            MemoryDataStore dataStore = memoryStore != null ? memoryStore : new MemoryDataStore();

            dataStore.VirtualStore.Add(rootCertificatePath, rootCertificatePath);
            dataStore.VirtualStore.Add(verifyCertificatePath, verifyCertificatePath);

            AzureSession.Instance.DataStore = dataStore;

            TestRunner.RunTestScript("Test-AzureIotDpsCertificateLifeCycle");
        }
    }
}
