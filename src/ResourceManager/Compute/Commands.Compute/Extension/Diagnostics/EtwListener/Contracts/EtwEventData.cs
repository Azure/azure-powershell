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

namespace Microsoft.VisualStudio.EtwListener.Common.Contracts
{
    [DataContract]
    internal class EtwEventData
    {
        [DataMember]
        public DateTimeOffset Timestamp { get; set; }

        [DataMember]
        public string ProviderName { get; set; }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public int ProcessId { get; set; }

        [DataMember]
        public string Level { get; set; }

        [DataMember]
        public string Keywords { get; set; }

        [DataMember]
        public string EventName { get; set; }

        [DataMember]
        public IDictionary<string, object> Payload { get; set; }
    }
}
