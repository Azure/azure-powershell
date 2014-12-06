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

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// Extends SecureString and string to convert from one to the other
    /// </summary>
    public static class SecureStringExtension
    {

        /// <summary>
        /// Converts a string into a secure string.
        /// </summary>
        /// <param name="str">the string to be converted.</param>
        public static SecureString ToSecureString( this string str )
        {
            if ( str == null )
            {
                throw new ArgumentNullException( "str" );
            }

            SecureString secureString = null;

            try
            {
                secureString = new SecureString();

                foreach ( char ch in str )
                {
                    secureString.AppendChar( ch );
                }

                return secureString;
            }
            catch ( Exception )
            {
                if ( secureString != null )
                {
                    secureString.Dispose();
                }

                throw;
            }
        }

        /// <summary>
        /// Converts the secure string to a string.
        /// </summary>
        /// <param name="secureString">the secure string to be converted.</param>
        public static string ToStringExt( this SecureString secureString )
        {
            string str = null;
            IntPtr stringPointer = IntPtr.Zero;

            if ( secureString == null )
            {
                throw new ArgumentNullException( "secureString" );
            }

            try
            {
                stringPointer = Marshal.SecureStringToBSTR(secureString);
                str = Marshal.PtrToStringBSTR(stringPointer);
            }
            finally
            {
                Marshal.ZeroFreeBSTR(stringPointer);
            }

            return str;
        }
    }
}
