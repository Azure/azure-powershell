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
    /// <summary>
    /// A model for an Azure subscription
    /// </summary>
    public class AzureSubscription : IAzureSubscription
    {
        /// <summary>
        /// The subscription identifier, a globbaly-unique identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The firendly name of the subscription
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The subscription state.  For example, enabled or disabled
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Cistom properties for the subscription
        /// </summary>
        public IDictionary<string, string> ExtendedProperties { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Create a hash code based on the identifier - all subscriptions with the same id should hash identically
        /// </summary>
        /// <returns>A hash code for the subscription</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        /// <summary>
        /// Compare with other subscriptions based on subscription id
        /// </summary>
        /// <param name="obj">The object to compare</param>
        /// <returns>True if the object is a subscription with the same identifier, otherwise false</returns>
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

        /// <summary>
        /// A collection fo string constants for known extensible proeprties
        /// </summary>
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
