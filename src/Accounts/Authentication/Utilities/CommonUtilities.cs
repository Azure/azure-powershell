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

namespace Microsoft.Azure.Commands.Common.Authentication
{
    public class CommonUtilities
    {
        /// <summary>
        /// Check if it is in desktop session
        /// </summary>
        /// <returns></returns>
        public virtual bool IsDesktopSession()
        {
            //Check only for Linux platform
            //Linux: https://github.com/microsoft/Git-Credential-Manager-Core/blob/master/src/shared/Microsoft.Git.CredentialManager/Interop/Posix/PosixSessionManager.cs
            //MacOS: https://github.com/microsoft/Git-Credential-Manager-Core/blob/master/src/shared/Microsoft.Git.CredentialManager/Interop/MacOS/MacOSSessionManager.cs
            //Windows: https://github.com/microsoft/Git-Credential-Manager-Core/blob/master/src/shared/Microsoft.Git.CredentialManager/Interop/Windows/WindowsSessionManager.cs
            if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("DISPLAY"));
            }
            return true;
        }
    }
}
