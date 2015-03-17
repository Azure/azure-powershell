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

using System.Runtime.Serialization;

namespace Microsoft.Azure.Commands.Automation.DataContract
{
    /// <summary>
    /// The odata error message.
    /// </summary>
    [DataContract]
    public class OdataErrorMessage
    {
        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        [DataMember(Name = "lang")]
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        [DataMember(Name = "value")]
        public string Value { get; set; }
    }
}