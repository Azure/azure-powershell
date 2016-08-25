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

namespace Microsoft.AzureStack.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Argument Validation Methods
    /// </summary>
    public static class ArgumentValidator
    {
        /// <summary>
        /// Checks if argument is null.
        /// </summary>
        /// <param name="paramName">Name of the property.</param>
        /// <param name="value">The value.</param>
        public static void ValidateNotNull(string paramName, object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        /// <summary>
        /// Checks if argument is empty.
        /// </summary>
        /// <param name="paramName">Name of the property.</param>
        /// <param name="value">The value.</param>
        public static void ValidateNotEmpty(string paramName, string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName);
            }

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(Resources.ExpectedNotEmptyValue, paramName: paramName);
            }
        }

        /// <summary>
        /// Checks if argument is null or empty collection.
        /// </summary>
        /// <typeparam name="T">Type of items in the collection</typeparam>
        /// <param name="paramName">Name of the property.</param>
        /// <param name="collection">The collection.</param>
        public static void ValidateNotEmpty<T>(string paramName, IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(paramName);
            }

            if (!collection.Any())
            {
                throw new ArgumentException(Resources.ExpectedNotEmptyCollection, paramName: paramName);
            }
        }

    }
}
