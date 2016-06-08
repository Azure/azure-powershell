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
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebEntities
{
    [DataContract(Namespace = UriElements.ServiceNamespace)]
    public class TraceMessage
    {
        [DataMember(IsRequired = false)]
        public string Message { get; set; }

        [DataMember(IsRequired = false)]
        public int MessageId { get; set; }

        [DataMember(IsRequired = false)]
        public string ServerName { get; set; }

        [DataMember(IsRequired = false)]
        public DateTime TimeStamp { get; set; }

        [DataMember(IsRequired = false)]
        public int TraceLevel { get; set; }

    }

    /// <summary>
    /// Collection of trace messages
    /// </summary>
    [CollectionDataContract(Namespace = UriElements.ServiceNamespace)]
    public class TraceMessages : List<TraceMessage>
    {

        /// <summary>
        /// Empty collection
        /// </summary>
        public TraceMessages() { }

        /// <summary>
        /// Initialize collection
        /// </summary>
        /// <param name="users"></param>
        public TraceMessages(List<TraceMessage> traceMessages) : base(traceMessages) { }
    }
}
