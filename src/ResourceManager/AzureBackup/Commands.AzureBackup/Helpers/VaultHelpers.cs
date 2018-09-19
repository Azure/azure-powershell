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
using ClientModel = Microsoft.Azure.Management.BackupServices.Models;
using CmdletModel = Microsoft.Azure.Commands.AzureBackup.Models;

namespace Microsoft.Azure.Commands.AzureBackup.Helpers
{
    internal static class VaultHelpers
    {
        /// <summary>
        /// Gets CmdletModel of backup vault from Client model
        /// </summary>
        /// <param name="vault"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
        public static CmdletModel.AzureRMBackupVault GetCmdletVault(ClientModel.AzureBackupVault vault, string storageType)
        {
            var response = new CmdletModel.AzureRMBackupVault
            {
                ResourceId = vault.Id,
                Name = vault.Name,
                Region = vault.Location,
                ResourceGroupName = GetResourceGroup(vault.Id),
                Storage = storageType,
            };

            return response;
        }

        /// <summary>
        /// Gets ResourceGroup from vault ID
        /// </summary>
        /// <param name="vaultId"></param>
        /// <returns></returns>
        public static string GetResourceGroup(string vaultId)
        {
            string[] tokens = vaultId.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            return tokens[3];
        }

        // NOTE: Commenting code which will be used in a later sprint, but not right now.

        /// <summary>
        /// Extension to convert enumerable Hashtable into a dictionary
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        // public static Dictionary<string, string> ConvertToDictionary(this Hashtable[] tags)
        // {
        //     return tags == null
        //         ? null
        //         : tags
        //             .CoalesceEnumerable()
        //             .Select(hashTable => hashTable.OfType<DictionaryEntry>()
        //                 .ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value))
        //             .Where(tagDictionary => tagDictionary.ContainsKey("Name"))
        //             .Select(tagDictionary => Tuple
        //                 .Create(
        //                     tagDictionary["Name"].ToString(),
        //                     tagDictionary.ContainsKey("Value") ? tagDictionary["Value"].ToString() : string.Empty))
        //             .Distinct(kvp => kvp.Item1)
        //             .ToDictionary(kvp => kvp.Item1, kvp => kvp.Item2);
        // }

        /// <summary>
        /// Extension to coalesce enumerable
        /// </summary>
        /// <typeparam name="TSource">Enumerable type</typeparam>
        /// <param name="source">Enumerable</param>
        /// <returns></returns>
        // public static IEnumerable<TSource> CoalesceEnumerable<TSource>(this IEnumerable<TSource> source)
        // {
        //     return source ?? Enumerable.Empty<TSource>();
        // }

        /// <summary>
        /// Extension to remove duplicates from enumerable based on a provided key selector
        /// </summary>
        /// <typeparam name="TSource">Enumerable type</typeparam>
        /// <typeparam name="TKeyType">Type of key</typeparam>
        /// <param name="source">Input enumerable to remove duplicates from</param>
        /// <param name="keySelector">Lambda to select key</param>
        /// <returns></returns>
        // public static IEnumerable<TSource> Distinct<TSource, TKeyType>(this IEnumerable<TSource> source, Func<TSource, TKeyType> keySelector)
        // {
        //     var set = new Dictionary<TKeyType, TSource>(EqualityComparer<TKeyType>.Default);
        //     foreach (TSource element in source)
        //     {
        //         TSource value;
        //         var key = keySelector(element);
        //         if (!set.TryGetValue(key, out value))
        //         {
        //             yield return element;
        //         }
        //         else
        //         {
        //             set[key] = value;
        //         }
        //     }
        // }

        /// <summary>
        /// Extension to convert dictionary to hashtable enumerable
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        // public static Hashtable[] GetTagsHashtables(this IDictionary<string, string> tags)
        // {
        //     return tags == null
        //         ? null
        //         : tags.Select(kvp => new Hashtable { { "Name", kvp.Key }, { "Value", kvp.Value } }).ToArray();
        // }
    }
}
