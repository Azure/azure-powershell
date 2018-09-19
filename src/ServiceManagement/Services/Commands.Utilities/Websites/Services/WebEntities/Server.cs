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
    [DataContract(Namespace = UriElements.ServiceNamespace)]
    public enum ServerStates
    {
        [EnumMember]
        NotReady = 0,
        [EnumMember]
        Offline = 1,
        [EnumMember]
        Installing = 2,
        [EnumMember]
        Ready = 3,
    }

    /// <summary>
    /// Class that represents a Server.
    /// </summary>
    [DataContract(Namespace = UriElements.ServiceNamespace)]
    public class Server
    {

        /// <summary>
        /// Name of the server
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Current status
        /// </summary>
        [DataMember]
        public string Status { get; set; }

        /// <summary>
        /// Last line of the log
        /// </summary>
        [DataMember]
        public string StatusMessage { get; set; }

        /// <summary>
        /// Server state
        /// </summary>
        [DataMember]
        public ServerStates ServerState { get; set; }

        /// <summary>
        /// Current cpu utilization
        /// </summary>
        [DataMember]
        public int CpuPercentage { get; set; }

        /// <summary>
        /// Current memory utilization
        /// </summary>
        [DataMember]
        public int MemoryPercentage { get; set; }

        /// <summary>
        /// Number of running sites
        /// </summary>
        [DataMember]
        public int RunningSitesNumber { get; set; }

        [DataMember(IsRequired = false)]
        public string[] SslBindings { get; set; }

        /// <summary>
        /// Compute mode
        /// </summary>
        [DataMember(IsRequired = false)]
        public ComputeModeOptions? ComputeMode { get; set; }

        /// <summary>
        /// Worker size
        /// </summary>
        [DataMember(IsRequired = false)]
        public WorkerSizeOptions? WorkerSize { get; set; }
    }

    /// <summary>
    /// Collection of servers
    /// </summary>
    [CollectionDataContract(Namespace = UriElements.ServiceNamespace)]
    public class Servers : List<Server>
    {

        /// <summary>
        /// Empty collection
        /// </summary>
        public Servers() { }

        /// <summary>
        /// Initialize collection
        /// </summary>
        /// <param name="sites"></param>
        public Servers(List<Server> list) : base(list) { }
    }

    /// <summary>
    /// Class that represents a SSL binding.
    /// </summary>
    [DataContract(Namespace = UriElements.ServiceNamespace)]
    public class ServerSslBinding
    {
        /// <summary>
        /// IPAddress of the binding
        /// </summary>
        [DataMember]
        public string IPAddress { get; set; }

        /// <summary>
        /// Current memory utilization
        /// </summary>
        [DataMember]
        public int Port { get; set; }

        /// <summary>
        /// Current memory utilization
        /// </summary>
        [DataMember(IsRequired = false)]
        public string HostName { get; set; }
    }

    /// <summary>
    /// Collection of servers
    /// </summary>
    [CollectionDataContract(Namespace = UriElements.ServiceNamespace)]
    public class ServerSslBindings : List<ServerSslBinding>
    {
        /// <summary>
        /// Empty collection
        /// </summary>
        public ServerSslBindings() { }

        /// <summary>
        /// Initialize collection
        /// </summary>
        /// <param name="sites"></param>
        public ServerSslBindings(List<ServerSslBinding> list) : base(list) { }

        public ServerSslBindings(IEnumerable<ServerSslBinding> list) : base(list) { }
    }
}
