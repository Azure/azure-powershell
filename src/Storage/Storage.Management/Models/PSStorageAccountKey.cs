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

using StorageModels = Microsoft.Azure.Management.Storage.Models;

namespace Microsoft.Azure.Commands.Management.Storage.Models
{
    //Wrapper of StorageAccountKey property KeyPermission 
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum PSKeyPermission
    {
        [System.Runtime.Serialization.EnumMember(Value = "Read")]
        Read,
        [System.Runtime.Serialization.EnumMember(Value = "Full")]
        Full
    }

    internal static class PSKeyPermissionEnumExtension
    {
        internal static PSKeyPermission? ParseKeyPermission(this StorageModels.KeyPermission? keyPermission)
        {
            if (keyPermission == null)
            {
                return null;
            }
            switch (keyPermission)
            {
                case StorageModels.KeyPermission.Read:
                    return PSKeyPermission.Read;
                case StorageModels.KeyPermission.Full:
                    return PSKeyPermission.Full;
            }
            return null;
        }
    }

    //Wrapper of StorageAccountKey  
    public class PSStorageAccountKey
    {
        public PSStorageAccountKey(StorageModels.StorageAccountKey storageAccountKey)
        {
            this.KeyName = storageAccountKey.KeyName;
            this.Value = storageAccountKey.Value.ToSecureString();
            this.Permissions = storageAccountKey.Permissions.ParseKeyPermission();
            this.CreationTime = storageAccountKey.CreationTime;
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "keyName")]
        public string KeyName { get; private set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "value")]
        public System.Security.SecureString Value { get; private set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "permissions")]
        public PSKeyPermission? Permissions { get; private set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "creationTime")]
        public System.DateTime? CreationTime { get; private set; }
    }
}
