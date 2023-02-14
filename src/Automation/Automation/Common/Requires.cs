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

namespace Microsoft.Azure.Commands.Automation.Common
{
    /// <summary>
    /// Argument checking utility
    /// </summary>
    internal static class Requires
    {
        /// <summary>
        /// Checks argument value
        /// </summary>
        /// <typeparam name="T">Type of argument</typeparam>
        /// <param name="name">Name of argument</param>
        /// <param name="value">Value of argument</param>
        /// <returns>The <see cref="ArgumentRequirements{T}"/> for this argument</returns>
        public static ArgumentRequirements<T> Argument<T>(string name, T value)
        {
            return new ArgumentRequirements<T>(name, value);
        }

        /// <summary>
        /// Argument requirement struct
        /// </summary>
        /// <typeparam name="T">Type of argument</typeparam>
        internal struct ArgumentRequirements<T>
        {
            /// <summary>
            /// The name.
            /// </summary>
            public string Name;

            /// <summary>
            /// The value.
            /// </summary>
            public T Value;

            /// <summary>
            /// Initializes a new instance of the ArgumentRequirements struct
            /// </summary>
            /// <param name="name">The name</param>
            /// <param name="value">The value</param>
            public ArgumentRequirements(string name, T value)
            {
                this.Name = name;
                this.Value = value;
            }

            /// <summary>
            /// Checks argument value for not null
            /// </summary>
            /// <returns>The not null requirement</returns>
            public ArgumentRequirements<T> NotNull()
            {
                if (this.Value == null)
                {
                    throw new ArgumentNullException(this.Name);
                }

                return this;
            }

            /// <summary>
            /// Checks argument value for not null or empty
            /// </summary>
            /// <returns>The not null requirement</returns>
            public ArgumentRequirements<T> NotNullOrEmpty()
            {
                if (this.Value == null)
                {
                    throw new ArgumentNullException(this.Name);
                }
                else if (string.IsNullOrEmpty(this.Value.ToString()))
                {
                    throw new ArgumentNullException(this.Name);
                }

                return this;
            }
        }
    }
}
