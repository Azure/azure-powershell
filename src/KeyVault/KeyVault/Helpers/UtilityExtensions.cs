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

using Azure.Security.KeyVault.Keys;

using Microsoft.Azure.Commands.KeyVault.Models;

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;

namespace Microsoft.Azure.Commands.KeyVault
{
    internal static class UtilityExtensions
    {
        public static string ToPlainText(this SecureString secureString)
        {
            IntPtr bstr = Marshal.SecureStringToBSTR(secureString);

            try
            {
                return Marshal.PtrToStringBSTR(bstr);
            }
            finally
            {
                Marshal.FreeBSTR(bstr);
            }
        }

        public static PSKeyReleasePolicy ToPSKeyReleasePolicy(this KeyReleasePolicy keyReleasePolicy)
        {
            if (keyReleasePolicy == null)
            {
                return null;
            }
            return new PSKeyReleasePolicy(keyReleasePolicy);
        }
    }
}
