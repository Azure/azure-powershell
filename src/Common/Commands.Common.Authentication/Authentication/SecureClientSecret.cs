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

using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;

namespace Microsoft.Azure.Commands.Common.Authentication
{

    /// <summary>
    /// This class allows to pass client secret as a SecureString to the API.
    /// </summary>
    public static class SecureClientSecret
    {
#if NETSTANDARD1_6
        public static string SecureStringToString(SecureString value)
        {
            string passwordValueToAdd = String.Empty;

            if (value != null)
            {
                IntPtr ptr = SecureStringMarshal.SecureStringToCoTaskMemUnicode(value);
                passwordValueToAdd = Marshal.PtrToStringUni(ptr);
                Marshal.ZeroFreeCoTaskMemUnicode(ptr);
            }

            return passwordValueToAdd;
        }
#else
        public static string SecureStringToString(SecureString secureString)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }
    
#endif
    }
}
