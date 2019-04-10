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
/*#if !NETSTANDARD
using Microsoft.Azure.Management.Storage.Models;
namespace Microsoft.Azure.Commands.Compute
{
    public static class StorageExtensions
    {
        public static AccountType? Sku(this StorageAccount account)
        {
            return account.AccountType;
        }

        public static string SkuName(this StorageAccount account)
        {
            return account.AccountType.Value.ToString();
        }

        public static bool IsPremiumLrs(this StorageAccount account)
        {
            return account.AccountType.Value == AccountType.PremiumLRS;
        }

        public static void SetAsStandardGRS(this StorageAccountCreateParameters createParams)
        {
            createParams.AccountType = AccountType.StandardGRS;
        }

        public static string GetFirstAvailableKey(this StorageAccountKeys listKeyResult)
        {
            return !string.IsNullOrEmpty(listKeyResult.Key1) ? listKeyResult.Key1 : listKeyResult.Key2;
        }

        public static string GetKey1(this StorageAccountKeys listKeyResult)
        {
            return listKeyResult.Key1;
        }

        public static string GetKey2(this StorageAccountKeys listKeyResult)
        {
            return listKeyResult.Key2;
        }
    }    
}
#else*/
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.Storage.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute
{
    public static class StorageExtensions
    {
        public static Sku Sku(this StorageAccount account)
        {
            return account.Sku;
        }

        public static string SkuName(this StorageAccount account)
        {
            return account.Sku.Name.ToString();
        }

        public static bool IsPremiumLrs(this StorageAccount account)
        {
            return account.Sku.Name == Microsoft.Azure.Management.Storage.Models.SkuName.PremiumLRS;
        }

        public static void SetAsStandardGRS(this StorageAccountCreateParameters createParams)
        {
            createParams.Sku = new Sku(Microsoft.Azure.Management.Storage.Models.SkuName.StandardGRS);
        }

        public static string GetFirstAvailableKey(this StorageAccountListKeysResult listKeyResult)
        {
            return listKeyResult.Keys.ElementAt(0).Value;
        }

        public static string GetKey1(this StorageAccountListKeysResult listKeyResult)
        {
            return listKeyResult.Keys.ElementAt(0).Value;
        }

        public static string GetKey2(this StorageAccountListKeysResult listKeyResult)
        {
            return listKeyResult.Keys.ElementAt(1).Value;
        }
    }
}

//#endif