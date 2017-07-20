﻿// ----------------------------------------------------------------------------------
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
using System.Collections.Generic;
using Microsoft.Azure.Management.ContainerRegistry.Models;

namespace Microsoft.Azure.Commands.ContainerRegistry
{
    public class PSContainerRegistry
    {
        public PSContainerRegistry(Registry registry)
        {
            Id = registry?.Id;
            ResourceGroupName = ParseResourceGroupFromId(Id);
            Name = registry?.Name;
            Type = registry?.Type;
            Location = registry?.Location;
            Tags = registry?.Tags;
            SkuName = registry?.Sku?.Name;
            SkuTier = registry?.Sku?.Tier;
            LoginServer = registry?.LoginServer;
            CreationDate = registry?.CreationDate;
            ProvisioningState = registry?.ProvisioningState;
            AdminUserEnabled = registry?.AdminUserEnabled;
            StorageAccountName = registry?.StorageAccount?.Name;
        }

        public string Id { get; set; }
        public string ResourceGroupName { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public IDictionary<string, string> Tags { get; set; }
        public string SkuName { get; set; }
        public string SkuTier { get; set; }
        public string LoginServer { get; set; }
        public DateTime? CreationDate { get; set; }
        public ProvisioningState? ProvisioningState { get; set; }
        public bool? AdminUserEnabled { get; set; }
        public string StorageAccountName { get; set; }

        public static string ParseResourceGroupFromId(string idFromServer)
        {
            if (!string.IsNullOrEmpty(idFromServer))
            {
                string[] tokens = idFromServer.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                return tokens[3];
            }

            return null;
        }
    }
}
