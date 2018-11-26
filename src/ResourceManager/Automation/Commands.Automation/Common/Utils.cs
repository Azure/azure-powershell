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

namespace Microsoft.Azure.Commands.Automation.Common
{
    internal static class Utils
    {
        internal static string GetStringFromSecureString(SecureString ss)
        {
            IntPtr buffer = IntPtr.Zero;
            string plainTextString = null;

            try
            {
                buffer = Marshal.SecureStringToCoTaskMemUnicode(ss);
                plainTextString = Marshal.PtrToStringUni(buffer);
            }
            finally
            {
                if (buffer != IntPtr.Zero)
                {
                    Marshal.ZeroFreeCoTaskMemUnicode(buffer);
                }
            }

            return plainTextString;
        }
    }
}
