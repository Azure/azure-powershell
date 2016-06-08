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

using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebEntities
{
    /// <summary>
    /// Class that represents a subscription.
    /// </summary>
    [DataContract(Namespace = UriElements.ServiceNamespace)]
    public class Subscription
    {
        /// <summary>
        /// Name of the subscription
        /// </summary>
        [DataMember]
        [Description("Subscription Name")]
        public string Name { get; set; }

        /// <summary>
        /// Description of the subscription
        /// </summary>
        [DataMember]
        [Description("Subscription Description")]
        public string Description { get; set; }

        /// <summary>
        /// Suspended
        /// </summary>
        [DataMember]
        public bool? Suspended { get; set; }

        /// <summary>
        /// Name of the user who is owner of the Subscription
        /// </summary>
        [DataMember]
        [PIIValue]
        public string OwnerUserName { get; set; }
    }

    /// <summary>
    /// Collection of subscriptions
    /// </summary>
    [CollectionDataContract(Namespace = UriElements.ServiceNamespace)]
    public class Subscriptions : List<Subscription>
    {

        /// <summary>
        /// Empty collection
        /// </summary>
        public Subscriptions() { }

        /// <summary>
        /// Initialize collection
        /// </summary>
        /// <param name="subscriptions"></param>
        public Subscriptions(List<Subscription> subscriptions) : base(subscriptions) { }
    }
}
