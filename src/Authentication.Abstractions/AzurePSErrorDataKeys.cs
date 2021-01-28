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

using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common
{
    /// <summary>
    /// Represent key names in Exception.Data for Azure PowerShell.
    /// </summary>
    public static class AzurePSErrorDataKeys
    {
        /// <summary>
        /// Key prefix, user could add any other keys into Exception.Data with this prefix
        /// </summary>
        public static readonly string KeyPrefix = "AzPS";

        /// <summary>
        /// Key for ErrorKind
        /// </summary>
        public static readonly string ErrorKindKey = KeyPrefix + "ErrorKind";

        /// <summary>
        /// Key for desensitized error message
        /// </summary>
        public static readonly string DesensitizedErrorMessageKey = KeyPrefix + "DesensitizedMessage";

        /// <summary>
        /// Key for status code from http response
        /// </summary>
        public static readonly string HttpStatusCode = KeyPrefix + "HttpStatusCode";

        /// <summary>
        /// Key for cloud error code in http response body
        /// </summary>
        public static readonly string CloudErrorCodeKey = KeyPrefix + "CloudErrorCode";

        /// <summary>
        /// Key for authentication error code which normally comes from MSAL.NET
        /// </summary>
        public static readonly string AuthErrorCodeKey = KeyPrefix + "AuthErrorCode";

        /// <summary>
        /// Key for parameter name which usually used in Argument related exception
        /// </summary>
        public static readonly string ParamNameKey = KeyPrefix + "ParamName";

        /// <summary>
        /// Key for file name which usually used in IO related exception
        /// </summary>
        public static readonly string FileNameKey = KeyPrefix + "FileName";

        /// <summary>
        /// Key for dictionary key which usually used in AzPSKeyNotFoundException
        /// </summary>
        public static readonly string NotFoundKeyNameKey = KeyPrefix + "NotFoundKeyName";

        /// <summary>
        /// Key for line number where exception is thrown
        /// </summary>
        public static readonly string ErrorLineNumberKey = KeyPrefix + "ErrorLineNumber";

        /// <summary>
        /// Key for file name in which exception is thrown
        /// </summary>
        public static readonly string ErrorFileNameKey = KeyPrefix + "ErrorFileName";

        /// <summary>
        /// Key for hresult returned from underlying OS API
        /// </summary>
        public static readonly string ErrorHResultKey = KeyPrefix + "HResult";

        /// <summary>
        /// Determine whether the "key" is predefined one
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsKeyPredefined(string key)
        {
            return KeyList.Contains(key);
        }

        /// <summary>
        /// Known key name list
        /// </summary>
        private static HashSet<string> KeyList = new HashSet<string>(new string[] {
            ErrorKindKey,
            DesensitizedErrorMessageKey,
            HttpStatusCode,
            AuthErrorCodeKey,
            ParamNameKey,
            FileNameKey,
            NotFoundKeyNameKey,
            ErrorLineNumberKey,
            ErrorFileNameKey,
            ErrorHResultKey,
            CloudErrorCodeKey,
        });
    }
}
