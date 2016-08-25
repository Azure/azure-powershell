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
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.ServiceManagemenet.Common.Models;
using System;
using System.Runtime.InteropServices;
using System.Security;
using Xunit;
using Xunit.Abstractions;
using Assert = Xunit.Assert;

namespace Microsoft.WindowsAzure.Commands.Common.Test.Common
{
    public class ServicePrincipalStoreTests
    {
        public ServicePrincipalStoreTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanStoreAndRetrieveSingleKeyCorrectly()
        {
            const string appId = "myServiceKeyTest";
            string tenantId = Guid.NewGuid().ToString();
            const string password = "My sekret password";

            using (SecureString secret = SecureStringFromString(password))
            {
                ServicePrincipalKeyStore.SaveKey(appId, tenantId, secret);
            }

            try
            {
                string retrievedPassword;
                using (SecureString secret = ServicePrincipalKeyStore.GetKey(appId, tenantId))
                {
                    retrievedPassword = StringFromSecureString(secret);
                }

                Assert.Equal(password, retrievedPassword);
            }
            finally
            {
                ServicePrincipalKeyStore.DeleteKey(appId, tenantId);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RetrievingNonExistingKeyReturnsNull()
        {
            const string appId = "myKeyTest";
            string tenantId = Guid.NewGuid().ToString();

            SecureString ss = null;
            try
            {
                ss = ServicePrincipalKeyStore.GetKey(appId, tenantId);
                Assert.Null(ss);
            }
            finally
            {
                if (ss != null)
                {
                    ss.Dispose();
                }
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DeletingKeyWorks()
        {
            const string appId = "myKeyTest";
            string tenantId = Guid.NewGuid().ToString();

            using (SecureString ss = SecureStringFromString("sekret"))
            {
                ServicePrincipalKeyStore.SaveKey(appId, tenantId, ss);
            }

            using (SecureString ss = ServicePrincipalKeyStore.GetKey(appId, tenantId))
            {
                Assert.NotNull(ss);
            }

            ServicePrincipalKeyStore.DeleteKey(appId, tenantId);

            using (SecureString ss = ServicePrincipalKeyStore.GetKey(appId, tenantId))
            {
                Assert.Null(ss);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanStoreMultipleKeysIndependently()
        {
            const string appId = "myKeyTest";
            string tenant1 = Guid.NewGuid().ToString();
            string tenant2 = Guid.NewGuid().ToString();
            const string pwd1 = "password one";
            const string pwd2 = "second password";

            using (SecureString ss = SecureStringFromString(pwd1))
            {
                ServicePrincipalKeyStore.SaveKey(appId, tenant1, ss);
            }

            using (SecureString ss = SecureStringFromString(pwd2))
            {
                ServicePrincipalKeyStore.SaveKey(appId, tenant2, ss);
            }
            try
            {
                using (SecureString ss = ServicePrincipalKeyStore.GetKey(appId, tenant1))
                {
                    Assert.Equal(pwd1, StringFromSecureString(ss));
                }

                using (SecureString ss = ServicePrincipalKeyStore.GetKey(appId, tenant2))
                {
                    Assert.Equal(pwd2, StringFromSecureString(ss));
                }
            }
            finally
            {
                ServicePrincipalKeyStore.DeleteKey(appId, tenant1);
                ServicePrincipalKeyStore.DeleteKey(appId, tenant2);
            }
        }

        /// <summary>
        /// Helper function to turn a string into a SecureString instance.
        /// </summary>
        /// <param name="s">string to "secure"</param>
        /// <returns>SecureString instance</returns>
        private SecureString SecureStringFromString(string s)
        {
            SecureString ss = new SecureString();
            foreach (char c in s)
            {
                ss.AppendChar(c);
            }
            ss.MakeReadOnly();
            return ss;
        }

        /// <summary>
        /// Helper function to crack out the contents of a SecureString
        /// and turn it into a regular string.
        /// </summary>
        /// <remarks>Never do this for real, it defeats the point of
        /// SecureString!</remarks>
        /// <param name="ss">The SecureString to crack.</param>
        /// <returns>Contents of <paramref name="ss"/> as a regular string.</returns>
        private string StringFromSecureString(SecureString ss)
        {
            IntPtr buffer = IntPtr.Zero;
            try
            {
                buffer = Marshal.SecureStringToGlobalAllocUnicode(ss);
                return Marshal.PtrToStringUni(buffer);
            }
            finally
            {
                if (buffer != IntPtr.Zero)
                {
                    Marshal.ZeroFreeGlobalAllocUnicode(buffer);
                }
            }
        }
    }
}
