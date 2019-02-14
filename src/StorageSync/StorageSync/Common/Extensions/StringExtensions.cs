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

namespace Microsoft.Azure.Commands.StorageSync.Common.Extensions
{
    /// <summary>
    /// String Extensions class
    /// </summary>
    public static class StringExtensions
    {

        /// <summary>
        /// This function will transform an string to uri object.
        /// </summary>
        /// <param name="uriString">Uri String</param>
        /// <param name="uriKind">Uri kind</param>
        /// <param name="throwException">Throw Exception</param>
        /// <returns>Uri object</returns>
        public static Uri ToUri(this string uriString, UriKind uriKind = UriKind.RelativeOrAbsolute, bool throwException = true)
        {
            try
            {
                return new Uri(uriString, uriKind);
            }
            catch (Exception) when (!throwException)
            {
            }
            return default(Uri);
        }

        /// <summary>
        /// This function will convert a string to server certificate.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="throwException">if set to <c>true</c> [throw exception].</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] ToBase64Bytes(this string source, bool throwException = true)
        {
            try
            {
                return Convert.FromBase64String(source);
            }
            catch (FormatException) when (!throwException)
            {
            }

            return default(byte[]);
        }

    }
}
