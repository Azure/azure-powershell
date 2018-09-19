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
    [DataContract(Name = "Status", Namespace = UriElements.ServiceNamespace)]
    public enum StatusOptions
    {
        [EnumMember]
        Ready = 0,
        [EnumMember]
        Pending = 1,
    }


    [DataContract(Name = "ComputeMode", Namespace = UriElements.ServiceNamespace)]
    public enum ComputeModeOptions
    {
        [EnumMember]
        Shared = 0,
        [EnumMember]
        Dedicated = 1
    }

    [DataContract(Name = "WorkerSize", Namespace = UriElements.ServiceNamespace)]
    public enum WorkerSizeOptions
    {
        [EnumMember]
        Small = 0,
        [EnumMember]
        Medium = 1,
        [EnumMember]
        Large = 2
    }

    [DataContract(Name = "WebSpaceAvailabilityState", Namespace = UriElements.ServiceNamespace)]
    public enum WebSpaceAvailabilityState
    {
        [EnumMember]
        Normal = 0,
        [EnumMember]
        Limited = 1,
    }

    /// <summary>
    /// WebSpace
    /// </summary>
    [DataContract(Namespace = UriElements.ServiceNamespace)]
    public class WebSpace
    {
        [DataMember(IsRequired = false)]
        public string Name { get; set; }

        [DataMember(IsRequired = false)]
        public string Plan { get; set; }

        [DataMember(IsRequired = false)]
        public string Subscription { get; set; }

        [DataMember(IsRequired = false)]
        public string GeoLocation { get; set; }

        [DataMember(IsRequired = false)]
        public string GeoRegion { get; set; }

        [DataMember(IsRequired = false)]
        public ComputeModeOptions? ComputeMode { get; set; }

        [DataMember(IsRequired = false)]
        public WorkerSizeOptions? WorkerSize { get; set; }

        [DataMember(IsRequired = false)]
        public int? NumberOfWorkers { get; set; }

        [DataMember(IsRequired = false)]
        public WorkerSizeOptions? CurrentWorkerSize { get; set; }

        [DataMember(IsRequired = false)]
        public int? CurrentNumberOfWorkers { get; set; }

        [DataMember(IsRequired = false)]
        public StatusOptions Status { get; set; }

        [DataMember(IsRequired = false)]
        public WebSpaceAvailabilityState AvailabilityState { get; set; }
    }

    /// <summary>
    /// Collection of webspaces
    /// </summary>
    [CollectionDataContract(Namespace = UriElements.ServiceNamespace)]
    public class WebSpaces : List<WebSpace>
    {

        /// <summary>
        /// Empty collection
        /// </summary>
        public WebSpaces() { }

        /// <summary>
        /// Initialize collection
        /// </summary>
        /// <param name="sites"></param>
        public WebSpaces(List<WebSpace> webspaces) : base(webspaces) { }
    }
}
