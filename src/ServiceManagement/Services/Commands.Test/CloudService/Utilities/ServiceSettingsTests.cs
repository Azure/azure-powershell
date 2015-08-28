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
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.WindowsAzure.Commands.Test.CloudService.Utilities
{
    
    public class ServiceSettingsTests : SMTestBase
    {
        public ServiceSettingsTests()
        {
            AzurePowerShell.ProfileDirectory = Test.Utilities.Common.Data.AzureSdkAppDir;
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ServiceSettingsTest()
        {


            ServiceSettings settings = new ServiceSettings();
            AzureAssert.AreEqualServiceSettings(string.Empty, string.Empty, string.Empty, string.Empty, settings);
        }

        /// <summary>
        /// Verify that using an invalid storage account name throws an
        /// exception.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void InvalidStorageAccountName()
        {
            // Create a temp directory that we'll use to "publish" our service
            using (FileSystemHelper files = new FileSystemHelper(this) { EnableMonitoring = true })
            {
                // Import our default publish settings
                files.CreateAzureSdkDirectoryAndImportPublishSettings();

                string serviceName = null;
                Testing.AssertThrows<ArgumentException>(() =>
                    ServiceSettings.LoadDefault(null, null, null, null, null, "I HAVE INVALID CHARACTERS !@#$%", null, null, out serviceName));
                Testing.AssertThrows<ArgumentException>(() =>
                    ServiceSettings.LoadDefault(null, null, null, null, null, "ihavevalidcharsbutimjustwaytooooooooooooooooooooooooooooooooooooooooolong", null, null, out serviceName));
            }
        }

        /// <summary>
        /// Verify that a service name with invalid characters is correctly
        /// sanitized to a storage account name.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SanitizeServiceNameForStorageAccountName()
        {
            // Create a temp directory that we'll use to "publish" our service
            using (FileSystemHelper files = new FileSystemHelper(this) { EnableMonitoring = true })
            {
                // Import our default publish settings
                files.CreateAzureSdkDirectoryAndImportPublishSettings();

                string serviceName = null;
                ServiceSettings settings = ServiceSettings.LoadDefault(null, null, null, null, null, null, "My-Custom-Service!", null, out serviceName);
                Assert.Equal("myx2dcustomx2dservicex21", settings.StorageServiceName);

                settings = ServiceSettings.LoadDefault(null, null, null, null, null, null, "MyCustomServiceIsWayTooooooooooooooooooooooooLong", null, out serviceName);
                Assert.Equal("mycustomserviceiswaytooo", settings.StorageServiceName);
            }
        }

        /// <summary>
        /// Verify that ServicSettings will accept unknown Microsoft Azure RDFE location.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDefaultLocationWithUnknwonLocation()
        {
            // Create a temp directory that we'll use to "publish" our service
            using (FileSystemHelper files = new FileSystemHelper(this) { EnableMonitoring = true })
            {
                // Import our default publish settings
                files.CreateAzureSdkDirectoryAndImportPublishSettings();
                string serviceName = null;
                string unknownLocation = "Unknown Location";

                ServiceSettings settings = ServiceSettings.LoadDefault(null, null, unknownLocation, null, null, null, "My-Custom-Service!", null, out serviceName);
                Assert.Equal<string>(unknownLocation.ToLower(), settings.Location.ToLower());

            }
        }
    }
}