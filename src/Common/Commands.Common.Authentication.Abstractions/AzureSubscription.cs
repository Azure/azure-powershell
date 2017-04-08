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
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
    public class AzureSubscription : IAzureSubscription
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string State { get; set; }

        public IDictionary<string, string> ExtendedProperties { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var anotherSubscription = obj as AzureSubscription;
            if (anotherSubscription == null)
            {
                return false;
            }
            else
            {
                return anotherSubscription.Id == Id;
            }
        }

        public static class Property
        {
            /// <summary>
            /// Comma separated registered resource providers, i.e.: websites,compute,hdinsight
            /// </summary>
            public const string RegisteredResourceProviders = "RegisteredResourceProviders",

            /// <summary>
            /// Associated tenants
            /// </summary>
            Tenants = "Tenants",

            /// <summary>
            /// If this property existed on the subscription indicates that it's default one.
            /// </summary>
            Default = "Default",

            StorageAccount = "StorageAccount",
            Environment = "Environment",
                Account = "Account";
        }
    }
}
