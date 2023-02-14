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

namespace Microsoft.Azure.Commands.ResourceManager.Common
{
    public abstract class IKeyStoreKey
    {
        /// <summary>
        /// Create key from the data fields of KeyStoreKey.
        /// </summary>
        protected abstract string CreateKey();

        /// <summary>
        /// Convert key to string.
        /// </summary>
        public override abstract string ToString();

        /// <summary>
        /// Generate hash code of KeyStoreKey.
        /// </summary>
        public override abstract int GetHashCode();

        /// <summary>
        /// Check whether the current key is exactly equal to another.
        /// </summary>
        public override abstract bool Equals(object obj);

        /// <summary>
        /// Check whether the current key can be treated as equal to another even though they are not equal.
        /// This method can be used as fuzzy search of the keys.
        /// </summary>
        public abstract bool BeEquivalent(object obj);
    }
}
