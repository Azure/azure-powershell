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
    public interface IKeyCache
    {
        void SaveKey<T>(IKeyStoreKey key, T value);

        T GetKey<T>(IKeyStoreKey key);

        bool DeleteKey(IKeyStoreKey key);

        void Clear();

        void SetBeforeAccess(KeyStoreCallbak beforeAccess);

        void SetOnUpdate(KeyStoreCallbak onUpdate);
        void Deserialize(byte[] Data, bool shouldClearExistingCache);

        byte[] Serialize();
    }
}
