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
    /// <summary>
    /// A utility class to get the window handle of a command prompt or terminal.
    /// https://github.com/AzureAD/microsoft-authentication-library-for-dotnet/wiki/wam#parent-window-handles
    /// </summary>
    public static class WindowHandleUtilities
    {
        enum GetAncestorFlags
        {
            GetParent = 1,
            GetRoot = 2,
            /// <summary>
            /// Retrieves the owned root window by walking the chain of parent and owner windows returned by GetParent.
            /// </summary>
            GetRootOwner = 3
        }

        /// <summary>
        /// Retrieves the handle to the ancestor of the specified window.
        /// </summary>
        /// <param name="hwnd">A handle to the window whose ancestor is to be retrieved.
        /// If this parameter is the desktop window, the function returns NULL. </param>
        /// <param name="flags">The ancestor to be retrieved.</param>
        /// <returns>The return value is the handle to the ancestor window.</returns>
        [DllImport("user32.dll", ExactSpelling = true)]
        static extern IntPtr GetAncestor(IntPtr hwnd, GetAncestorFlags flags);

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        public static IntPtr GetConsoleOrTerminalWindow()
        {
            if (SharedUtilities.IsWindowsPlatform())
            {
                IntPtr consoleHandle = GetConsoleWindow();
                IntPtr handle = GetAncestor(consoleHandle, GetAncestorFlags.GetRootOwner);
                return handle;
            }
            else
            {
                // can't call Windows native APIs
                return (IntPtr)0;
            }
        }
    }
}
