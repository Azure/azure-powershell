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

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers
{
    /// <summary>
    /// Extension methods to use with enums.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Converts an enum to another enum - assuming their string values are the same.
        /// </summary>
        /// <typeparam name="T">Type of destination enum.</typeparam>
        /// <param name="enumValue">Source enum.</param>
        /// <returns>Destination enum equivalent to the source enum.</returns>
        public static T ToEnum<T>(this Enum enumValue)
        {
            return enumValue.ToString().ToEnum<T>();
        }

        /// <summary>
        /// Converts a string to an enum.
        /// </summary>
        /// <typeparam name="T">Type of destination enum.</typeparam>
        /// <param name="enumValue">String value of the enum.</param>
        /// <returns>Destination enum equivalent to the source string.</returns>
        public static T ToEnum<T>(this string enumValue)
        {
            return (T)Enum.Parse(typeof(T), enumValue);
        }
    }
}
