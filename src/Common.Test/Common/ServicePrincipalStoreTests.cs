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
using Microsoft.Azure.Commands.ResourceManager.Common;
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
        private IServicePrincipalKeyStore _keyStore;

        public ServicePrincipalStoreTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            _keyStore = new AzureRmServicePrincipalKeyStore();
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
                _keyStore.SaveKey(appId, tenantId, secret);
            }

            try
            {
                string retrievedPassword;
                using (SecureString secret = _keyStore.GetKey(appId, tenantId))
                {
                    retrievedPassword = StringFromSecureString(secret);
                }

                Assert.Equal(password, retrievedPassword);
            }
            finally
            {
                _keyStore.DeleteKey(appId, tenantId);
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
                ss = _keyStore.GetKey(appId, tenantId);
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
                _keyStore.SaveKey(appId, tenantId, ss);
            }

            using (SecureString ss = _keyStore.GetKey(appId, tenantId))
            {
                Assert.NotNull(ss);
            }

            _keyStore.DeleteKey(appId, tenantId);

            using (SecureString ss = _keyStore.GetKey(appId, tenantId))
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
                _keyStore.SaveKey(appId, tenant1, ss);
            }

            using (SecureString ss = SecureStringFromString(pwd2))
            {
                _keyStore.SaveKey(appId, tenant2, ss);
            }
            try
            {
                using (SecureString ss = _keyStore.GetKey(appId, tenant1))
                {
                    Assert.Equal(pwd1, StringFromSecureString(ss));
                }

                using (SecureString ss = _keyStore.GetKey(appId, tenant2))
                {
                    Assert.Equal(pwd2, StringFromSecureString(ss));
                }
            }
            finally
            {
                _keyStore.DeleteKey(appId, tenant1);
                _keyStore.DeleteKey(appId, tenant2);
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
