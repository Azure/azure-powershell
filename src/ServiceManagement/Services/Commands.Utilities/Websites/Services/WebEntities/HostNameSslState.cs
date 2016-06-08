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
    /// Class that represents a SSL-enabled host name.
    /// </summary>
    [DataContract(Namespace = UriElements.ServiceNamespace)]
    public class HostNameSslState
    {

        /// <summary>
        /// Host name
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// SSL type
        /// </summary>
        [DataMember]
        public SslState SslState { get; set; }

    }

    [DataContract(Namespace = UriElements.ServiceNamespace)]
    public enum SslState
    {
        [EnumMember]
        Disabled = 0,
        [EnumMember]
        SniEnabled = 1,
        [EnumMember]
        IpBasedEnabled = 2
    }

    /// <summary>
    /// Collection of SSL-enabled host names
    /// </summary>
    [CollectionDataContract(Namespace = UriElements.ServiceNamespace)]
    public class HostNameSslStates : List<HostNameSslState>
    {

        /// <summary>
        /// Empty collection
        /// </summary>
        public HostNameSslStates() { }

        /// <summary>
        /// Initialize collection
        /// </summary>
        /// <param name="sites"></param>
        public HostNameSslStates(List<HostNameSslState> list) : base(list) { }
    }
}
