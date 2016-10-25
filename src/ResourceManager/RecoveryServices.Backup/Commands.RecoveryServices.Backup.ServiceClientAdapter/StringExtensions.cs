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

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS
{
    /// <summary>
    /// Extension methods on strings.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Converts the given string to its camelcase. SampleString becomes sampleString.
        /// </summary>
        /// <param name="str">Input string.</param>
        /// <returns>Camel-cased string.</returns>
        public static string ToCamelCase(this string str)
        {
            return string.IsNullOrEmpty(str) ? 
                str : string.Format("{0}{1}", char.ToLower(str[0]), str.Substring(1));
        }
    }
}
