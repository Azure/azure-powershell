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
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebEntities
{
    /// <summary>
    /// Offer Contract (has to be implemented by all resource providers called by the RDFE)
    /// </summary>
    /// Note: Need to keep this data contract in sync with RDFE
    [DataContract(Name = "ServiceOffer", Namespace = UriElements.ServiceNamespace)]
    public class Offer
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [DataMember]
        public string OfferName { get; set; }

        /// <summary>
        /// Gets or sets the offer settings.
        /// </summary>
        /// <value>
        /// The offer settings.
        /// </value>
        [DataMember]
        public IList<OfferSetting> ServiceOfferSettings { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Offer"/> class.
        /// </summary>
        public Offer()
        {
            ServiceOfferSettings = new List<OfferSetting>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Offer"/> class.
        /// </summary>
        /// <param name="offerName">Name of the offer.</param>
        /// <param name="quotaSettings">Existing quota settings.</param>
        public Offer(string offerName, IList<OfferSetting> serviceOfferSettings)
        {
            OfferName = offerName;
            ServiceOfferSettings = serviceOfferSettings;
        }
    }

    [DataContract(Name = "ServiceOfferSetting", Namespace = UriElements.ServiceNamespace)]
    public class OfferSetting
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [DataMember]
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [DataMember]
        public string Value { get; set; }
    }

    /// <summary>
    /// Collection of offers
    /// </summary>
    [CollectionDataContract(Namespace = UriElements.ServiceNamespace)]
    public class Offers : List<Offer>
    {

        /// <summary>
        /// Empty collection
        /// </summary>
        public Offers() { }

        /// <summary>
        /// Initialize from list
        /// </summary>
        /// <param name="offers"></param>
        public Offers(List<Offer> offers) : base(offers) { }
    }
}
