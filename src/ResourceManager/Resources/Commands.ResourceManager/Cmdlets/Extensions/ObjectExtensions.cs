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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions
{
    /// <summary>
    /// The object extension methods.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Casts the specified object to type T.
        /// </summary>
        /// <typeparam name="T">The type to cast to</typeparam>
        /// <param name="obj">The input object</param>
        public static T Cast<T>(this object obj)
        {
            return (T)obj;
        }

        /// <summary>
        /// Wraps the object in an array of length 1.
        /// </summary>
        /// <typeparam name="T">Type of object to wrap.</typeparam>
        /// <param name="obj">Object to wrap in array.</param>
        public static T[] AsArray<T>(this T obj)
        {
            return new T[] { obj };
        }
    }
}
