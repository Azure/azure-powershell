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

using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CmdletModel = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using ResourceManagerModel = Microsoft.Azure.Management.Internal.Resources.Models;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using CrrModel = Microsoft.Azure.Management.RecoveryServices.Backup.CrossRegionRestore.Models;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers
{
    /// <summary>
    /// Utilities used by the helpers.
    /// </summary>
    public class HelperUtils
    {
        /// <summary>
        /// Gets list of enums of type T given the corresponding list of string equivalents. 
        /// This method parses each of the strings and converts them into enums.
        /// </summary>
        /// <typeparam name="T">Type of the enum into which each string in the input list is to be type casted</typeparam>
        /// <param name="strList">List of strings</param>
        /// <returns></returns>
        public static List<T> GetEnumListFromStringList<T>(IList<string> strList)
        {
            if (strList == null || strList.Count == 0)
            {
                return null;
            }
            var ret = new List<T>();

            foreach (string str in strList)
            {
                ret.Add((T)Enum.Parse(typeof(T), str));
            }

            return ret;
        }

        /// <summary>
        /// Gets list of string equivalents given the corresponding list of enums of type T. 
        /// </summary>
        /// <typeparam name="T">Type of the enum whose list should be converted to list of strings</typeparam>
        /// <param name="enumList">List of enums</param>
        /// <returns></returns>
        public static List<string> GetStringListFromEnumList<T>(IList<T> enumList)
        {
            if (enumList == null || enumList.Count == 0)
            {
                return null;
            }
            var ret = new List<string>();

            foreach (T item in enumList)
            {
                ret.Add(item.ToString());
            }

            return ret;
        }

        /// <summary>
        /// Gets list of enum type S equivalents given the corresponding list of enums of type T. 
        /// </summary>
        /// <typeparam name="T">Type of the enum whose list should be converted to list of strings.</typeparam>
        /// <typeparam name="S">Type of the enum whose list should be converted from list of T.</typeparam>
        /// <param name="enumListT">List of enums.</param>
        /// <returns>List of enums converted.</returns>
        public static List<S> EnumListConverter<T, S>(IList<T> enumListT)
        {
            if (enumListT == null || enumListT.Count == 0)
            {
                return null;
            }
            var enumListS = new List<S>();

            foreach (T enumT in enumListT)
            {
                enumListS.Add(enumT.ToString().ToEnum<S>());
            }

            return enumListS;
        }

        /// <summary>
        /// Helper function to parse resource id which in format of "[\{Key}\{value}]*"
        /// </summary>
        /// <param name="id">Id of the resource</param>
        /// <returns>dictionary of UriEnum as key and value as value of corresponding URI enum</returns>
        public static Dictionary<CmdletModel.UriEnums, string> ParseUri(string id)
        {
            Dictionary<CmdletModel.UriEnums, string> keyValuePairDict =
                new Dictionary<CmdletModel.UriEnums, string>();
            if (!string.IsNullOrEmpty(id))
            {
                string idPattern = @"/[^/]*/[^/]*";
                string uriPattern = @"/";
                Regex reg = new Regex(idPattern, RegexOptions.IgnoreCase);

                // Match the regular expression pattern against a uri string.
                Match match = reg.Match(id);

                while (match.Success)
                {
                    string[] keyValuePair = match.Value.Split(
                        new string[] { uriPattern },
                        StringSplitOptions.RemoveEmptyEntries
                        );
                    CmdletModel.UriEnums key;
                    CmdletModel.UriEnums value;
                    if (keyValuePair.Length == 2)
                    {
                        if (Enum.TryParse(keyValuePair[0], true, out key) &&
                            !Enum.TryParse(keyValuePair[1], true, out value))
                        {
                            keyValuePairDict.Add(key, keyValuePair[1]);
                        }
                    }
                    match = match.NextMatch();
                }
            }
            return keyValuePairDict;
        }

        /// <summary>
        /// Gets container URI from the provided dictionary of key value pairs.
        /// </summary>
        /// <param name="keyValuePairDict">Dictionary of UriEnum as key and value as value of corresponding URI enum</param>
        /// <param name="id">ID of the resource</param>
        /// <returns></returns>
        public static string GetContainerUri(
            Dictionary<CmdletModel.UriEnums, string> keyValuePairDict,
            string id
            )
        {
            string containerUri = string.Empty;

            if (keyValuePairDict.ContainsKey(CmdletModel.UriEnums.ProtectionContainers))
            {
                containerUri = keyValuePairDict[CmdletModel.UriEnums.ProtectionContainers];
            }
            else
            {
                throw new ArgumentException(string.Format(Resources.URIValueNotFound,
                    CmdletModel.UriEnums.ProtectionContainers.ToString(), id));
            }
            return containerUri;
        }

        /// <summary>
        /// Gets protected item URI from the provided dictionary of key value pairs.
        /// </summary>
        /// <param name="keyValuePairDict">Dictionary of UriEnum as key and value as value of corresponding URI enum</param>
        /// <param name="id">ID of the resource</param>
        /// <returns></returns>
        public static string GetProtectedItemUri(
            Dictionary<CmdletModel.UriEnums, string> keyValuePairDict,
            string id
            )
        {
            string itemUri = string.Empty;

            if (keyValuePairDict.ContainsKey(CmdletModel.UriEnums.ProtectedItems))
            {
                itemUri = keyValuePairDict[CmdletModel.UriEnums.ProtectedItems];
            }
            else
            {
                throw new ArgumentException(string.Format(Resources.URIValueNotFound,
                    CmdletModel.UriEnums.ProtectedItems.ToString(), id));
            }
            return itemUri;
        }

        /// <summary>
        /// Gets protectable item URI from the provided dictionary of key value pairs.
        /// </summary>
        /// <param name="keyValuePairDict">Dictionary of UriEnum as key and value as value of corresponding URI enum</param>
        /// <param name="id">ID of the resource</param>
        /// <returns></returns>
        public static string GetProtectableItemUri(
            Dictionary<CmdletModel.UriEnums, string> keyValuePairDict,
            string id
            )
        {
            string protectableItemUri = string.Empty;

            if (keyValuePairDict.ContainsKey(CmdletModel.UriEnums.ProtectableItems))
            {
                protectableItemUri = keyValuePairDict[CmdletModel.UriEnums.ProtectableItems];
            }
            else
            {
                throw new ArgumentException(string.Format(Resources.URIValueNotFound,
                    CmdletModel.UriEnums.ProtectableItems.ToString(), id));
            }
            return protectableItemUri;
        }

        /// <summary>
        /// Gets polcy name from the provided dictionary of key value pairs.
        /// </summary>
        /// <param name="keyValuePairDict">Dictionary of UriEnum as key and value as value of corresponding URI enum</param>
        /// <param name="id">ID of the resource</param>
        /// <returns></returns>
        public static string GetPolicyNameFromPolicyId(
            Dictionary<CmdletModel.UriEnums, string> keyValuePairDict,
            string id
            )
        {
            string policyName = string.Empty;

            if (keyValuePairDict.ContainsKey(CmdletModel.UriEnums.BackupPolicies))
            {
                policyName = keyValuePairDict[CmdletModel.UriEnums.BackupPolicies];
            }
            else
            {
                throw new ArgumentException(string.Format(Resources.URIValueNotFound,
                    CmdletModel.UriEnums.BackupPolicies.ToString(), id));
            }
            return policyName;
        }

        public static string GetSubscriptionIdFromId(
            Dictionary<CmdletModel.UriEnums, string> keyValuePairs,
            string id)
        {
            string subscriptionId = string.Empty;

            if (keyValuePairs.ContainsKey(CmdletModel.UriEnums.Subscriptions))
            {
                subscriptionId = keyValuePairs[CmdletModel.UriEnums.Subscriptions];
            }
            else
            {
                throw new ArgumentException(string.Format(Resources.URIValueNotFound,
                    CmdletModel.UriEnums.Subscriptions.ToString(), id));
            }

            return subscriptionId;
        }

        public static string GetResourceGroupNameFromId(
            Dictionary<CmdletModel.UriEnums, string> keyValuePairs,
            string id)
        {
            string resourceGroupName = string.Empty;

            if (keyValuePairs.ContainsKey(CmdletModel.UriEnums.ResourceGroups))
            {
                resourceGroupName = keyValuePairs[CmdletModel.UriEnums.ResourceGroups];
            }
            else
            {
                throw new ArgumentException(string.Format(Resources.URIValueNotFound,
                    CmdletModel.UriEnums.ResourceGroups.ToString(), id));
            }

            return resourceGroupName;
        }

        public static string GetVMNameFromId(Dictionary<CmdletModel.UriEnums, string> keyValuePairs,
            string id)
        {
            string virtualMachineName = string.Empty;

            if (keyValuePairs.ContainsKey(CmdletModel.UriEnums.VirtualMachines))
            {
                virtualMachineName = keyValuePairs[CmdletModel.UriEnums.VirtualMachines];
            }
            else
            {
                throw new ArgumentException(string.Format(Resources.URIValueNotFound,
                    CmdletModel.UriEnums.VirtualMachines.ToString(), id));
            }

            return virtualMachineName;
        }

        public static string GetVaultNameFromId(
            Dictionary<CmdletModel.UriEnums, string> keyValuePairs,
            string id)
        {
            string vaultName = string.Empty;

            if (keyValuePairs.ContainsKey(CmdletModel.UriEnums.Vaults))
            {
                vaultName = keyValuePairs[CmdletModel.UriEnums.Vaults];
            }
            else
            {
                throw new ArgumentException(string.Format(Resources.URIValueNotFound,
                    CmdletModel.UriEnums.Vaults.ToString(), id));
            }

            return vaultName;
        }

        /// <summary>
        /// Retrieves all the pages returned by a paginated API.
        /// </summary>
        /// <typeparam name="T">Type of the object returned by the paginated API</typeparam>
        /// <param name="listResources">Delegate representing the paginated API</param>
        /// <param name="listNext">Delegate representing the call to retrieve the next page</param>
        /// <returns>List of objects returned by the API</returns>
        public static List<T> GetPagedListCrr<T>(
            Func<IPage<T>> listResources, Func<string, IPage<T>> listNext)
            where T : CrrModel.Resource
        {
            var resources = new List<T>();
            string nextLink = null;            
            var pagedResources = listResources();
            
            foreach (var pagedResource in pagedResources)
            {
                resources.Add(pagedResource);
            }            
            nextLink = pagedResources.NextPageLink;
            
            while (!string.IsNullOrEmpty(nextLink))
            {               
                pagedResources = listNext(nextLink);
                nextLink = pagedResources.NextPageLink;
                
                foreach (var pagedResource in pagedResources)
                {                    
                    resources.Add(pagedResource);
                }                
            }            
            return resources;
        }

        /// <summary>
        /// Retrieves all the pages returned by a paginated API.
        /// </summary>
        /// <typeparam name="T">Type of the object returned by the paginated API</typeparam>
        /// <param name="listResources">Delegate representing the paginated API</param>
        /// <param name="listNext">Delegate representing the call to retrieve the next page</param>
        /// <returns>List of objects returned by the API</returns>
        public static List<T> GetPagedList<T>(
            Func<IPage<T>> listResources, Func<string, IPage<T>> listNext)
            where T : ServiceClientModel.Resource
        {
            var resources = new List<T>();
            string nextLink = null;

            var pagedResources = listResources();

            foreach (var pagedResource in pagedResources)
            {
                resources.Add(pagedResource);
            }

            nextLink = pagedResources.NextPageLink;

            while (!string.IsNullOrEmpty(nextLink))
            {
                pagedResources = listNext(nextLink);
                nextLink = pagedResources.NextPageLink;

                foreach (var pagedResource in pagedResources)
                {
                    resources.Add(pagedResource);
                }
            }

            return resources;
        }

        public static List<T> GetPagedRMList<T>(
            Func<IPage<T>> listResources, Func<string, IPage<T>> listNext)
            where T : ResourceManagerModel.Resource
        {
            var resources = new List<T>();
            string nextLink = null;

            var pagedResources = listResources();

            foreach (var pagedResource in pagedResources)
            {
                resources.Add(pagedResource);
            }

            nextLink = pagedResources.NextPageLink;

            while (!string.IsNullOrEmpty(nextLink))
            {
                pagedResources = listNext(nextLink);
                nextLink = pagedResources.NextPageLink;

                foreach (var pagedResource in pagedResources)
                {
                    resources.Add(pagedResource);
                }
            }

            return resources;
        }

        #region Common Helper Functions
        /// <summary>
        /// Helper function to return one of Token or SecureToken after decryption
        /// </summary>
        /// <param name="token"></param>
        /// <param name="secureToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static string GetPlainToken(string token, System.Security.SecureString secureToken)
        {
            bool hasToken = !string.IsNullOrEmpty(token);
            bool hasSecureToken = secureToken != null && secureToken.Length > 0;

            if (hasToken || hasSecureToken)
            {
                if (hasToken && hasSecureToken)
                {
                    throw new ArgumentException(Resources.BothTokenProvided);
                }
                else if (hasToken)
                {
                    Logger.Instance.WriteWarning(Resources.TokenParameterDepricate);
                    return token;
                }
                else
                {
                    var plainToken = secureToken.ConvertToString();
                    Logger.Instance.WriteDebug("Converted secure token");
                    return plainToken;
                }
            }
            Logger.Instance.WriteDebug("plainToken returning empty");
            return "";
        }

        #endregion
    }
}
