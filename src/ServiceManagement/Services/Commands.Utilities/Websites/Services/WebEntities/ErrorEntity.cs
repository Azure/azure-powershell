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
    /// Body of the error response returned from the API.
    /// </summary>
    [DataContract(Namespace = UriElements.ServiceNamespace, Name = "Error")]
    public class ErrorEntity
    {
        /// <summary>
        /// Basic error code
        /// </summary>
        [DataMember(Order = 1)]
        public string Code { get; set; }

        /// <summary>
        /// Any details of the error
        /// </summary>
        [DataMember(Order = 2)]
        public string Message { get; set; }

        /// <summary>
        /// Type of error
        /// </summary>
        [DataMember(Order = 3)]
        public string ExtendedCode { get; set; }

        /// <summary>
        /// Message template
        /// </summary>
        [DataMember(Order = 4)]
        public string MessageTemplate { get; set; }

        /// <summary>
        /// Parameters for the template
        /// </summary>
        [DataMember(Order = 5)]
        public List<string> Parameters { get; set; }
    }
}
