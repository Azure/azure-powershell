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

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.Media.Rest.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using RestApiEndpoint = Microsoft.Azure.Management.Media.Rest.Models.ApiEndpoint;
using RestStorageAccount = Microsoft.Azure.Management.Media.Rest.Models.StorageAccount;
using RestMediaServiceProperties = Microsoft.Azure.Management.Media.Rest.Models.MediaServiceProperties;
using RestMediaService = Microsoft.Azure.Management.Media.Rest.Models.MediaService;
using RestServiceKeys = Microsoft.Azure.Management.Media.Rest.Models.ServiceKeys;

namespace Microsoft.Azure.Commands.Media.Models
{
    public static class ModelExtensions
    {
        public static PSMediaService ToPSMediaService(this RestMediaService mediaService)
        {
            return new PSMediaService
            {
                Id = mediaService.Id,
                Name = mediaService.Name,
                Type = mediaService.Type,
                Location = mediaService.Location,
                Tags = mediaService.Tags.ToHashTableTags(),
                Properties = mediaService.Properties.ToPSMediaServiceProperties()
            };
        }

        public static PSMediaServiceProperties ToPSMediaServiceProperties(this RestMediaServiceProperties mediaServiceProperties)
        {
            return new PSMediaServiceProperties
            {
                ApiEndpoints = mediaServiceProperties.ApiEndpoints.Select(x => x.ToPSApiEndpoint()).ToList(),
                StorageAccounts = mediaServiceProperties.StorageAccounts.Select(x => x.ToPSStorageAccount()).ToList()
            };
        }

        public static PSApiEndpoint ToPSApiEndpoint(this RestApiEndpoint apiEndpoint)
        {
            return new PSApiEndpoint
            {
                Endpoint = apiEndpoint.Endpoint,
                MajorVersion = apiEndpoint.MajorVersion
            };
        }

        public static PSStorageAccount ToPSStorageAccount(this RestStorageAccount storageAccount)
        {
            return new PSStorageAccount
            {
                Id = storageAccount.Id,
                IsPrimary = storageAccount.IsPrimary
            };
        }

        public static IDictionary<string, string> ToDictionaryTags(this Hashtable table)
        {
            if (table == null)
            {
                return null;
            }

            return table.Cast<DictionaryEntry>().ToDictionary(x => (string) x.Key, x => (string) x.Value);
        }

        public static Hashtable ToHashTableTags(this IDictionary<string, string> tags)
        {
            if (tags == null)
            {
                return null;
            }

            var tagsInHashTable = new Hashtable();
            tags.Keys.ForEach(k => tagsInHashTable.Add(k, tags[k]));
            return tagsInHashTable;
        }

        public static PSServiceKeys ToPSServiceKeys(this RestServiceKeys serviceKeys)
        {
            return new PSServiceKeys
            {
                PrimaryAuthEndpoint = serviceKeys.PrimaryAuthEndpoint,
                PrimaryKey = serviceKeys.PrimaryKey,
                SecondaryAuthEndpoint = serviceKeys.SecondaryAuthEndpoint,
                SecondaryKey = serviceKeys.SecondaryKey,
                Scope = serviceKeys.Scope
            };
        }

        public static PSServiceKey ToPSServiceKey(this RegenerateKeyOutput serviceKey, string keyType)
        {
            return new PSServiceKey
            {
                Key = serviceKey.Key,
                KeyType = keyType
            };
        }
    }
}
