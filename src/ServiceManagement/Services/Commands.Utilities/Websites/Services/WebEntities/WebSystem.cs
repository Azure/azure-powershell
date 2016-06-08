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
    /// Class that represents a Web System.
    /// </summary>
    [DataContract(Namespace = UriElements.ServiceNamespace)]
    public class WebSystem
    {
        /// <summary>
        /// Name for the web system
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Administrator account
        /// </summary>
        [DataMember]
        public string Username { get; set; }

        /// <summary>
        /// PAssword for the administrator account
        /// </summary>
        [DataMember]
        [PIIValue]
        public string Password { get; set; }

        /// <summary>
        /// File share for content storage
        /// </summary>
        [DataMember]
        public string FileShare { get; set; }

        /// <summary>
        /// Publishing DNS
        /// </summary>
        [DataMember]
        public string PublishingDns { get; set; }

        /// <summary>
        /// Ftp DNS
        /// </summary>
        [DataMember]
        public string FtpDns { get; set; }


        /// <summary>
        /// Parking page name
        /// </summary>
        [DataMember]
        public string ParkingPage { get; set; }

        /// <summary>
        /// Parking page content
        /// </summary>
        [DataMember]
        public string ParkingPageContent { get; set; }

        /// <summary>
        /// Storage domain
        /// </summary>
        [DataMember]
        public string StorageDomain { get; set; }

        /// <summary>
        /// Databases
        /// </summary>
        [DataMember]
        public ConnectionStrings ConnectionStrings { get; set; }

        /// <summary>
        /// Link to a page that displays the Control Panel for the Web System.
        /// </summary>
        [DataMember]
        public string ControlPanelUrl { get; set; }
    }

    /// <summary>
    /// Collection of web systems
    /// </summary>
    [CollectionDataContract(Namespace = UriElements.ServiceNamespace)]
    public class WebSystems : List<WebSystem>
    {

        /// <summary>
        /// Empty collection
        /// </summary>
        public WebSystems() { }

        /// <summary>
        /// Initialize from list
        /// </summary>
        /// <param name="plans"></param>
        public WebSystems(List<WebSystem> list) : base(list) { }
    }
}
