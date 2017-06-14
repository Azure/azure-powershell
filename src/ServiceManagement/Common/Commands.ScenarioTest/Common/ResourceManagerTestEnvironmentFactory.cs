//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using Hyak.Common;
using System;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest.Common
{
    public class ResourceManagerTestEnvironmentFactory : TestEnvironmentFactory
    {
        /// <summary>
        /// The environment variable name for CSM OrgId authentication
        /// 
        /// Sample Value 1 - Get token from user and password:
        /// TEST_CSM_ORGID_AUTHENTICATION=SubscriptionId={subscription-id};BaseUri=https://api-next.resources.windows-int.net/;UserId={user-id};Password={password}
        /// 
        /// Sample Value 2 - Prompt for login credentials:
        /// TEST_CSM_ORGID_AUTHENTICATION=SubscriptionId={subscription-id};AADAuthEndpoint=https://login.windows-ppe.net/;BaseUri=https://api-next.resources.windows-int.net/
        /// </summary>
        const string TestCSMOrgIdConnectionStringKey = "TEST_CSM_ORGID_AUTHENTICATION";

        /// <summary>
        /// The full uri of the template gallery to use for this test run
        /// 
        /// Sample Value 1: next uri
        /// TEST_CSM_GALLERY_URI=https://next.gallery.azure-test.net
        /// </summary>
        const string TestCSMGalleryUri = "TEST_CSM_GALLERY_URI";

        /// <summary>
        /// Gallery for RDFENext environment
        /// </summary>
        const string DefaultGalleryUri = "https://next.gallery.azure-test.net";
        /// <summary>
        /// Return the test environment created using CSM environment variables
        /// </summary>
        /// <returns>The test environment.</returns>
        protected override TestEnvironment GetTestEnvironmentFromContext()
        {
            TestEnvironment environment = null;
            try
            {
                environment = base.GetOrgIdTestEnvironment(TestCSMOrgIdConnectionStringKey);
            }
            catch (ArgumentException exception)
            {
                // allow running gallery tests
                TracingAdapter.Information("Node.exe was not found on the system, please install the x86 version of node.exe to run tests, received exception {0}", exception);
            }

            string galleryUri = Environment.GetEnvironmentVariable(TestCSMGalleryUri);
            if (null == environment)
            {
                // we should be able to run gallery tests, even if credentials are not set up
                environment = new TestEnvironment();
            }

            if (!string.IsNullOrEmpty(galleryUri))
            {
                environment.GalleryUri = new Uri(galleryUri);
            }
            else
            {
                environment.GalleryUri = new Uri(DefaultGalleryUri);
            }

            return environment;
        }
    }
}
