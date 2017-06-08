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
using System.Collections;
using System.Collections.Generic;
using System.Security;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    /// <summary>
    /// Helper class to store service principal keys and retrieve them
    /// from the Windows Credential Store.
    /// </summary>
    public static class ServicePrincipalKeyStore
    {
        private static IDictionary<string, SecureString> _credentials = new Dictionary<string, SecureString>();

        public static void SaveKey(string appId, string tenantId, SecureString serviceKey)
        {
            var key = CreateKey(appId, tenantId);
            _credentials[key] = serviceKey;
        }

        public static SecureString GetKey(string appId, string tenantId)
        {
            IntPtr pCredential = IntPtr.Zero;
            try
            {
                var key = CreateKey(appId, tenantId);
                return _credentials[key];

            }
            catch
            {
                // we could be running in an environment that does not have credentials store
            }

            return null;
        }


        public static void DeleteKey(string appId, string tenantId)
        {
            try
            {
                var key = CreateKey(appId, tenantId);
                _credentials.Remove(key);
            }
            catch
            {
            }
        }

        private static string CreateKey(string appId, string tenantId)
        {
            return $"{appId}_{tenantId}";
        }

        internal static SecureString ConvertToSecureString(string password)
        {
            if (password == null)
                throw new ArgumentNullException("password");

            var securePassword = new SecureString();

            foreach (char c in password)
                securePassword.AppendChar(c);

            securePassword.MakeReadOnly();
            return securePassword;
        }
    }
}