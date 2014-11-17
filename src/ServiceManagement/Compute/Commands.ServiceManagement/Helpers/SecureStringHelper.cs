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
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers
{
    using NSM = Management.Compute.Models;
    using PVM = Model;

    public static class SecureStringHelper
    {
        const string PublicTypeStr = "Public";
        const string PrivateTypeStr = "Private";

        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public static string ConvertToUnsecureString(this SecureString securePassword)
        {
            if (securePassword == null)
                throw new ArgumentNullException("securePassword");

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        public static SecureString GetSecureString(NSM.ResourceExtensionParameterValue item)
        {
            SecureString secureStr = null;

            bool isPrivate = string.Equals(
                item.Type,
                PrivateTypeStr,
                StringComparison.OrdinalIgnoreCase);

            if (item != null && isPrivate)
            {
                secureStr = GetSecureString(item.Value);
            }

            return secureStr;
        }

        public static string GetPlainString(NSM.ResourceExtensionParameterValue item)
        {
            string str = null;

            bool isPublic = string.Equals(
                item.Type,
                PublicTypeStr,
                StringComparison.OrdinalIgnoreCase);

            if (item != null && isPublic)
            {
                str = item.Value;
            }

            return str;
        }
		
        public static string GetPlainString(PVM.ResourceExtensionParameterValue item)
        {
            string str = null;

            if (item != null)
            {
                if (string.Equals( item.Type, PublicTypeStr, StringComparison.OrdinalIgnoreCase))
                {
                    str = item.Value;
                }
                else if (string.Equals(item.Type, PrivateTypeStr, StringComparison.OrdinalIgnoreCase))
                {
                    str = item.SecureValue.ConvertToUnsecureString();
                }
            }

            return str;
        }

        public static SecureString GetSecureString(string str)
        {
            SecureString secureStr = null;

            if (!string.IsNullOrEmpty(str))
            {
                secureStr = new SecureString();
                foreach (char c in str)
                {
                    secureStr.AppendChar(c);
                }
            }

            return secureStr;
        }
    }
}
